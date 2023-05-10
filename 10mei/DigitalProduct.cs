using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _10mei
{
    public class DigitalProduct : Product
    {
        public string LicenseKey {get; set;}

        public DigitalProduct(string licensekey, int id, string name, string description, double price, int quantity) : base(id, name, description, price, quantity)
        {
            LicenseKey = licensekey;
        }
    }
}
