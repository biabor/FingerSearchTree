using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerSearchTree
{
    public static class Bounds
    {
        public static long BiP(int level)
        {
            return (long)Math.Pow(2, 2 * level + 3) - 2;
        }

        public static long Fi(int level)
        {
            return (long)Math.Pow(2, 2* level + 1);
        }

        public static long Ai(int level)
        {
            return (long)Math.Pow(2, 2 * level);
        }
    }
}