namespace System.Threading.Workflow
{
    using System.Extract;
    using System.Linq;
    using System.Series;
    using System.Uniques;

    public class NoteEvoker : Catalog<WorkItem>, IUnique
    {
        public IDeck<WorkItem> RelatedWorks = new Board<WorkItem>();
        public IDeck<string> RelatedWorkNames = new Board<string>();
        private Uscn SerialCode;

        public NoteEvoker(WorkItem sender, WorkItem recipient, params WorkItem[] relayWorks)
        {
            Sender = sender;
            SenderName = sender.Worker.Name;
            Recipient = recipient;
            RecipientName = recipient.Worker.Name;
            SerialCode = new Uscn(
                SenderName.UniqueKey(RecipientName.UniqueKey()),
                RecipientName.UniqueKey()
            );
            RelatedWorks.Add(relayWorks);
            RelatedWorkNames.Add(RelatedWorks.Select(rn => rn.Worker.Name));
        }

        public NoteEvoker(WorkItem sender, WorkItem recipient, params string[] relayNames)
        {
            Sender = sender;
            SenderName = sender.Name;
            Recipient = recipient;
            RecipientName = recipient.Name;
            SerialCode = new Uscn(
                SenderName.UniqueKey(RecipientName.UniqueKey()),
                RecipientName.UniqueKey()
            );
            RelatedWorkNames.Add(relayNames);
            var namekeys = relayNames.ForEach(s => s.UniqueKey());
            RelatedWorks.Add(
                Sender.Case
                    .AsValues()
                    .Where(m => m.Any(k => namekeys.Contains(k.UniqueKey)))
                    .SelectMany(os => os.AsValues())
                    .ToList()
            );
        }

        public NoteEvoker(WorkItem sender, string recipientName, params WorkItem[] relayWorks)
        {
            Sender = sender;
            SenderName = sender.Name;
            RecipientName = recipientName;
            SerialCode = new Uscn(
                SenderName.UniqueKey(RecipientName.UniqueKey()),
                RecipientName.UniqueKey()
            );
            var rcpts = Sender.Case
                .AsValues()
                .Where(m => m.ContainsKey(recipientName))
                .SelectMany(os => os.AsValues())
                .ToArray();
            Recipient = rcpts.FirstOrDefault();
            RelatedWorks.Add(relayWorks);
            RelatedWorkNames.Add(RelatedWorks.Select(rn => rn.Worker.Name));
        }

        public NoteEvoker(WorkItem sender, string recipientName, params string[] relayNames)
        {
            Sender = sender;
            SenderName = sender.Worker.Name;
            var rcpts = Sender.Case
                .AsValues()
                .Where(m => m.ContainsKey(recipientName))
                .SelectMany(os => os.AsValues())
                .ToArray();
            Recipient = rcpts.FirstOrDefault();
            RecipientName = recipientName;
            SerialCode = new Uscn(
                SenderName.UniqueKey(RecipientName.UniqueKey()),
                RecipientName.UniqueKey()
            );
            RelatedWorkNames.Add(relayNames);
            var namekeys = relayNames.ForEach(s => s.UniqueKey());
            RelatedWorks.Add(
                Sender.Case
                    .AsValues()
                    .Where(m => m.Any(k => namekeys.Contains(k.UniqueKey)))
                    .SelectMany(os => os.AsValues())
                    .ToList()
            );
        }

        public IUnique Empty => new Usid();

        public string EvokerName { get; set; }

        public EvokerType EvokerType { get; set; }

        public WorkItem Recipient { get; set; }

        public string RecipientName { get; set; }

        public WorkItem Sender { get; set; }

        public string SenderName { get; set; }

        public new ulong UniqueKey
        {
            get => SerialCode.UniqueKey;
            set => SerialCode.SetUniqueKey(value);
        }

        public ulong UniqueType
        {
            get => SerialCode.UniqueType;
            set => SerialCode.SetUniqueSeed(value);
        }

        public int CompareTo(IUnique other)
        {
            return SerialCode.CompareTo(other);
        }

        public bool Equals(IUnique other)
        {
            return SerialCode.Equals(other);
        }

        public byte[] GetBytes()
        {
            return ($"{SenderName}.{RecipientName}").GetBytes();
        }

        public byte[] GetUniqueBytes()
        {
            return SerialCode.GetUniqueBytes();
        }
    }
}
