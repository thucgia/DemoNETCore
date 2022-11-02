using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int[] Suppliers { get; set; }
    }
}
