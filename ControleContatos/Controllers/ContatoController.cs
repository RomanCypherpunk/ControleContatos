using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Create()
        {

            return View();
        }

        public IActionResult Edit(int id)
        {
           ContatoModel contato = _contatoRepositorio.ListarporID(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarporID(id);
            return View(contato);
        }

        public IActionResult DeleteContato(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Create", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Nao conseguimos cadastrar o seu Contato, tente novamente. Detalhe do Erro: {erro.Message } ";
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
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Edit", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Nao conseguimos atualizar o seu Contato, tente novamente. Detalhe do Erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}
