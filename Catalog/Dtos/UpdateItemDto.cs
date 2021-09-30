using System;
using System.ComponentModel.DataAnnotations;

// Contrato de nuestros servicios con el cliente. Su funcion es mantener la conexion
// entre el cliente y el servicio, cuando se hace alguna modificacion a los datos almacenados.
// Lo que se hara es que este nuevo modelo se definira en el controller.  

namespace Catalog.Dtos
{   
        public record UpdateItemDto
        {
            [Required]
            public string         Name {get; init;}   

            [Required]
            [Range(1, 1000)]
            public decimal        Price {get; init;}   
        } 
}