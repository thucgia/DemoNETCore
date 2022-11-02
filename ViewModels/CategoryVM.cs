using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewModels
{
    public class CategoryVM
    {
        //[StringLength(1, ErrorMessage = "Name length can't be more than 8.")]
        public string Name { get; set; }
    }
}
