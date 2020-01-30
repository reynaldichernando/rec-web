using MongoDB.Driver;

using System.Collections.Generic;
using System.Threading.Tasks;
using Binus.SampleWebAPI.Model.Base;
using MongoDB.Bson;
using Binus.SampleWebAPI.Model.Common;

namespace Binus.SampleWebAPI.Data.Infrastructures.Base.MongoDB
{
    public interface IMongoDBRepository<T> where T : class
    {
        Task<GetOneResult<TEntity>> GetOne<TEntity>(string id) where TEntity : class, new();
        Task<GetOneResult<TEntity>> GetOne<TEntity>(string id, ProjectionDefinition<TEntity> Projection) where TEntity : class, new();

        /// <summary>
        /// A generic GetOne method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOneResult<TEntity>> GetOne<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();
        Task<GetOneResult<TEntity>> GetOne<TEntity>(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> Projection) where TEntity : class, new();

        /// <summary>
        /// A generic get many method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<GetManyResult<TEntity>> GetMany<TEntity>(IEnumerable<string> ids) where TEntity : class, new();
        Task<GetManyResult<TEntity>> GetMany<TEntity>(IEnumerable<string> ids, ProjectionDefinition<TEntity> Projection) where TEntity : class, new();
        Task<GetManyResult<TEntity>> GetMany<TEntity>(IEnumerable<ObjectId> ids) where TEntity : class, new();
        Task<GetManyResult<TEntity>> GetMany<TEntity>(IEnumerable<ObjectId> ids, ProjectionDefinition<TEntity> Projection) where TEntity : class, new();

        Task<IAggregateFluent<TEntity>> GetManyAggregate<TEntity>() where TEntity : class, new();

        /// <summary>
        /// A generic get many method with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<GetManyResult<TEntity>> GetMany<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();
        Task<GetManyResult<TEntity>> GetMany<TEntity>(FilterDefinition<TEntity> filter, ProjectionDefinition<TEntity> Projection) where TEntity : class, new();

      
        /// <summary>
        /// GetMany with filter and projection
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <returns>A cursor for the query</returns>
        IFindFluent<TEntity, TEntity> FindCursor<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// A generic get all method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        Task<GetManyResult<TEntity>> GetAll<TEntity>() where TEntity : class, new();
        Task SetPaging(int PageSize, int CurrentPage);
        Task SortData(List<SortField> Sort);
        Task<GetManyResult<TEntity>> GetAll<TEntity>(ProjectionDefinition<TEntity> Projection) where TEntity : class, new();

      

        /// <summary>
        /// A generic Exists method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> Exists<TEntity>(string id) where TEntity : class, new();
        SortDefinition<TEntity> ConvertSort<TEntity>();
        /// <summary>
        /// A generic count method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<long> Count<TEntity>(string id) where TEntity : class, new();

        /// <summary>
        /// A generic count method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<long> Count<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new();

        /// <summary>
        /// A generic Add One method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<Result> AddOne<TEntity>(TEntity item) where TEntity : class, new();

        /// <summary>
        /// A generic delete one method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteOne<TEntity>(string id) where TEntity : class, new();

        /// <summary>
        /// A generic delete many method
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<Result> DeleteMany<TEntity>(IEnumerable<string> ids) where TEntity : class, new();

        #region Update
        /// <summary>
        /// UpdateOne by id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result> UpdateOne<TEntity>(string id, UpdateDefinition<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// UpdateOne with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result> UpdateOne<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// UpdateMany with Ids
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result> UpdateMany<TEntity>(IEnumerable<string> ids, UpdateDefinition<TEntity> update) where TEntity : class, new();

        /// <summary>
        /// UpdateMany with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task<Result> UpdateMany<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update) where TEntity : class, new();
        #endregion Update

        #region Find And Update

        /// <summary>
        /// GetAndUpdateOne with filter
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="update"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<GetOneResult<TEntity>> GetAndUpdateOne<TEntity>(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update, FindOneAndUpdateOptions<TEntity, TEntity> options) where TEntity : class, new();

        #endregion Find And Update
    }
}
