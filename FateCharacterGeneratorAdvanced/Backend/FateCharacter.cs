using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateCharacterGeneratorAdvanced.Backend
{
    [Serializable]
    class FateCharacter
    {
        public int MaxSkill { get; set; }
        public Dictionary<string, ushort> Skills { get; set; }
        public bool IsMale { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool LoadOnStart { get; set; }
        public string Description { get; set; }

        [NonSerialized]
        private bool _isSaved;
        public bool IsSaved
        {
            get { return _isSaved; }
            set { _isSaved = value; }
        }

        public static FateCharacter GetRandomChar(bool isMale, bool isFemale)
        {
            FateCharacter fc = new FateCharacter();
            if (isMale && isFemale || !isMale && !isFemale)
                fc.IsMale = FateCharacter.isRandomMale();
            else
                fc.IsMale = isMale ? true : false;

            fc.Name = FateCharacter.GetRandomName(fc.IsMale);
            fc.Skills = FateCharacter.GetRandomSkills(Resources.MaxSkill);
            fc.DateCreated = DateTime.Now;
            fc.LoadOnStart = false;
            return fc;
        }

        public static Dictionary<string, ushort> GetRandomSkills(uint maxskill)
        {
            Dictionary<string, ushort> result = new Dictionary<string, ushort>();
            for (int i = 1; i <= maxskill; i++)
            {
                int turns = (int)maxskill - i + 1;
                for (int h = 0; h < turns; h++)
                {
                    string skill = Resources.Skills[Resources.Rdm.Next(Resources.Skills.Length)];
                    if (result.ContainsKey(skill))
                    {
                        h -= 1;
                        continue;
                    }
                    result.Add(skill, (ushort)(maxskill - turns + 1));
                }
            }
            return result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private static bool isRandomMale()
        {
            if (Resources.Rdm.NextDouble() > 0.5)
                return true;
            return false;
        }

        public static string GetRandomName(bool isMale)
        {
            return string.Format("{0} {1}", FateCharacter.GetRandomForeName(isMale), FateCharacter.GetRandomSurName());
        }

        public static string GetRandomForeName(bool isMale)
        {
            if (isMale)
                return Resources.MaleForeNames[Resources.Rdm.Next(Resources.MaleForeNames.Length)];
            return Resources.FemaleForeNames[Resources.Rdm.Next(Resources.FemaleForeNames.Length)];
        }

        public static string GetRandomForeName(bool male, bool female)
        {
            if (male && female || !male && !female)
            {
                return FateCharacter.GetRandomForeName(FateCharacter.isRandomMale());
            }
            if (male)
                return Resources.MaleForeNames[Resources.Rdm.Next(Resources.MaleForeNames.Length)];
            return Resources.FemaleForeNames[Resources.Rdm.Next(Resources.FemaleForeNames.Length)];
        }

        public static string GetRandomSurName()
        {
            return Resources.SurNames[Resources.Rdm.Next(Resources.SurNames.Length)];
        }
    }
}
