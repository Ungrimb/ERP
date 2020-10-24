using ERP.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Models
{
    public partial class Empleado : IEntity
    {
        public Empleado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
