namespace FragmentJamella.Helpers
{
    public static class GameHelper
    {
        public const string CONNECTED_TO_AS_ADDRESS = "206F92F0";
        //This points to some player information. I dunno, I stole it from the player bar code. 
        public const string LOGGED_IN_OFFLINE_MODE = "20734740";
        public const int LUI_HEAP = 0x20100120;

        public enum CurrentElf
        {
            MAIN,
            OFFLINE,
            ONLINE,
            UNKNOWN
        };

        /// <summary>
        /// Retruns which fragment ELF is loaded based on where the Heap is initialized.
        /// </summary>
        /// <param name="heap_high"></param>
        /// <returns>CurrentElf enum value</returns>
        public static CurrentElf GetCurrentElfFile(int heap_high)
        {
            switch(heap_high)
            {
                //Heap is initialized at 0x00328B80
                case 0x33:
                    return CurrentElf.MAIN;
                //Heap is initialized at 0x00734A00
                case 0x73:
                    return CurrentElf.OFFLINE;
                //Heap is initialized at 0x0091D680
                case 0x92:
                    return CurrentElf.ONLINE;
                default:
                    return CurrentElf.UNKNOWN;
            }
        }

        //Address to global pointer for PLAYER instance, which should stay the same regardless to any file changes.
        public const int OFFLINE_PLAYER_POINTER = 0x2049d050;
        public const int ONLINE_PLAYER_POINTER = 0x20642780;

        public const int PLAYER_NAME = 0xC;
        public const int PLAYER_MODEL_STRING = 0x3C;

        public const int PLAYER_CHARACTER_CLASS = 0x3759;
        public const int PLAYER_CHARACTER_MODEL = 0x375A;
        public const int PLAYER_CHARACTER_COLOR = 0x375B;
        public const int PLAYER_CHARACTER_SIZE = 0x375C;

        public const int PLAYER_STATS_LEVEL = 0x87BA;
        public const int PLAYER_STATS_HP = 0x87D0;
        public const int PLAYER_STATS_SP = 0x87D2;
        public const int PLAYER_STATS_PATK = 0x87D4;
        public const int PLAYER_STATS_PDEF = 0x87D6;
        public const int PLAYER_STATS_PHIT = 0x87D8;
        public const int PLAYER_STATS_PEVA = 0x87DA;
        public const int PLAYER_STATS_MATK = 0x87DC;
        public const int PLAYER_STATS_MDEF = 0x87DE;
        public const int PLAYER_STATS_MHIT = 0x87E0;
        public const int PLAYER_STATS_MEVA = 0x87E2;
        public const int PLAYER_STATS_EARTH = 0x87E4;
        public const int PLAYER_STATS_WATER = 0x87E6;
        public const int PLAYER_STATS_FIRE = 0x87E8;
        public const int PLAYER_STATS_WOOD = 0x87EA;
        public const int PLAYER_STATS_THUNDER = 0x87EC;
        public const int PLAYER_STATS_DARK = 0x87EE;
        public const int PLAYER_STATS_MIND = 0x87F0;
        public const int PLAYER_STATS_BODY = 0x87F2;
        public const int PLAYER_STATS_CLASS = 0x8884;
    }
}
