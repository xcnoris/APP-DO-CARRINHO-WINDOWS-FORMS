using CarrinhoWebApp.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Carrinho_WEB_APP.Services
{
    public class CongregacaoAPI
    {
        private readonly HttpClient _httpClient;
        public CongregacaoAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }


         // Renomear o método para um nome mais apropriado
        public async Task<ICollection<CongregacaoModel>?> GetTodasCongregacoesAsync()
        {
            // Ajustar o endpoint para a URL correta da API
            return await _httpClient.GetFromJsonAsync<ICollection<CongregacaoModel>>("api/Congregacao/BuscarTodos");
        }
    }
}
