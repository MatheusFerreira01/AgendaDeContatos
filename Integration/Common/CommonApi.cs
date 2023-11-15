
using Microsoft.Extensions.Primitives;
using System.Reflection.Metadata;

namespace AgendaDeContatos.Integration.Common
{
    public class CommonApi
    {
        public static readonly string ViaCepUri = "https://viacep.com.br";
        public static readonly string ViaCepRoute = "/ws/{cep}/json/";
    }
}
