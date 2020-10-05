using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            LineasPedidos = new HashSet<LineasPedido>();
        }

        public long Id { get; set; }
        public string State { get; set; }
        public long? IdCostumer { get; set; }
        public string Priority { get; set; }
        public long? IdEmployee { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? AssingDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public virtual Cliente IdCostumerNavigation { get; set; }
        public virtual Empleado IdEmployeeNavigation { get; set; }
        public virtual ICollection<LineasPedido> LineasPedidos { get; set; }
    }
}
