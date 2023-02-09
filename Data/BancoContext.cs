using Desafio___Aplicação_WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {   
        }

        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
