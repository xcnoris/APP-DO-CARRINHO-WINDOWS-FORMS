using CarrinhoWebApp.Models;
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

        public async Task AddAsync(CongregacaoModel congregacao)
        {
            await _httpClient.PostAsJsonAsync("api/Congregacao/Adicionar", congregacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Congregacao/Remover/{id}");
        }

        public async Task<CongregacaoModel?> GetPorId(int id)
        {
            return await _httpClient.GetFromJsonAsync<CongregacaoModel>($"api/Congregacao/BuscarPorId/{id}");
        }
        public async Task AtualizarPorId(CongregacaoModel congregacao)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"api/Congregacao/Atualizar/{congregacao.Id}", congregacao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
