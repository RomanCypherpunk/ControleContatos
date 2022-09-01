using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancocontext)
        {
            _bancoContext = bancocontext;
        }

        public ContatoModel ListarporID(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.ID == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;


        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarporID(contato.ID);

            if (contatoDB == null) throw new System.Exception("Houve erro na atualizaçao do Contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;


        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarporID(contato.ID);

            if (contatoDB == null) throw new System.Exception("Houve erro ao apagar o Contato");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
