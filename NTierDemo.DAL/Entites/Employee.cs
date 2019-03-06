using NTierDemo.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL.Entites
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime HiredDate { get; set; }
        public decimal GrossSalary { get; set; }
    }
}
