using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using System.Linq;

namespace CleanArchitecture.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IRepository reasonRepository)
        {
            if (reasonRepository.ListAll<Reason>().Any()) return 0;

            reasonRepository.Add(new Reason
            {
                Description = "Berkshire Hathaway Homestate Companies are recognized as a leaders in the insurance industry",
                LastChangedBy = "Bob Beck"
            });
            reasonRepository.Add(new Reason
            {
                Description = "Berkshire Hathaway Homestate Companies are well respected company with quality offerings",
                LastChangedBy = "Susie Baxter"
            });
            reasonRepository.Add(new Reason
            {
                Description = "Berkshire Hathaway Homestate Companies are big companies with a small company feel",
                LastChangedBy = "Dolf Lungren"
            });

            return reasonRepository.ListAll<Reason>().Count;
        }
    }
}
