using System.Collections;

namespace EstimatR
{
    public struct EstimatorObject
    {
        public double[] Item;
        public EstimatorObjectMode Mode;

        public EstimatorObject(EstimatorObject item)
        {
            Item = item.Item;
            Mode = item.Mode;
        }

        public EstimatorObject(object item)
        {
            var type = item.GetType();
            if (type.IsValueType)
            {
                //sprawdzcz czy numeric
                Item = new double[] { Convert.ToDouble(item) };
                Mode = EstimatorObjectMode.Single;
            }
            else if (type.IsArray)  //analogicznie int[], decimal[], etc. wszystkie liczbowe rzutowac
            {
                //sprawdzcz czy numeric                                
                //Item = (double[]) item; //czy jeszcze inaczej? kopiowac pola?
                Item = ((Array)item).Cast<object>().Select(o => Convert.ToDouble(o)).ToArray();
                Mode = EstimatorObjectMode.Multi;
            }
            else if (type.IsAssignableTo(typeof(IList))) //is IList nie dziala !!!!
            {
                if (((IList)item).Count > 0 && ((IList)item)[0] is ValueType)
                {
                    //sprawdzcz czy numeric
                    Item = ((IList)item).Cast<object>().Select(o => Convert.ToDouble(o)).ToArray();
                    Mode = EstimatorObjectMode.Multi;
                }
                else
                {
                    throw new Exception("Wrong data type");
                }
            }
            else
            {
                throw new Exception("Wrong data type");
            }
        }
    }

    public enum EstimatorObjectMode
    {
        Multi,
        Single
    }
}
