﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.DataContract;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using UPC.TS.Infraestructure.Enum;
namespace UPC.TS.DataImplement.Infraestructura
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T Single(object primaryKey)
        {

            var dbResult = dbSet.Find(primaryKey);
            return dbResult;

        }

        /// <summary>
        /// Returns the object with the primary key specifies or the default for the type
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }





        //public virtual IEnumerable<T> GetAllWithDeleted()
        //{
        //    var dbresult = _unitOfWork.Db.Fetch<T>("");

        //    return dbresult;
        //}

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual object Insert(T entity)
        {
            SetValue(ref entity, "ESTREG", (int)Estados.Auditoria.Activo);
            dynamic obj = dbSet.Add(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj;

        }

        public virtual object Update(T entity)
        {
            SetValue(ref entity, "ESTREG", (int)Estados.Auditoria.Activo);
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();
            return entity;
        }
        public void Delete(object id)
        {

            T entity = dbSet.Find(id);
            SetValue(ref entity, "ESTREG", (int)Estados.Auditoria.Inactivo );
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this._unitOfWork.Db.SaveChanges();
            //if (_unitOfWork.Db.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            //{
            //    dbSet.Attach(entity);
            //}
            //dynamic obj = dbSet.Remove(entity);
            //this._unitOfWork.Db.SaveChanges();
            //return obj.Id;
        }
        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        internal DbContext Database { get { return _unitOfWork.Db; } }
        public Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable().ToList();
        }


        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;
            Filter(ref query, filter);
            return orderBy != null ? orderBy(query).SingleOrDefault() : query.SingleOrDefault();
        }

        public IEnumerable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            Filter(ref query, filter);
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        private static void Filter<T>(ref IQueryable<T> query, Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                query = query.Where(filter);
            }
        }

        private static void SetValue(ref T obj, string property, object value)
        {
            var propertyInfo = obj.GetType().GetProperty(property);
            var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            var safeValue = (value == null) ? null : Convert.ChangeType(value, type);
            propertyInfo.SetValue(obj, safeValue, null);
        }
    }
}
