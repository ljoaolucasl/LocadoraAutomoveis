using FluentResults;

namespace LocadoraAutomoveis.Aplicacao.Compartilhado
{
    public class CustomError : Error
    {
        public string ErrorMessage { get; set; }

        public string PropertyName { get; set; }

        public CustomError(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}
