using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWVoiceControl.Properties;

namespace WoWVoiceControl.Classes
{
    internal class Shaman : WoWClass
    {
        public Shaman() : base()
        {
            classAbilityNames = new[] { "Lightning Bolt", "Healing Surge", "Ancestral Spirit", "Ghost Wolf", "Wind Shear", "Water Walking", "Reincarnation", "Astral Recall", "Far Sight", "Hex", "Astral Shift", "Purge", "Heroism / Bloodlust" };

            classSpecialisationAbilityNames.Add("Elemental", new[] { "Earth Shock", "Flame Shock", "Lava Burst", "Thunderstorm", "Cleanse Spirit", "Frost Shock", "Chain Lightning", "Fire Elemental", "Earthquake Totem", "Earth Elemental" });
            classSpecialisationAbilityNames.Add("Enhancement", new[] {"Lava Lash", "Rockbiter",  "Flametongue", "Cleanse Spirit", "Frostbrand", "Stormstrike", "Crash Lightning", "Stormlash", "Feral Spirit", "Spirit Walk" });
            classSpecialisationAbilityNames.Add("Restoration", new[] { "Flame Shock", "Riptide", "Lava Burst", "Healing Stream Totem", "Purify Spirit", "Chain Heal", "Chain Lightning", "Ancestral Vision", "Healing Rain", "Healing Tide Totem", "Healing Wave", "Spirit Link Totem", "Spiritwalker's Grace"});

            ClassIcon = Resources.sham_icon;

            className = "Shaman";
        }
    }
}
