using System;
using System.Linq;

namespace FragmentJamella.Helpers
{
    public static class StatHelper
    {
        public static int[] GetStats(string charModel, int level, int[] sliders = null)
        {
            sliders = sliders ?? new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] levelone = LevelOneStats(charModel);
            int[] levelup = LevelUpStats(charModel);
            int[] element = ElementMultiplier(charModel);
            int[] slidestats = SliderStats(charModel, sliders);
            for (int i = 0; i < 8; i++)
                levelone[i + 2] += slidestats[i];
            for (int i = 0; i < 18; i++)
                if (levelup[i] < 1) levelup[i] = 1;
            levelup = levelup.Select(x => x * (level-1)).ToArray();
            levelup = levelup.Zip(levelone, (x, y) => x + y).ToArray();
            for (int i = 0; i < 6; i++)
            {
                levelup[i + 10] *= element[i];
            }
            if (levelup[1] > 9999) levelup[1] = 9999;
            for (int i = 1; i < 18; i++)
                if (levelup[i] > 999) levelup[i] = 999;
            return levelup;
        }

        public static int[] SliderStats(string charModel, int[] sliders = null)
        {
            sliders = sliders ?? new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] levelone = LevelOneStats(charModel);
            int[] newstat = new int[8];
            int[] remain = new int[8];
            int round = 99;
            int order = 0;

            for (int i = 0; i < 8; i++)
            {
                int prod = levelone[i + 2] * sliders[i];
                newstat[i] = prod / 100;
                remain[i] = prod % 100;
                round += remain[i];
            }
            round = round / 100;

            for (int i = 0; i < round; i++)
            {
                int high = remain[0];
                order = 0;
                for (int j = 1; j < 8; j++)
                {
                    if (remain[j] > high)
                    {
                        high = remain[j];
                        order = j;
                    }
                }
                remain[order] = -1;
                newstat[order] += 1;
            }

            return newstat;
        }

        private static int[] LevelOneStats(string charModel)
        {
            int[] classGender = ParseClassGender(charModel);
            return new int[][][]
                {
                    new int [][]{
                        new int[] {63, 13, 15, 14, 33, 33, 14, 14, 26, 26, 6, 6, 6, 6, 6, 6, 30, 40 }, //Twin M
                        new int[] {61, 15, 14, 14, 33, 33, 14, 14, 26, 26, 6, 6, 6, 6, 6, 6, 40, 30 }  //Twin F
                    },
                    new int [][]{
                        new int[] {66, 13, 15, 14, 33, 33, 14, 14, 26, 26, 6, 6, 6, 6, 6, 6, 40, 40 }, //Blade M
                        new int[] {64, 15, 14, 14, 33, 33, 14, 14, 26, 26, 6, 6, 6, 6, 6, 6, 40, 40 }  //Blade F
                    },
                    new int [][]{
                        new int[] {70, 13, 16, 15, 32, 30, 13, 13, 26, 26, 6, 6, 6, 6, 6, 6, 15, 50 }, //HeavyB M
                        new int[] {68, 15, 15, 15, 32, 30, 13, 13, 26, 26, 6, 6, 6, 6, 6, 6, 20, 50 }  //HeavyB F
                    },
                    new int [][]{
                        new int[] {75, 13, 18, 14, 33, 33, 14, 13, 26, 26, 6, 6, 6, 6, 6, 6, 15, 50 }, //Axe M
                        new int[] {73, 15, 17, 14, 33, 33, 14, 13, 26, 26, 6, 6, 6, 6, 6, 6, 20, 50 }  //Axe F
                    },
                    new int [][]{
                        new int[] {70, 13, 17, 14, 33, 33, 13, 13, 26, 26, 6, 6, 6, 6, 6, 6, 15, 50 }, //Long M
                        new int[] {68, 15, 16, 14, 33, 33, 13, 13, 26, 26, 6, 6, 6, 6, 6, 6, 20, 50 }  //Long F
                    },
                    new int [][]{
                        new int[] {55, 20, 11, 14, 30, 31, 18, 13, 32, 28, 6, 6, 6, 6, 6, 6, 50, 15 }, //Wave M
                        new int[] {53, 22, 10, 14, 30, 31, 18, 13, 32, 28, 6, 6, 6, 6, 6, 6, 50, 15 }  //Wave F
                    }
                }[classGender[0]][classGender[1]].Zip(LevelOneSize(charModel), (x, y) => x + y).ToArray();
        }

        private static int[] LevelUpStats(string charModel)
        {
            int[] classGender = ParseClassGender(charModel);
            return new int[][][]
                {
                    new int [][]{
                        new int[] {18,  3,  5,  4, 13, 13,  4,  4,  6,  6, 1, 1, 1, 1, 1, 1,  6,  8 }, //Twin M
                        new int[] {16,  4,  4,  4, 14, 13,  4,  4,  6,  6, 1, 1, 1, 1, 1, 1,  8,  6 }  //Twin F
                    },
                    new int [][]{
                        new int[] {20,  3,  6,  6, 11, 11,  3,  3,  6,  6, 1, 1, 1, 1, 1, 1,  1, 10 }, //Blade M
                        new int[] {18,  4,  5,  6, 12, 11,  3,  3,  6,  6, 1, 1, 1, 1, 1, 1,  4, 10 }  //Blade F
                    },
                    new int [][]{
                        new int[] {20,  3,  7,  5, 12, 10,  3,  3,  6,  6, 1, 1, 1, 1, 1, 1,  1, 10 }, //HeavyB M
                        new int[] {18,  4,  6,  5, 13, 10,  3,  3,  6,  6, 1, 1, 1, 1, 1, 1,  4, 10 }  //HeavyB F
                    },
                    new int [][]{
                        new int[] {25,  3,  8,  4, 13,  8,  2,  3,  6,  6, 1, 1, 1, 1, 1, 1,  1, 10 }, //Axe M
                        new int[] {23,  4,  7,  4, 14,  8,  2,  3,  6,  6, 1, 1, 1, 1, 1, 1,  2, 10 }  //Axe F
                    },
                    new int [][]{
                        new int[] {20,  3,  7,  6, 13, 12,  3,  4,  6,  6, 1, 1, 1, 1, 1, 1,  1, 10 }, //Long M
                        new int[] {18,  4,  6,  6, 14, 12,  3,  4,  6,  6, 1, 1, 1, 1, 1, 1,  3, 10 }  //Long F
                    },
                    new int [][]{
                        new int[] {15,  5,  1,  4, 10, 11,  8,  3, 12,  8, 1, 1, 1, 1, 1, 1, 10,  2 }, //Wave M
                        new int[] {13,  6,  1,  4, 10, 11,  8,  3, 12,  8, 1, 1, 1, 1, 1, 1, 12,  1 }  //Wave F
                    }
                }[classGender[0]][classGender[1]].Zip(LevelUpSize(charModel), (x, y) => x + y).ToArray();
        }

        private static int[] ParseClassGender(string charModel)
        {
            int charClass = charModel.Length > 1 ? "tbhalw".IndexOf(charModel.ToCharArray()[1]) : 0;
            int charGender = charModel.Length > 2 ? charModel.ToCharArray()[2] - '1' : 0;
            if (charGender > 8) charGender = 9; //Blademaseter model 10 uses char 'a'. 'a' - '1' = 48. use 9 for array below
            charGender = new int[][] { new int[]{ 0, 0, 0, 0, 1, 1, 1, 1 },
                                       new int[]{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },
                                       new int[]{ 0, 0, 1, 1, 0, 1 },
                                       new int[]{ 0, 0, 1, 1, 1 },
                                       new int[]{ 0, 0, 0, 1, 1, 1 },
                                       new int[]{ 0, 0, 0, 1, 1, 1 } }[charClass][charGender];
            return new int[] { charClass, charGender };
        }

        private static int[] ElementMultiplier(string charModel)
        {
            // {Earth, Water, Fire, Wood, Thunder, Dark}
            switch (charModel.Length > 6 ? charModel.Substring(6) : "rd")
            {
                case "br":
                    return new int[] { 2, 1, 1, 0, 1, 1 }; //Brown
                case "bl":
                    return new int[] { 1, 2, 0, 1, 1, 1 }; //Blue
                case "rd":
                    return new int[] { 1, 0, 2, 1, 1, 1 }; //Red
                case "gr":
                    return new int[] { 0, 1, 1, 2, 1, 1 }; //Green
                case "yl":
                    return new int[] { 1, 1, 1, 1, 2, 0 }; //Yellow
                case "pp":
                    return new int[] { 1, 1, 1, 1, 0, 2 }; //Purple
                default:
                    return new int[] { 1, 1, 1, 1, 1, 1 };
            }
        }


        private static int[] LevelOneSize(string charModel)
        {
            int size = charModel.Length > 3 ? charModel.ToCharArray()[3] - 'a' : 4;
            return LevelOneWidth(size % 3).Zip(LevelOneHeight(size / 3), (x, y) => x + y).ToArray();
        }

        private static int[] LevelOneHeight(int height)
        {
            return new int[][]
            {
                new int[] { -2, 0, -2, 0, 5,  5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 }, //Short
                new int[] {  0, 0,  0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 }, //Medium
                new int[] {  2, 0,  2, 0, 0, -3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -3, 3 }, //Tall
            }[height];
        }

        private static int[] LevelOneWidth(int width)
        {
            return new int[][]
            {
                new int[] { -2,  2, -1, -2,  0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  5, -5 }, //Skinny
                new int[] {  0,  0,  0,  0,  0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0,  0 }, //Medium
                new int[] {  3, -1,  1,  3, -2, -5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -5,  5 }, //Fat
            }[width];
        }

        private static int[] LevelUpSize(string charModel)
        {
            int size = charModel.Length > 3 ? charModel.ToCharArray()[3] - 'a' : 4;
            return LevelUpWidth(size % 3).Zip(LevelUpHeight(size / 3), (x, y) => x + y).ToArray();
        }

        private static int[] LevelUpHeight(int height)
        {
            return new int[][] 
            {
                new int[] { -1, 0, -1, 0, 2,  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 }, //Short
                new int[] {  0, 0,  0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 }, //Medium
                new int[] {  1, 0,  1, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 1 }, //Tall
            }[height];
        }

        private static int[] LevelUpWidth(int width)
        {
            return new int[][]
            {
                new int[] { -1,  1, -1, -1,  0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  3, -1 }, //Skinny
                new int[] {  0,  0,  0,  0,  0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0,  0 }, //Medium
                new int[] {  2, -1,  1,  1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1,  2 }, //Fat
            }[width];            
        }

    }
}
