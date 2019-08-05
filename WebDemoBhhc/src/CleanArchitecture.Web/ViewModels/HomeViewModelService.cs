using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using CleanArchitecture.Web.Interfaces;
using System.Collections.Generic;

namespace CleanArchitecture.Web.ViewModels
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository _reasonRepository;
        private readonly ITranslate _translateService;

        public HomeViewModelService(IRepository reasonRepository, ITranslate translateService)
        {
            _reasonRepository = reasonRepository;
            _translateService = translateService;
        }

        public IEnumerable<Reason> GetReasons(int languageOption)
        {
            var reasons = _reasonRepository.ListAll<Reason>();

            if(languageOption != (int)LanguageOption.English)
            {
                foreach (var reason in reasons)
                {
                    reason.Description = _translateService.GetTranslation(reason.Description, languageOption);
                }
            }

            return reasons;
        }

        public void AddReason(Reason reason)
        {
            _reasonRepository.Add<Reason>(reason);
        }

        public Reason GetReasonById(int id)
        {
            return _reasonRepository.GetById<Reason>(id);
        }

        public void UpdateReason(Reason reason)
        {
            _reasonRepository.Update<Reason>(reason);
        }

        public void DeleteReason(Reason reason)
        {
            _reasonRepository.Delete<Reason>(reason);
        }
    }
}
