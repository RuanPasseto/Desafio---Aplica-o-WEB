using ControleDeContatos.Data;
using Desafio___Aplicação_WEB.Models;

namespace Desafio___Aplicação_WEB.Repositorio
{
    public class ContatosRepositorio : IContatosRepositorio

    {
        private readonly BancoContext _bancoContext;
        public ContatosRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");

            contatoDB.Nome= contato.Nome;
            contatoDB.Rg = contato.Rg;
            contatoDB.Cpf = contato.Cpf;
            contatoDB.Endereco = contato.Endereco;
            contatoDB.Cep = contato.Cep;
            contatoDB.Bairro = contato.Bairro;
            contatoDB.Cidade = contato.Cidade;
            contatoDB.DataNascimento = contato.DataNascimento;
            contatoDB.Email = contato.Email;
            contatoDB.TelefoneResidencial = contato.TelefoneResidencial;
            contatoDB.TelefoneComercial = contato.TelefoneComercial;
            contatoDB.Celular = contato.Celular;
            contatoDB.Faceboo = contato.Faceboo;
            contatoDB.Instagram = contato.Instagram;
            contatoDB.Twitter = contato.Twitter;
            contatoDB.LinkedIn = contato.LinkedIn;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;

        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new Exception("Houve um erro na deleção do contato");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
