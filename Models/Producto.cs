using System;
using System.Collections.Generic;

namespace testAPI.Models
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public int? CategoriaId { get; set; }
        public string? Nombre { get; set; }
        public decimal? Valor { get; set; }

        public virtual Categorium? Categoria { get; set; }
    }
}
