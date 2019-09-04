using MediatR;
using Microsoft.AspNetCore.Http;
using PetOmetro.Application.Pets.Models;
using System;

namespace PetOmetro.Application.Pets.Commands.UpdatePet
{
    public class UpdatePet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtNascimento { get; set; }
        public int IdGeneroPet { get; set; }
        public string Comentario { get; set; }
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }
    }

    public class UpdatePetCommand : IRequest<PetViewModel>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public DateTime? DtNascimento { get; set; }
        public int IdGeneroPet { get; set; }
        public string Comentario { get; set; }
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }
    }
}
