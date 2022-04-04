using Microsoft.AspNetCore.Mvc;
namespace SuperHeroes.Controllers
{
    //Criando a Controller

    //nomeando a rota api
    [Route("api/[controller]")]
    //Declarando um atributo que melhora do desenvolvimento de APIs
    [ApiController]
    public class SuperHeroController : Controller
    {
        //lista com as informações que serão passadas sobre os herois
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            //Povoando a lista da classe SuperHero
            //new SuperHero{
            //    Id = 1,
            //    Name = "Batman",
            //    FirstName = "Bruce",
            //    LastName = "Wayne",
            //    Place = "Gotham"
            //},
            new SuperHero{
                Id = 2,
                Name = "SuperMan",
                FirstName = "Clark",
                LastName = "Kent",
                Place = "Kripton"
            }
        };
        private readonly DataContext context;

        public SuperHeroController(DataContext context)
        {
            this.context = context;
        }

        //Identifica uma ação que suporta o método GET
        [HttpGet]

        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            //status de retorno que sera produzido
            return Ok(await context.SuperHeroes.ToListAsync());
        }

        //Metodo GET para um unico heroi
        [HttpGet("{id}")]

        //Mesma base do GET anterior, só que sem a lista dessa vez, pois deve retornar apenar um heroi
        public async Task<ActionResult<SuperHero>> Get(int id) 
        {
            var hero = await context.SuperHeroes.FindAsync(id);

            // Usando lambda para encontrar o heroi de acordo com o id
           // var hero = heroes.Find(h => h.Id == id);
           
            
            // Tratando parametros nulos.
            if (hero == null)
                return BadRequest("Heroi não encontrado.");
            return Ok(hero);
        }

        // Metodo POST para adicionar herois a nossa lista.
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();
            return Ok(context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var DbHero = await context.SuperHeroes.FindAsync(request.Id);
            //var hero = heroes.Find(h => h.Id == request.Id);
            if (DbHero == null)
                return BadRequest("Heroi nao encontrado");
            
            DbHero.Name = request.Name;
            DbHero.FirstName = request.FirstName;
            DbHero.LastName = request.LastName;
            DbHero.Place = request.Place;

            await context.SaveChangesAsync();
            return Ok(await context.SuperHeroes.ToListAsync());
        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id) 
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            //var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Heroi não encontrado.");
            context.SuperHeroes.Remove(hero);
            await context.SaveChangesAsync();
            return Ok(await context.SuperHeroes.ToListAsync());
        }
    }
}
