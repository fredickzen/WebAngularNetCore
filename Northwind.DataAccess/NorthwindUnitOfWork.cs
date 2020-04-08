using Northwind.Repositories;
using Northwind.UnitOfWork;

namespace Northwind.DataAccess
{
    public class NorthwindUnitOfWork:IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Costumer = new CustomerRepository(connectionString);
        }
        public ICustomerRepository Costumer { get; private set; }
    }
}
