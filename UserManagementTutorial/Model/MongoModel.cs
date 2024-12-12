using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using UserManagementTutorial.Model.Entities;

namespace DataAccessLayer.Repositories.Nimbus.v2 {
    public class MongoUserModel {
        private readonly IMongoCollection<User> collection;

        public MongoUserModel() {
            var client = new MongoClient(ConfigurationManager.AppSettings["Mongo_DatabaseUrl"]);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["Mongo_DatabaseName"]);

            collection = database.GetCollection<User>("Users");
        }

        public async Task<IEnumerable<User>> GetAllAsync() {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetAsync(int id) {
            return await collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user) {
            await collection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(User user) {
            await collection.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteAsync(int id) {
            await collection.DeleteOneAsync(user => user.Id == id);
        }
    }

}