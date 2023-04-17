using System;
using System.Collections.Generic;
using System.Text;

namespace EstimatR
{
    public class EstimatorInput<A, B> where A : EstimatorObjectCollection where B : EstimatorObjectCollection
    {
        public EstimatorObjectCollection X;
        public EstimatorObjectCollection Y;


        //czy dawac pusty????
        public EstimatorInput()
        {
            X = new EstimatorObjectCollection();
            Y = new EstimatorObjectCollection();
        }

        public EstimatorInput(A x, B y)
        {
            if (x.Count != y.Count)
            {
                throw new StatisticsExceptions(StatisticsExceptionList.DataTypeInconsistentXY);
            }

            X = x;
            Y = y;
        }
    }
}
