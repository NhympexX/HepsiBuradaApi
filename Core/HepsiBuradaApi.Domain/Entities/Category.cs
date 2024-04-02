using HepsiBuradaApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Domain.Entities
{
    public class Category : EntityBase { 
        public  int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priority { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            
        }
        public Category(int parentID,string name,int priority)
        {
            ParentId = parentID;
            Name = name;
            Priority = priority;
        }

    }
}
