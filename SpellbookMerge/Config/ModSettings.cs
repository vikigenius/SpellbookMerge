namespace SpellbookMerge.Config
{
    public class ModSettings : IOverridable
    {
        public Blueprints Blueprints { get; private set; } = Blueprints.FromEmbeddedResource();

        public void OverrideFrom(string userConfigDir)
        {
            Blueprints.OverrideFrom(userConfigDir);
        }

        public void SaveTo(string userConfigDir)
        {
            Blueprints.SaveTo(userConfigDir);
        }
    }
}