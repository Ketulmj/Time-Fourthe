using MongoDB.Driver;
using TimeFourthe.Entities;
using TimeFourthe.Configurations;
using Microsoft.Extensions.Options;
using IdGenerator;

namespace  TimeFourthe.Services {
    public class TimetableService {
        private readonly IMongoCollection<TimetableData> _timetableCollection;
        public TimetableService(IOptions<MongoDbSettings> mongoDbSettings) {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _timetableCollection = database.GetCollection<TimetableData>(mongoDbSettings.Value.CollectionName[1]);
        }
        public async Task<List<TimetableData>> GetTimetableDataAsync() =>
            await _timetableCollection.Find(timetableData => true).ToListAsync();

        public async Task InsertTimetableDataAsync(TimetableData timetableData) =>
            await _timetableCollection.InsertOneAsync(timetableData);
    }

}