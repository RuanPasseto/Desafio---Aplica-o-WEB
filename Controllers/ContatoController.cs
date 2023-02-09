using Desafio___Aplicação_WEB.Models;
using Desafio___Aplicação_WEB.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Desafio___Aplicação_WEB.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatosRepositorio _contatosRepositorio;
        public ContatoController(IContatosRepositorio contatosRepositorio)
        {
            _contatosRepositorio = contatosRepositorio;  
        }

        public IActionResult Index()
        {
           List<ContatoModel> contatos= _contatosRepositorio.BuscarTodos(); 

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatosRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatosRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatosRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar seu contato";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar seu contato, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }   

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _contatosRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro, tente novament, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _contatosRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro, tente novament, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
