using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Web.ApiModels
{
    public class ReasonDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LastChangedBy { get; set; }
        public DateTime LastChangedDateTime { get; set; }

        //ToDo:  This could be replace by AutoMapper
        public static ReasonDTO FromReason(Reason item)
        {
            return new ReasonDTO()
            {
                Id = item.Id,
                Description = item.Description,
                LastChangedBy = item.LastChangedBy,
                LastChangedDateTime = item.LastChangedDateTime
            };
        }
    }
}
