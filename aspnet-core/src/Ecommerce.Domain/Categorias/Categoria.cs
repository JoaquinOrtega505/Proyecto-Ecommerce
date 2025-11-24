using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ecommerce.Categorias
{
    public class Categoria : FullAuditedAggregateRoot<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Guid? CategoriaPadreId { get; set; }
        public int Orden { get; set; }
        public bool Activa { get; set; }

        protected Categoria()
        {
        }

        public Categoria(
            Guid id,
            string nombre,
            string descripcion = null,
            Guid? categoriaPadreId = null,
            int orden = 0) : base(id)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CategoriaPadreId = categoriaPadreId;
            Orden = orden;
            Activa = true;
        }
    }
}
