using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using SpellbookMerge.Extensions;

namespace SpellbookMerge.Features
{
    internal static class AeonIncorporateSpellbook {
        public static void AddAeonIncorporateSpellbookFeature()
        {
            Resources.CreateBlueprint<BlueprintFeatureSelectMythicSpellbook>("AeonIncorporateSpellbook", bp => {
                var inquisitorSpellbook =
                    Resources.TryGetBlueprint<BlueprintSpellbook>("57fab75111f377248810ece84193a5a5");
                var aeonSpellList = Resources.TryGetBlueprint<BlueprintSpellList>("ca8c6024bd2519f4b97162a3ad286920");

                bp.SetName("Mythic Spellbook");
                bp.SetDescription("At 3rd rank, Aeon receives the ability to cast mythic {g|Encyclopedia:Spell}spells{/g}. He can either choose to take it as part of an existing Inquisitor spellbook, or as a standalone spellbook.");
                
                bp.m_AllowedSpellbooks = new[] { inquisitorSpellbook.ToReference<BlueprintSpellbookReference>() };
                bp.m_MythicSpellList = aeonSpellList.ToReference<BlueprintSpellListReference>();
                bp.IsClassFeature = true;
            });
        }
    }
}