using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using customer.Repository;
using customer.Model;

namespace customer.Manager
{
    public class CustomerManager
    {
        CustomerRepository _CustomerRepository = new CustomerRepository();

        public List<Customer> Search(Customer customerA)
        {

            return _CustomerRepository.Search(customerA);

        }

        public bool Save(Customer customerA)
        {

            return _CustomerRepository.Save(customerA);
        }

        public bool IsCodeExists(Customer customerA)
        {

            return _CustomerRepository.IsCodeExists(customerA);

        }

        public bool IsContactExists(Customer customerA)
        {
            return _CustomerRepository.IsContactExists(customerA);

        }

        public List<Customer> DistrictComboBox()
        {
            return _CustomerRepository.DistrictComboBox();
        }
    }
}
