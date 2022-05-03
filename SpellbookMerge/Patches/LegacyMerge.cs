using System;
using System.Linq;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Class.LevelUp;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;

namespace SpellbookMerge.Patches
{
    public class LegacyMerge
    {
        [HarmonyPatch(typeof(ApplySpellbook), nameof(ApplySpellbook.Apply), new Type[] {typeof(LevelUpState), typeof(UnitDescriptor)})]
        // ReSharper disable once UnusedType.Local
        private static class ApplySpellbookApplyPatch
        {
	        // ReSharper disable once UnusedMember.Local
            private static bool Prefix(LevelUpState state, UnitDescriptor unit)
            {
                if (!Main.Enabled) return true;
                Apply(state, unit);
                return false;
            }
            
	        public static void Apply(LevelUpState state, UnitDescriptor unit)
			{
                if (state.SelectedClass == null)
				{
					return;
				}
				var component = state.SelectedClass.GetComponent<SkipLevelsForSpellProgression>();
				if (component != null && component.Levels.Contains(state.NextClassLevel))
				{
					return;
				}
				var classData = unit.Progression.GetClassData(state.SelectedClass);
				if (classData?.Spellbook == null) return;
				Spellbook spellbook = unit.DemandSpellbook(classData.Spellbook);
				if (state.SelectedClass.Spellbook && state.SelectedClass.Spellbook != classData.Spellbook)
				{
					var spellbook2 = unit.Spellbooks.FirstOrDefault(s => s.Blueprint == state.SelectedClass.Spellbook);
					if (spellbook2 != null)
					{
						foreach (AbilityData abilityData in spellbook2.GetAllKnownSpells())
						{
							spellbook.AddKnown(abilityData.SpellLevel, abilityData.Blueprint);
						}
						unit.DeleteSpellbook(state.SelectedClass.Spellbook);
					}
				}
				int casterLevel = spellbook.CasterLevel;
				spellbook.AddLevelFromClass(classData.CharacterClass);
				int casterLevel2 = spellbook.CasterLevel;
				SpellSelectionData spellSelectionData = state.DemandSpellSelection(spellbook.Blueprint, spellbook.Blueprint.SpellList);
				if (spellbook.Blueprint.SpellsKnown != null)
				{
					for (int i = 0; i <= 10; i++)
					{
						BlueprintSpellsTable spellsKnown = spellbook.Blueprint.SpellsKnown;
						int num = spellsKnown.GetCount(casterLevel, i);
						int num2 = spellsKnown.GetCount(casterLevel2, i);
						spellSelectionData.SetLevelSpells(i, Math.Max(0, num2 - num));
					}
				}
				int maxSpellLevel = spellbook.MaxSpellLevel;
				if (spellbook.Blueprint.SpellsPerLevel > 0)
				{
					if (casterLevel == 0)
					{
						spellSelectionData.SetExtraSpells(0, maxSpellLevel);
						spellSelectionData.ExtraByStat = true;
						spellSelectionData.UpdateMaxLevelSpells(unit);
					}
					else
					{
						spellSelectionData.SetExtraSpells(spellbook.Blueprint.SpellsPerLevel, maxSpellLevel);
					}
				}
				foreach (AddCustomSpells customSpells in spellbook.Blueprint.GetComponents<AddCustomSpells>())
				{
					ApplySpellbook.TryApplyCustomSpells(spellbook, customSpells, state, unit);
				}
			}
        }
    }
}