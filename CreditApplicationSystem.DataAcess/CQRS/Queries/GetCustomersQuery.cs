using CreditApplicationSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplicationSystem.DataAccess.CQRS.Queries
{
    public class GetCustomersQuery : QueryBase<List<Customer>>
    {
        public string Name { get; set; }

        public override Task<List<Customer>> Execute(CreditApplicationWorkflowDbContext context)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return context.Customers.ToListAsync();
            }

            return context.Customers
                .Where(x => x.CustomerFirstName.Contains(Name) || x.CustomerLastName.Contains(Name))
                .ToListAsync();
        }
    }
}