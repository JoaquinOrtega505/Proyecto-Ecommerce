using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ecommerce.Pedidos
{
    public class Pedido : FullAuditedAggregateRoot<Guid>
    {
        public Guid UsuarioId { get; set; }
        public DateTime FechaPedido { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal Total { get; set; }
        public string DireccionEnvio { get; set; }
        public List<PedidoItem> Items { get; set; }

        protected Pedido()
        {
            Items = new List<PedidoItem>();
        }

        public Pedido(
            Guid id,
            Guid usuarioId,
            string direccionEnvio,
            List<PedidoItem> items) : base(id)
        {
            UsuarioId = usuarioId;
            FechaPedido = DateTime.UtcNow;
            Estado = EstadoPedido.Pendiente;
            DireccionEnvio = direccionEnvio;
            Items = items;
            Total = items.Sum(i => i.Subtotal);
        }

        public void CambiarEstado(EstadoPedido nuevoEstado)
        {
            Estado = nuevoEstado;
        }
    }

    public class PedidoItem
    {
        public Guid ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;

        protected PedidoItem()
        {
        }

        public PedidoItem(
            Guid productoId,
            string productoNombre,
            int cantidad,
            decimal precioUnitario)
        {
            ProductoId = productoId;
            ProductoNombre = productoNombre;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }

    public enum EstadoPedido
    {
        Pendiente = 0,
        Pagado = 1,
        Enviado = 2,
        Entregado = 3,
        Cancelado = 4
    }
}
