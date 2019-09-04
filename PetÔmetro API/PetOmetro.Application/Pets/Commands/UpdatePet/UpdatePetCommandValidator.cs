using FluentValidation;

namespace PetOmetro.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
    {
        public UpdatePetCommandValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0);

            RuleFor(e => e.Nome)
                .NotEmpty()
                .MaximumLength(64);

            RuleFor(e => e.Raca)
                .MaximumLength(64);

            RuleFor(e => e.Especie)
                .MaximumLength(64);

            RuleFor(e => e.Comentario)
                .MaximumLength(512);

            RuleFor(e => e.IdGeneroPet)
                .GreaterThan(0);
        }
    }
}
