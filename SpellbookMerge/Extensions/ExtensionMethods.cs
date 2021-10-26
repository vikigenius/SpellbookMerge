using System;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Localization;
using SpellbookMerge.Utilities;

namespace SpellbookMerge.Extensions
{
    public static class ExtensionMethods
    {
        public static void SetName(this BlueprintUnitFact feature, String name) {
            feature.m_DisplayName = Resources.CreateString(feature.name + ".Name", name);
        }
        
        public static void SetDescription(this BlueprintUnitFact feature, LocalizedString description) {
            feature.m_Description = description;
        }
        
        public static void SetDescription(this BlueprintUnitFact feature, String description) {
            var taggedDescription = DescriptionTools.TagEncyclopediaEntries(description);
            feature.m_Description = Resources.CreateString(feature.name + ".Description", taggedDescription);
        }
    }
}