﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    /// <summary>
    /// Репозиторий для чтения
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Основной ключ</typeparam>
    public abstract class ReadRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey>
        where TPrimaryKey : struct
        where T : class, IEntity<TPrimaryKey>
    {
        protected readonly DbContext Context;
        protected DbSet<T> EntitySet;

        protected ReadRepository(DbContext context)
        {
            Context = context;
            EntitySet = Context.Set<T>();
        }

        /// <summary>
        /// Запросить все сущности в базе
        /// </summary>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>IQueryable массив сущностей</returns>
        public virtual IQueryable<T> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ? EntitySet.AsNoTracking() : EntitySet;
        }

        /// <summary>
        /// Запросить все сущности в базе
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>Список сущностей</returns>
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await GetAll(asNoTracking).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получить сущность по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        /// <returns>сущность</returns>
        public virtual T Get(TPrimaryKey id)
        {
            return EntitySet.Find(id);
        }

        /// <summary>
        /// Получить сущность по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        /// <returns>сущность</returns>
        public virtual async Task<T> GetAsync(TPrimaryKey id)
        {
            return await EntitySet.FindAsync((object)id);
        }
    }
}
