namespace LocadoraAutomoveis.Aplicacao.Extensions
{
    public static class ValidationResultExtensions
    {
        public static List<IError> ConverterParaListaDeErros(this ValidationResult validacao)
        {
            return new List<IError>(validacao.Errors.Select(item => new CustomError(item.ErrorMessage, item.PropertyName)));
        }
    }
}
