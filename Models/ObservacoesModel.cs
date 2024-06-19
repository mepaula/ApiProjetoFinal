namespace Api.Models
{
    public class ObservacoesModel
    {
        public int Id_Observacoes { get; set; }
        public string ObservacoesDescricao { get; set; } = string.Empty;
        public string ObservacoesLocal { get; set; } = string.Empty;
        public DateTime ObservacoesData { get; set; } = DateTime.MinValue;
        public int? PessoaId { get; set; }
        public int? UsuarioId { get; set; }

        public static implicit operator List<object>(ObservacoesModel v)
        {
            throw new NotImplementedException();
        }
    }
}
