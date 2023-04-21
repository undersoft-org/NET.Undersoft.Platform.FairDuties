namespace Undersoft.AEP
{
    public class AllocModel<V> : AllocModel where V : IAllocable
    {
        public AllocModel() : base()
        {
            base.Source = typeof(V).New<V>();
        }

        public AllocModel(params object[] arguments) : base()
        {
            base.Source = typeof(V).New<V>(arguments);
        }

        public new V Source
        {
            get => (V)base.Source;
            set => base.Source = value;
        }

        public new AllocModel<V> Target
        {
            get => (AllocModel<V>)base.Target;
            set => base.Target = value;
        }

        public new V Current => Target.Source;
    }

    public class AllocModel : Alloc, IAllocModel
    {
        public AllocModel()
        {
            Target = this;
        }

        public IAllocable Source { get; set; }

        public IAllocModel Target { get; set; }

        public IAllocable Current => Target.Source;
    }
}
