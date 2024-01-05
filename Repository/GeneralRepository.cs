using Microsoft.EntityFrameworkCore;
using SupplyManagement.Contract;
using SupplyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SupplyManagement.Repository
{
    public class GeneralRepository<TEntity, Type> : IGeneralRepository<TEntity, Type> where TEntity : class
    {
        protected readonly SupplyManagementContext _context;

        public GeneralRepository(SupplyManagementContext context)
        {
            _context = context;
        }

        public TEntity GetById(Type id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }


        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}