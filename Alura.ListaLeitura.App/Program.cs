using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();
            IWebHost host = new WebHostBuilder()
                .UseKestrel() //Servidor Kestrel
                .UseStartup<Startup>() //indica que o métido de inicialização está na classe Startup do argumento, poderia ser quualquer uma
                .Build(); //.Build() cria a implementação do host de acesso HTTP
            host.Run(); //Fica disponível para acesso

            /*ImprimeLista(_repo.ParaLer);
            ImprimeLista(_repo.Lendo);
            ImprimeLista(_repo.Lidos);*/
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
