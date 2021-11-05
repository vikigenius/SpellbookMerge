using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;

namespace SpellbookMerge.Patches
{
    public class MythicProgression
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        private static class BlueprintsCacheInitPatch
        {
            private static bool _initialized;
            
            private static void Postfix()
            {
                if (!Main.Enabled || _initialized) return;
                _initialized = true;
                Main.LogHeader("Patching Mythic Progressions");
                PatchAeonProgression();
                PatchAzataProgression();
            }

            private static void PatchAeonProgression()
            {
                var aeonProgression = Resources.ProgressionBlueprints.AeonProgression;
                var aeonIncorporateSpellbookFeature =
                    Resources.TryGetModBlueprint<BlueprintFeatureSelectMythicSpellbook>("AeonIncorporateSpellbook");
                aeonProgression.LevelEntries[0].m_Features
                    .Add(aeonIncorporateSpellbookFeature.ToReference<BlueprintFeatureBaseReference>());
                Main.Log("Patched Aeon Progression");
            }
            
            private static void PatchAzataProgression()
            {
                var azataProgression = Resources.ProgressionBlueprints.AzataProgression;
                var azataIncorporateSpellbookFeature =
                    Resources.TryGetModBlueprint<BlueprintFeatureSelectMythicSpellbook>("AzataIncorporateSpellbook");
                azataProgression.LevelEntries[0].m_Features
                    .Add(azataIncorporateSpellbookFeature.ToReference<BlueprintFeatureBaseReference>());
                Main.Log("Patched Azata Progression");
            }
        }
    }
}