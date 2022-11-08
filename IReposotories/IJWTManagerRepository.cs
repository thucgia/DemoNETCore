using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.IReposotories
{
    public interface IJWTManagerRepository
    {
        Tokens GenerateToken(User obj);
    }
}
