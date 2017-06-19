using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWVoiceControl.Classes
{
    internal class Druid : WoWClass
    {
        public Druid() : base()
        {
            classAbilityNames = new[] { "Moonfire", "Regrowth", "Cat Form", "Dash", "Bear Form", "Growl", "Revive", "Teleport: Moonglade", "Prowl", "Travel Form", "Entangling Roots", "Rebirth" };

            classSpecialisationAbilityNames.Add("Balance", new[] { "" });

        }
    }
}
