using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;


namespace Catalog.Controllers  // Aca se reciben las peticiones y se controlan
{

    // "ControllerBase" -> Se importa "Microsoft.AspNetCore.Mvc"; hara que  el archivo
    // sea una clase controladora 

    [ApiController]  // Da comportamiento adicionales a la clase controladora
    [Route("items")] // URL donde el controlador enviara las respuestas
    public class ItemsController : ControllerBase
    {
         private readonly IItemsRepository repository; // Interfaz del repository

         // aca se hizo  la inyeccion de la dependecia 
         public ItemsController(IItemsRepository repository) 
         {
             this.repository = repository;
         }
    
         // GET /items 
            [HttpGet] // Debe especificarse el tipo de peticion
         public IEnumerable<ItemDto> GetItems(){
            
            // Se uso el metodo definido en "Extensions"
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
         }


         // "ActionResult" permitira retornar mas de un tipo de este metodo
         // GET /items/id
        [HttpGet("{id}")]
         public ActionResult<ItemDto> GetItem(Guid id)
         {
             var item = repository.GetItem(id);
             
             if (item is null)
             {
                 return NotFound();
             }
             return item.AsDto();
         }

        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new{id = item.Id}, item.AsDto());

        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto) 
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with 
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);
            
            return NoContent();
        }

        // Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(id);
            return NoContent();
        }

    }
}