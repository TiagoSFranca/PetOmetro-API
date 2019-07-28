using MediatR;
using PetOmetro.Application.Pets.Models;
using System;

namespace PetOmetro.Application.Pets.Commands.CreatePet
{
    public class CreatePet
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtNascimento { get; set; }
        public int IdGeneroPet { get; set; }
        public string Comentário { get; set; }
    }

    public class CreatePetCommand : IRequest<PetViewModel>
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtNascimento { get; set; }
        public int IdGeneroPet { get; set; }
        public string Comentário { get; set; }
    }
}
