using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Mvc
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            //Usando parte da API .NET chamada Reflection
            //rota padrão: /<Classe>Logica/Metodo
            //var strClasse = Convert.ToString(context.GetRouteValue("classe"));
            var classe = Convert.ToString(context.GetRouteValue("classe"));

            //classe = classe.First().ToString().ToUpper() + classe.Substring(1);

            var nomeMetodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Alura.ListaLeitura.App.Logica.{classe}Logica";
            
            var tipo = Type.GetType(classe);
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo.ToLower()).First();

            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);
        }
    }
}
