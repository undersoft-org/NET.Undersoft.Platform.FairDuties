using System;
using System.Collections.Generic;
using System.Text;

namespace EstimatR
{
    public class LinearLastSquareEstimator : Estimator
    {
        private bool validParameters;
        private double[][] parameterTheta;

        public override void Prepare(EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection> input)
        {
            //verify
            Input = input;
            validInput = true;
            validParameters = false;
        }

        public override void Prepare(EstimatorObjectCollection x, EstimatorObjectCollection y)
        {
            Prepare(new EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection>(x, y));
        }

        public override void Create()
        {
            // cov = inv(X'*X)
            // M = covA*X' ==> inv(X'*X)*X'
            // theta = M*Y
            // y = x*theta
            //in other words:
            //X_k = X[k].Item - multi D
            //y_k = Y[k].Item[0] - 1D or multi D
            //theta = (sum_{k=1}^{N}X_k*X_k')^{-1} (sum_{k=1}^{N}X_k*y_k)

            if (validInput == false)
            {
                throw new StatisticsExceptions(StatisticsExceptionList.DataType);
            }

            double[][] X = CreateMatrix(Input.X);
            double[][] Y = CreateMatrix(Input.Y);
            double[][] XT = MatrixOperations.MatrixTranpose(X);
            double[][] XTX = MatrixOperations.MatrixProduct(XT, X);
            double[][] invXTX = MatrixOperations.MatrixInverse(XTX);

            //throw exception if covariance matrix is invertible //try catch na inverse matrix

            double[][] invXTX_X = MatrixOperations.MatrixProduct(invXTX, XT);
            double[][] theta = MatrixOperations.MatrixProduct(invXTX_X, Y);
            parameterTheta = theta;
        }

        public override EstimatorObject Evaluate(object x)
        {
            return Evaluate(new EstimatorObject(x));
        }

        public override EstimatorObject Evaluate(EstimatorObject x) //nazwe dac inna niz xValue
        {
            if (validParameters == false) //to aviod recalculations of systemParameters
            {
                Create();
            }

            return new EstimatorObject(MatrixOperations.MatrixVectorProduct(MatrixOperations.MatrixTranpose(parameterTheta), x.Item));
        }

        public override void Update(EstimatorInput<EstimatorObjectCollection, EstimatorObjectCollection> input)
        {
            throw new StatisticsExceptions(StatisticsExceptionList.MethodCannotBeProceeded);
        }

        public override void Update(EstimatorObjectCollection x, EstimatorObjectCollection y)
        {
            throw new StatisticsExceptions(StatisticsExceptionList.MethodCannotBeProceeded);
        }

        public override double[][] GetParameters()
        {
            return MatrixOperations.MatrixDuplicate(parameterTheta);
        }

    }
}
