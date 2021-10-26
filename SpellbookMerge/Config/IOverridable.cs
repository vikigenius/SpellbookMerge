namespace SpellbookMerge.Config
{
    public interface IOverridable
    {
        public void OverrideFrom(string userConfigDir);
        public void SaveTo(string userConfigDir);
    }
}