
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

        public async Task AddCarrinhoAsync(CarrinhoModel carrinho)
        {
            await _httpClient.PostAsJsonAsync("api/Carrinho/Adicionar", carrinho);
        }

        public async Task DeleteCarrinhoAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Carrinho/Remover/{id}");
        }

        public async Task<CarrinhoModel?> GetCarrinhoPorId(int id)
        {
            return await _httpClient.GetFromJsonAsync<CarrinhoModel>($"api/Carrinho/BuscarPorId/{id}");
        }
    }
}
