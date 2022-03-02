using System;
using System.Collections.Generic;

namespace bd.bd
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Endereco { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public int? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public long? Telefone { get; set; }
        public long? Celular { get; set; }
        public string? Website { get; set; }
        public string? Tipodepessoa { get; set; }
        public long? Cnpj { get; set; }
        public long? Cpf { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
