namespace FragmentJamella.Helpers
{
    public static class GameHelper
    {
        public const string CONNECTED_TO_AS_ADDRESS = "206F92F0";
        //This points to some player information. I dunno, I stole it from the player bar code. 
        public const string LOGGED_IN_OFFLINE_MODE = "20734740";
        public const string LUI_HEAP = "20100120";

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
        public const string OFFLINE_PLAYER_POINTER = "2049d050";
        public const string ONLINE_PLAYER_POINTER = "20642780";

        public const string PLAYER_NAME = "C";
        public const string PLAYER_MODEL_STRING = "3C";

        public const string PLAYER_CHARACTER_CLASS = "3759";
        public const string PLAYER_CHARACTER_MODEL = "375A";
        public const string PLAYER_CHARACTER_COLOR = "375B";
        public const string PLAYER_CHARACTER_SIZE = "375C";

        public const string PLAYER_STATS_LEVEL = "87BA";
        public const string PLAYER_STATS_HP = "87D0";
        public const string PLAYER_STATS_SP = "87D2";
        public const string PLAYER_STATS_PATK = "87D4";
        public const string PLAYER_STATS_PDEF = "87D6";
        public const string PLAYER_STATS_PHIT = "87D8";
        public const string PLAYER_STATS_PEVA = "87DA";
        public const string PLAYER_STATS_MATK = "87DC";
        public const string PLAYER_STATS_MDEF = "87DE";
        public const string PLAYER_STATS_MHIT = "87E0";
        public const string PLAYER_STATS_MEVA = "87E2";
        public const string PLAYER_STATS_EARTH = "87E4";
        public const string PLAYER_STATS_WATER = "87E6";
        public const string PLAYER_STATS_FIRE = "87E8";
        public const string PLAYER_STATS_WOOD = "87EA";
        public const string PLAYER_STATS_THUNDER = "87EC";
        public const string PLAYER_STATS_DARK = "87EE";
        public const string PLAYER_STATS_MIND = "87F0";
        public const string PLAYER_STATS_BODY = "87F2";
        public const string PLAYER_STATS_CLASS = "8884";
    }
}
