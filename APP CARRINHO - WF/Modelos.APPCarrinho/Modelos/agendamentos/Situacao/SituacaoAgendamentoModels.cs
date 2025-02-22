namespace Modelos.APPCarrinho.agendamentos.Situacao
{
    public class SituacaoAgendamentoModels
    {
        public bool Status;
        public string Mensagem;
        public string Id { get; set; }
        public string Nome { get; set; }

        public static ICollection<SituacaoAgendamentoModels> Situacoes = new List<SituacaoAgendamentoModels>();

        public SituacaoAgendamentoModels()
        {
            Status = true;
        }
    }
}
