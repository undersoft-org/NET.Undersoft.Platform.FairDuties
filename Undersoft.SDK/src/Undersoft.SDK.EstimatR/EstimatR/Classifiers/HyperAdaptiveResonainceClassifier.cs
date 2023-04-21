using System.Diagnostics;
using System.Series;
using System.Text;

namespace EstimatR
{
    public class HyperAdaptiveResonainceClassifier
    {
        #region Properties -------------------
        public List<string> NameList { get; set; }

        public int ItemSize { get; set; }

        public List<SubjectItem> ItemList { get; set; }

        public List<Cluster> ClusterList { get; set; }

        public List<HyperCluster> HyperClusterList { get; set; }

        private Catalog<Cluster> ItemToClusterMap;

        private Dictionary<Cluster, HyperCluster> ClusterToHyperClusterMap;

        #endregion

        #region Constants & Parameters -------

        public double bValue = 0.2f;

        public double pValue = 0.6f;

        public double p2Value = 0.3f;

        public const int rangeLimit = 1;

        public int IterationLimit = 50;

        private string tempHardFileName = "surveyResults.art";

        #endregion

        #region Constructors -----------------
        public HyperAdaptiveResonainceClassifier()
        {
            NameList = new List<string>();
            ItemList = new List<SubjectItem>();
            ClusterList = new List<Cluster>();
            HyperClusterList = new List<HyperCluster>();
            ItemToClusterMap = new Catalog<Cluster>();
            ClusterToHyperClusterMap = new Dictionary<Cluster, HyperCluster>();

            LoadFile(tempHardFileName);
            ItemList = NormalizeItemList(ItemList);
            Create();
        }

        //it has sens only if FEatureItemList != null && .any == true
        public void Create()
        {
            ClusterList.Clear();
            HyperClusterList.Clear();
            ItemToClusterMap.Clear();
            ClusterToHyperClusterMap.Clear();

            for (int i = 0; i < ItemList.Count; i++)
            {
                AssignCluster(ItemList[i]);
            }

            //Get items assigned to hyperClusters
            for (int i = 0; i < HyperClusterList.Count; i++)
            {
                HyperClusterList[i].GetHyperClusterItemList();
            }
        }

        public void Create(ICollection<SubjectItem> itemCollection)
        {
            ItemList.AddRange(itemCollection);

            ClusterList.Clear();
            HyperClusterList.Clear();
            ItemToClusterMap.Clear();
            ClusterToHyperClusterMap.Clear();

            for (int i = 0; i < ItemList.Count; i++)
            {
                ItemList[i].Id = i;
                AssignCluster(ItemList[i]);
            }

            //Get items assigned to hyperClusters
            for (int i = 0; i < HyperClusterList.Count; i++)
            {
                HyperClusterList[i].GetHyperClusterItemList();
            }
        }

        #endregion

        #region Core methods -----------------

        public void Append(ICollection<SubjectItem> itemCollection)
        {
            int currentCount = ItemList.Count;

            ItemList.AddRange(itemCollection);

            //start from 0 (Chin Xi) or from the currently added collection (RR) ? in my opinion it should be from currentCount, otherwise unecessary and redundant calculations
            for (int i = currentCount; i < ItemList.Count; i++)
            {
                ItemList[i].Id = i;          //update Id according to ItemList numeration
                AssignCluster(ItemList[i]);
            }

            //Get items assigned to hyperClusters
            for (int i = 0; i < HyperClusterList.Count; i++)
            {
                HyperClusterList[i].GetHyperClusterItemList();
            }
        }

        //what about Id???
        public void Append(SubjectItem item)
        {
            item.Id = ItemList.Count;    //update Id according to ItemList numeration
            ItemList.Add(item);
            AssignCluster(item);

            //Get items assigned to hyperClusters
            for (int i = 0; i < HyperClusterList.Count; i++)
            {
                HyperClusterList[i].GetHyperClusterItemList();
            }
        }

        public void AssignCluster(SubjectItem item)
        {
            int iterationCounter = IterationLimit;  //assign IterationLimit
            bool isAssignementChanged = true;
            double itemVectorMagnitude = CalculateVectorMagnitude(item.Vector);

            while (isAssignementChanged && iterationCounter > 0)
            {
                isAssignementChanged = false;

                List<KeyValuePair<Cluster, double>> clusterToProximityList = new List<KeyValuePair<Cluster, double>>();
                double proximityThreshold = itemVectorMagnitude / (bValue + rangeLimit * ItemSize);  // ||E_i||/(b+1)

                //Calculate proximity values for item and clusters
                for (int i = 0; i < ClusterList.Count; i++)
                {
                    double clusterVectorMagnitude = CalculateVectorMagnitude(ClusterList[i].ClusterVector);
                    double proximity = CaulculateVectorIntersectionMagnitude(item.Vector, ClusterList[i].ClusterVector) / (bValue + clusterVectorMagnitude); //prox = ||C_j and E_i ||/ (b + ||E_i||) > proxThres
                    if (proximity > proximityThreshold)
                    {
                        clusterToProximityList.Add(new KeyValuePair<Cluster, double>(ClusterList[i], proximity));
                    }
                }

                if (clusterToProximityList.Count > 0)        //???? tutaj zobaczyc, czy nie trzeba sprawdzic dodania lub ominiecia dodania
                {
                    clusterToProximityList.Sort((x, y) => -1 * x.Value.CompareTo(y.Value));  //sorting in place in descending order

                    //search from the maximum proximity to smallest
                    for (int i = 0; i < clusterToProximityList.Count; i++)
                    {
                        Cluster newCluster = clusterToProximityList[i].Key;
                        double vigilance = CaulculateVectorIntersectionMagnitude(newCluster.ClusterVector, item.Vector) / itemVectorMagnitude;
                        if (vigilance >= pValue) //passed all tests and has max proximity
                        {
                            if (ItemToClusterMap.ContainsKey(item.Id)) //find cluster with this item
                            {
                                Cluster previousCluster = ItemToClusterMap[item.Id];
                                if (ReferenceEquals(newCluster, previousCluster)) break;    //if the best is the same, then it will break (not considered others)
                                if (previousCluster.RemoveItemFromCluster(item) == false)      //the cluster is empty
                                {
                                    ClusterList.Remove(previousCluster);
                                }
                            }
                            //Add item to the current cluster
                            newCluster.AddItemToCluster(item);
                            ItemToClusterMap[item.Id] = newCluster;
                            isAssignementChanged = true;
                            break;
                        }
                    }
                }

                if (ItemToClusterMap.ContainsKey(item.Id) == false)
                {
                    Cluster newCluster = new Cluster(item);
                    ClusterList.Add(newCluster);
                    ItemToClusterMap.Add(item.Id, newCluster);
                    isAssignementChanged = true;
                }

                iterationCounter--;
            }

            AssignHyperCluster();
        }

        public void AssignHyperCluster()
        {
            int iterationCounter = IterationLimit;  //assign IterationLimit
            bool isAssignementChanged = true;

            while (isAssignementChanged && iterationCounter > 0)
            {
                isAssignementChanged = false;
                for (int j = 0; j < ClusterList.Count; j++)
                {
                    List<KeyValuePair<HyperCluster, double>> hyperClusterToProximityList = new List<KeyValuePair<HyperCluster, double>>();
                    Cluster cluster = ClusterList[j];
                    double clusterVectorMagnitude = CalculateVectorMagnitude(cluster.ClusterVector);
                    double proximityThreshold = clusterVectorMagnitude / (bValue + rangeLimit * ItemSize);  // ||C_j||/(b+1)

                    //Calculate proximity values for cluster and hyperClusters
                    for (int i = 0; i < HyperClusterList.Count; i++)
                    {
                        double hyperClusterVectorMagnitude = CalculateVectorMagnitude(HyperClusterList[i].HyperClusterVector);
                        double proximity = CaulculateVectorIntersectionMagnitude(cluster.ClusterVector, HyperClusterList[i].HyperClusterVector) / (bValue + hyperClusterVectorMagnitude); //prox = ||HC_i and C_j ||/ (b + ||HC_j||) > proxThres
                        if (proximity > proximityThreshold)
                        {
                            hyperClusterToProximityList.Add(new KeyValuePair<HyperCluster, double>(HyperClusterList[i], proximity));
                        }
                    }

                    if (hyperClusterToProximityList.Count > 0)
                    {
                        hyperClusterToProximityList.Sort((x, y) => -1 * x.Value.CompareTo(y.Value));  //sorting in place in descending order

                        //search from the maximum proximity to smallest
                        for (int i = 0; i < hyperClusterToProximityList.Count; i++)
                        {
                            HyperCluster newHyperCluster = hyperClusterToProximityList[i].Key;
                            double vigilance = CaulculateVectorIntersectionMagnitude(newHyperCluster.HyperClusterVector, cluster.ClusterVector) / clusterVectorMagnitude;   //(vig = || HC_i and C_j|| / ||C_j||) >= p
                            if (vigilance >= p2Value) //passed all tests and has max proximity
                            {
                                if (ClusterToHyperClusterMap.ContainsKey(cluster)) //find cluster with this item
                                {
                                    HyperCluster previousHyperCluster = ClusterToHyperClusterMap[cluster];
                                    if (ReferenceEquals(newHyperCluster, previousHyperCluster)) break;    //if the best is the same, then it will break (not considered others)                                    
                                    if (previousHyperCluster.RemoveClusterFromHyperCluster(cluster) == false)      //the cluster is empty
                                    {
                                        HyperClusterList.Remove(previousHyperCluster);
                                    }
                                }
                                //Add item to the current hyperCluster
                                newHyperCluster.AddClusterToHyperCluster(cluster);
                                ClusterToHyperClusterMap[cluster] = newHyperCluster;
                                isAssignementChanged = true;

                                break;
                            }
                        }
                    }

                    if (ClusterToHyperClusterMap.ContainsKey(cluster) == false)
                    {
                        HyperCluster newHyperCluster = new HyperCluster(cluster);
                        HyperClusterList.Add(newHyperCluster);
                        ClusterToHyperClusterMap.Add(cluster, newHyperCluster);
                        isAssignementChanged = true;
                    }
                }

                iterationCounter--;
            }
        }

        public SubjectItem SimilarTo(SubjectItem item)
        {
            StringBuilder outputText = new StringBuilder();
            double tempItemSimilarSum = 0;
            double itemSimilarSum = 0;
            SubjectItem itemSimilar = null;
            Cluster cluster = null;

            ItemToClusterMap.TryGet(item.Id, out cluster);
            if (cluster == null)
            {
                //tak jest u (Chin Xi) czy aby dodawac? w cluster powinny byc elementy, ktore mamy na ItemList, inaczej moze powstac niespojnosc!!!
                //to tworzy cluster, ale moze nie byc z nim polaczenia poprzez item, gdy ten item nie nalezy do ItemList
                //AssignCluster(item);  //przedyskutowac z Darkiem
            }
            else
            {
                //for each item in cluster find the closest
                List<SubjectItem> clusterItemList = cluster.ClusterItemList;
                for (int i = 0; i < clusterItemList.Count; i++)
                {
                    if (!ReferenceEquals(item, clusterItemList[i]))
                    {
                        tempItemSimilarSum = CaulculateVectorIntersectionMagnitude(item.Vector, clusterItemList[i].Vector) / CalculateVectorMagnitude(clusterItemList[i].Vector);    //||item(Reference) and itemFromCluster||/ ||itemFromcluster|| => max ||
                        if (itemSimilarSum == 0 || itemSimilarSum < tempItemSimilarSum)
                        {
                            itemSimilarSum = tempItemSimilarSum;
                            itemSimilar = clusterItemList[i];
                        }
                    }
                }

                if (itemSimilar != null)
                {
                    outputText.Append(" Most similiar taste have item " + itemSimilar.Name + "\r\n\r\n");
                }
                else
                {
                    outputText.Append(" There is no similiar item " + item.Name + "\r\n\r\n");
                }
            }
            Debug.WriteLine(outputText.ToString());

            return itemSimilar;
        }

        public SubjectItem SimilarInGroupsTo(SubjectItem item)
        {
            StringBuilder outputText = new StringBuilder();
            double tempItemSimilarSum = 0;
            double itemSimilarSum = 0;
            SubjectItem itemSimilar = null;
            Cluster cluster = null;

            ItemToClusterMap.TryGet(item.Id, out cluster);
            if (cluster == null)
            {
                //czy aby dodawac? w cluster powinny byc elementy, ktore mamy na ItemList, inaczej moze powstac niespojnosc!!!
                //AssignCluster(item);    //przedyskutowac z Darkiem
            }
            else
            {
                HyperCluster hyperCluster = ClusterToHyperClusterMap[cluster];
                List<SubjectItem> hyperClusterItemList = hyperCluster.GetHyperClusterItemList();
                for (int i = 0; i < hyperClusterItemList.Count; i++)
                {

                    if (!ReferenceEquals(item, hyperClusterItemList[i]))
                    {
                        tempItemSimilarSum = CaulculateVectorIntersectionMagnitude(item.Vector, hyperClusterItemList[i].Vector) / CalculateVectorMagnitude(hyperClusterItemList[i].Vector);    //||item(Reference) and itemFromCluster||/ ||itemFromcluster|| => max ||
                        if (itemSimilarSum == 0 || itemSimilarSum < tempItemSimilarSum)
                        {
                            itemSimilarSum = tempItemSimilarSum;
                            itemSimilar = hyperClusterItemList[i];
                        }
                    }
                }

                if (itemSimilar != null)
                {
                    outputText.Append(" Most similiar taste in hyper cluster have item " + itemSimilar.Name + "\r\n\r\n");
                }
                else
                {
                    outputText.Append(" There is no simiilar item in hyper cluster " + item.Name + "\r\n\r\n");
                }
            }
            Debug.WriteLine(outputText.ToString());

            return itemSimilar;
        }

        public SubjectItem SimilarInOtherGroupsTo(SubjectItem item)
        {
            StringBuilder outputText = new StringBuilder();
            double tempItemSimilarSum = 0;
            double itemSimilarSum = 0;
            SubjectItem itemSimilar = null;

            if (!ItemToClusterMap.TryGet(item.Id, out Cluster cluster))
            {
                //czy aby dodawac? w cluster powinny byc elementy, ktore mamy na ItemList, inaczej moze powstac niespojnosc!!!
                //AssignCluster(item); //przedyskutowac z Darkiem
            }
            else
            {
                HyperCluster hyperCluster = ClusterToHyperClusterMap[cluster];
                for (int j = 0; j < hyperCluster.ClusterList.Count; j++)
                {
                    if (!ReferenceEquals(cluster, hyperCluster.ClusterList[j]))    //find in clusters different than item
                    {
                        List<SubjectItem> clusterItemList = hyperCluster.ClusterList[j].ClusterItemList;
                        for (int i = 0; i < clusterItemList.Count; i++)
                        {
                            tempItemSimilarSum = CaulculateVectorIntersectionMagnitude(item.Vector, clusterItemList[i].Vector) / CalculateVectorMagnitude(clusterItemList[i].Vector);    //||item(Reference) and itemFromCluster||/ ||itemFromcluster|| => max ||
                            if (itemSimilarSum == 0 || itemSimilarSum < tempItemSimilarSum)
                            {
                                itemSimilarSum = tempItemSimilarSum;
                                itemSimilar = clusterItemList[i];
                            }
                        }
                    }
                }

                if (itemSimilar != null)
                {
                    outputText.Append(" Most similiar taste in hyper cluster (other clusters) have item " + itemSimilar.Name + "\r\n\r\n");
                }
                else
                {
                    outputText.Append(" There is no simiilar item in hyper cluster (other clusters) " + item.Name + "\r\n\r\n");
                }
            }
            Debug.WriteLine(outputText.ToString());

            return itemSimilar;
        }

        #endregion


        #region Static methods ---------------
        //to moze zrobic pozniej przez interfejsy?

        //In general, they can be different for Cluster than for Item
        public static double[] CalculateIntersection(List<SubjectItem> input, double[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = input[0].Vector[i];
                for (int j = 1; j < input.Count; j++)
                {
                    output[i] = Math.Min(output[i], input[j].Vector[i]);
                }
            }
            return output;
        }
        public static double[] CalculateSummary(List<SubjectItem> input, double[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    output[i] += input[j].Vector[i];
                }
            }

            return output;
        }

        //it allows to use various update functions dependent on all input feature vectors
        public static double[] UpdateIntersectionByLast(List<SubjectItem> input, double[] output)
        {
            int n = input.Count - 1;
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = Math.Min(output[i], input[n].Vector[i]);
            }
            return output;
        }
        public static double[] UpdateSummaryByLast(List<SubjectItem> input, double[] output)
        {
            int n = input.Count - 1;
            for (int i = 0; i < output.Length; i++)
            {
                output[i] += input[n].Vector[i];
            }
            return output;
        }

        //In general, they can be different for Cluster than for Item
        public static double[] CalculateClusterIntersection(List<Cluster> input, double[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = input[0].ClusterVector[i];
                for (int j = 1; j < input.Count; j++)
                {
                    output[i] = Math.Min(output[i], input[j].ClusterVector[i]);
                }
            }
            return output;
        }
        public static double[] CalculateClusterSummary(List<Cluster> input, double[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    output[i] += input[j].ClusterVector[i];
                }
            }

            return output;
        }

        //it allows to use various update functions dependent on all input feature vectors
        public static double[] UpdateClusterIntersectionByLast(List<Cluster> input, double[] output)
        {
            int n = input.Count - 1;
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = Math.Min(output[i], input[n].ClusterVector[i]);
            }
            return output;
        }
        public static double[] UpdateClusterSummaryByLast(List<Cluster> input, double[] output)
        {
            int n = input.Count - 1;
            for (int i = 0; i < output.Length; i++)
            {
                output[i] += input[n].ClusterVector[i];
            }
            return output;
        }

        public static List<SubjectItem> NormalizeItemList(List<SubjectItem> featureItemList)
        {
            List<SubjectItem> normalizedItemList = new List<SubjectItem>();

            int length;
            for (int i = 0; i < featureItemList.Count; i++)
            {
                length = featureItemList[0].Vector.Length;
                double[] featureVector = new double[length];
                for (int j = 0; j < length; j++)
                {
                    featureVector[j] = featureItemList[i].Vector[j] / 10.00;
                }
                normalizedItemList.Add(new SubjectItem(featureItemList[i].Id, featureItemList[i].Name, featureVector));
            }
            return normalizedItemList;
        }

        static public double CalculateVectorMagnitude(double[] vector)
        {
            double result = 0;
            for (int i = 0; i < vector.Length; ++i)
            {
                result += vector[i];
            }
            return result;
        }

        static public double CaulculateVectorIntersectionMagnitude(double[] vector1, double[] vector2)
        {
            double result = 0;

            for (int i = 0; i < vector1.Length; ++i)
            {
                result += Math.Min(vector1[i], vector2[i]);
            }

            return result;
        }

        #endregion

        #region Auxuliary methods ------------

        public void LoadFile(string fileLocation)
        {
            string line;
            NameList.Clear();
            NameList.Add("Name");

            StreamReader file = new StreamReader(fileLocation);

            while ((line = file.ReadLine()) != null)
            {
                if (line == "ItemList")
                {
                    break;
                }
            }

            if (line == null)
            {
                throw new Exception("ART File does not have a section marked ItemList!");
            }
            else
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "--")
                    {
                        break;
                    }
                    else
                    {
                        NameList.Add(line);
                    }
                }
                ItemSize = NameList.Count - 1;

                //Finished reading itemList, now read all the people
                int featureItemId = 0;
                while ((line = file.ReadLine()) != null)
                {
                    string featureName = line;
                    line = file.ReadLine();
                    double[] featureVector = new double[ItemSize];
                    int i = 0;
                    while ((line != null) && (line != "--"))
                    {
                        featureVector[i] = Int32.Parse(line); /// 10.00; //here
                                                              /// read the
                                                              /// values, but
                                                              /// normalize in
                                                              /// other part.
                        ++i;
                        line = file.ReadLine();
                    }

                    if (line == "--")
                    {
                        if (i != ItemSize)
                        {
                            //For those who don't have a fully specified prefList, fill with 0s for rest. 
                            for (int j = i; j < ItemSize; ++j)
                            {
                                featureVector[j] = 0;
                            }
                        }
                        ItemList.Add(new SubjectItem(featureItemId, featureName, featureVector));
                        featureItemId++;
                    }
                }
            }

            file.Close();
        }

        #endregion

    }
}
