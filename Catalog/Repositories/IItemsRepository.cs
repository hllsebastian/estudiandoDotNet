using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        // get todo el listado
        Item GetItem(Guid id);
        // get por id
        IEnumerable<Item> GetItems();
        // crear nuevo item
        void CreateItem(Item item);
        // Para actualizar item
        void UpdateItem(Item item);
        // Para borrar el item 
        void DeleteItem(Guid id);

    }
    
}