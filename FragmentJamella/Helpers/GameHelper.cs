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

        //These are all based of PLAYER pointer, original online versions are left in comments.
        //Type IDs 0 - 2
        //L1
        public const string SHORTCUT_L1_CIRCLE_TYPE_ID = "2890"; //"20C403C0";
        public const string SHORTCUT_L1_TRIANGLE_TYPE_ID = "2891"; //"20C403C1";
        public const string SHORTCUT_L1_SQUARE_TYPE_ID = "2892"; //"20C403C2";
        public const string SHORTCUT_L1_X_TYPE_ID = "2893"; //"20C403C3";

        public const string SHORTCUT_R1_CIRCLE_TYPE_ID = "2894"; //"20C403C4";
        public const string SHORTCUT_R1_TRIANGLE_TYPE_ID = "2895"; //"20C403C5";
        public const string SHORTCUT_R1_SQUARE_TYPE_ID = "2896"; //"20C403C6";
        public const string SHORTCUT_R1_X_TYPE_ID = "2897"; //"20C403C7";

        public const string SHORTCUT_L2_CIRCLE_TYPE_ID = "2898"; //"20C403C8";
        public const string SHORTCUT_L2_TRIANGLE_TYPE_ID = "2899"; //"20C403C9";
        public const string SHORTCUT_L2_SQUARE_TYPE_ID = "289a"; //"20C403CA";
        public const string SHORTCUT_L2_X_TYPE_ID = "289B"; //"20C403CB";

        public const string SHORTCUT_R2_CIRCLE_TYPE_ID = "289C"; //"20C403CC";
        public const string SHORTCUT_R2_TRIANGLE_TYPE_ID = "289D"; //"20C403CD";
        public const string SHORTCUT_R2_SQUARE_TYPE_ID = "289E"; //"20C403CE";
        public const string SHORTCUT_R2_X_TYPE_ID = "289F"; //"20C403CF";

        //Category IDs A - C
        public const string SHORTCUT_L1_CIRCLE_CATEGORY_ID = "28A0"; //"20C403D0";
        public const string SHORTCUT_L1_TRIANGLE_CATEGORY_ID = "28A2"; //"20C403D2";
        public const string SHORTCUT_L1_SQUARE_CATEGORY_ID = "28A4"; //"20C403D4";
        public const string SHORTCUT_L1_X_CATEGORY_ID = "28A6"; //"20C403D6";

        public const string SHORTCUT_R1_CIRCLE_CATEGORY_ID = "28A8"; //"20C403D8";
        public const string SHORTCUT_R1_TRIANGLE_CATEGORY_ID = "28AA"; //"20C403DA";
        public const string SHORTCUT_R1_SQUARE_CATEGORY_ID = "28AC"; //"20C403DC";
        public const string SHORTCUT_R1_X_CATEGORY_ID = "28AE"; //"20C403DE";

        public const string SHORTCUT_L2_CIRCLE_CATEGORY_ID = "28B0"; //"20C403E0";
        public const string SHORTCUT_L2_TRIANGLE_CATEGORY_ID = "28B2"; //"20C403E2";
        public const string SHORTCUT_L2_SQUARE_CATEGORY_ID = "28B4"; //"20C403E4";
        public const string SHORTCUT_L2_X_CATEGORY_ID = "28B6"; //"20C403E6";

        public const string SHORTCUT_R2_CIRCLE_CATEGORY_ID = "28B8"; //"20C403E8";
        public const string SHORTCUT_R2_TRIANGLE_CATEGORY_ID = "28BA"; //"20C403EA";
        public const string SHORTCUT_R2_SQUARE_CATEGORY_ID = "28BC"; //"20C403EC";
        public const string SHORTCUT_R2_X_CATEGORY_ID = "28BE"; //"20C403EE";

        //Short Cut IDs
        public const string SHORTCUT_L1_CIRCLE_ID = "28C0"; //"20C403F0";
        public const string SHORTCUT_L1_TRIANGLE_ID = "28C2"; //"20C403F2";
        public const string SHORTCUT_L1_SQUARE_ID = "28C4"; //"20C403F4";
        public const string SHORTCUT_L1_X_ID = "28C6"; //"20C403F6";

        public const string SHORTCUT_R1_CIRCLE_ID = "28C8"; //"20C403F8";
        public const string SHORTCUT_R1_TRIANGLE_ID = "28CA"; //"20C403FA";
        public const string SHORTCUT_R1_SQUARE_ID = "28CC"; //"20C403FC";
        public const string SHORTCUT_R1_X_ID = "28CE"; //"20C403FE";

        public const string SHORTCUT_L2_CIRCLE_ID = "28D0"; //"20C40400";
        public const string SHORTCUT_L2_TRIANGLE_ID = "28D2"; //"20C40402";
        public const string SHORTCUT_L2_SQUARE_ID = "28D4"; //"20C40404";
        public const string SHORTCUT_L2_X_ID = "28D6"; //"20C40406";

        public const string SHORTCUT_R2_CIRCLE_ID = "28D8"; //"20C40408";
        public const string SHORTCUT_R2_TRIANGLE_ID = "28DA"; //"20C4040A";
        public const string SHORTCUT_R2_SQUARE_ID = "28DC"; //"20C4040C";
        public const string SHORTCUT_R2_X_ID = "28DE"; //"20C4040E";

        //Message Locations
        public const string SHORTCUT_L1_CIRCLE_MESSAGE = "28E0"; //"20C40410";
        public const string SHORTCUT_L1_TRIANGLE_MESSAGE = "2901"; //"20C40431";
        public const string SHORTCUT_L1_SQUARE_MESSAGE = "2922"; //"20C40452";
        public const string SHORTCUT_L1_X_MESSAGE = "2943"; //"20C40473";

        public const string SHORTCUT_R1_CIRCLE_MESSAGE = "2964"; //"20C40494";
        public const string SHORTCUT_R1_TRIANGLE_MESSAGE = "2985"; //"20C404B5";
        public const string SHORTCUT_R1_SQUARE_MESSAGE = "29A6"; //"20C404D6";
        public const string SHORTCUT_R1_X_MESSAGE = "29C7"; //"20C404F7";

        public const string SHORTCUT_L2_CIRCLE_MESSAGE = "29E8"; //"20C40518";
        public const string SHORTCUT_L2_TRIANGLE_MESSAGE = "2A09"; //"20C40539";
        public const string SHORTCUT_L2_SQUARE_MESSAGE = "2A2A"; //"20C4055A";
        public const string SHORTCUT_L2_X_MESSAGE = "2A4B"; //"20C4057B";

        public const string SHORTCUT_R2_CIRCLE_MESSAGE = "2A6C"; //"20C4059C";
        public const string SHORTCUT_R2_TRIANGLE_MESSAGE = "2A8D"; //"20C405BD";
        public const string SHORTCUT_R2_SQUARE_MESSAGE = "2AAE"; //"20C405DE";
        public const string SHORTCUT_R2_X_MESSAGE = "2ACF"; //"20C405FF";

        // Short cut notes
        // Each button combo has the following info:
        // Category ID 0 = Message, 1 = Spell, 2 = Item
        // Spell / Item ID
        // If Category ID = 0 Then we load the message that is below the spell / item IDS

        public static List<ShortCutIDModel> ShortCutIdData = new List<ShortCutIDModel>()
        {
            { new ShortCutIDModel("0000",1,"0","N/A")},
            { new ShortCutIDModel("0001",1,"0","Normal Attack")},
            { new ShortCutIDModel("0002",1,"0","Data Drain")},
            { new ShortCutIDModel("0003",1,"0","Data Arc")},
            { new ShortCutIDModel("0004",1,"0","2128 Drain")},
            { new ShortCutIDModel("0005",1,"0","Drain Heart")},
            { new ShortCutIDModel("0006",1,"0","Saber Dance")},
            { new ShortCutIDModel("0007",1,"0","Tiger Claws")},
            { new ShortCutIDModel("0008",1,"0","Staccatto")},
            { new ShortCutIDModel("0009",1,"0","Flame Dance")},
            { new ShortCutIDModel("000A",1,"0","Blazing Wheel")},
            { new ShortCutIDModel("000B",1,"0","Twin Dragons")},
            { new ShortCutIDModel("000C",1,"0","Red Flame")},
            { new ShortCutIDModel("000D",1,"0","Flame Vortex")},
            { new ShortCutIDModel("000E",1,"0","Dragon Rage")},
            { new ShortCutIDModel("000F",1,"0","Orchid Dance")},
            { new ShortCutIDModel("0010",1,"0","Splinter Splash")},
            { new ShortCutIDModel("0011",1,"0","Gale of Swords")},
            { new ShortCutIDModel("0012",1,"0","Orchid Strike")},
            { new ShortCutIDModel("0013",1,"0","Wildflower")},
            { new ShortCutIDModel("0014",1,"0","Typhoon Blade")},
            { new ShortCutIDModel("0015",1,"0","Thunder Dance")},
            { new ShortCutIDModel("0016",1,"0","Thunder Coil")},
            { new ShortCutIDModel("0017",1,"0","Lightning Rage")},
            { new ShortCutIDModel("0018",1,"0","Storm Strike")},
            { new ShortCutIDModel("0019",1,"0","Tempest Strike")},
            { new ShortCutIDModel("001A",1,"0","Storm Rage")},
            { new ShortCutIDModel("001B",1,"0","Dark Dance")},
            { new ShortCutIDModel("001C",1,"0","Swirling Dark")},
            { new ShortCutIDModel("001D",1,"0","Twin Darkness")},
            { new ShortCutIDModel("001E",1,"0","Darkness Slash")},
            { new ShortCutIDModel("001F",1,"0","Terror Cyclone")},
            { new ShortCutIDModel("0020",1,"0","Evil Twin")},
            { new ShortCutIDModel("0021",1,"0","Cross Slash")},
            { new ShortCutIDModel("0022",1,"0","Crack Beat")},
            { new ShortCutIDModel("0023",1,"0","Revolver")},
            { new ShortCutIDModel("0024",1,"0","Gan Slash")},
            { new ShortCutIDModel("0025",1,"0","Gan Crack")},
            { new ShortCutIDModel("0026",1,"0","Gan Revolver")},
            { new ShortCutIDModel("0027",1,"0","GiGan Slash")},
            { new ShortCutIDModel("0028",1,"0","GiGan Crack")},
            { new ShortCutIDModel("0029",1,"0","Ganz Spiral")},
            { new ShortCutIDModel("002A",1,"0","Rue Slash")},
            { new ShortCutIDModel("002B",1,"0","Rue Crack")},
            { new ShortCutIDModel("002C",1,"0","Rue Revolver")},
            { new ShortCutIDModel("002D",1,"0","GiRue Slash")},
            { new ShortCutIDModel("002E",1,"0","GiRue Crack")},
            { new ShortCutIDModel("002F",1,"0","Ruem Spiral")},
            { new ShortCutIDModel("0030",1,"0","Vak Slash")},
            { new ShortCutIDModel("0031",1,"0","Vak Crack")},
            { new ShortCutIDModel("0032",1,"0","Vak Revolver")},
            { new ShortCutIDModel("0033",1,"0","GiVak Slash")},
            { new ShortCutIDModel("0034",1,"0","GiVak Crack")},
            { new ShortCutIDModel("0035",1,"0","Vakz Spiral")},
            { new ShortCutIDModel("0036",1,"0","Ani Slash")},
            { new ShortCutIDModel("0037",1,"0","Ani Crack")},
            { new ShortCutIDModel("0038",1,"0","Ani Revolver")},
            { new ShortCutIDModel("0039",1,"0","GiAni Slash")},
            { new ShortCutIDModel("003A",1,"0","GiAni Crack")},
            { new ShortCutIDModel("003B",1,"0","Anid Spiral")},
            { new ShortCutIDModel("003C",1,"0","Death Bringer")},
            { new ShortCutIDModel("003D",1,"0","Hayabusa")},
            { new ShortCutIDModel("003E",1,"0","Calamity")},
            { new ShortCutIDModel("003F",1,"0","Sohgasho")},
            { new ShortCutIDModel("0040",1,"0","Gan Smash")},
            { new ShortCutIDModel("0041",1,"0","Danku")},
            { new ShortCutIDModel("0042",1,"0","Gan Drive")},
            { new ShortCutIDModel("0043",1,"0","Gohryu")},
            { new ShortCutIDModel("0044",1,"0","Gan Divider")},
            { new ShortCutIDModel("0045",1,"0","Kyokushin")},
            { new ShortCutIDModel("0046",1,"0","Ganz Maxima")},
            { new ShortCutIDModel("0047",1,"0","Gohrai")},
            { new ShortCutIDModel("0048",1,"0","Vak Smash")},
            { new ShortCutIDModel("0049",1,"0","Karin")},
            { new ShortCutIDModel("004A",1,"0","Vak Drive")},
            { new ShortCutIDModel("004B",1,"0","Kannon")},
            { new ShortCutIDModel("004C",1,"0","Vak Divider")},
            { new ShortCutIDModel("004D",1,"0","Ohka")},
            { new ShortCutIDModel("004E",1,"0","Vak Maxima")},
            { new ShortCutIDModel("004F",1,"0","Garekka")},
            { new ShortCutIDModel("0050",1,"0","Juk Smash")},
            { new ShortCutIDModel("0051",1,"0","Hirameki")},
            { new ShortCutIDModel("0052",1,"0","Juk Drive")},
            { new ShortCutIDModel("0053",1,"0","Kitsutsuki")},
            { new ShortCutIDModel("0054",1,"0","Juk Divider")},
            { new ShortCutIDModel("0055",1,"0","Karatakewari")},
            { new ShortCutIDModel("0056",1,"0","Juka Maxima")},
            { new ShortCutIDModel("0057",1,"0","Kamikusabi")},
            { new ShortCutIDModel("0058",1,"0","Rai Smash")},
            { new ShortCutIDModel("0059",1,"0","Raika")},
            { new ShortCutIDModel("005A",1,"0","Rai Drive")},
            { new ShortCutIDModel("005B",1,"0","Rairaku")},
            { new ShortCutIDModel("005C",1,"0","Rai Divider")},
            { new ShortCutIDModel("005D",1,"0","Murakumo")},
            { new ShortCutIDModel("005E",1,"0","Raio Maxima")},
            { new ShortCutIDModel("005F",1,"0","Unyo no Tachi")},
            { new ShortCutIDModel("0060",1,"0","Axel Pain")},
            { new ShortCutIDModel("0061",1,"0","Triple Wield")},
            { new ShortCutIDModel("0062",1,"0","Brandish")},
            { new ShortCutIDModel("0063",1,"0","Gan Break")},
            { new ShortCutIDModel("0064",1,"0","Gan Tornado")},
            { new ShortCutIDModel("0065",1,"0","Gan Basher")},
            { new ShortCutIDModel("0066",1,"0","GiGan Break")},
            { new ShortCutIDModel("0067",1,"0","GiGan Rampage")},
            { new ShortCutIDModel("0068",1,"0","Ganz Punish")},
            { new ShortCutIDModel("0069",1,"0","Rue Break")},
            { new ShortCutIDModel("006A",1,"0","Rue Tornado")},
            { new ShortCutIDModel("006B",1,"0","Rue Basher")},
            { new ShortCutIDModel("006C",1,"0","GiRue Break")},
            { new ShortCutIDModel("006D",1,"0","GiRue Rampage")},
            { new ShortCutIDModel("006E",1,"0","Ruem Punish")},
            { new ShortCutIDModel("006F",1,"0","Rai Break")},
            { new ShortCutIDModel("0070",1,"0","Rai Tornado")},
            { new ShortCutIDModel("0071",1,"0","Rai Basher")},
            { new ShortCutIDModel("0072",1,"0","GiRai Break")},
            { new ShortCutIDModel("0073",1,"0","GiRai Rampage")},
            { new ShortCutIDModel("0074",1,"0","Raio Punish")},
            { new ShortCutIDModel("0075",1,"0","Ani Break")},
            { new ShortCutIDModel("0076",1,"0","Ani Tornado")},
            { new ShortCutIDModel("0077",1,"0","Ani Basher")},
            { new ShortCutIDModel("0078",1,"0","GiAni Break")},
            { new ShortCutIDModel("0079",1,"0","GiAni Rampage")},
            { new ShortCutIDModel("007A",1,"0","Anid Punish")},
            { new ShortCutIDModel("007B",1,"0","Triple Doom")},
            { new ShortCutIDModel("007C",1,"0","Repulse Cage")},
            { new ShortCutIDModel("007D",1,"0","Double Sweep")},
            { new ShortCutIDModel("007E",1,"0","Rue Doom")},
            { new ShortCutIDModel("007F",1,"0","Rue Repulse")},
            { new ShortCutIDModel("0080",1,"0","Rue Wipe")},
            { new ShortCutIDModel("0081",1,"0","GiRue Doom")},
            { new ShortCutIDModel("0082",1,"0","GiRue Vortex")},
            { new ShortCutIDModel("0083",1,"0","Ruem Tempest")},
            { new ShortCutIDModel("0084",1,"0","Vak Doom")},
            { new ShortCutIDModel("0085",1,"0","Vak Repulse")},
            { new ShortCutIDModel("0086",1,"0","Vak Wipe")},
            { new ShortCutIDModel("0087",1,"0","GiVak Doom")},
            { new ShortCutIDModel("0088",1,"0","GiVak Vortex")},
            { new ShortCutIDModel("0089",1,"0","Vakz Tempest")},
            { new ShortCutIDModel("008A",1,"0","Juk Doom")},
            { new ShortCutIDModel("008B",1,"0","Juk Repulse")},
            { new ShortCutIDModel("008C",1,"0","Juk Wipe")},
            { new ShortCutIDModel("008D",1,"0","GiJuk Doom")},
            { new ShortCutIDModel("008E",1,"0","GiJuk Vortex")},
            { new ShortCutIDModel("008F",1,"0","Juka Tempest")},
            { new ShortCutIDModel("0090",1,"0","Rai Doom")},
            { new ShortCutIDModel("0091",1,"0","Rai Repulse")},
            { new ShortCutIDModel("0092",1,"0","Rai Wipe")},
            { new ShortCutIDModel("0093",1,"0","GiRai Doom")},
            { new ShortCutIDModel("0094",1,"0","RiRai Vortex")},
            { new ShortCutIDModel("0095",1,"0","Raio Tempest")},
            { new ShortCutIDModel("0096",1,"0","Repth")},
            { new ShortCutIDModel("0097",1,"0","Ol Repth")},
            { new ShortCutIDModel("0098",1,"0","Pha Repth")},
            { new ShortCutIDModel("0099",1,"0","La Repth")},
            { new ShortCutIDModel("009A",1,"0","Ola Repth")},
            { new ShortCutIDModel("009B",1,"0","Phal Repth")},
            { new ShortCutIDModel("009C",1,"0","Duk Lei")},
            { new ShortCutIDModel("009D",1,"0","Suvi Lei")},
            { new ShortCutIDModel("009E",1,"0","Dek Do")},
            { new ShortCutIDModel("009F",1,"0","Miu Lei")},
            { new ShortCutIDModel("00A0",1,"0","Mumyn Lei")},
            { new ShortCutIDModel("00A1",1,"0","Ranki Lei")},
            { new ShortCutIDModel("00A2",1,"0","Maj Lei")},
            { new ShortCutIDModel("00A3",1,"0","Dek Corv")},
            { new ShortCutIDModel("00A4",1,"0","Dek Vorv")},
            { new ShortCutIDModel("00A5",1,"0","Dek Torv")},
            { new ShortCutIDModel("00A6",1,"0","Dek Corma")},
            { new ShortCutIDModel("00A7",1,"0","Dek Vorma")},
            { new ShortCutIDModel("00A8",1,"0","Dek Torma")},
            { new ShortCutIDModel("00A9",1,"0","Dek Ganz")},
            { new ShortCutIDModel("00AA",1,"0","Dek Ruem")},
            { new ShortCutIDModel("00AB",1,"0","Dek Vakz")},
            { new ShortCutIDModel("00AC",1,"0","Dek Juka")},
            { new ShortCutIDModel("00AD",1,"0","Dek Raio")},
            { new ShortCutIDModel("00AE",1,"0","Dek Anid")},
            { new ShortCutIDModel("00AF",1,"0","Rig Saem")},
            { new ShortCutIDModel("00B0",1,"0","Rig Gaem")},
            { new ShortCutIDModel("00B1",1,"0","Ap Do")},
            { new ShortCutIDModel("00B2",1,"0","Rip Teyn")},
            { new ShortCutIDModel("00B3",1,"0","Rip Synk")},
            { new ShortCutIDModel("00B4",1,"0","Rip Maen")},
            { new ShortCutIDModel("00B5",1,"0","Ap Corv")},
            { new ShortCutIDModel("00B6",1,"0","Ap Vorv")},
            { new ShortCutIDModel("00B7",1,"0","Ap Torv")},
            { new ShortCutIDModel("00B8",1,"0","Ap Corma")},
            { new ShortCutIDModel("00B9",1,"0","Ap Vorma")},
            { new ShortCutIDModel("00BA",1,"0","Ap Torma")},
            { new ShortCutIDModel("00BB",1,"0","Ap Ganz")},
            { new ShortCutIDModel("00BC",1,"0","Ap Ruem")},
            { new ShortCutIDModel("00BD",1,"0","Ap Vakz")},
            { new ShortCutIDModel("00BE",1,"0","Ap Juka")},
            { new ShortCutIDModel("00BF",1,"0","Ap Raio")},
            { new ShortCutIDModel("00C0",1,"0","Ap Anid")},
            { new ShortCutIDModel("00C1",1,"0","Gan Don")},
            { new ShortCutIDModel("00C2",1,"0","GiGan Don")},
            { new ShortCutIDModel("00C3",1,"0","OrGan Don")},
            { new ShortCutIDModel("00C4",1,"0","PhaGan Don")},
            { new ShortCutIDModel("00C5",1,"0","Gan Rom")},
            { new ShortCutIDModel("00C6",1,"0","MeGan Rom")},
            { new ShortCutIDModel("00C7",1,"0","OrGan Rom")},
            { new ShortCutIDModel("00C8",1,"0","PhaGan Rom")},
            { new ShortCutIDModel("00C9",1,"0","Gan Zot")},
            { new ShortCutIDModel("00CA",1,"0","GiGan Zot")},
            { new ShortCutIDModel("00CB",1,"0","OrGan Zot")},
            { new ShortCutIDModel("00CC",1,"0","PhaGan Zot")},
            { new ShortCutIDModel("00CD",1,"0","Yarthkins")},
            { new ShortCutIDModel("00CE",1,"0","Yarthkins Ch")},
            { new ShortCutIDModel("00CF",1,"0","Yarthkins Rf")},
            { new ShortCutIDModel("00D0",1,"0","Yarthkins Pha")},
            { new ShortCutIDModel("00D1",1,"0","Rue Rom")},
            { new ShortCutIDModel("00D2",1,"0","MeRue Rom")},
            { new ShortCutIDModel("00D3",1,"0","OrRue  Rom")},
            { new ShortCutIDModel("00D4",1,"0","PhaRue Rom")},
            { new ShortCutIDModel("00D5",1,"0","Rue Kruz")},
            { new ShortCutIDModel("00D6",1,"0","GiRue Kruz")},
            { new ShortCutIDModel("00D7",1,"0","MeRue Kruz")},
            { new ShortCutIDModel("00D8",1,"0","PhaRue Kruz")},
            { new ShortCutIDModel("00D9",1,"0","Rue Zot")},
            { new ShortCutIDModel("00DA",1,"0","MeRue Zot")},
            { new ShortCutIDModel("00DB",1,"0","LaRue Zot")},
            { new ShortCutIDModel("00DC",1,"0","PhaRue Zot")},
            { new ShortCutIDModel("00DD",1,"0","Merrows")},
            { new ShortCutIDModel("00DE",1,"0","Merrows Ch")},
            { new ShortCutIDModel("00DF",1,"0","Merrows Rf")},
            { new ShortCutIDModel("00E0",1,"0","Merrows Pha")},
            { new ShortCutIDModel("00E1",1,"0","Vak Don")},
            { new ShortCutIDModel("00E2",1,"0","GiVak Don")},
            { new ShortCutIDModel("00E3",1,"0","RaVak Don")},
            { new ShortCutIDModel("00E4",1,"0","PhaVak Don")},
            { new ShortCutIDModel("00E5",1,"0","Vak Rom")},
            { new ShortCutIDModel("00E6",1,"0","BiVak Rom")},
            { new ShortCutIDModel("00E7",1,"0","OrVak Rom")},
            { new ShortCutIDModel("00E8",1,"0","PhaVak Rom")},
            { new ShortCutIDModel("00E9",1,"0","Vak Kruz")},
            { new ShortCutIDModel("00EA",1,"0","GiVak Kruz")},
            { new ShortCutIDModel("00EB",1,"0","MeVak Kruz")},
            { new ShortCutIDModel("00EC",1,"0","PhaVak Kruz")},
            { new ShortCutIDModel("00ED",1,"0","Vulcan")},
            { new ShortCutIDModel("00EE",1,"0","Vulcan Ch")},
            { new ShortCutIDModel("00EF",1,"0","Vulcan Rf")},
            { new ShortCutIDModel("00F0",1,"0","Vulcan Pha")},
            { new ShortCutIDModel("00F1",1,"0","Juk Rom")},
            { new ShortCutIDModel("00F2",1,"0","BiJuk Rom")},
            { new ShortCutIDModel("00F3",1,"0","RaJuk Rom")},
            { new ShortCutIDModel("00F4",1,"0","PhaJuk Rom")},
            { new ShortCutIDModel("00F5",1,"0","Juk Kruz")},
            { new ShortCutIDModel("00F6",1,"0","MeJuk Kruz")},
            { new ShortCutIDModel("00F7",1,"0","OrmJuk Kruz")},
            { new ShortCutIDModel("00F8",1,"0","PhaJuk Kruz")},
            { new ShortCutIDModel("00F9",1,"0","Juk Zot")},
            { new ShortCutIDModel("00FA",1,"0","RaJuk Zot")},
            { new ShortCutIDModel("00FB",1,"0","OrJuk Zot")},
            { new ShortCutIDModel("00FC",1,"0","PhaJuk Zot")},
            { new ShortCutIDModel("00FD",1,"0","Krake")},
            { new ShortCutIDModel("00FE",1,"0","Krake Ch")},
            { new ShortCutIDModel("00FF",1,"0","Krake Rf")},
            { new ShortCutIDModel("0100",1,"0","Krake Pha")},
            { new ShortCutIDModel("0101",1,"0","Rai Don")},
            { new ShortCutIDModel("0102",1,"0","MeRai Don")},
            { new ShortCutIDModel("0103",1,"0","GiRai Don")},
            { new ShortCutIDModel("0104",1,"0","PhaRai Don")},
            { new ShortCutIDModel("0105",1,"0","Rai Rom")},
            { new ShortCutIDModel("0106",1,"0","GiRai Rom")},
            { new ShortCutIDModel("0107",1,"0","MeRai Rom")},
            { new ShortCutIDModel("0108",1,"0","PhaRai Rom")},
            { new ShortCutIDModel("0109",1,"0","Rai Kruz")},
            { new ShortCutIDModel("010A",1,"0","MeRai Kruz")},
            { new ShortCutIDModel("010B",1,"0","OrmRai Kruz")},
            { new ShortCutIDModel("010C",1,"0","PhaRai Kruz")},
            { new ShortCutIDModel("010D",1,"0","Lanceor")},
            { new ShortCutIDModel("010E",1,"0","Lanceor Ch")},
            { new ShortCutIDModel("010F",1,"0","Lanceor Rf")},
            { new ShortCutIDModel("0110",1,"0","Lanceor Pha")},
            { new ShortCutIDModel("0111",1,"0","Ani Don")},
            { new ShortCutIDModel("0112",1,"0","BiAni Don")},
            { new ShortCutIDModel("0113",1,"0","OrbiAni Don")},
            { new ShortCutIDModel("0114",1,"0","PhAni Don")},
            { new ShortCutIDModel("0115",1,"0","Ani Kruz")},
            { new ShortCutIDModel("0116",1,"0","MeAni Kruz")},
            { new ShortCutIDModel("0117",1,"0","OrmeAni Kruz")},
            { new ShortCutIDModel("0118",1,"0","PhAni Kruz")},
            { new ShortCutIDModel("0119",1,"0","Ani Zot")},
            { new ShortCutIDModel("011A",1,"0","MeAni Zot")},
            { new ShortCutIDModel("011B",1,"0","OrmeAni Zot")},
            { new ShortCutIDModel("011C",1,"0","PhAni Zot")},
            { new ShortCutIDModel("011D",1,"0","Wryneck")},
            { new ShortCutIDModel("011E",1,"0","Wryneck Ch")},
            { new ShortCutIDModel("011F",1,"0","Wryneck Rf")},
            { new ShortCutIDModel("0120",1,"0","Wryneck Pha")},
            { new ShortCutIDModel("0121",1,"0","Meooow!!")},
            { new ShortCutIDModel("0122",1,"0","Stuck?")},
            { new ShortCutIDModel("0123",1,"0","Summon Goblin")},
            { new ShortCutIDModel("0124",1,"0","More Goblins")},
            { new ShortCutIDModel("0125",1,"0","Goblin King")},
            { new ShortCutIDModel("0126",1,"0","King of Goblin")},
            { new ShortCutIDModel("0127",1,"0","Para Repth")},
            { new ShortCutIDModel("0128",1,"0","Rig Saem")},
            { new ShortCutIDModel("0129",1,"0","Rig Geam")},
            { new ShortCutIDModel("012A",1,"0","Ap Corv")},
            { new ShortCutIDModel("012B",1,"0","Ap Vorv")},
            { new ShortCutIDModel("012C",1,"0","Ap Torv")},
            { new ShortCutIDModel("012D",1,"0","Ap Corma")},
            { new ShortCutIDModel("012E",1,"0","Ap Vorma")},
            { new ShortCutIDModel("012F",1,"0","Ap Torma")},
            { new ShortCutIDModel("0130",1,"0","MinaGan Shido")},
            { new ShortCutIDModel("0131",1,"0","MinaRue Shiku")},
            { new ShortCutIDModel("0132",1,"0","MinaVak Garo")},
            { new ShortCutIDModel("0133",1,"0","MinaJuk Shiku")},
            { new ShortCutIDModel("0134",1,"0","MinaRai Garo")},
            { new ShortCutIDModel("0135",1,"0","MinaAni Gaso")},
            { new ShortCutIDModel("0136",1,"0","MinaPao Rom")},
            { new ShortCutIDModel("0137",1,"0","MinaPeru Kruz")},
            { new ShortCutIDModel("0138",1,"0","MinaSepu Zot")},
            { new ShortCutIDModel("0139",1,"0","MinaTepo Don")},
            { new ShortCutIDModel("013A",1,"0","Mina Jia")},
            { new ShortCutIDModel("013B",1,"0","Mina Musu")},
            { new ShortCutIDModel("013C",1,"0","Mina Odo")},
            { new ShortCutIDModel("013D",1,"0","Mina Noku")},
            { new ShortCutIDModel("013E",1,"0","Mina Iru")},
            { new ShortCutIDModel("013F",1,"0","Mina Yamu")},
            { new ShortCutIDModel("0140",1,"0","Mina Uji")},
            { new ShortCutIDModel("0141",1,"0","Mina Magi")},
            { new ShortCutIDModel("0142",1,"0","OrMinaGan Shido")},
            { new ShortCutIDModel("0143",1,"0","OrMinaRue Shiku")},
            { new ShortCutIDModel("0144",1,"0","OrMinaVak Garo")},
            { new ShortCutIDModel("0145",1,"0","OrMinaJuk Shiku")},
            { new ShortCutIDModel("0146",1,"0","OrMinaRai Garo")},
            { new ShortCutIDModel("0147",1,"0","OrMinaAni Gaso")},
            { new ShortCutIDModel("0148",1,"0","OminaPao Rom")},
            { new ShortCutIDModel("0149",1,"0","OminaPeru Kruz")},
            { new ShortCutIDModel("014A",1,"0","OminaSepu Zot")},
            { new ShortCutIDModel("014B",1,"0","OminaTepo Don")},
            { new ShortCutIDModel("014C",1,"0","PhaMina Jia")},
            { new ShortCutIDModel("014D",1,"0","PhaMina Musu")},
            { new ShortCutIDModel("014E",1,"0","PhaMina Odo")},
            { new ShortCutIDModel("014F",1,"0","PhaMina Noku")},
            { new ShortCutIDModel("0150",1,"0","PhaMina Iru")},
            { new ShortCutIDModel("0151",1,"0","PhaMina Yamu")},
            { new ShortCutIDModel("0152",1,"0","PhaMina Uji")},
            { new ShortCutIDModel("0153",1,"0","PhaMina Magi")},
            { new ShortCutIDModel("0000",2,"A","Health Drink")},
            { new ShortCutIDModel("0001",2,"A","Healing Potion")},
            { new ShortCutIDModel("0002",2,"A","Healing Elixir")},
            { new ShortCutIDModel("0003",2,"A","Antidote")},
            { new ShortCutIDModel("0004",2,"A","Restorative")},
            { new ShortCutIDModel("0005",2,"A","Resurrect")},
            { new ShortCutIDModel("0006",2,"A","Warrior Blood")},
            { new ShortCutIDModel("0007",2,"A","Knight Blood")},
            { new ShortCutIDModel("0008",2,"A","Hunter Blood")},
            { new ShortCutIDModel("0009",2,"A","Hermit Blood")},
            { new ShortCutIDModel("000A",2,"A","Beast Blood")},
            { new ShortCutIDModel("000B",2,"A","Wizard Blood")},
            { new ShortCutIDModel("000C",2,"A","Well Water")},
            { new ShortCutIDModel("000D",2,"A","Pure Water")},
            { new ShortCutIDModel("000E",2,"A","Burning Oil")},
            { new ShortCutIDModel("000F",2,"A","Holy Sap")},
            { new ShortCutIDModel("0010",2,"A","Sports Drink")},
            { new ShortCutIDModel("0011",2,"A","Cooked Bile")},
            { new ShortCutIDModel("0012",2,"A","Mage's Soul")},
            { new ShortCutIDModel("0013",2,"A","Artisan's Soul")},
            { new ShortCutIDModel("0014",2,"A","Emperor's Soul")},
            { new ShortCutIDModel("0015",2,"A","Noble Wine")},
            { new ShortCutIDModel("0016",2,"A","Risky Coffee")},
            { new ShortCutIDModel("0017",2,"A","Recovery Drink")},
            { new ShortCutIDModel("0000",2,"B","Raining Rocks")},
            { new ShortCutIDModel("0001",2,"B","Raging Earth")},
            { new ShortCutIDModel("0002",2,"B","Stone Storm")},
            { new ShortCutIDModel("0003",2,"B","Gaia's Spell")},
            { new ShortCutIDModel("0004",2,"B","Meteor Strike")},
            { new ShortCutIDModel("0005",2,"B","Cosmic Truth")},
            { new ShortCutIDModel("0006",2,"B","Ice Storm")},
            { new ShortCutIDModel("0007",2,"B","Ice Flow")},
            { new ShortCutIDModel("0008",2,"B","Ice Strike")},
            { new ShortCutIDModel("0009",2,"B","Cygnus")},
            { new ShortCutIDModel("000A",2,"B","Absolute Zero")},
            { new ShortCutIDModel("000B",2,"B","Permafrost")},
            { new ShortCutIDModel("000C",2,"B","Fire Tempest")},
            { new ShortCutIDModel("000D",2,"B","Meteor Swarm")},
            { new ShortCutIDModel("000E",2,"B","Flame Blast")},
            { new ShortCutIDModel("000F",2,"B","Fireball Storm")},
            { new ShortCutIDModel("0010",2,"B","Hellstorm")},
            { new ShortCutIDModel("0011",2,"B","Inferno Strike")},
            { new ShortCutIDModel("0012",2,"B","Green Gale")},
            { new ShortCutIDModel("0013",2,"B","Gale Breath")},
            { new ShortCutIDModel("0014",2,"B","Leafblight")},
            { new ShortCutIDModel("0015",2,"B","Wood Sprite")},
            { new ShortCutIDModel("0016",2,"B","Jungle Rage")},
            { new ShortCutIDModel("0017",2,"B","Forest of Fear")},
            { new ShortCutIDModel("0018",2,"B","Lightning Bolt")},
            { new ShortCutIDModel("0019",2,"B","Plasma Storm")},
            { new ShortCutIDModel("001A",2,"B","Ion Strike")},
            { new ShortCutIDModel("001B",2,"B","Raging Plasma")},
            { new ShortCutIDModel("001C",2,"B","Thunderbolt")},
            { new ShortCutIDModel("001D",2,"B","Plasma Gale")},
            { new ShortCutIDModel("001E",2,"B","Nightblight")},
            { new ShortCutIDModel("001F",2,"B","Dark Night")},
            { new ShortCutIDModel("0020",2,"B","Dark Traitor")},
            { new ShortCutIDModel("0021",2,"B","Chaos Spell")},
            { new ShortCutIDModel("0022",2,"B","Nightfear")},
            { new ShortCutIDModel("0023",2,"B","Nightshade")},
            { new ShortCutIDModel("0024",2,"B","The Death")},
            { new ShortCutIDModel("0025",2,"B","The Hanged Man")},
            { new ShortCutIDModel("0026",2,"B","The Lovers")},
            { new ShortCutIDModel("0027",2,"B","The Moon")},
            { new ShortCutIDModel("0028",2,"B","The Fool")},
            { new ShortCutIDModel("0029",2,"B","The Devil")},
            { new ShortCutIDModel("002A",2,"B","Warrior's Bane")},
            { new ShortCutIDModel("002B",2,"B","Knight's Bane")},
            { new ShortCutIDModel("002C",2,"B","Hunter's Bane")},
            { new ShortCutIDModel("002D",2,"B","Hermit's Bane")},
            { new ShortCutIDModel("002E",2,"B","Beast's Bane")},
            { new ShortCutIDModel("002F",2,"B","Wizard's Bane")},
            { new ShortCutIDModel("0030",2,"B","Stonebane")},
            { new ShortCutIDModel("0031",2,"B","Waterbane")},
            { new ShortCutIDModel("0032",2,"B","Firebane")},
            { new ShortCutIDModel("0033",2,"B","Treebane")},
            { new ShortCutIDModel("0034",2,"B","Lightbane")},
            { new ShortCutIDModel("0035",2,"B","Nightbane")},
            { new ShortCutIDModel("0036",2,"B","Health Charm")},
            { new ShortCutIDModel("0037",2,"B","Soul Charm")},
            { new ShortCutIDModel("0038",2,"B","Speed Charm")},
            { new ShortCutIDModel("0039",2,"B","Light Cross")},
            { new ShortCutIDModel("003A",2,"B","Hale Cross")},
            { new ShortCutIDModel("003B",2,"B","Divine Cross")},
            { new ShortCutIDModel("003C",2,"B","Summon Earth")},
            { new ShortCutIDModel("003D",2,"B","Summon Water")},
            { new ShortCutIDModel("003E",2,"B","Summon Fire")},
            { new ShortCutIDModel("003F",2,"B","Summon Wood")},
            { new ShortCutIDModel("0040",2,"B","Summon Thunder")},
            { new ShortCutIDModel("0041",2,"B","Summon Night")},
            { new ShortCutIDModel("0042",2,"B","Stonecall")},
            { new ShortCutIDModel("0043",2,"B","Aquacall")},
            { new ShortCutIDModel("0044",2,"B","Infernocall")},
            { new ShortCutIDModel("0045",2,"B","Greencall")},
            { new ShortCutIDModel("0046",2,"B","Thundercall")},
            { new ShortCutIDModel("0047",2,"B","Nightcall")},
            { new ShortCutIDModel("0000",2,"C","Fortune Wire")},
            { new ShortCutIDModel("0001",2,"C","Sprite Ocarina")},
            { new ShortCutIDModel("0002",2,"C","Fairy's Orb")},
        };
    }
}
