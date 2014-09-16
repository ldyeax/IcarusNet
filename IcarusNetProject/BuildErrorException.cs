using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IcarusNetProject
{
    public class BuildErrorException : Exception
    {
        public BuildErrorException(Exception ex) : base(ex.Message, ex)
        {

        }
    }
}
