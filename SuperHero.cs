namespace SuperHeroes
{
    public class SuperHero
    {
        //Criando Model, declarando quais dados serão passados e aplicando encapsulamento.
        public int Id{ get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
