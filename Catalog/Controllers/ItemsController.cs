using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Catalog.Controllers  // Aca se reciben las peticiones y se controlan
{

    // "ControllerBase" -> Se importa "Microsoft.AspNetCore.Mvc"; hara que  el archivo
    // se una clase controladora 

    [ApiController]  // Da comportamiento adicionales a la clase controladora
    [Route("items")] // URL donde el controlador enviara las respuestas
    public class ItemsController : ControllerBase
    {
         private readonly IItemsRepository repository; // Interfaz del repository

         public ItemsController(IItemsRepository repository)
         {
             this.repository = repository;
         }
    
         // GET /items 
            [HttpGet] // Debe especificarse el tipo de peticion
         public IEnumerable<ItemDto> GetItems(){

            var items = repository.GetItems().Select(item => new ItemDto
            {
                Id          = item.Id,
                Name        = item.Name,
                Price       = item.Price,
                CreatedDate = item.CreatedDate,
            });

            return items;
         }


         // "ActionResult" permitira retornar mas de un tipo de este metodo
         // GET /items/id
        [HttpGet("{id}")]
         public ActionResult<Item> GetItem(Guid id)
         {
             var item = repository.GetItem(id);
             
             if (item is null)
             {
                 return NotFound();
             }
             return item;
         }
    
    }
}