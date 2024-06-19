using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
        public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
        {
            public void Configure(EntityTypeBuilder<PessoaModel> builder)
            {
                builder.HasKey(x => x.Id_Pessoa);
                builder.Property(x => x.PessoaNome).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PessoaRoupa).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PessoaCor).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PessoaSexo).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PessoaObservacao).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PessoaFoto).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PessoaLocoalDesaparecimento).IsRequired().HasMaxLength(255);
                builder.Property(x => x.PessoaDtDesaparecimento).IsRequired();
                builder.Property(x => x.PessoaDtEncontro);
                builder.Property(x => x.PessoaStatus).IsRequired().HasMaxLength(255);
                builder.Property(x => x.UsuarioId);
            }
        }
}
