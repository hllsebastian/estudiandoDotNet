using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {

        // Se crearon las intancias para la DB y el repositorio
        private const string dataBaseName = "Catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;

        // Aca se hara la inyeccion de la instancia de mongoDB
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(dataBaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }

        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}