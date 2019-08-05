using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Web
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {

            //Reasons

            //Remove any existing data
            var reasons = dbContext.Reasons;
            foreach (var item in reasons)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            //Add seed data
            dbContext.Reasons.Add(new Reason()
            {
                Description = "Description Test 1"
            });
            dbContext.Reasons.Add(new Reason()
            {
                Description = "Description Test 2"
            });
            dbContext.SaveChanges();
        }



    }
}
