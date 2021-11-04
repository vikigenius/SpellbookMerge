using System.Collections.Generic;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;

namespace SpellbookMerge.Patches
{
    internal class AzataProgression
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        private static class BlueprintsCacheInitPatch
        {
            private static bool _initialized;
            
            private static void Postfix()
            {
                if (!Main.Enabled || _initialized) return;
                _initialized = true;
                Main.LogHeader("Azata Progression");
                PatchAzataProgression();
                PatchMagusSpellSlotProgression();
                PatchBardSpellSlotProgression();
                PatchSkaldSpellSlotProgression();
            }

            private static void PatchAzataProgression()
            {
                var azataProgression = Resources.TryGetBlueprint<BlueprintProgression>("9db53de4bf21b564ca1a90ff5bd16586");
                var azataIncorporateSpellbookFeature =
                    Resources.TryGetModBlueprint<BlueprintFeatureSelectMythicSpellbook>("AzataIncorporateSpellbook");
                azataProgression!.LevelEntries[0].m_Features
                    .Add(azataIncorporateSpellbookFeature.ToReference<BlueprintFeatureBaseReference>());
                Main.Log("Patched Azata Progression");
            }
            
            // Patch Magus Spellbook to allow 7th level spells
            private static void PatchMagusSpellSlotProgression() {
                var magusSpellSlots = Resources.TryGetBlueprint<BlueprintSpellsTable>("6326b540f7c6a604f9d6f82cc0e2293c");
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(magusSpellSlots!.Levels);
                for (var i = 0; i < 8; i++) {
                    var spellLevel = new SpellsLevelEntry
                    {
                        Count = i switch
                        {
                            > 6 => new[] {0, 5, 5, 5, 5, 5, 5, 3},
                            > 4 => new[] {0, 5, 5, 5, 5, 5, 5, 2},
                            _ => new[] {0, 5, 5, 5, 5, 5, 5}
                        }
                    };
                    levels.Add(spellLevel);
                }
                magusSpellSlots.Levels = levels.ToArray();
                Main.Log($"Patched Magus Spell Levels to {magusSpellSlots.Levels.Length}");
            }
            
            // Patch Bard Spellbook to allow 7th level spells
            private static void PatchBardSpellSlotProgression() {
                var bardSpellSlots = Resources.TryGetBlueprint<BlueprintSpellsTable>("0a8eec9ca5c0dc64795243ab3c55d924");
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(bardSpellSlots!.Levels);
                for (var i = 0; i < 8; i++) {
                    var spellLevel = new SpellsLevelEntry
                    {
                        Count = i switch
                        {
                            > 6 => new[] {0, 5, 5, 5, 5, 5, 5, 3},
                            > 4 => new[] {0, 5, 5, 5, 5, 5, 5, 2},
                            _ => new[] {0, 5, 5, 5, 5, 5, 5}
                        }
                    };
                    levels.Add(spellLevel);
                }
                bardSpellSlots.Levels = levels.ToArray();
                Main.Log($"Patched Bard Spell Levels to {bardSpellSlots.Levels.Length}");
            }
            
            // Patch Bard Spellbook to allow 7th level spells
            private static void PatchSkaldSpellSlotProgression() {
                var skaldSpellSlots = Resources.TryGetBlueprint<BlueprintSpellsTable>("39aeb5d8dafde5a40ba2032dec65db70");
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(skaldSpellSlots!.Levels);
                for (var i = 0; i < 8; i++) {
                    var spellLevel = new SpellsLevelEntry
                    {
                        Count = i switch
                        {
                            > 6 => new[] {0, 5, 5, 5, 5, 5, 5, 3},
                            > 4 => new[] {0, 5, 5, 5, 5, 5, 5, 2},
                            _ => new[] {0, 5, 5, 5, 5, 5, 5}
                        }
                    };
                    levels.Add(spellLevel);
                }
                skaldSpellSlots.Levels = levels.ToArray();
                Main.Log($"Patched Skald Spell Levels to {skaldSpellSlots.Levels.Length}");
            }
        }
    }
}