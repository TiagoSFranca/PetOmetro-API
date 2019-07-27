using System;

namespace PetOmetro.Domain.Domain
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime DtNascimento { get; set; }
        public int IdGenero { get; set; }

        public string Comentário { get; set; }
        public string UrlImagem { get; set; }

        public virtual GeneroPet Genero { get; set; }

    }
}
