using System;
using System.Collections.Generic;

namespace bd.bd
{
    public partial class Pedido
    {
        public int Idpedidos { get; set; }
        public DateOnly Datapedido { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
