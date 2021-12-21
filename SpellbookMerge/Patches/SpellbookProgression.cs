using System.Collections.Generic;
using System.Linq;
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
                PatchSwordSaintSpellSlotProgression();
                PatchBloodRagerSpellSlotProgression();
                PatchAlchemistSpellSlotProgression();
                PatchPaladinSpellSlotProgression();
            }

            private static void PatchHybridCasterSpellProgression(BlueprintSpellsTable hybridCasterSlots)
            {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(hybridCasterSlots.Levels);
                var additionalSlotTables = new List<int[]>
                {
                    new[] {0, 5, 5, 5, 5, 5, 5, 1},
                    new[] {0, 5, 5, 5, 5, 5, 5, 2},
                    new[] {0, 5, 5, 5, 5, 5, 5, 3},
                    new[] {0, 5, 5, 5, 5, 5, 5, 4},
                    new[] {0, 5, 5, 5, 5, 5, 5, 5},
                };
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry {Count = slots}));
                hybridCasterSlots.Levels = levels.ToArray();
            }
            
            // Patch Inquisitor Spellbook to allow 7th level spells
            private static void PatchInquisitorSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["Inquisitor"]) return;
                var inquisitorSpellSlots = Resources.SpellTableBlueprints.InquisitorSpellsTable;
                PatchHybridCasterSpellProgression(inquisitorSpellSlots);
                Main.Log($"Patched Inquisitor Spell Levels to {inquisitorSpellSlots.Levels.Length}");
            }

            // Patch WarPriest Spellbook to allow 7th level spells
            private static void PatchWarPriestSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["WarPriest"]) return;
                var warPriestSpellSlots = Resources.SpellTableBlueprints.WarPriestSpellsTable;
                PatchHybridCasterSpellProgression(warPriestSpellSlots);
                Main.Log($"Patched WarPriest Spell Levels to {warPriestSpellSlots.Levels.Length}");
            }
            
            // Patch Bard Spellbook to allow 7th level spells (Also used by Hunter)
            private static void PatchBardSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["Bard"]) return;
                var bardSpellSlots = Resources.SpellTableBlueprints.BardSpellsTable;
                PatchHybridCasterSpellProgression(bardSpellSlots);
                Main.Log($"Patched Bard Spell Levels to {bardSpellSlots.Levels.Length}");
            }
            
            // Patch Magus Spellbook to allow 7th level spells
            private static void PatchMagusSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["Magus"]) return;
                var magusSpellSlots = Resources.SpellTableBlueprints.MagusSpellsTable;
                PatchHybridCasterSpellProgression(magusSpellSlots);
                Main.Log($"Patched Magus Spell Levels to {magusSpellSlots.Levels.Length}");
            }
            
            // Patch Skald Spellbook to allow 7th level spells
            private static void PatchSkaldSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["Skald"]) return;
                var skaldSpellSlots = Resources.SpellTableBlueprints.SkaldSpellsTable;
                PatchHybridCasterSpellProgression(skaldSpellSlots);
                Main.Log($"Patched Skald Spell Levels to {skaldSpellSlots.Levels.Length}");
            }

            // Patch SwordSaint Spellbook to allow 7th level spells
            private static void PatchSwordSaintSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["SwordSaint"]) return;
                var swordSaintSpellSlots = Resources.SpellTableBlueprints.SwordSaintSpellsTable;
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(swordSaintSpellSlots.Levels);
                var additionalSlotTables = new List<int[]>
                {
                    new[] {0, 4, 4, 4, 4, 4, 4, 1},
                    new[] {0, 4, 4, 4, 4, 4, 4, 2},
                    new[] {0, 4, 4, 4, 4, 4, 4, 3},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4},
                };
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry {Count = slots}));

                swordSaintSpellSlots.Levels = levels.ToArray();
                Main.Log($"Patched SwordSaint Spell Levels to {swordSaintSpellSlots.Levels.Length}");
            }
            
            // Patch BloodRager Spellbook to allow 7th level spells
            private static void PatchBloodRagerSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["BloodRager"]) return;
                var bloodRagerSpellSlots = Resources.SpellTableBlueprints.BloodRagerSpellsTable;
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(bloodRagerSpellSlots.Levels);
                var additionalSlotTables = new List<int[]>
                {
                    new[] {0, 4, 4, 3, 3, 1},
                    new[] {0, 4, 4, 4, 3, 2},
                    new[] {0, 4, 4, 4, 4, 3, 1},
                    new[] {0, 4, 4, 4, 4, 4, 2},
                    new[] {0, 4, 4, 4, 4, 4, 3, 1},
                    new[] {0, 4, 4, 4, 4, 4, 4, 2},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4},
                };
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry {Count = slots}));
                bloodRagerSpellSlots.Levels = levels.ToArray();
                Main.Log($"Patched BloodRager Spell Levels to {bloodRagerSpellSlots.Levels.Length}");
            }
            
            // Patch Alchemist Spellbook to allow 7th level spells
            private static void PatchAlchemistSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["Alchemist"]) return;
                var alchemistSpellSlots = Resources.SpellTableBlueprints.AlchemistSpellsTable;
                PatchHybridCasterSpellProgression(alchemistSpellSlots);
                Main.Log($"Patched Alchemist Spell Levels to {alchemistSpellSlots.Levels.Length}");
            }

            // Patch Paladin Spellbook to allow 10th level spells
            private static void PatchPaladinSpellSlotProgression()
            {
                if (!Main.ModSettings.PatchSettings.SpellProgressionPatches["Paladin"]) return;
                var paladinSpellSlots = Resources.SpellTableBlueprints.PaladinSpellsTable;
                paladinSpellSlots.Levels[18].Count = new[] {0, 4, 4, 4, 4, 2, 2};
                paladinSpellSlots.Levels[19].Count = new[] {0, 4, 4, 4, 4, 4, 4};
                paladinSpellSlots.Levels[20].Count = new[] {0, 4, 4, 4, 4, 4, 4, 2};
 
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>(paladinSpellSlots.Levels);
                var additionalSlotTables = new List<int[]>
                {
                    new[] {0, 4, 4, 4, 4, 4, 4, 4},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4, 2},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4, 4},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4, 4, 2},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2},
                    new[] {0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                };
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry {Count = slots}));
                paladinSpellSlots.Levels = levels.ToArray();
                Main.Log($"Patched Paladin Spell Levels to {paladinSpellSlots.Levels.Length}");
            }
        }
    }
}