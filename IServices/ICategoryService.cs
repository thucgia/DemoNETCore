﻿using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.IServices
{
    public interface ICategoryService
    {
        Category getCategoryById(int id);
    }
}
