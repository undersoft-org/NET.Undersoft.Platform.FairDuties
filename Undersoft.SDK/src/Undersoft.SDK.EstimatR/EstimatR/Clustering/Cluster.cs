namespace EstimatR
{
    //RR: pozniej zamienie nazwe na wlasciwa
    public class Cluster
    {
        //----- remove for debugging and tests only
        //public double tempClusterVectorMagnitude { get; set; }  // remove for debugging and tests only
        //public double tempClusterVectorSummaryMagnitude { get; set; }  // remove for debugging and tests only
        //----- remove for debugging and tests only

        /// <summary>
        /// The non-negative integral vector that represents a cluster. We use
        /// int instead of unsigned for simplicity.
        /// </summary>
        public double[] ClusterVector { get; set; }

        /// <summary>
        /// The list of people that are included in this cluster.
        /// </summary>
        public List<SubjectItem> ClusterItemList { get; set; }

        /// <summary>
        /// The summar vector that is associated with this cluster
        /// </summary>
        public double[] ClusterVectorSummary { get; set; }

        /// <summary>
        /// Constructor. Cluster vector is set to the initial feature vector. 
        /// </summary>
        /// <param name="item">The item used to construct this cluster</param>
        public Cluster(SubjectItem item)
        {
            //resulting values should be copied
            ClusterVector = new double[item.Vector.Length];
            Array.Copy(item.Vector, ClusterVector, item.Vector.Length);
            ClusterVectorSummary = new double[item.Vector.Length];
            Array.Copy(item.Vector, ClusterVectorSummary, item.Vector.Length);
            ClusterItemList = new List<SubjectItem>();
            ClusterItemList.Add(item);

            //----- remove for debugging and tests only
            //tempClusterVectorMagnitude = HyperAdaptiveResonainceTheory.CalculateVectorMagnitude(ClusterVector);   //remove for debugging and tests only
            //tempClusterVectorSummaryMagnitude = HyperAdaptiveResonainceTheory.CalculateVectorMagnitude(ClusterVectorSummary); //remove for debugging and tests only                                                                                                                

        }

        /// <summary>
        /// Remove a item from this cluster and update cluster Vector
        /// accordingly (basd on other assigned items) Return false if ItemList
        /// is empty
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public bool RemoveItemFromCluster(SubjectItem item)
        {
            if (ClusterItemList.Remove(item) == true)
            {
                if (ClusterItemList.Count > 0)   //recalculate vector summary only if not empty
                {
                    HyperAdaptiveResonainceTheory.CalculateIntersection(ClusterItemList, ClusterVector);
                    HyperAdaptiveResonainceTheory.CalculateSummary(ClusterItemList, ClusterVectorSummary);

                    //----- remove for debugging and tests only
                    //tempClusterVectorMagnitude = HyperAdaptiveResonainceTheory.CalculateVectorMagnitude(ClusterVector);   //remove for debugging and tests only
                    //tempClusterVectorSummaryMagnitude = HyperAdaptiveResonainceTheory.CalculateVectorMagnitude(ClusterVectorSummary); //remove for debugging and tests only                                                                                                                
                    //----- remove for debugging and tests only

                }
            }
            return ClusterItemList.Count > 0;
        }

        /// <summary>
        /// Add a item to this cluster and adjust the cluster vector, itemship
        /// list and sum vector accordingly.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void AddItemToCluster(SubjectItem item)
        {
            if (!ClusterItemList.Contains(item))
            {
                ClusterItemList.Add(item);
                HyperAdaptiveResonainceTheory.UpdateIntersectionByLast(ClusterItemList, ClusterVector);
                HyperAdaptiveResonainceTheory.UpdateSummaryByLast(ClusterItemList, ClusterVectorSummary);

                //----- remove for debugging and tests only
                //tempClusterVectorMagnitude = HyperAdaptiveResonainceTheory.CalculateVectorMagnitude(ClusterVector);   //remove for debugging and tests only
                //tempClusterVectorSummaryMagnitude = HyperAdaptiveResonainceTheory.CalculateVectorMagnitude(ClusterVectorSummary); //remove for debugging and tests only                                                                                                                
                //----- remove for debugging and tests only
            }
        }

        //Move here(?) Calculate/Update VectorItersection & VectorSummary
        //Individual for class Cluster(?) Calculate/Update VectorItersection & VectorSummary for Cluster & HyperCluster?
        // ale to zamyka przyszly polimorfizm

    }

}
