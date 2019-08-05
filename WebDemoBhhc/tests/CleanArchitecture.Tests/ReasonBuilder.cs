using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Tests
{
    public class ReasonBuilder
    {
        private readonly Reason _reason = new Reason();

        public ReasonBuilder Id(int id)
        {
            _reason.Id = id;
            return this;
        }

        public ReasonBuilder Description(string description)
        {
            _reason.Description = description;
            return this;
        }

        public ReasonBuilder LastChangedBy(string lastChangedBy)
        {
            _reason.LastChangedBy = lastChangedBy;
            return this;
        }

        //  LastChangedDate
        public ReasonBuilder LastChangedDateTime(DateTime lastChangedDateTime)
        {
            _reason.LastChangedDateTime = lastChangedDateTime;
            return this;
        }

        public Reason Build() => _reason;
    }
}
