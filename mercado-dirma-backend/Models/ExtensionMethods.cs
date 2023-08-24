using System.ComponentModel.DataAnnotations;

namespace mercado_dirma_backend.Models
{
    public static class ExtensionMethods
    {
        public static string GetName(this Day value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var displayAttribute = fieldInfo?.GetCustomAttributes(
                typeof(DisplayAttribute), false
            ) as DisplayAttribute[];

            if (displayAttribute == null || displayAttribute.Length == 0)
            {
                return value.ToString(); // Si no se encuentra el atributo, devolver el nombre del enum
            }

            return displayAttribute[0].GetName();
        }
    }
}
