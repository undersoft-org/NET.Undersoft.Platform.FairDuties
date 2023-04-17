/*************************************************
   Copyright (c) 2021 Undersoft

   System.Instant.Link.cs
   
   @project: Vegas.Sdk
   @stage: Development
   @author: Dariusz Hanc
   @date: (29.05.2021) 
   @licence MIT
 *************************************************/
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Instant;
using System.Threading;
using System.Threading.Tasks;
using System.Uniques;

namespace UltimatR
{     
    public enum Towards
    {
        None,
        ToSet,
        ToSingle,
        SetToSet 
    }


    public interface IDsoRelation : IUnique
    {
        Towards Towards { get; set; }

        MemberRubric LinkedMember { get; }
    }

    public abstract class DsoRelation : IDsoRelation
    {
        protected Uscn serialcode;

        protected DsoRelation()
        {          
        }

        public virtual Towards Towards { get; set; }

        public virtual IUnique Empty => Uscn.Empty;       

        public virtual Uscn SerialCode { get => serialcode; set => serialcode = value; }

        public virtual ulong UniqueKey { get => serialcode.UniqueKey; set => serialcode.UniqueKey = value; }
        public virtual ulong UniqueType { get => serialcode.UniqueType; set => serialcode.UniqueType = value; }

        public virtual int CompareTo(IUnique other)
        {
            return serialcode.CompareTo(other);
        }
        public virtual bool Equals(IUnique other)
        {
            return serialcode.Equals(other);
        } 
        public virtual byte[] GetBytes()
        {
            return serialcode.GetBytes();
        }
        public virtual byte[] GetUniqueBytes()
        {
            return serialcode.GetUniqueBytes();
        }

        public virtual MemberRubric LinkedMember { get; }
    }   
}
