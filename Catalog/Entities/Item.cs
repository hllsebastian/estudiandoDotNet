using System;

namespace Catalog.Entities 
{
    public record Item
    {
        // "Guid" -> se usa System
        public Guid           Id {get; init;}  // "init" Despues de inicializado, no cambia su valor
        public string         Name {get; init;}   
        public decimal        Price {get; init;}   
        public DateTimeOffset CreatedDate {get; set;}   
        
    }    
}