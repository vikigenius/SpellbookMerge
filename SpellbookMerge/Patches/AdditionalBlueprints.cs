using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;

namespace SpellbookMerge.Patches
{
    // ReSharper disable once UnusedType.Global
    public class AdditionalBlueprints
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        // ReSharper disable once UnusedType.Local
        private static class BlueprintsCacheInitPatch
        {
            private static bool _initialized;

            [HarmonyPriority(Priority.First)]
            // ReSharper disable once UnusedMember.Local
            private static void Postfix()
            {
                if (!Main.Enabled || _initialized) return;
                _initialized = true;
                Main.LogHeader("Adding new Blueprints");
                Features.IncorporateSpellbook.AddAeonIncorporateSpellbookFeature();
                Features.IncorporateSpellbook.AddAzataIncorporateSpellbookFeature();
                Features.IncorporateSpellbook.AddDemonIncorporateSpellbookFeature();
                Features.IncorporateSpellbook.AddTricksterIncorporateSpellbookFeature();
            }
        }
    }
}