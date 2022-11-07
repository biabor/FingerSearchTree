﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerSearchTree
{
    public class Leaf : Node
    {
        public int Value { get; }

        public override int Min { get => Value; }

        public override int Max { get => Value; }

        public Leaf(Block1 father, int value):base(0)
        {
            Father = father;
            Value = value;
        }
    }
}
