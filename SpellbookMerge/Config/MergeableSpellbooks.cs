using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace SpellbookMerge.Config
{
    public abstract class MergeableSpellbook
    {
        [JsonProperty(PropertyName = "ShouldMerge")]
        public bool ShouldMerge { get; private set; } = true;
    }
    
    public class MergeableBaseSpellbook : MergeableSpellbook {}

    public class AeonMergedSpellbook : MergeableSpellbook
    {
        [JsonProperty(PropertyName = "Inquisitor")]
        public MergeableBaseSpellbook? Inquisitor { get; private set; } = new MergeableBaseSpellbook();
    }
    
    public class MergeableSpellbooks: IOverridable
    {
        [JsonProperty(PropertyName = "Aeon")]
        public AeonMergedSpellbook? Aeon { get; private set; } = new AeonMergedSpellbook();
        private static JsonSerializerSettings? _cachedSettings;
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

        public void OverrideFrom(string userConfigDir)
        {
            var settingsFile = Path.Combine(userConfigDir, "MergeableSpellbooks.json");
            if (!File.Exists(settingsFile))
            {
                SaveTo(userConfigDir);
                return;
            }
            var loadedSettings = MergeableSpellbooks.FromFile(settingsFile);
            Aeon = loadedSettings!.Aeon;
        }

        public void SaveTo(string userConfigDir)
        {
            var settingsFile = Path.Combine(userConfigDir, "MergeableSpellbooks.json");
            File.WriteAllText(settingsFile, JsonConvert.SerializeObject(this, SerializerSettings));
        }

        public static MergeableSpellbooks FromEmbeddedResource()
        {
            JsonSerializer serializer = JsonSerializer.Create();
            var resourcePath = $"SpellbookMerge.Config.MergeableSpellbooks.json";
            var assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream(resourcePath)!;
            using StreamReader streamReader = new StreamReader(stream);
            using var reader = new JsonTextReader(streamReader);
            return serializer.Deserialize<MergeableSpellbooks>(reader)!;
        }

        private static MergeableSpellbooks? FromFile(string filename)
        {
            return JsonConvert.DeserializeObject<MergeableSpellbooks>(File.ReadAllText(filename));
        }
        
        
    }
}