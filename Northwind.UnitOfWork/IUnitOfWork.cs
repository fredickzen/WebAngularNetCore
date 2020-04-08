using Northwind.Repositories;

namespace Northwind.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Costumer { get; }
    }
}
