using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Kingmaker.Utility;
using Newtonsoft.Json;

namespace SpellbookMerge.Config
{
    public class PatchSettings : IOverridable
    {
        [JsonProperty]
        public readonly SortedDictionary<string, bool> SpellProgressionPatches = new SortedDictionary<string, bool>();
        private static JsonSerializerSettings? _cachedSettings;

        public void OverrideFrom(string userConfigDir)
        {
            var settingsFile = Path.Combine(userConfigDir, "PatchSettings.json");
            if (!File.Exists(settingsFile))
            {
                SaveTo(userConfigDir);
                return;
            }
            var loadedSettings = FromFile(settingsFile);
            loadedSettings!.SpellProgressionPatches.ForEach(entry =>
            {
                var (key, value) = entry;
                if (SpellProgressionPatches.ContainsKey(key))
                {
                    SpellProgressionPatches[key] = value;
                }
            });
        }

        public void SaveTo(string userConfigDir)
        {
            var patchSettingsFile = Path.Combine(userConfigDir, "PatchSettings.json");
            File.WriteAllText(patchSettingsFile, JsonConvert.SerializeObject(this, SerializerSettings));
        }
        
        private static JsonSerializerSettings SerializerSettings {
            get
            {
                return _cachedSettings ??= new JsonSerializerSettings
                {
                    CheckAdditionalContent = false,
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    FloatParseHandling = FloatParseHandling.Double,
                    Formatting = Formatting.Indented,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    ObjectCreationHandling = ObjectCreationHandling.Replace,
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    StringEscapeHandling = StringEscapeHandling.Default,
                };
            }
        }
        
        public static PatchSettings FromEmbeddedResource()
        {
            JsonSerializer serializer = JsonSerializer.Create();
            var resourcePath = $"SpellbookMerge.Config.PatchSettings.json";
            var assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream(resourcePath)!;
            using StreamReader streamReader = new StreamReader(stream);
            using var reader = new JsonTextReader(streamReader);
            return serializer.Deserialize<PatchSettings>(reader)!;
        }

        public static PatchSettings? FromFile(string filename)
        {
            return JsonConvert.DeserializeObject<PatchSettings>(File.ReadAllText(filename));
        }
    }
}