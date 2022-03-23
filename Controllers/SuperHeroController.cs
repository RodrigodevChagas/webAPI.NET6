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
        //Identifica uma ação que suporta o método GET
        [HttpGet]
     
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            //lista com as informações que serão passadas sobre os herois
            var heroes = new List<SuperHero>
            {
                //instanciando a classe SuperHero
                new SuperHero{
                    Id = 1,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham"
                }
            };
            //status de retorno que sera produzido
            return Ok(heroes);
        }
    }
}
