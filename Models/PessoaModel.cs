namespace Api.Models
{
    public class PessoaModel
    {
        public int Id_Pessoa { get; set; }
        public string PessoaNome { get; set; } = string.Empty;
        public string PessoaRoupa { get; set; } = string.Empty;
        public string PessoaCor { get; set; } = string.Empty;
        public string PessoaSexo { get; set; } = string.Empty;
        public string PessoaObservacao { get; set; } = string.Empty;
        public string PessoaFoto { get; set; } = string.Empty;
        public string PessoaLocoalDesaparecimento { get; set; } = string.Empty;
        public DateTime PessoaDtDesaparecimento { get; set; } = DateTime.MinValue;
        public DateTime? PessoaDtEncontro { get; set; } = DateTime.MinValue;
        public byte PessoaStatus { get; set; }
        public int? UsuarioId { get; set; }

        public static implicit operator List<object>(PessoaModel v)
        {
            throw new NotImplementedException();
        }
    }
}
