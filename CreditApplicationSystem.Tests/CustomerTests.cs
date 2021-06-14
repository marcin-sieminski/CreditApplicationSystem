using CreditApplicationSystem.DataAccess;
using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditApplicationSystem.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CanInsertCustomerIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertCustomer");
            using var context = new CreditApplicationWorkflowDbContext(builder.Options);
            var customer = new Customer();

            context.Customers.Add(customer);

            Assert.AreEqual(EntityState.Added, context.Entry(customer).State);
        }
    }
}