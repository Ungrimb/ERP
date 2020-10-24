using ERP.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Models
{
    public partial class LineasPedido : IEntity
    {
        public long Id { get; set; }
        public long IdPedido { get; set; }
        public long IdProducto { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
