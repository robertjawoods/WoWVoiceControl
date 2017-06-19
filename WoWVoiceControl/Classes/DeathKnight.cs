using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWVoiceControl.Properties;

namespace WoWVoiceControl.Classes
{
    internal class DeathKnight : WoWClass
    {
        public DeathKnight() : base()
        {
            classAbilityNames = new[] { "Death Grip", "Death Strike", "Anti-Magic Shell", "Dark Command", "Wraith Walk", "Mind Freeze", "Icebound Fortitude", "Path of Frost", "Control Undead", "Raise Ally"};

            classSpecialisationAbilityNames.Add("Blood", new[] { "Asphyxiate", "Heart Strike", "Marrowrend", "Blood Boil", "Death and Decay", "Dancing Rune Weapon", "Vampiric Blood", "Death's Caress", "Gorefiend's Grasp"});
            classSpecialisationAbilityNames.Add("Frost", new[] { "Frost Strike", "Howling Blast", "Obliterate", "Empower Rune Weapon", "Pillar of Frost", "Remorseless Winter", "Chains of Ice" });
            classSpecialisationAbilityNames.Add("Unholy", new[] { "Death Coil", "Festering Strike", "Outbreak", "Raise Dead", "Death and Decay", "Chains of Ice", "Dark Transformation", "Summon Gargoyle", "Army of the Dead"});

            className = "Death Knight";

            ClassIcon = Resources.dk_icon;
        }
    }
}
