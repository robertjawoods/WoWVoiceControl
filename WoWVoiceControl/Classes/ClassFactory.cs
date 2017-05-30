namespace WoWVoiceControl.Classes
{

    public enum Classes
    {
        Warrior,
        Shaman,
        DemonHunter,
        Warlock,
        Priest,
        Mage,
        Paladin,
        DeathKnight,
        Monk,
        Druid
    }

    static class ClassFactory
    {
        public static WoWClass GetClass(Classes @class)
        {
            switch (@class)
            {
                case Classes.DemonHunter:
                    return new DemonHunter();

                case Classes.Warlock:
                    return new Warlock();

                default:
                    return null;
            }
        }
    }
}
