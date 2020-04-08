using Northwind.Repositories;

namespace Northwind.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Costumer { get; }
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
    }
}
