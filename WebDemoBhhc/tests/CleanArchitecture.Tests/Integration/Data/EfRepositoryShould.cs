using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace CleanArchitecture.Tests.Integration.Data
{
    public class EfRepositoryShould
    {
        private AppDbContext _dbContext;

        private static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("TestDatabase")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        /// <summary>
        /// Test that we can add an item and set the ID via repository
        /// </summary>
        [Fact]
        public void AddReasonAndSetId()
        {
            //Arrange
            var repository = GetRepository();
            var item = new ReasonBuilder().Build();

            //Act
            item.Description = "This is a test!";
            item.LastChangedBy = "Bob";
            item.LastChangedDateTime = DateTime.Now;

            repository.Add(item);

            var newItem = repository.ListAll<Reason>().FirstOrDefault();

            //Assert
            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }

        /// <summary>
        /// Test that we can update a Reason after adding it via the db Context
        /// </summary>
        [Fact]
        public void UpdateReasonAfterAddingIt()
        {
            //Arrange
            // add an item
            var repository = GetRepository();
            var initialDescription = Guid.NewGuid().ToString();
            var item = new ReasonBuilder().Description(initialDescription).Build();

            //Act
            repository.Add(item);

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = repository.ListAll<Reason>()
                .FirstOrDefault(i => i.Description == initialDescription);
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newDescription = Guid.NewGuid().ToString();
            newItem.Description = newDescription;

            // Update the item
            repository.Update(newItem);
            var updatedItem = repository.ListAll<Reason>()
                .FirstOrDefault(i => i.Description == newDescription);
            
            //Assert
            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Description, updatedItem.Description);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }

        [Fact]
        public void DeleteReasonAfterAddingIt()
        {
            //Arrange
            // add an item
            var repository = GetRepository();
            var initialDescription = Guid.NewGuid().ToString();
            var item = new ReasonBuilder().Description(initialDescription).Build();

            //Act
            repository.Add(item);

            // delete the item
            repository.Delete(item);

            //Assert
            // verify it's no longer there
            Assert.DoesNotContain(repository.ListAll<Reason>(),
                i => i.Description == initialDescription);
        }

        private EfRepository GetRepository()
        {
            var options = CreateNewContextOptions();

            _dbContext = new AppDbContext(options);
            return new EfRepository(_dbContext);
        }
    }
}
