using System;

namespace FingerSearchTree
{
    public static class Helpers
    {
        public static long Bi(int level)
        {
            return 128 * (long)Math.Pow(4,level); 
        }

        public static long BiP(int level) 
        {
            return 32 * (long)Math.Pow(4, level);
        }

        public static long Ai(int level) 
        {
            return (long)Math.Pow(2, level);
        }

        public static long Fi(int level) 
        {
            return 4 * (long)Math.Pow(2, level); 
        }

        internal static long Ri(int level)
        {
            return 8 * (Fi(level) / Ai(level));
        }

        public static long RiP (int level)
        {
            return 128 / 32;//Bi(level) / BiP(level); 
        }
    }
}
