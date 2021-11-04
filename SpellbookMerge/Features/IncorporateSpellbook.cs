using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using SpellbookMerge.Extensions;

namespace SpellbookMerge.Features
{
    internal static class IncorporateSpellbook {
        public static void AddAeonIncorporateSpellbookFeature()
        {
            Resources.CreateBlueprint<BlueprintFeatureSelectMythicSpellbook>("AeonIncorporateSpellbook", bp => {
                var inquisitorSpellbook =
                    Resources.TryGetBlueprint<BlueprintSpellbook>("57fab75111f377248810ece84193a5a5");
                var warPriestSpellbook =
                    Resources.TryGetBlueprint<BlueprintSpellbook>("7d7d51be2948d2544b3c2e1596fd7603");
                var aeonSpellList = Resources.TryGetBlueprint<BlueprintSpellList>("ca8c6024bd2519f4b97162a3ad286920");

                bp.SetName("Mythic Spellbook");
                bp.SetDescription("At 3rd rank, Aeon receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. He can either choose to take it as part of an existing hybrid divine caster spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    inquisitorSpellbook.ToReference<BlueprintSpellbookReference>(),
                    warPriestSpellbook.ToReference<BlueprintSpellbookReference>()
                };
                bp.m_MythicSpellList = aeonSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }
        
        public static void AddAzataIncorporateSpellbookFeature()
        {
            Resources.CreateBlueprint<BlueprintFeatureSelectMythicSpellbook>("AzataIncorporateSpellbook", bp => {
                var magusSpellbook =
                    Resources.TryGetBlueprint<BlueprintSpellbook>("5d8d04e76dff6c5439de99af0d57be63");
                var bardSpellbook =
                    Resources.TryGetBlueprint<BlueprintSpellbook>("bc04fc157a8801d41b877ad0d9af03dd");
                var skaldSpellbook =
                    Resources.TryGetBlueprint<BlueprintSpellbook>("8f159d2f22ced074ea32995eb5a446a0");
                var azataSpellList = Resources.TryGetBlueprint<BlueprintSpellList>("ca8c6024bd2519f4b97162a3ad286920");

                bp.SetName("Mythic Spellbook");
                bp.SetDescription("At 3rd rank, Azata receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. They can either choose to take it as part of an existing hybrid arcane caster spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[]
                {
                    magusSpellbook.ToReference<BlueprintSpellbookReference>(),
                    bardSpellbook.ToReference<BlueprintSpellbookReference>(),
                    skaldSpellbook.ToReference<BlueprintSpellbookReference>()
                };
                bp.m_MythicSpellList = azataSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }
    }
}