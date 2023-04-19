namespace UltimatR
{

    public class LinkDto : Dto
    {
        public virtual long LeftEntityId { get; set; }

        public virtual long RightEntityId { get; set; }
    }
}