using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MES_v1.Models
{
    public class MongoCRUD
    {
        private IMongoDatabase db;
        public MongoCRUD(string dataBase)
        {
            var client = new MongoClient();
            db = client.GetDatabase(dataBase);
        }

        public Task InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            return collection.InsertOneAsync(record);
        }

        public IQueryable<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            var result = collection.AsQueryable();
            return result;
        }


    }
}