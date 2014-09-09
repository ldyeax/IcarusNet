using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace IcarusNetFrontend_Winforms
{
    public class IcarusNetSettings
    {
        [JsonIgnore]
        public static IcarusNetSettings Instance;
        [JsonIgnore]
        static JsonSerializerSettings jsonSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented };

#pragma warning disable 0618
        static IcarusNetSettings()
        {
            jsonSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter() { CamelCaseText = true });
            jsonSettings.TypeNameHandling = TypeNameHandling.None;
            var resolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            resolver.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
            jsonSettings.ContractResolver = resolver;
        }
#pragma warning restore 0618

        public string LastOpenProjectPath = null;

        public static void Save()
        {
            File.WriteAllText(ProjectLocations.SettingsFile, JsonConvert.SerializeObject(Instance, jsonSettings));
        }
        public static void Load()
        {
            Instance = JsonConvert.DeserializeObject<IcarusNetSettings>(File.ReadAllText(ProjectLocations.SettingsFile), jsonSettings);
        }
    }
}
