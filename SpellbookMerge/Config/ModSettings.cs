namespace SpellbookMerge.Config
{
    public class ModSettings : IOverridable
    {
        public Blueprints Blueprints { get; private set; } = Blueprints.FromEmbeddedResource();
        public MergeableSpellbooks MergeableSpellbooks { get; private set; } = MergeableSpellbooks.FromEmbeddedResource();

        public void OverrideFrom(string userConfigDir)
        {
            Blueprints.OverrideFrom(userConfigDir);
            MergeableSpellbooks.OverrideFrom(userConfigDir);
        }

        public void SaveTo(string userConfigDir)
        {
            Blueprints.SaveTo(userConfigDir);
            MergeableSpellbooks.SaveTo(userConfigDir);
        }
    }
}