using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
         Task<Product> Get(Guid id);

         Task<IEnumerable<Product>> GetAll();

         Task Add(Product product);

         Task Delete(string id);

         Task Update(Product product);
    }
}