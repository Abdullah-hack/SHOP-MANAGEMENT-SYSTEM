using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Customer
{
    public class CustomerModel
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string contact { get; set; }
        public string adress { get; set; }

        public CustomerModel(int id, string name, int age, string contact, string adress)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.contact = contact;
            this.adress = adress;
        }

        public CustomerModel(string name, int age, string contact, string adress)
        {
            this.name = name;
            this.age = age;
            this.contact = contact;
            this.adress = adress;
        }


        public override string ToString()
        {
            return $"{id},{name},{age},{contact},{adress}";
        }
    }
}
