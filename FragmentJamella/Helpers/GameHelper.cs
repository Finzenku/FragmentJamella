using System.Collections.Generic;

namespace FragmentJamella
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
        
    }
}
