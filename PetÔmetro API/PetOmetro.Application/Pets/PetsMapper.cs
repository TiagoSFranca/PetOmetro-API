using AutoMapper;
using Microsoft.AspNetCore.Http;
using PetOmetro.Application.Pets.Commands.CreatePet;
using PetOmetro.Application.Pets.Commands.UpdatePet;
using PetOmetro.Application.Pets.Models;
using PetOmetro.Domain.Entities;
using System;

namespace PetOmetro.Application.Pets
{
    public class PetsMapper
    {
        private readonly IHttpContextAccessor _acessor;
        private readonly string _baseUrl;

        public PetsMapper(Profile profile, IHttpContextAccessor acessor)
        {
            _acessor = acessor;

            var request = _acessor.HttpContext.Request;
            _baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";

            Map(profile);
        }

        protected void Map(Profile profile)
        {
            profile.CreateMap<Pet, PetViewModel>()
                .AfterMap((src, dest) => dest.UrlImagem = ConvertToUrl(src.UrlImagem));

            profile.CreateMap<Pet, PetItemViewModel>()
                .AfterMap((src, dest) => dest.UrlImagem = ConvertToUrl(src.UrlImagem));

            profile.CreateMap<CreatePetCommand, Pet>();
            profile.CreateMap<CreatePet, CreatePetCommand>();

            profile.CreateMap<UpdatePetCommand, Pet>();
            profile.CreateMap<UpdatePet, UpdatePetCommand>()
                .AfterMap((src, dest) => dest.UrlImagem = UndoConvertToUrl(src.UrlImagem));
        }

        private string UndoConvertToUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            url = url.Replace(_baseUrl, "");

            if (url.Contains("null", StringComparison.InvariantCultureIgnoreCase))
                return null;

            return url;
        }

        private string ConvertToUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            return _baseUrl + (url.StartsWith("/") ? "" : "/") + url;
        }
    }
}
