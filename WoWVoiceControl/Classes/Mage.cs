using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWVoiceControl.Properties;

namespace WoWVoiceControl.Classes
{
    internal class Mage : WoWClass
    {
        public Mage() : base()
        {
            ClassIcon = Resources.m_icon;

            classAbilityNames = new[] { "Frost Nova", "Blink", "Polymorph", "Conjure Refreshment", "Ice Block", "Counterspell", "Slow Fall", "Spellsteal", "Time Warp", "Invisibility" };

            classSpecialisationAbilityNames.Add("Frost", new[] { "Ice Lance", "Frostbolt", "Summon Water Elemental", "Blizzard", "Flurry", "Ice Barrier", "Brain Freeze", "Cone of Cold", "Icy Veins", "Cold Snap", "Frozen Orb"});
            classSpecialisationAbilityNames.Add("Fire", new[] { "Fireball", "Pyroblast", "Scorch", "Flamestrike", "Blazing Barrier", "Dragon's Breath", "Combustion", "Fire Blast" } );
            classSpecialisationAbilityNames.Add("Arcane", new[] { "Arcane Barrage", "Arcane Blast", "Arcane Missiles", "Arcane Explosion", "Evocation", "Prismatic Barrier", "Slow", "Arcane Power", "Displacement", "Presence of Mind", "Greater Invisibility" });

            className = "Mage";
        }
    }
}
