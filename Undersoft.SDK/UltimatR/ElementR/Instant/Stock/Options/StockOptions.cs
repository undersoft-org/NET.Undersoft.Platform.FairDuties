﻿using System.Runtime.InteropServices;

namespace System.Instant.Stock
{
    public class StockOptions<T> : StockOptions
    {
        public StockOptions() : base(new Figures<T>().Combine()) { }

        public StockOptions(IFigures figures) : base(figures) { }
    }

    public class StockOptions
    {
        public StockOptions() { }

        public StockOptions(IFigures figures) : this(figures.FigureType, figures.FigureSize)
        {
            this.figures = figures;
            Type = figures.Type;
        }

        public StockOptions(Type type) : this(new Figures(type, FigureMode.Reference).Combine()) { }

        public StockOptions(Type type, int blockSize)
        {
            ItemType = type;
            blocksize = blockSize;
        }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        protected string stockname;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        protected string basepath;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        protected string stockpath;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        protected string sectorsuffix;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        protected string regitrysuffix;
        protected ushort sectorsize = 25 * 1000;
        protected ushort clustersize = 10;
        protected int blocksize = 0;
        protected bool oversized = false;
        protected bool isowner = true;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        protected string typestring;
        protected Type type;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        protected string itemtypestring;
        protected Type itemtype;
        protected IFigures figures;

        public IFigures Figures
        {
            get => figures;
            set => figures = value;
        }

        public Type Type
        {
            get =>
                type ??=
                    typestring == null
                        ? type = Type.GetType(typestring = typeof(byte[]).FullName)
                        : type = Type.GetType(typestring);
            set
            {
                typestring = value.FullName;
                type = value;
            }
        }
        public Type ItemType
        {
            get =>
                itemtype ??=
                    itemtypestring == null
                        ? itemtype = Type.GetType(itemtypestring = typeof(byte[]).FullName)
                        : itemtype = Type.GetType(itemtypestring);
            set
            {
                itemtypestring = value.FullName;
                itemtype = value;
            }
        }

        public virtual string RegistrySuffix
        {
            get => regitrysuffix ??= "str";
            set => regitrysuffix = value;
        }

        public virtual string SectorSuffix
        {
            get => sectorsuffix ??= "std";
            set => sectorsuffix = value;
        }

        public virtual string FileName => $"{type.Name}.{SectorSuffix}";

        public virtual string StockName => $"{BasePath}__{type.FullName}.{SectorSuffix}";

        public virtual string FilePath => $"{BasePath}/{type.Name}/{FileName}";

        public virtual string StockPath => $"{BasePath}/{type.Name}";

        public virtual string BasePath
        {
            get => basepath ??= "MMFS";
            set => basepath = value;
        }

        public virtual ushort SectorSize
        {
            get => sectorsize;
            set => sectorsize = value;
        }

        public virtual ushort ClusterSize
        {
            get => clustersize;
            set => clustersize = value;
        }

        public virtual bool Oversized
        {
            get => oversized;
            set => oversized = value;
        }

        public virtual bool IsOwner
        {
            get => isowner;
            set => isowner = value;
        }

        public virtual int BlockSize
        {
            get => blocksize;
            set => blocksize = value;
        }
    }
}
