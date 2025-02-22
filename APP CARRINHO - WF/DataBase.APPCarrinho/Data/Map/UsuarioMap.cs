

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.APPCarrinho.Class.User;

namespace DataBase.APPCarrinho.Data.Map
{
    internal class UsuarioMap : IEntityTypeConfiguration<UserModels>
    {
        public void Configure(EntityTypeBuilder<UserModels> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.CPF);
            bld.Property(x => x.Nome);
            bld.Property(x => x.TipoUserId);
            bld.Property(x => x.Login);
            bld.Property(x => x.Senha);
            bld.Property(x => x.SituacaoId);
            bld.Property(x => x.DataCriacao);
            bld.Property(x => x.DataAtualizacao);
        }
    }
}
