using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{


    // Lista de items que seran inicialiadores con los que se estara trabajando.
    // La instancia de la lista no cambiara despues de construido el repositorio
    public class InMemItemsRepository : IItemsRepository // Aca se cambio la clase heredadora por la de la interfaz
    {

        // "List" -> importar System.Collections.Generic
        // "CreatedDate = DateTimeOffset.UtcNow" es la fecha y hora en el momento
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Crash 3", Price = 19, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Batman Arkham", Price = 25, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Resident Evil 0", Price = 15, CreatedDate = DateTimeOffset.UtcNow }
        };

        // "IEnumerable" una interface basica para retornar una coleccion de items, se importa el "System.Collections.Generic"
        public IEnumerable<Item> GetItems() // Obteniendo todos los items
        {
            return items;
        }

        // Se importa "System.Linq" para usar el "Where"
        public Item GetItem(Guid id) // Obteniendo item por id
        {
            // Con el "SingleOrDefault()", retornara solo el valor del id, si no se define, retornara la coleccion de datos
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}