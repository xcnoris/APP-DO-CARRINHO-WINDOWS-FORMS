

using CarrinhoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.APPCarrinho.Class.User;

namespace DataBase.APPCarrinho.Data.Map
{
    internal class CongregacaoMap : IEntityTypeConfiguration<CongregacaoModel>
    {
        public void Configure(EntityTypeBuilder<CongregacaoModel> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.Nome);
            bld.Property(x => x.SituacaoId);
            bld.Property(x => x.DataCriacao);
            bld.Property(x => x.DataAtulizacao);
        }
    }
}
