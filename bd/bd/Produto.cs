using System;
using System.Collections.Generic;

namespace bd.bd
{
    public partial class Produto
    {
        public int IdProduto { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preço { get; set; }
        public int? QntEmEstoque { get; set; }
        public string? NomeFornecedor { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public decimal? PesoLiquido { get; set; }
        public decimal? PesoBruto { get; set; }
        public DateOnly? DataValidade { get; set; }
        public string? Marca { get; set; }
        public int? CodigoFornecedor { get; set; }

        public virtual Fornecedore? CodigoFornecedorNavigation { get; set; }
    }
}
