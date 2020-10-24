using ERP.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Models
{
    public partial class Producto : IEntity
    {
        public Producto()
        {
            LineasPedidos = new HashSet<LineasPedido>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? IdCategory { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }

        public virtual Categoria IdCategoryNavigation { get; set; }
        public virtual ICollection<LineasPedido> LineasPedidos { get; set; }
    }
}
