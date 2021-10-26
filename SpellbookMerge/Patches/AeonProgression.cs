using System.Collections.Generic;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;

namespace SpellbookMerge.Patches
{
    internal class AeonProgression
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        private static class BlueprintsCacheInitPatch
        {
            private static bool _initialized;
            
            private static void Postfix()
            {
                if (!Main.Enabled || _initialized) return;
                _initialized = true;
                Main.LogHeader("Aeon Progression");
                PatchAeonProgression();
            }

            private static void PatchAeonProgression()
            {
                var aeonSpellbook = Main.ModSettings.MergeableSpellbooks.Aeon;
                if (!aeonSpellbook!.ShouldMerge) return;
                var aeonProgression = Resources.TryGetBlueprint<BlueprintProgression>("34b9484b0d5ce9340ae51d2bf9518bbe");
                var aeonIncorporateSpellbookFeature =
                    Resources.TryGetModBlueprint<BlueprintFeatureSelectMythicSpellbook>("AeonIncorporateSpellbook");
                aeonProgression!.LevelEntries[0].m_Features
                    .Add(aeonIncorporateSpellbookFeature.ToReference<BlueprintFeatureBaseReference>());
                Main.Log("Patched Aeon Progression");
            }
            
            // Patch Inquisitor Spellbook to allow 7th level spells
            private static void PatchInquisitorSpellSlotProgression() {
                var inquisitorSpellSlots = Resources.TryGetBlueprint<BlueprintSpellsTable>("83d3e15962e5d6949b90b5c226a2b487");
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(inquisitorSpellSlots!.Levels);
                for (var i = 0; i < 8; i++) {
                    var spellLevel = new SpellsLevelEntry();
                    spellLevel.Count = i switch
                    {
                        > 6 => new[] {0, 5, 5, 5, 5, 5, 5, 3},
                        > 4 => new[] {0, 5, 5, 5, 5, 5, 5, 2},
                        _ => new[] {0, 5, 5, 5, 5, 5, 5}
                    };
                    levels.Add(spellLevel);
                }
                inquisitorSpellSlots.Levels = levels.ToArray();
                Main.Log($"Patched Inquisitor Spell Levels to {inquisitorSpellSlots.Levels.Length}");
            }
        }
    }
}