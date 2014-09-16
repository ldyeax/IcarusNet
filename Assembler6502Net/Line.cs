using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assembler6502Net
{
    public class Line
    {
        static string formatLine(string line)
        {
            string ret = line.Replace('\t', ' ').Trim();
            int? commentMarkerLocation = null;
            bool inQuotes = false;
            for (int i = ret.Length - 1; i >= 0; i--)
            {
                if (ret[i] == '"')
                {
                    inQuotes = !inQuotes;
                    continue;
                }

                if (!inQuotes && ret[i] == ';')
                {
                    commentMarkerLocation = i;
                }
            }

            if (commentMarkerLocation != null)
            {
                ret = ret.Substring(0, commentMarkerLocation.Value);
            }

            return ret;
        }

        //static ushort getNumb

        public SyntaxErrorException ThrownException = null;

        const string alphabet = "qwertuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        const string numerals = "1234567890";
        const string hexchars = "abcdefABCDEF1234567890";

        public Directive Directive = null;
        public string Label = null;
        public Assembly.OpCode? OpCode = null;
        public Assembly.AddressingMethod? AddressingMethod = null;
        public RValue RValue = null;
        public KeyValuePair<string, string>? VariableAssignment = null;
        public ushort PC;

        public List<byte> ComputedBytes = null;

        public Line() { }

        public Line(string s, int lineno)
        {
            string line = formatLine(s);
            if (line.Length == 0)
                return;

            if (line.Contains(':'))
            {
                string[] bycolon = line.Split(':');
                Label = bycolon[0];
                if (bycolon.Length > 1)
                    line = formatLine(bycolon[1]);
                else
                    line = "";
            }

            if (line.Length == 0)
                return;

            if (line.Contains('='))
            {
                string[] byequals = (from str in line.Split('=') select formatLine(str)).ToArray();
                if (byequals.Length != 2)
                    throw new SyntaxErrorException(lineno, "Invalid variable syntax");
                string lvalue = byequals.First();
                string rvalue = byequals.Last();
                if (lvalue.Length == 0)
                    throw new SyntaxErrorException(lineno, "Empty lvalue of variable assignment");


                if (lvalue != "*")
                {
                    if (!alphabet.Contains(lvalue[0]))
                        throw new SyntaxErrorException(lineno, "Lvalue must be * or alphanumeric beginning with nonnumeric");
                    foreach (char c in lvalue)
                    {
                        if (!alphabet.Contains(c) && !numerals.Contains(c))
                            throw new SyntaxErrorException(lineno, "Lvalue must be * or alphanumeric beginning with nonnumeric");
                    }
                }


                VariableAssignment = new KeyValuePair<string, string>(lvalue, rvalue);
                return;
            }

            if (line.StartsWith("."))
            {
                string directiveName = line.Split(' ')[0];
                line = line.Substring(directiveName.Length + 1, line.Length - (directiveName.Length + 1));
                line = formatLine(line);

                if (line.StartsWith("\""))
                {
                    line = line.Substring(1, line.Length - 2);
                    //for (int i = 0; i < line.Length; ++i)
                    //{
                    //    if (line[i] == '"')
                    //    {
                    //        line = line.Substring(1, i - 1);
                    //        break;
                    //    }
                    //}
                }

                this.Directive = new Directive(directiveName.Substring(1, directiveName.Length - 1), line);
                

                return;
            }

            if (line.Length < 3)
                throw new SyntaxErrorException(lineno, "Line length less than 3");

            string opcode = line.Substring(0, 3);
            try
            {
                //this.OpCode = (OpCode)Enum.Parse(typeof(OpCode), opcode, true);
                OpCode = Assembly.GetOpCode(opcode);
            }
            catch (ArgumentException)
            {
                throw new SyntaxErrorException(lineno, "Illegal opcode");
            }

            List<string> byspace = line.Split(' ').ToList();

            byspace.RemoveAt(0);

            if (byspace.Count == 0)
                return;

            this.RValue = new RValue(formatLine(string.Join("", byspace.ToArray())));

            return;
        }

        /// <summary>
        /// Searches input variables for match. If found returns true. Otherwise returns false.
        /// </summary>
        /// <param name="variables"></param>
        public bool ResolveVariables(IDictionary<string, string> variables)
        {
            //branches and jumps can use variables, not just labels
            //so those have to be checked for here because it will later be assumed that the variables were already filled in
            foreach (var varname in variables.Keys)
            {
                if (this.RValue != null && RValue.ValueMiddle == varname)
                {
                    RValue.ValueMiddle = variables[varname];
                    return true;
                }
                if (this.Directive != null && this.Directive.RawArgumentWithoutQuotes == varname)
                {
                    Directive.RawArgumentWithoutQuotes = variables[varname];
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines addressing method of a line
        /// </summary>
        /// <param name="assembler"></param>
        public void DetermineAddressingMethod(AssemblerConfig config)
        {
            if (this.OpCode == null)
                throw new InvalidOperationException("Attempt to determine addressing method of non-statement");

            if (this.RValue == null)
            {
                this.AddressingMethod = Assembly.AddressingMethod.implied;
                return;
            }

            //will include branches, jmp, implied, accumulator (shown as implied 
            if (Assembly.OpcodeTable[OpCode.Value].Keys.Count == 1)
            {
                AddressingMethod = Assembly.OpcodeTable[OpCode.Value].Keys.First();
                return;
            }

            //branches and jumps were already detected before this point
            this.RValue.ParseValue(this.OpCode.Value);

            var result = this.RValue.ComputedValue;

            var choices =
                RValue.LineEndingToOptions[this.RValue.ValueRight].Where(
                    choice => Assembly.OpcodeTable[this.OpCode.Value].Keys.Contains(choice)
                ).ToList();

            if (choices.Count == 0)
                throw new SyntaxErrorException("Illegal addressing method for opcode");

            if (choices.Count == 1)
            {
                this.AddressingMethod = choices.First();
                return;
            }

            if (result.Literal)
            {
                this.AddressingMethod = Assembly.AddressingMethod.immediate;
                return;
            }

            choices.Remove(Assembly.AddressingMethod.immediate);

            if (choices.Count == 0)
                throw new SyntaxErrorException("Illegal addressing method for opcode");

            if (choices.Count == 1)
            {
                this.AddressingMethod = choices.First();
                return;
            }

            Assembly.AddressingMethod lo = choices.Where(choice => Assembly.AddressingMethodLength[choice] == 1).First();
            Assembly.AddressingMethod hi = choices.Where(choice => Assembly.AddressingMethodLength[choice] == 2).First();

            switch (config.OperandLength)
            {
                case AssemblerConfig.OperandLengthOption.Longest:
                    this.AddressingMethod = hi;
                    return;
                case AssemblerConfig.OperandLengthOption.Smallest:
                    if (result.Result > byte.MaxValue)
                    {
                        this.AddressingMethod = hi;
                        return;
                    }

                    this.AddressingMethod = lo;
                    return;
                case AssemblerConfig.OperandLengthOption.AsWritten:
                    //Only works in binary and hex because they're the ones where one extra digit is the point where it goes from one byte to two
                    if (result.Base == 2 || result.Base == 16)
                    {
                        //maximum characters before there are more characters than necessary to represent 256
                        int bumpLimit = result.Base == 2 ? 8 : 2;

                        if (result.ValueString.Length > bumpLimit)
                        {
                            this.AddressingMethod = hi;
                            return;
                        }

                        this.AddressingMethod = lo;
                        return;
                    }

                    if (result.Result > byte.MaxValue)
                    {
                        this.AddressingMethod = hi;
                        return;
                    }
                    this.AddressingMethod = lo;
                    return;
            }

            throw new SyntaxErrorException("Unable to determine addressing method");
        }

        bool resolveLabels(IDictionary<string, ushort> labels)
        {
            foreach (var label in labels.Keys)
            {
                if (RValue != null && RValue.ValueMiddle == label)
                {
                    RValue.ValueMiddle = "$" + Convert.ToString(labels[label], 16);
                    return true;
                }
                if (Directive != null && Directive.RawArgumentWithoutQuotes == label)
                {
                    Directive.RawArgumentWithoutQuotes = "$" + Convert.ToString(labels[label], 16);
                    return true;
                }
            }

            return false;
        }

        void finishResolveLabelsAndAssembleSecondPass()
        {
            ComputedBytes = new List<byte>();
            ComputedBytes.Add(Assembly.OpcodeTable[OpCode.Value][AddressingMethod.Value]);

            switch (Assembly.AddressingMethodLength[AddressingMethod.Value])
            {
                case 0:
                    break;
                case 1:
                    {
                        if (RValue.ComputedValue.Result > byte.MaxValue)
                            throw new SyntaxErrorException("Value out of range for byte");
                        ComputedBytes.Add((byte)RValue.ComputedValue.Result);
                    }
                    break;
                case 2:
                    {
                        foreach (byte b in Assembly.UshortToLE(RValue.ComputedValue.Result))
                            ComputedBytes.Add(b);                  
                    }
                    break;
            }
        }

        /// <summary>
        /// called on second pass once labels have already been initialized
        /// addressing method has already been assigned to
        /// </summary>
        /// <param name="assembler"></param>
        public void ResolveLabelsAndAssembleSecondPass(Assembler assembler, int lineno)
        {
            if (this.VariableAssignment != null)
            {
                return;
            }

            if (this.AddressingMethod != null && this.AddressingMethod.Value == Assembly.AddressingMethod.implied)
            {
                //no work to do
                finishResolveLabelsAndAssembleSecondPass();
                return;
            }
                

            if (!resolveLabels(assembler.Labels) && assembler.AssemblerGroup != null)
                resolveLabels(assembler.AssemblerGroup.Labels);

            if (this.Directive != null)
            {
                this.ComputedBytes = new List<byte>();

                this.Directive.ParseValue();
                if (this.Directive.Bytes != null)
                {
                    this.ComputedBytes = this.Directive.Bytes.ToList();
                    return;
                }

                int n = this.Directive.ComputedValue.GetNumeral();
                switch (this.Directive.Type)
                {
                    case DirectiveType.@byte:

                        if (n < 0)
                            n = Assembly.TwosComplement8bit(n);

                        if (n < byte.MinValue || n > byte.MaxValue)
                            throw new SyntaxErrorException("Value out of range for byte");

                        ComputedBytes.Add((byte)n);
                        return;
                    case DirectiveType.word:
                        if (n < 0 || n > ushort.MaxValue)
                            throw new SyntaxErrorException("Value out of range for word");

                        foreach (byte b in Assembly.UshortToLE((ushort)n))
                        {
                            ComputedBytes.Add(b);
                        }
                        return;
                }
                throw new SyntaxErrorException("Unspecified error with directive");
            }

            if (this.RValue != null)
                this.RValue.ParseValue(this.OpCode.Value, this.AddressingMethod.Value, PC);

            //Label searching and value setting done - now only concerned with determining the addressing method

            if (this.AddressingMethod != null)
            {
                //The label replacement has been finished by now, and jmps and branches are finished
                finishResolveLabelsAndAssembleSecondPass();
                return;
            }

            //throw new SyntaxErrorException(lineno, "End of second pass reached without finding an addressing method");
        }
    }
}
