using MongoDB.Driver;
using  Lms.Course.Service.Entites;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Lms.Course.Service.Repositories{
    public class CourseRepository{
        public const string collectionName = "TbCourse";
        private readonly IMongoCollection<TbCourse> dbCollection;
        private readonly FilterDefinitionBuilder<TbCourse> filterBuilder = Builders<TbCourse>.Filter;

        public CourseRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("LmsDb");
            dbCollection = database.GetCollection<TbCourse>(collectionName);
        }

        public async Task<IReadOnlyCollection<TbCourse>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<TbCourse> GetAsync(Guid Id) 
        {
            var filter = filterBuilder.Eq(entity => entity.Id,Id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TbCourse entity) 
        {
            if (entity == null){
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(TbCourse entity) 
        {
            if (entity == null){
                throw new ArgumentNullException(nameof(entity));
            }

            var filter = filterBuilder.Eq(entity => entity.Id, entity.Id);
            var oldEntity = await dbCollection.Find(filter).FirstOrDefaultAsync();

            await dbCollection.ReplaceOneAsync(filter,entity);
        }

        public async Task DeleteAsync(Guid id) 
        {
            var filter = filterBuilder.Eq(entity => entity.Id,id);
            await dbCollection.DeleteOneAsync(filter);
        }


    }
}