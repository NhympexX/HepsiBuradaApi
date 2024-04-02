﻿using HepsiBuradaApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Domain.Entities
{
    public class Brand : EntityBase
    {
        public  string Name { get; set; }
        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }
    }
}
