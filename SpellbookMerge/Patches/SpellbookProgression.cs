using System.Collections.Generic;
using HarmonyLib;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;

namespace SpellbookMerge.Patches
{
    public class SpellbookProgression
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        private static class BlueprintsCacheInitPatch
        {
            private static bool _initialized;

            private static void Postfix()
            {
                if (!Main.Enabled || _initialized) return;
                _initialized = true;
                Main.LogHeader("Patching spellbook progressions");
                PatchInquisitorSpellSlotProgression();
                PatchWarPriestSpellSlotProgression();
                PatchMagusSpellSlotProgression();
                PatchBardSpellSlotProgression();
                PatchSkaldSpellSlotProgression();
            }

            private static void PatchHybridCasterSpellProgression(BlueprintSpellsTable hybridCasterSlots)
            {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(hybridCasterSlots.Levels);
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
                hybridCasterSlots.Levels = levels.ToArray();
            }
            
            // Patch Inquisitor Spellbook to allow 7th level spells
            private static void PatchInquisitorSpellSlotProgression()
            {
                var inquisitorSpellSlots = Resources.SpellTableBlueprints.InquisitorSpellsTable;
                PatchHybridCasterSpellProgression(inquisitorSpellSlots);
                Main.Log($"Patched Inquisitor Spell Levels to {inquisitorSpellSlots.Levels.Length}");
            }

            // Patch WarPriest Spellbook to allow 7th level spells
            private static void PatchWarPriestSpellSlotProgression()
            {
                var warPriestSpellSlots = Resources.SpellTableBlueprints.WarPriestSpellsTable;
                PatchHybridCasterSpellProgression(warPriestSpellSlots);
                Main.Log($"Patched WarPriest Spell Levels to {warPriestSpellSlots.Levels.Length}");
            }
            
            // Patch Bard Spellbook to allow 7th level spells
            private static void PatchBardSpellSlotProgression()
            {
                var bardSpellSlots = Resources.SpellTableBlueprints.BardSpellsTable;
                PatchHybridCasterSpellProgression(bardSpellSlots);
                Main.Log($"Patched Bard Spell Levels to {bardSpellSlots.Levels.Length}");
            }
            
            // Patch Magus Spellbook to allow 7th level spells
            private static void PatchMagusSpellSlotProgression()
            {
                var magusSpellSlots = Resources.SpellTableBlueprints.MagusSpellsTable;
                PatchHybridCasterSpellProgression(magusSpellSlots);
                Main.Log($"Patched Magus Spell Levels to {magusSpellSlots.Levels.Length}");
            }
            
            // Patch Skald Spellbook to allow 7th level spells
            private static void PatchSkaldSpellSlotProgression()
            {
                var skaldSpellSlots = Resources.SpellTableBlueprints.SkaldSpellsTable;
                PatchHybridCasterSpellProgression(skaldSpellSlots);
                Main.Log($"Patched Skald Spell Levels to {skaldSpellSlots.Levels.Length}");
            }
        }
    }
}