namespace WoWVoiceControl.Classes
{
    public class DemonHunter : WoWClass
    {
        public DemonHunter() : base()
        {
            classAbilityNames = new[] { "Consume Magic", "Glide", "Imprison", "Metamorphosis", "Spectral Sight", "Throw Glaive" };

            classSpecialisationAbilityNames.Add("Vengeance", new[] { "Soul Barrier", "Fel Devastation", "Spirit Bomb", "Fel Eruption", "Sigil of Chains", "Sigil of Misery", "Fracture", "Felblade", "Sigil of Silence", "Demon Spikes", "Fiery Brand", "Shear", "Sigil of Flame", "Soul Cleave", "Immolation Aura" });
            classSpecialisationAbilityNames.Add("Havoc", new[] { "Fel Barrage", "Fel Eruption", "Nemesis", "Netherwalk", "Chaos Strike", "Felblade", "Blade Dance", "Blur", "Chaos Nova", "Eye Beam", "Fel Rush", "Soul Carver", "Vengeful Retreat", "Fury of the Illidari", "Demon's Bite" });

            className = "Demon Hunter";
        }
    }
}
