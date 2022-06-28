using System;

namespace FingerSearchTree
{
    public static class Helpers
    {
        public static long Bi(int level)
        {
            return (long)Math.Pow(2, (2 * level) + 4);
        }

        public static long BiP(int level) 
        {
            return (long) Math.Pow(2, 2 * level + 3) - 2;
        }

        public static long Ai(int level) 
        {
            return (long)Math.Pow(2, 2 * level);
        }

        public static long Fi(int level) 
        {
            return (long)Math.Pow(2, 2 * level + 1); 
        }

        public static long RiP (int level)
        {
            return Bi(level) / BiP(level); 
        }
    }
}
