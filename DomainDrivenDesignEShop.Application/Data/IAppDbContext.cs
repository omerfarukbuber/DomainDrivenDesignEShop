using DomainDrivenDesignEShop.Domain.Customers;
using DomainDrivenDesignEShop.Domain.Orders;
using DomainDrivenDesignEShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DomainDrivenDesignEShop.Application.Data;

public interface IAppDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Order> Orders { get; set; }
    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}