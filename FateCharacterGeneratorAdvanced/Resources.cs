using FateCharacterGeneratorAdvanced.Backend;
using System;

namespace FateCharacterGeneratorAdvanced
{
    static class Resources
    {
        public readonly static string GfxPath = Environment.CurrentDirectory + @"\gfx\";
        public readonly static string SavePath = Environment.CurrentDirectory + @"\saves\";
        public readonly static uint MaxSkill = 4;
        public readonly static Random Rdm = new Random();
        public readonly static string[] FemaleForeNames = ConfigReader.readConfigFiles(ConfigFileTypes.femaleforenames);
        public readonly static string[] MaleForeNames = ConfigReader.readConfigFiles(ConfigFileTypes.maleforenames);
        public readonly static string[] SurNames = ConfigReader.readConfigFiles(ConfigFileTypes.surnames);
        public readonly static string[] Skills = ConfigReader.readConfigFiles(ConfigFileTypes.skills);
    }
}
