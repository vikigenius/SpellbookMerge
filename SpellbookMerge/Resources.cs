using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Localization;

namespace SpellbookMerge
{
    public static class Resources
    {
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
                AssetGuid = Main.ModSettings.Blueprints!.GetGuiD(name)
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