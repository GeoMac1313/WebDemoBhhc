using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchitecture.Core.Entities 
{
    public class Reason : BaseEntity
    {
        //public int Id { get; set; }
        public string Description { get; set; }

        [Display(Name = "Changed")]
        public string LastChangedBy { get; set; }
        public DateTime LastChangedDateTime { get; set; }
    }
}
