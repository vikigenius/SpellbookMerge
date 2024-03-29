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
    }
}