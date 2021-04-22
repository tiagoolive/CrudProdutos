using CrudProdutos.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProdutos.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<Product[]> GetAllProducts()
        {
            IQueryable<Product> query = _context.Products;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public Product GetProductById(int productId)
        {
            IQueryable<Product> query = _context.Products;

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(paciente => paciente.Id == productId);

            return query.FirstOrDefault();
        }
    }
}
