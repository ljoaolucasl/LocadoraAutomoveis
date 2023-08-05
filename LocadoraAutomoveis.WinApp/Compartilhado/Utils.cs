using System.ComponentModel;

namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public static class Utils
    {
        public static TEnum GetEnumValueFromDescription<TEnum>(string descricao)
        {
            foreach (var field in typeof(TEnum).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == descricao)
                        return (TEnum)field.GetValue(null);
                }
                else
                {
                    if (field.Name == descricao)
                        return (TEnum)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Nenhum enum encontrado com a descrição '{descricao}'.");
        }
    }
}
