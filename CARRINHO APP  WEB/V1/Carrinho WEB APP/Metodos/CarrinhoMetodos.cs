using Carrinho_WEB_APP.Pages.Carro;
using Carrinho_WEB_APP.Services;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Carrinho_WEB_APP.Metodos
{
    public class CarrinhoMetodos
    {
        private readonly NavigationManager _navigationManager;
        private readonly Carrinho_API _carrinhoAPI;

        // Construtor para injetar as dependências necessárias
        public CarrinhoMetodos(NavigationManager navigationManager, Carrinho_API carrinhoAPI)
        {
            _navigationManager = navigationManager;
            _carrinhoAPI = carrinhoAPI;
        }

        // Método para redirecionar para a página do carrinho
        public void VoltarToCarrinho()
        {
            _navigationManager.NavigateTo("/carrinho");
        }

        // Método para deletar um carrinho
        public async Task Deletar(int carrinhoId)
        {
            try
            {
                // Chama a API para deletar o carrinho pelo Id
                await _carrinhoAPI.DeleteCarrinhoAsync(carrinhoId);

                // Após deletar, redireciona de volta à página do carrinho
                VoltarToCarrinho();

                // Mensagem de sucesso
                Console.WriteLine("Carrinho deletado com sucesso!");
            }
            catch (ValidationException ex)
            {
                // Exibe a mensagem de erro de validação
                Console.WriteLine($"Erro ao deletar carrinho: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Captura outras exceções
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
    }
}
