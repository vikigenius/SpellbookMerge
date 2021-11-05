using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;

namespace SpellbookMerge
{
    public static class Resources
    {
        internal static class SpellbookBlueprints
        {
            public static BlueprintSpellbook InquisitorSpellbook => TryGetBlueprint<BlueprintSpellbook>("57fab75111f377248810ece84193a5a5")!;
            public static BlueprintSpellbook WarPriestSpellbook => TryGetBlueprint<BlueprintSpellbook>("7d7d51be2948d2544b3c2e1596fd7603")!;
            public static BlueprintSpellbook MagusSpellbook => TryGetBlueprint<BlueprintSpellbook>("5d8d04e76dff6c5439de99af0d57be63")!;
            public static BlueprintSpellbook BardSpellbook => TryGetBlueprint<BlueprintSpellbook>("bc04fc157a8801d41b877ad0d9af03dd")!;
            public static BlueprintSpellbook SkaldSpellbook => TryGetBlueprint<BlueprintSpellbook>("8f159d2f22ced074ea32995eb5a446a0")!;
            public static BlueprintSpellbook SwordSaintSpellbook => TryGetBlueprint<BlueprintSpellbook>("682545e11e5306c45b14ca78bcbe3e62")!;
        }

        internal static class SpellListBlueprints
        {
            public static BlueprintSpellList AeonSpellList => TryGetBlueprint<BlueprintSpellList>("ca8c6024bd2519f4b97162a3ad286920")!;
            public static BlueprintSpellList AzataSpellList => TryGetBlueprint<BlueprintSpellList>("10c634d2b386d8d41b18a889adb8cd49")!;
        }

        internal static class ProgressionBlueprints
        {
            public static BlueprintProgression AeonProgression => TryGetBlueprint<BlueprintProgression>("34b9484b0d5ce9340ae51d2bf9518bbe")!;
            public static BlueprintProgression AzataProgression => TryGetBlueprint<BlueprintProgression>("9db53de4bf21b564ca1a90ff5bd16586")!;

        }

        internal static class SpellTableBlueprints
        {
            public static BlueprintSpellsTable InquisitorSpellsTable => TryGetBlueprint<BlueprintSpellsTable>("83d3e15962e5d6949b90b5c226a2b487")!;
            public static BlueprintSpellsTable WarPriestSpellsTable => TryGetBlueprint<BlueprintSpellsTable>("c73a394ec54adc243aef8ac967e39324")!;
            public static BlueprintSpellsTable MagusSpellsTable => TryGetBlueprint<BlueprintSpellsTable>("6326b540f7c6a604f9d6f82cc0e2293c")!;
            public static BlueprintSpellsTable BardSpellsTable => TryGetBlueprint<BlueprintSpellsTable>("0a8eec9ca5c0dc64795243ab3c55d924")!;
            public static BlueprintSpellsTable SkaldSpellsTable => TryGetBlueprint<BlueprintSpellsTable>("39aeb5d8dafde5a40ba2032dec65db70")!;
            public static BlueprintSpellsTable SwordSaintSpellsTable => TryGetBlueprint<BlueprintSpellsTable>("b9fdc0b2d37eb9e4298f9163edf5ca82")!;
        }

        
        private static readonly Dictionary<BlueprintGuid, SimpleBlueprint> ModBlueprints = new Dictionary<BlueprintGuid, SimpleBlueprint>();
        // All localized strings created in this mod, mapped to their localized key. Populated by CreateString.
        private static Dictionary<string, LocalizedString> textToLocalizedString = new Dictionary<string, LocalizedString>();

        private static void AddBlueprint(SimpleBlueprint blueprint) {
            AddBlueprint(blueprint, blueprint.AssetGuid);
        }

        private static void AddBlueprint(SimpleBlueprint blueprint, BlueprintGuid assetId) {
            var loadedBlueprint = ResourcesLibrary.TryGetBlueprint(assetId);
            if (loadedBlueprint == null) {
                ModBlueprints[assetId] = blueprint;
                ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(assetId, blueprint);
                blueprint.OnEnable();
                Main.Log($"Added blueprint {assetId}");
            } else {
                Main.Log($"Failed to Add: {blueprint.name}");
                Main.Log($"Asset ID: {assetId} already in use by: {loadedBlueprint.name}");
            }
        }

        public static T CreateBlueprint<T>(string name, Action<T>? init = null) where T : SimpleBlueprint, new() {
            var result = new T {
                name = name,
                AssetGuid = Main.ModSettings.Blueprints.GetGuiD(name)
            };
            AddBlueprint(result);
            init?.Invoke(result);
            return result;
        }
        
        public static LocalizedString CreateString(string key, string value) {
            // See if we used the text previously.
            // (It's common for many features to use the same localized text.
            // In that case, we reuse the old entry instead of making a new one.)
            if (textToLocalizedString.TryGetValue(value, out LocalizedString localized)) {
                return localized;
            }
            var strings = LocalizationManager.CurrentPack?.Strings;
            if (strings!.TryGetValue(key, out string oldValue) && value != oldValue) {
                Main.LogDebug($"Info: duplicate localized string `{key}`, different text.");
            }
            strings[key] = value;
            localized = new LocalizedString {
                m_Key = key
            };
            textToLocalizedString[value] = localized;
            return localized;
        }
        
        private static T? TryGetBlueprint<T>(BlueprintGuid id) where T : SimpleBlueprint {
            var asset = ResourcesLibrary.TryGetBlueprint(id);
            var value = asset as T;
            if (value == null) { Main.Log($"COULD NOT LOAD: {id} - {typeof(T)}"); }
            return value;
        }

        public static T? TryGetBlueprint<T>(string id) where T : SimpleBlueprint {
            var assetId = new BlueprintGuid(Guid.Parse(id));
            return TryGetBlueprint<T>(assetId);
        }
        
        public static T? TryGetModBlueprint<T>(string name) where T : SimpleBlueprint {
            var assetId = Main.ModSettings.Blueprints.GetGuiD(name);
            ModBlueprints.TryGetValue(assetId, out var value);
            return value as T;
        }
    }
}