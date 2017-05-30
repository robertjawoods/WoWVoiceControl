using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace WoWVoiceControl.Classes
{
    /// <summary>
    /// Base class for all different classes. 
    /// </summary>
    public class WoWClass
    {
        private Dictionary<string, string> classAbilityBindings;

        protected string className;
        public string ClassName => className; 

        public WoWClass()
        {
            classAbilityBindings = GenericHotkeys.GenericKeys;
        }

        public IReadOnlyDictionary<string, string> ClassAbilityBindings => classAbilityBindings;

        public IReadOnlyDictionary<string, string[]> ClassSpecialisationAbilityNames => classSpecialisationAbilityNames;

        public string[] ClassAbilityNames => classAbilityNames;

        public void AddHotKey(string abilityName, string hotKeyString)
        {
            try
            {
               classAbilityBindings.Add(abilityName, hotKeyString);
            }
            catch
            {
                SpeechSynthesizer errorSynth = new SpeechSynthesizer();
                errorSynth.SpeakAsync("ability already bound.");
            }
        }

        protected string[] classAbilityNames;

        protected Dictionary<string, string[]> classSpecialisationAbilityNames = new Dictionary<string, string[]>();

        public Grammar GenerateGrammar()
        {
            GrammarBuilder classGrammar = new GrammarBuilder();

            classGrammar.Append(new Choices(classAbilityNames), 0, 1);

            classGrammar.Append(GenericHotkeys.GenerateGenericChoices(), 0, 1);

            foreach (string[] spec in classSpecialisationAbilityNames.Values)
                classGrammar.Append(new Choices(spec), 0, 1);

            return new Grammar(classGrammar);
        }
    }
}
