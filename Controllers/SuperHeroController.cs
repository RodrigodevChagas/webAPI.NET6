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
            new SuperHero{
                Id = 1,
                Name = "Batman",
                FirstName = "Bruce",
                LastName = "Wayne",
                Place = "Gotham"
            },
            new SuperHero{
                Id = 2,
                Name = "SuperMan",
                FirstName = "Clark",
                LastName = "Kent",
                Place = "Kripton"
            }
        };

        //Identifica uma ação que suporta o método GET
        [HttpGet]

        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            //status de retorno que sera produzido
            return Ok(heroes);
        }

        //Metodo GET para um unico heroi
        [HttpGet("{id}")]

        //Mesma base do GET anterior, só que sem a lista dessa vez, pois deve retornar apenar um heroi
        public async Task<ActionResult<SuperHero>> Get(int id) 
        {
            // Usando lambda para encontrar o heroi de acordo com o id
            var hero = heroes.Find(h => h.Id == id);
           // Tratando parametros nulos.
            if (hero == null)
                return BadRequest("Heroi não encontrado.");
            return Ok(hero);
        }

        // Metodo POST para adicionar herois a nossa lista.
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Heroi nao encontrado");
            
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id) 
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Heroi não encontrado.");
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
