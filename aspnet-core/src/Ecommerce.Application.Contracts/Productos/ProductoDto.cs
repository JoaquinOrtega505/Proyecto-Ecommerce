using System;
using Volo.Abp.Application.Dtos;

namespace Ecommerce.Productos
{
    public class ProductoDto : EntityDto<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Guid CategoriaId { get; set; }
        public string ImagenUrl { get; set; }
        public bool Activo { get; set; }
    }

    public class CrearActualizarProductoDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Guid CategoriaId { get; set; }
        public string ImagenUrl { get; set; }
    }
}
