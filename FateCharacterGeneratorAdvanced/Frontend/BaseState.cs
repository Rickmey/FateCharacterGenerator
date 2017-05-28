using FateCharacterGeneratorAdvanced.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FateCharacterGeneratorAdvanced.Frontend
{
    class BaseState
    {
        private static BaseState instance;
        public static BaseState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaseState();
                }
                return instance;
            }
        }

        public bool isFemale { get; set; }
        public bool isMale { get; set; }
        public Dictionary<TabPage, FateCharacter> CharacterMap { get; set; }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public BaseState()
        {
            this.isFemale = true;
            this.isMale = true;
            this.CharacterMap = new Dictionary<TabPage, FateCharacter>();
            this.MinValue = 0;
            this.MaxValue = 1;
        }
    }
}
