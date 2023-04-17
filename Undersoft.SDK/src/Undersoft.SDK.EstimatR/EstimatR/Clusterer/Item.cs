namespace EstimatR
{
    public class Item
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public double[] Vector { get; set; }

        public Item(long id, string name, double[] vectors)
        {
            Id = id;
            Name = name;

            Vector = vectors;
        }

        public Item(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Vector = item.Vector;
        }
    }

}
