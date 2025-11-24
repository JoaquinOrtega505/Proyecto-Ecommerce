using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ecommerce.Carritos
{
    public class Carrito : FullAuditedAggregateRoot<Guid>
    {
        public Guid UsuarioId { get; set; }
        public List<CarritoItem> Items { get; set; }

        protected Carrito()
        {
            Items = new List<CarritoItem>();
        }

        public Carrito(Guid id, Guid usuarioId) : base(id)
        {
            UsuarioId = usuarioId;
            Items = new List<CarritoItem>();
        }

        public void AgregarItem(Guid productoId, int cantidad, decimal precio)
        {
            var item = Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                item.Cantidad += cantidad;
            }
            else
            {
                Items.Add(new CarritoItem(productoId, cantidad, precio));
            }
        }

        public void ActualizarCantidad(Guid productoId, int cantidad)
        {
            var item = Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                item.Cantidad = cantidad;
            }
        }

        public void EliminarItem(Guid productoId)
        {
            var item = Items.FirstOrDefault(i => i.ProductoId == productoId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public void Vaciar()
        {
            Items.Clear();
        }

        public decimal ObtenerTotal()
        {
            return Items.Sum(i => i.Subtotal);
        }
    }

    public class CarritoItem
    {
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Subtotal => Cantidad * Precio;

        protected CarritoItem()
        {
        }

        public CarritoItem(Guid productoId, int cantidad, decimal precio)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
