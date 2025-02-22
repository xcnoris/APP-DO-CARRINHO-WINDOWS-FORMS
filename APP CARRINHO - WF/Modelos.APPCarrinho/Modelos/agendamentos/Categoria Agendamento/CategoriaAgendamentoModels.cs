namespace Modelos.APPCarrinho.agendamentos.Categoria_Agendamento
{
    public class CategoriaAgendamentoModels
    {

        public bool Status;
        public string Mensagem;
        public static ICollection<CategoriaAgendamentoModels> categorias = new List<CategoriaAgendamentoModels>();


        public string Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public CategoriaAgendamentoModels()
        {
            Status = true;
        }
    }
}
