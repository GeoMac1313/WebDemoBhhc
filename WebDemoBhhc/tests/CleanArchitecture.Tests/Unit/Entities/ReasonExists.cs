using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CleanArchitecture.Tests.Core.Entities
{
    /// <summary>
    /// Unit Tests for Reason object.
    /// Unit test are for testing discrete units of functionality in isolation.
    /// </summary>
    public class ReasonExists
    {
        /// <summary>
        /// Test that we fields are the same after assigning them in a Reason object
        /// </summary>
        [Fact]
        public void ReasonIndividualFieldsShould()
        {
            //Arrange
            string description = "This is a test";
            string lastChangedby = "Joe Schmoe";
            DateTime lastChangedDateTime = DateTime.Now;

            var item = new ReasonBuilder().Build();

            //Act
            item.Description = description;
            item.LastChangedBy = lastChangedby;
            item.LastChangedDateTime = lastChangedDateTime;

            //Assert
            Assert.Equal(description, item.Description);
            Assert.Equal(lastChangedby, item.LastChangedBy);
            Assert.Equal(lastChangedDateTime, item.LastChangedDateTime);
        }

        /// <summary>
        /// Test that we can add 3 Reasons into a list
        /// </summary>
        [Fact]
        public void ReasonsAddShould()
        {
            //Arrange
            var item = new ReasonBuilder().Build();
            var item2 = new ReasonBuilder().Build();
            var item3 = new ReasonBuilder().Build();

            //Act
            item.Description = "Test 1";
            item2.Description = "Test 2";
            item3.Description = "Test 3";

            List<Reason> reasons = new List<Reason>();
            reasons.Add(item);
            reasons.Add(item2);
            reasons.Add(item3);

            //Assert
            Assert.Equal(3, reasons.Count());
        }

        /// <summary>
        /// Test that we can remove 1 reason from a set of 3 to yield 2 objects in a list.
        /// </summary>
        [Fact]
        public void ReasonsRemoveShould()
        {
            //Arrange
            var item = new ReasonBuilder().Build();
            var item2 = new ReasonBuilder().Build();
            var item3 = new ReasonBuilder().Build();

            //Act
            item.Description = "Test 1";
            item2.Description = "Test 2";
            item3.Description = "Test 3";

            List<Reason> reasons = new List<Reason>();
            reasons.Add(item);
            reasons.Add(item2);
            reasons.Add(item3);

            reasons.Remove(item2);

            //Assert
            Assert.Equal(2, reasons.Count());
        }

    }
}
