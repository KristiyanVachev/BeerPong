﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BeerPong.Data.Contracts;

namespace BeerPong.Data
{
    public class Repository<T> : IRepository<T> 
        where T : class 
    {
        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Context cannot be null");
            }

            this.Context = dbContext;
            this.Set = this.Context.Set<T>();
        }

        protected IDbSet<T> Set { get; set; }

        protected DbContext Context { get; set; }

        public IEnumerable<T> Entities
        {
            get { return this.Set; }
        }
        
        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.Set
                .Where(filterExpression);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.Set
                .Where(filterExpression)
                .OrderBy(sortExpression);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            return this.Set
                 .Where(filterExpression)
                 .OrderBy(sortExpression)
                 .Select(selectExpression);
        }

        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}
