﻿namespace System.Instant.Mathset
{
    using System;
    using System.Reflection.Emit;

    [Serializable]
    public class Minus : BinaryOperator
    {
        public override double Apply(double a, double b)
        {
            return a - b;
        }

        public override void Compile(ILGenerator g)
        {
            g.Emit(OpCodes.Sub);
        }
    }
}
