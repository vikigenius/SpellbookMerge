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
                    Resources.SpellbookBlueprints.EldritchScionSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SorcererSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WizardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ArcanistSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SageSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.CrossbloodedSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.OracleSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.BardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ShamanSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ClericSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WitchSpellbook.ToReference<BlueprintSpellbookReference>(),

                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.AeonSpellList.ToReference<BlueprintSpellListReference>();
                // TODO This is just there for compatibility with Owlcat new changes in 1.3. We are not using it yet, since we reverted to the old merging behavior
                bp.m_SpellKnownForSpontaneous = Resources.SpellTableBlueprints.MythicSpontaneousSpellsKnownTable
                    .ToReference<BlueprintSpellsTableReference>();
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
                    Resources.SpellbookBlueprints.BloodRagerSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WizardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ExploiterWizardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.EldritchScionSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ArcanistSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SageSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.CrossbloodedSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.OracleSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ShamanSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ClericSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WitchSpellbook.ToReference<BlueprintSpellbookReference>(),
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.AzataSpellList.ToReference<BlueprintSpellListReference>();
                // TODO This is just there for compatibility with Owlcat new changes in 1.3. We are not using it yet, since we reverted to the old merging behavior
                bp.m_SpellKnownForSpontaneous = Resources.SpellTableBlueprints.MythicSpontaneousSpellsKnownTable
                    .ToReference<BlueprintSpellsTableReference>();
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
                    Resources.SpellbookBlueprints.SkaldSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.EldritchScionSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SageSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SorcererSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.CrossbloodedSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ArcanistSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.OracleSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.BardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ShamanSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ClericSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SorcererSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WizardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.DruidSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WitchSpellbook.ToReference<BlueprintSpellbookReference>(),
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.DemonSpellList.ToReference<BlueprintSpellListReference>();
                // TODO This is just there for compatibility with Owlcat new changes in 1.3. We are not using it yet, since we reverted to the old merging behavior
                bp.m_SpellKnownForSpontaneous = Resources.SpellTableBlueprints.MythicSpontaneousSpellsKnownTable
                    .ToReference<BlueprintSpellsTableReference>();
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
                    Resources.SpellbookBlueprints.WitchSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.EldritchScionSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SageSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SorcererSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.CrossbloodedSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ArcanistSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.OracleSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ShamanSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.ClericSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.SorcererSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.WizardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    Resources.SpellbookBlueprints.DruidSpellbook.ToReference<BlueprintSpellbookReference>(),
                };
                bp.m_MythicSpellList = Resources.SpellListBlueprints.TricksterSpellList.ToReference<BlueprintSpellListReference>();
                // TODO This is just there for compatibility with Owlcat new changes in 1.3. We are not using it yet, since we reverted to the old merging behavior
                bp.m_SpellKnownForSpontaneous = Resources.SpellTableBlueprints.MythicSpontaneousSpellsKnownTable
                    .ToReference<BlueprintSpellsTableReference>();
                bp.IsClassFeature = true;
            });
        }

    }
}