namespace SpellbookMerge.Config
{
    public class ModSettings : IOverridable
    {
        public Blueprints Blueprints { get; private set; } = Blueprints.FromEmbeddedResource();
        public PatchSettings PatchSettings { get; private set; } = PatchSettings.FromEmbeddedResource();
        
        public void OverrideFrom(string userConfigDir)
        {
            Blueprints.OverrideFrom(userConfigDir);
            PatchSettings.OverrideFrom(userConfigDir);
        }

        public void SaveTo(string userConfigDir)
        {
            Blueprints.SaveTo(userConfigDir);
            PatchSettings.SaveTo(userConfigDir);
        }
    }
}