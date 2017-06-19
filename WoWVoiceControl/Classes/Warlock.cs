using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWVoiceControl.Properties;

namespace WoWVoiceControl.Classes
{
    class Warlock : WoWClass
    {
        public Warlock() : base()
        {
            classAbilityNames = new[] { "Drain Life", "Summon Imp", "Soul Leech", "Create Healthstone", "Summon Voidwalker", "Fear", "Soulstone", "Health Funnel", "Eye of Kilrogg", "Unending Breath", "Summon Succubus", "Command Demon", "Banish", "Life Tap", "Summon Felhunter", "Summon Infernal", "Enslave Demon", "Summon Doomguard", "Unending Resolve", "Create Soulwell", "Ritual of Summoning", "Demonic Gateway", "Mortal Coil", "Demonic Circle", "Shadowfury", "Soul Harvest", "Soul Conduit", "Burning Rush", "Dark Pact" };

            classSpecialisationAbilityNames.Add("Affliction", new[] { "Corruption", "Agony", "Unstable Affliction", "Drain Soul", "Seed of Corruption", "Haunt", "Howl of Terror", "Siphon Life", "Grimoire of Sacrifice", "Soul Effigy", "Phantom Singularity" });
            classSpecialisationAbilityNames.Add("Demonology", new[] { "Shadow Bolt", "Hand of Gul'Dan", "Demonic Empowerment", "Call Dreadstalkers", "Doom", "Demonwrath", "Summon Felguard", "Shadowflame", "Implosion", "Summon Darkglare", "Demonbolt" });
            classSpecialisationAbilityNames.Add("Destruction", new[] { "Immolate", "Incinerate", "Conflagrate", "Chaos Bolt", "Rain of Fire", "Havoc" });

            ClassIcon = Resources.lock_icon;

            className = "Warlock";
        }
    }
}
