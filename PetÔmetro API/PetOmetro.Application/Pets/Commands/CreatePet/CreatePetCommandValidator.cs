using FluentValidation;

namespace PetOmetro.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty()
                .MaximumLength(64);

            RuleFor(e => e.Raca)
                .MaximumLength(64);

            RuleFor(e => e.Especie)
                .MaximumLength(64);

            RuleFor(e => e.Comentario)
                .MaximumLength(512);

            //RuleFor(e => e.Comentario)
            //    .MaximumLength(256);

            RuleFor(e => e.IdGeneroPet)
                .GreaterThan(0);
        }
    }
}
