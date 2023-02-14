using System;
using System.Collections.Generic;

namespace testAPI.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int CategoriaId { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
