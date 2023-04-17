using System;
using System.Collections.Generic;
using System.Text;

namespace EstimatR
{
    public abstract class Estimator
    {
        protected bool validInput;

        //sprawdzic raz jeszcz uzycie tego
        protected static double[][] CreateMatrix(EstimatorObjectCollection input)
        {
            double[][] result;

            result = new double[input.Count][];
            for (int i = 0; i < input.Count; i++)
            {
                result[i] = new double[input[0].Item.Length];
                for (int j = 0; j < input[0].Item.Length; j++)
                {
                    result[i][j] = input[i].Item[j];
                }
            }
            return result;
        }

        public EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection> Input;

        public abstract void Prepare(EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection> input);

        public abstract void Prepare(EstimatorObjectCollection x, EstimatorObjectCollection y);

        public abstract void Update(EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection> input);

        public abstract void Update(EstimatorObjectCollection x, EstimatorObjectCollection y);

        public abstract void Create();

        public abstract EstimatorObject Evaluate(EstimatorObject x);

        public abstract EstimatorObject Evaluate(object x);

        public virtual void SetAdvancedParameters(IList<object> advParameters = null)
        {

        }

        public abstract double[][] GetParameters();
    }
}
