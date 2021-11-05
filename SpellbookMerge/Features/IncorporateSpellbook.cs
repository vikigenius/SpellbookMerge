using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using SpellbookMerge.Extensions;

namespace SpellbookMerge.Features
{
    internal static class IncorporateSpellbook {
        public static void AddAeonIncorporateSpellbookFeature()
        {
            Resources.CreateBlueprint<BlueprintFeatureSelectMythicSpellbook>("AeonIncorporateSpellbook", bp =>
            {
                bp.SetName("Mythic Spellbook");
                bp.SetDescription("At 3rd rank, Aeon receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. He can either choose to take it as part of an existing hybrid divine caster spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    Resources.SpellbookBlueprints.InquisitorSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WarPriestSpellbook.ToReference<BlueprintSpellbookReference>()
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.AeonSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }
        
        public static void AddAzataIncorporateSpellbookFeature()
        {
            Resources.CreateBlueprint<BlueprintFeatureSelectMythicSpellbook>("AzataIncorporateSpellbook", bp =>
            {
                bp.SetName("Mythic Spellbook");
                bp.SetDescription("At 3rd rank, Azata receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. They can either choose to take it as part of an existing hybrid arcane caster spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    Resources.SpellbookBlueprints.MagusSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.BardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SkaldSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SwordSaintSpellbook.ToReference<BlueprintSpellbookReference>()
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.AzataSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }
    }
}