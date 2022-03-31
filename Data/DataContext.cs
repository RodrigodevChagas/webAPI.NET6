using Microsoft.EntityFrameworkCore;

namespace SuperHeroes.Data
{
    //Classe herda de DbContext para poder salvar as instancias das entidades.
    public class DataContext : DbContext
    {
        //Classe para linkar com a base de dados
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        //Propriedade que salva as instancias da classe SuperHero.
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
