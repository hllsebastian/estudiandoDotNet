using Catalog.Dtos;
using Catalog.Entities;


namespace Catalog
{
    // Para extender metodos fuera de una clase se usa el "public  static class"
    public  static class Extensions
    {
        public static ItemDto AsDto(this Item item) 
        {
            return new ItemDto
            {   
                Id          = item.Id,
                Name        = item.Name,
                Price       = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}