using System;
using System.Collections.Generic;

namespace bd.bd
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string NomeUsuario { get; set; } = null!;
        public string Senha { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
