using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
