using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace EstimatR
{
    public class EstimatorObjectCollection : Collection<EstimatorObject>
    {
        public EstimatorObjectCollection()
        {

        }

        public EstimatorObjectCollection(IList<EstimatorObject> range)  //dowolna lista/kolekcja zawierajaca obiekty DataEstimator - nie musi byc lista
        {
            foreach (EstimatorObject de in range)
            {
                this.Add(de);
            }
        }
    }
}
