﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EstimatR
{
    public class EmptyEstimator : Estimator
    {
        public override void Prepare(EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection> input)
        {
            Input = input;
        }

        public override void Prepare(EstimatorObjectCollection x, EstimatorObjectCollection y)
        {
            Input = new EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection>(x, y);
        }

        public override void Create()
        {

        }

        public override EstimatorObject Evaluate(object x)
        {
            return Evaluate(new EstimatorObject(x));
        }

        public override EstimatorObject Evaluate(EstimatorObject x)
        {
            return new EstimatorObject(x);
        }

        public override void Update(EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection> input)
        {
            return;
        }

        public override void Update(EstimatorObjectCollection x, EstimatorObjectCollection y)
        {
            return;
        }

        public override double[][] GetParameters()
        {
            return null;
        }
    }

}
