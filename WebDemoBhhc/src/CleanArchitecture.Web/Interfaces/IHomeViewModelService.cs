using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Interfaces
{
    public interface IHomeViewModelService
    {
        Reason GetReasonById(int id);
        IEnumerable<Reason> GetReasons(int languageOption);
        void AddReason(Reason reason);
        void UpdateReason(Reason reason);
        void DeleteReason(Reason reason);
    }
}
