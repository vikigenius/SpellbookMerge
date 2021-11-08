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
                bp.SetDescription("At 3rd rank, Aeon receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. They can either choose to take it as part of an existing spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    Resources.SpellbookBlueprints.InquisitorSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WarPriestSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.DruidSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.MagusSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SwordSaintSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.HunterSpellbook.ToReference<BlueprintSpellbookReference>(),
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
                bp.SetDescription("At 3rd rank, Azata receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. They can either choose to take it as part of an existing spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    Resources.SpellbookBlueprints.MagusSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.BardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SkaldSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SwordSaintSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SorcererSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.DruidSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.HunterSpellbook.ToReference<BlueprintSpellbookReference>(),
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.AzataSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }
        
        public static void AddDemonIncorporateSpellbookFeature()
        {
            Resources.CreateBlueprint<BlueprintFeatureSelectMythicSpellbook>("DemonIncorporateSpellbook", bp =>
            {
                bp.SetName("Mythic Spellbook");
                bp.SetDescription("At 3rd rank, Demon receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. They can either choose to take it as part of an existing spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    Resources.SpellbookBlueprints.MagusSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SwordSaintSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.BloodRagerSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.HunterSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SkaldSpellbook.ToReference<BlueprintSpellbookReference>()
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.DemonSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }
        
        public static void AddTricksterIncorporateSpellbookFeature()
        {
            Resources.CreateBlueprint<BlueprintFeatureSelectMythicSpellbook>("TricksterIncorporateSpellbook", bp =>
            {
                bp.SetName("Mythic Spellbook");
                bp.SetDescription("At 3rd rank, Trickster receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. They can either choose to take it as part of an existing spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    Resources.SpellbookBlueprints.MagusSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SwordSaintSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.AlchemistSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.EldritchScoundrelSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.BardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SkaldSpellbook.ToReference<BlueprintSpellbookReference>(),
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.TricksterSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }

    }
}