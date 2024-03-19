﻿
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructures.Data.Common
    {
    public class Repository : IRepository
        {

        private readonly CookBookDbContext context;

        public Repository(CookBookDbContext _context)
            {
            context = _context;
            }

        public DbSet<T> DbSet<T>() where T : class
            {
            return context.Set<T>();
            }


        public IQueryable<T> All<T>() where T : class
            {
            return DbSet<T>();
            }

        public IQueryable<T> AllReadOnly<T>() where T : class
            {
            return DbSet<T>().AsNoTracking();
            }

        public async Task AddAsync<T>(T entity) where T : class
            {
            await DbSet<T>().AddAsync(entity);
            }

        public async Task<T?> GetByIdAsync<T>(string id) where T : class
            {
            return await DbSet<T>().FindAsync(id);
            }

        public Task<int> SaveChangesAsync()
            {
            return context.SaveChangesAsync();
            }

        }
    }