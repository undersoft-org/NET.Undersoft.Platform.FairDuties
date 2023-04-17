namespace UltimatR
{

    public class DtoRelation : Dto
    {
        public virtual long LeftEntityId { get; set; }

        public virtual long RightEntityId { get; set; }
    }
}