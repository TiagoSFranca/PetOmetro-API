﻿using AutoMapper;
using PetOmetro.Application.Pets.Commands.CreatePet;
using PetOmetro.Application.Pets.Models;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Application.Pets
{
    public class PetsMapper : BaseMapper
    {
        public PetsMapper(Profile profile)
            : base(profile)
        {
        }

        protected override void Map(Profile profile)
        {
            profile.CreateMap<Pet, PetViewModel>();
            profile.CreateMap<Pet, PetItemViewModel>();
            profile.CreateMap<CreatePetCommand, Pet>();
            profile.CreateMap<CreatePet, CreatePetCommand>();
        }
    }
}
