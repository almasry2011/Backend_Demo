using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService1 : IProductService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public IEnumerable<Product> GetProducts()
        {
            NorthwindEntities db = new NorthwindEntities();
           return db.Products.ToList();
        }

        public string HellowWCF()
        {
            return "Hello WCF serves";
        }

        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
