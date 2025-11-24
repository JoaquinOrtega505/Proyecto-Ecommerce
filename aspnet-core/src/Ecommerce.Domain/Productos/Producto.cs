using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ecommerce.Productos
{
    public class Producto : FullAuditedAggregateRoot<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Guid CategoriaId { get; set; }
        public string ImagenUrl { get; set; }
        public bool Activo { get; set; }

        protected Producto()
        {
        }

        public Producto(
            Guid id,
            string nombre,
            string descripcion,
            decimal precio,
            int stock,
            Guid categoriaId,
            string imagenUrl = null) : base(id)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            CategoriaId = categoriaId;
            ImagenUrl = imagenUrl;
            Activo = true;
        }

        public void ActualizarStock(int cantidad)
        {
            Stock += cantidad;
        }

        public bool TieneStock(int cantidad)
        {
            return Stock >= cantidad;
        }
    }
}
