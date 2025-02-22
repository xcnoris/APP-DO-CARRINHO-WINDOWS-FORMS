

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos.APPCarrinho.Class.clientes;

namespace DataBase.APPCarrinho.Data.Map
{
    internal class EntidadeMap : IEntityTypeConfiguration<EntidadeModels>
    {
        public void Configure(EntityTypeBuilder<EntidadeModels> bld)
        {
            bld.HasKey(x => x.Id);
            bld.Property(x => x.CPF);
            bld.Property(x => x.Nome);
            bld.Property(x => x.CEP);
            bld.Property(x => x.Cidade_Nome);
            bld.Property(x => x.UF);
            bld.Property(x => x.Endereco);
            bld.Property(x => x.Endereco_Numero);
            bld.Property(x => x.Endereco_Complemento);
            bld.Property(x => x.Bairro);
            bld.Property(x => x.DDD_Celular);
            bld.Property(x => x.Celular);
            bld.Property(x => x.Sexo);
            bld.Property(x => x.DataNascimento);
            bld.Property(x => x.Email);
            bld.Property(x => x.CongregacaoId);
            bld.Property(x => x.SituacaoId);
            bld.Property(x => x.DataCriacao);
            bld.Property(x => x.DataAtualizacao);
        }
    }
}
