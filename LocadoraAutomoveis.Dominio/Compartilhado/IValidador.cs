using FluentValidation.Results;

namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public interface IValidador<T>
    {
        ValidationResult Validate(T instance);
    }
}
