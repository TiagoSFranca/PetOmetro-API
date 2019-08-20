using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
        public string Comentario { get; set; }
        public IFormFile Imagem { get; set; }
    }

    public class CreatePetCommand : IRequest<PetViewModel>
    {
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtNascimento { get; set; }
        public int IdGeneroPet { get; set; }
        public string Comentario { get; set; }
        public FormFile Imagem { get; set; }
    }
}
