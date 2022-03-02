using System;
using System.Collections.Generic;

namespace bd.bd
{
    public partial class ItemPedido
    {
        public int? Iditempedido { get; set; }
        public int? IdProduto { get; set; }
        public int? IdPedido { get; set; }

        public virtual Pedido? IdPedidoNavigation { get; set; }
        public virtual Produto? IdProdutoNavigation { get; set; }
    }
}
