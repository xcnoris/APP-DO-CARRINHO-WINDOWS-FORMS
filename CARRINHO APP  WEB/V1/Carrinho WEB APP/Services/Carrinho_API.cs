
using CarrinhoWebApp.Models;
using System.Net.Http.Json;

namespace Carrinho_WEB_APP.Services
{
    public class Carrinho_API
    {
        private readonly HttpClient _httpClient;

        public Carrinho_API(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<CarrinhoModel>?> GetTodosCarrinhoAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<CarrinhoModel>>("api/Carrinho/BuscarTodos");
        }
    }
}
