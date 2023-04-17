using System;
using System.Collections.Generic;

namespace EstimatR
{
    //RR: pozniej zamienie nazwe na wlasciwa
    public class Cluster
    {
        //----- remove for debugging and tests only
        public double tempClusterVectorMagnitude { get; set; }  // remove for debugging and tests only
        public double tempClusterVectorSummaryMagnitude { get; set; }  // remove for debugging and tests only
        //----- remove for debugging and tests only

        /// <summary>
        /// The non-negative integral vector that represents a cluster. We use
        /// int instead of unsigned for simplicity.
        /// </summary>
        public double[] ClusterVector { get; set; }

        /// <summary>
        /// The list of people that are included in this cluster.
        /// </summary>
        public List<Item> ClusterItemList { get; set; }

        /// <summary>
        /// The summar vector that is associated with this cluster
        /// </summary>
        public double[] ClusterVectorSummary { get; set; }

        /// <summary>
        /// Constructor. Cluster vector is set to the initial feature vector. 
        /// </summary>
        /// <param name="item">The item used to construct this cluster</param>
        public Cluster(Item item)
        {
            //resulting values should be copied
            ClusterVector = new double[item.Vector.Length];
            Array.Copy(item.Vector, ClusterVector, item.Vector.Length);
            ClusterVectorSummary = new double[item.Vector.Length];
            Array.Copy(item.Vector, ClusterVectorSummary, item.Vector.Length);
            ClusterItemList = new List<Item>();
            ClusterItemList.Add(item);

            //----- remove for debugging and tests only
            tempClusterVectorMagnitude = Clusterer.CalculateVectorMagnitude(ClusterVector);   //remove for debugging and tests only
            tempClusterVectorSummaryMagnitude = Clusterer.CalculateVectorMagnitude(ClusterVectorSummary); //remove for debugging and tests only                                                                                                                

        }

        /// <summary>
        /// Remove a item from this cluster and update cluster Vector
        /// accordingly (basd on other assigned items) Return false if ItemList
        /// is empty
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public bool RemoveItemFromCluster(Item item)
        {
            if (ClusterItemList.Remove(item) == true)
            {
                if (ClusterItemList.Count > 0)   //recalculate vector summary only if not empty
                {
                    Clusterer.CalculateIntersection(ClusterItemList, ClusterVector);
                    Clusterer.CalculateSummary(ClusterItemList, ClusterVectorSummary);

                    //----- remove for debugging and tests only
                    tempClusterVectorMagnitude = Clusterer.CalculateVectorMagnitude(ClusterVector);   //remove for debugging and tests only
                    tempClusterVectorSummaryMagnitude = Clusterer.CalculateVectorMagnitude(ClusterVectorSummary); //remove for debugging and tests only                                                                                                                
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
        public void AddItemToCluster(Item item)
        {
            if (!ClusterItemList.Contains(item))
            {
                ClusterItemList.Add(item);
                Clusterer.UpdateIntersectionByLast(ClusterItemList, ClusterVector);
                Clusterer.UpdateSummaryByLast(ClusterItemList, ClusterVectorSummary);

                //----- remove for debugging and tests only
                tempClusterVectorMagnitude = Clusterer.CalculateVectorMagnitude(ClusterVector);   //remove for debugging and tests only
                tempClusterVectorSummaryMagnitude = Clusterer.CalculateVectorMagnitude(ClusterVectorSummary); //remove for debugging and tests only                                                                                                                
                //----- remove for debugging and tests only
            }
        }

        //Move here(?) Calculate/Update VectorItersection & VectorSummary
        //Individual for class Cluster(?) Calculate/Update VectorItersection & VectorSummary for Cluster & HyperCluster?
        // ale to zamyka przyszly polimorfizm

    }

}
