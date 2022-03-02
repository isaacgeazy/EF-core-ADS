using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bd.bd
{
    public partial class painelContext : DbContext
    {
        public painelContext()
        {
        }

        public painelContext(DbContextOptions<painelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Fornecedore> Fornecedores { get; set; } = null!;
        public virtual DbSet<ItemPedido> ItemPedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=1234;database=painel", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .HasColumnName("bairro");

                entity.Property(e => e.Celular).HasColumnName("celular");

                entity.Property(e => e.Cep).HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(40)
                    .HasColumnName("cidade");

                entity.Property(e => e.Cnpj).HasColumnName("cnpj");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(60)
                    .HasColumnName("complemento");

                entity.Property(e => e.Cpf).HasColumnName("cpf");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(80)
                    .HasColumnName("endereco");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone).HasColumnName("telefone");

                entity.Property(e => e.Tipodepessoa)
                    .HasMaxLength(40)
                    .HasColumnName("tipodepessoa");

                entity.Property(e => e.Website)
                    .HasMaxLength(80)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<Fornecedore>(entity =>
            {
                entity.ToTable("fornecedores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .HasColumnName("bairro");

                entity.Property(e => e.Celular).HasColumnName("celular");

                entity.Property(e => e.Cep).HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(40)
                    .HasColumnName("cidade");

                entity.Property(e => e.Cnpj).HasColumnName("cnpj");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(60)
                    .HasColumnName("complemento");

                entity.Property(e => e.Cpf).HasColumnName("cpf");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(80)
                    .HasColumnName("endereco");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone).HasColumnName("telefone");

                entity.Property(e => e.Tipodepessoa)
                    .HasMaxLength(40)
                    .HasColumnName("tipodepessoa");

                entity.Property(e => e.Website)
                    .HasMaxLength(80)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("item_pedido");

                entity.HasIndex(e => e.IdPedido, "id_pedido");

                entity.HasIndex(e => e.IdProduto, "id_produto");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.Iditempedido).HasColumnName("iditempedido");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("item_pedido_ibfk_2");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("item_pedido_ibfk_1");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedidos)
                    .HasName("PRIMARY");

                entity.ToTable("pedidos");

                entity.HasIndex(e => e.IdCliente, "id_cliente");

                entity.HasIndex(e => e.IdUsuario, "id_usuario");

                entity.Property(e => e.Idpedidos)
                    .ValueGeneratedNever()
                    .HasColumnName("idpedidos");

                entity.Property(e => e.Datapedido).HasColumnName("datapedido");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("pedidos_ibfk_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("pedidos_ibfk_1");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PRIMARY");

                entity.ToTable("produtos");

                entity.HasIndex(e => e.CodigoFornecedor, "codigo_fornecedor");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Altura)
                    .HasPrecision(4, 2)
                    .HasColumnName("altura");

                entity.Property(e => e.CodigoFornecedor).HasColumnName("codigo_fornecedor");

                entity.Property(e => e.DataValidade).HasColumnName("dataValidade");

                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.Property(e => e.Largura)
                    .HasPrecision(4, 2)
                    .HasColumnName("largura");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .HasColumnName("marca");

                entity.Property(e => e.Nome)
                    .HasMaxLength(70)
                    .HasColumnName("nome");

                entity.Property(e => e.NomeFornecedor)
                    .HasMaxLength(70)
                    .HasColumnName("nomeFornecedor");

                entity.Property(e => e.PesoBruto)
                    .HasPrecision(5, 2)
                    .HasColumnName("pesoBruto");

                entity.Property(e => e.PesoLiquido)
                    .HasPrecision(5, 2)
                    .HasColumnName("pesoLiquido");

                entity.Property(e => e.Preço)
                    .HasPrecision(6, 2)
                    .HasColumnName("preço");

                entity.Property(e => e.QntEmEstoque).HasColumnName("qntEmEstoque");

                entity.HasOne(d => d.CodigoFornecedorNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.CodigoFornecedor)
                    .HasConstraintName("produtos_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NomeUsuario)
                    .HasMaxLength(60)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(60)
                    .HasColumnName("senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
