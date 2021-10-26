using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace SpellbookMerge.Utilities
{
    internal static class DescriptionTools {
        private static readonly EncyclopediaEntry[] EncyclopediaEntries = new EncyclopediaEntry[] {
            new()
            {
                Entry = "Spells",
                Patterns = { "Spells?" }
            },
        };

        public static string TagEncyclopediaEntries(string description) {
            var result = description;
            result = result.StripHTML();
            return EncyclopediaEntries.Aggregate(result,
                (current1, entry) =>
                    entry.Patterns.Aggregate(current1, (current, pattern) => current.ApplyTags(pattern, entry)));
        }

        private class EncyclopediaEntry {
            public string Entry = "";
            public List<string> Patterns = new List<string>();

            public string Tag(string keyword) {
                return $"{{g|Encyclopedia:{Entry}}}{keyword}{{/g}}";
            }
        }

        private static string ApplyTags(this string str, string from, EncyclopediaEntry entry) {
            var pattern = from.EnforceSolo().ExcludeTagged();
            var matches = Regex.Matches(str, pattern, RegexOptions.IgnoreCase)
                .OfType<Match>()
                .Select(m => m.Value)
                .Distinct();
            return matches.Aggregate(str,
                (current, match) => Regex.Replace(current, Regex.Escape(match).EnforceSolo().ExcludeTagged(),
                    entry.Tag(match), RegexOptions.IgnoreCase));
        }
        private static string StripHTML(this string str) {
            return Regex.Replace(str, "<.*?>", string.Empty);
        }
        private static string ExcludeTagged(this string str) {
            return $"{@"(?<!{g\|Encyclopedia:\w+}[^}]*)"}{str}{@"(?![^{]*{\/g})"}";
        }
        private static string EnforceSolo(this string str) {
            return $"{@"(?<![\w>]+)"}{str}{@"(?![^\s\.,""'<)]+)"}";
        }
    }
}