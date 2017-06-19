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
        Druid, 
        Rogue
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

                case Classes.DeathKnight:
                    return new DeathKnight();

                case Classes.Mage:
                    return new Mage();

                case Classes.Druid:
                    return new Druid();

                case Classes.Monk:
                    return new Monk();

                case Classes.Paladin:
                    return new Paladin();

                case Classes.Shaman:
                    return new Shaman();

                case Classes.Warrior:
                    return new Warrior();

                case Classes.Rogue:
                    return new Rogue();

                case Classes.Priest:
                    return new Priest();

                default:
                    return null;
            }
        }
    }
}
