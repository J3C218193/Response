﻿using BookingManagementApp.Contracts;
using BookingManagementApp.Data;
namespace API.Repositories
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        private readonly BookingManagementDbContext _context;
        public GeneralRepository(BookingManagementDbContext context)
        {
            _context = context;
        }      
        public TEntity? Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }

        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _context.Set<TEntity>().ToList();
        }
        public TEntity? GetByGuid(Guid guid)
        {
            return _context.Set<TEntity>().Find(guid);
        }
        public bool Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
