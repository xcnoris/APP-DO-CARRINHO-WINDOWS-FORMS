using CarrinhoAPI.Models;
using DataBase.APPCarrinho.Data.Map;
using DataBase.IntegradorCRM.Data.DataBase;

using Microsoft.EntityFrameworkCore;
using Modelos.APPCarrinho.Class.clientes;
using Modelos.APPCarrinho.Class.User;
using Modelos.APPCarrinho.Modelos.carrinho;

namespace DataBase.APPCarrinho.Data
{
    public class AppCarrinhoDBContext : DbContext
    {
        private readonly string _connectionString;

        // Construtor que aceita DbContextOptions
        public AppCarrinhoDBContext(DbContextOptions<AppCarrinhoDBContext> options)
            : base(options)
        {
        }

        public AppCarrinhoDBContext()
        {
            string teste = "";
            var conexao = new ConexaoDB(teste);
            _connectionString = conexao.Carregarbanco();
        }
        
        public DbSet<UserModels> Usuarios { get; set; }
        public DbSet<CongregacaoModel> Congregacoes { get; set; }
        public DbSet<EntidadeModels> Entidades { get; set; }
        public DbSet<CarrinhoModels> Carrinhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CongregacaoMap());
            modelBuilder.ApplyConfiguration(new EntidadeMap());
            modelBuilder.ApplyConfiguration(new CarrinhoMap());
            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aqui é usado a string de conexão carregada da classe ConexaoDB
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
