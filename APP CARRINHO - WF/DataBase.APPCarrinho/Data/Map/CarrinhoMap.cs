

using CarrinhoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.APPCarrinho.Class.User;
using Modelos.APPCarrinho.Modelos.carrinho;

namespace DataBase.APPCarrinho.Data.Map
{
    internal class CarrinhoMap : IEntityTypeConfiguration<CarrinhoModels>
    {
        public void Configure(EntityTypeBuilder<CarrinhoModels> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.Nome);
            bld.Property(x => x.SituacaoId);
            bld.Property(x => x.CongregacaoId);
            bld.Property(x => x.SituacaoId);
            bld.Property(x => x.Codigo_Carrinho);
        }
    }
}
