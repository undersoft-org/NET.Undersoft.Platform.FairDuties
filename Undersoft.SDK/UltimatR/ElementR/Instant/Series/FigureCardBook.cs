﻿namespace System.Instant
{
    using System.Collections.Generic;
    using System.Series;

    public abstract class FigureBaseAlbum : AlbumBase<IFigure>
    {
        public FigureBaseAlbum() : base() { }

        public FigureBaseAlbum(ICollection<IFigure> collections) : base(collections) { }

        public FigureBaseAlbum(IEnumerable<IFigure> collections) : base(collections) { }

        public FigureBaseAlbum(int capacity) : base(capacity) { }

        public override ICard<IFigure>[] EmptyDeck(int size)
        {
            return new Card<IFigure>[size];
        }

        public override ICard<IFigure> EmptyCard()
        {
            return new Card<IFigure>();
        }

        public override ICard<IFigure>[] EmptyCardTable(int size)
        {
            return new Card<IFigure>[size];
        }

        public override ICard<IFigure> NewCard(ICard<IFigure> value)
        {
            return new Card<IFigure>(value);
        }

        public override ICard<IFigure> NewCard(IFigure value)
        {
            return new Card<IFigure>(value);
        }

        public override ICard<IFigure> NewCard(object key, IFigure value)
        {
            return new Card<IFigure>(key, value);
        }

        public override ICard<IFigure> NewCard(ulong key, IFigure value)
        {
            return new Card<IFigure>(key, value);
        }

        internal override bool InnerAdd(IFigure value)
        {
            return InnerAdd(NewCard(value));
        }

        protected override ICard<IFigure> InnerPut(IFigure value)
        {
            return InnerPut(NewCard(value));
        }
    }
}
