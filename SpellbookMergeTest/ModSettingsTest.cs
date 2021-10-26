using SpellbookMerge.Config;
using Xunit;

namespace SpellbookMergeTest
{
    public class ModSettingsTest
    {
        [Fact]
        public void BlueprintsTest()
        {
            var blueprints = Blueprints.FromEmbeddedResource();
            Assert.NotNull(blueprints);
            Assert.NotEmpty(blueprints.NewBlueprints);
        }
        
        [Fact]
        public void MergeableSpellbooksTest()
        {
            var spellbooks = MergeableSpellbooks.FromEmbeddedResource();
            Assert.NotNull(spellbooks);
            Assert.True(spellbooks?.Aeon!.ShouldMerge);
            Assert.True(spellbooks?.Aeon!.Inquisitor!.ShouldMerge);
        }
    }
}