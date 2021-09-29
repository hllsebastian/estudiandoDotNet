using System;

// Contrato de nuestros servicios con el cliente. Su funcion es mantener la conexion
// entre el cliente y el servicio, cuando se hace alguna modificacion a los datos almacenados.
// Lo que se hara es que este nuevo modelo se definira en el controller.  

namespace Catalog.Dtos
{   
        public record ItemDto
        {
            // "Guid" -> se usa System
            public Guid           Id {get; init;}  // "init" Despues de inicializado, no cambia su valor
            public string         Name {get; init;}   
            public decimal        Price {get; init;}   
            public DateTimeOffset CreatedDate {get; set;}          
        } 
}