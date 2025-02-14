using MongoDB.Driver;
using TimeFourthe.Entities;
using TimeFourthe.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using IdGenerator;

namespace TimeFourthe.Services {
    public class UserService {
        private readonly IMongoCollection<User> _usersCollection;

        public UserService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _usersCollection = database.GetCollection<User>(mongoDbSettings.Value.CollectionName);
        }

        public async Task<List<User>> GetUsersAsync() =>
            await _usersCollection.Find(user => true).ToListAsync();

        public async Task<User?> GetUserAsync(string email) =>
            await _usersCollection.Find(user => user.Email==email).FirstOrDefaultAsync();

        public async Task CreateUserAsync(User user){
            user.UserId=new IdGeneratorClass().IdGenerator(user.Role);
            await _usersCollection.InsertOneAsync(user);
        }
        // check this method (not working)
        public async Task UpdateUserAsync(User user) {
            await _usersCollection.UpdateOneAsync(user => user.Id == user.Id, new BsonDocument("$set", user.ToBsonDocument())); 
        }
    }
}