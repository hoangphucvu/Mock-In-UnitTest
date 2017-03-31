using System.Collections.Generic;

namespace MoqUnitTest.Code.Demo14
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        IEnumerable<Customer> FetchAll();
    }
}