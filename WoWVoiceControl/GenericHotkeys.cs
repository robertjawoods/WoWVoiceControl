using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace WoWVoiceControl
{
    public static class GenericHotkeys
    {
        public static Dictionary<string, string> GenericKeys = new Dictionary<string, string>();

        public static Choices GenerateGenericChoices()
        {
            Choices genericChoices = new Choices("Auto Aun", "Eat", "Target", "Mount");
            return genericChoices;
        }
    }
}
