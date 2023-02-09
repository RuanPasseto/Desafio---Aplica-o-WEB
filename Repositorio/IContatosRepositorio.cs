using Desafio___Aplicação_WEB.Models;

namespace Desafio___Aplicação_WEB.Repositorio
{
    public interface IContatosRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
