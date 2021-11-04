using System;
using System.IO;
using HarmonyLib;
using Kingmaker;
using Kingmaker.Blueprints.JsonSystem;
using UnityModManagerNet;
using SpellbookMerge.Config;

namespace SpellbookMerge
{
    public static class Main
    {       
        public static bool Enabled { get; private set; }
        private static UnityModManager.ModEntry? ModEntry { get; set; }
        public static ModSettings ModSettings { get; } = new ModSettings();

        public static string? UserConfigDir { get; private set; }
        
        // ReSharper disable once UnusedMember.Local
        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            ModEntry = modEntry;
            UserConfigDir = ModEntry.Path + "UserSettings";
            Directory.CreateDirectory(UserConfigDir);
            ModSettings.OverrideFrom(UserConfigDir);
            ModEntry.OnToggle = OnToggle;
            var harmony = new Harmony(ModEntry.Info.Id);
            harmony.PatchAll();
            return true;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Enabled = value;
            return true;
        }
        
        public static void Log(string msg) {
            ModEntry!.Logger.Log(msg);
        }
        
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(string msg) {
            ModEntry!.Logger.Log(msg);
        }
        
        public static void LogPatch(string action, IScriptableObjectWithAssetId bp) {
            Log($"{action}: {bp.AssetGuid} - {bp.name}");
        }
        
        public static void LogHeader(string msg) {
            Log($"--{msg.ToUpper()}--");
        }

        public static void LogException(Exception e, string message) {
            Log(message);
            Log(e.ToString());
            PFLog.Mods.Error(message);
        }
        
        public static void LogError(string message) {
            Log(message);
            PFLog.Mods.Error(message);
        }
    }
}