namespace Undersoft.AEP.Core
{
    public class Usage<V> : Usage where V : IUsability
    {
        public Usage() : base()
        {
            base.Target = typeof(V).New<V>();
        }

        public Usage(params object[] arguments) : base()
        {
            base.Target = typeof(V).New<V>(arguments);
        }

        public new V Target
        {
            get => (V)base.Target;
            set => base.Target = value;
        }

        public new Usage<V> Used
        {
            get => (Usage<V>)base.Used;
            set => base.Used = value;
        }

        public new V Current
        {
            get => (V)base.Current;
        }
    }

    public class Usage : Raw.Usage, IUsage
    {
        public Usage()
        {
            Used = this;
        }

        public ISource Source { get; set; }

        public IUsability Target { get; set; }

        public IUsage Used { get; set; }

        public IUsability Current => Used.Target;
    }
}
