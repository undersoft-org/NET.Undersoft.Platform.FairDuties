using System.Uniques;

namespace EstimatR
{
    public class SubjectItem : UniqueObject
    {
        public string Name { get; set; }

        public double[] Vector { get; set; }

        public SubjectItem(long id, string name, double[] vectors)
        {
            Id = id;
            Name = name;

            Vector = vectors;
        }

        public SubjectItem(SubjectItem item)
        {
            Id = item.Id;
            Name = item.Name;
            Vector = item.Vector;
        }
    }

}
