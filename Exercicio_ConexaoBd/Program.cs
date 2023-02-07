using Dapper;
using System.Data.SqlClient;

namespace Exercicio_ConexaoBd
{
    internal class Program
    {

        // 1) Adicionar no NuGet:
        // - System.Data.SqlClient
        // - Dapper
        // - Dapper.Contrib

        public class Estados
        {
            public int Id { get; set; }
            public string? Estado { get; set; }
        }

        public class Times
        {
            public int Id { get; set; }
            public string? IdEstado { get; set; }
            public string? Nome { get; set; }
            public string? Cidade { get; set; }
        }


        static void Main(string[] args)
        {
            //IncluirEstado();
            //ListarEstados();

            //IncluirTimeBrasil();
            ListarTimesBrasil();
        }


        // String para criar conexao com o banco
        static string conexao = @"Data Source=(localdb)\MSSQLLocalDB; 
                                Initial Catalog=DbTimesFutebol;
                                Integrated Security=True";


        // Métodos referenctes à tabela TBTimesBrasil do DbTimesFutebol
        static void IncluirEstado()
        {
            Console.Write("Insira o nome do Estado que deseja adicionar ao banco de dados: ");
            string estado = Console.ReadLine();

            using (var conn = new SqlConnection(conexao))
            {
                var registros = conn.Execute("Insert into TBTimesBrasil (Estado) values (@Estado)",
                new { Estado = estado });
                Console.WriteLine("Registros inseridos: " + registros);
            }
        }

        static void ListarEstados()
        {
            using (var conn = new SqlConnection(conexao))
            {
                var estados = conn.Query<Estados>("Select * from TBTimesBrasil");
                foreach (var item in estados)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Estado: " + item.Estado);
                    Console.WriteLine("------------------------------------");
                }
            }
        }


        // Métodos referenctes à tabela TBTimes do DbTimesFutebol
        static void IncluirTimeBrasil()
        {
            Console.Write("Insira o nome do time que deseja adicionar ao banco de dados: ");
            string nomeTime = Console.ReadLine();
            Console.Write("Insira o Id do estado do time que deseja adicionar ao banco de dados: ");
            string idEstado = Console.ReadLine();
            Console.Write("Insira a cidade do time que deseja adicionar ao banco de dados: ");
            string cidade = Console.ReadLine();

            using (var conn = new SqlConnection(conexao))
            {
                var registros = conn.Execute("Insert into TBTimes (IdEstado, Nome, Cidade) values (@IdEstado, @Nome, @Cidade)",
                new { Nome = nomeTime, IdEstado = idEstado, Cidade = cidade });
                Console.WriteLine("Registros inseridos");
            }
        }

        static void ListarTimesBrasil()
        {
            using (var conn = new SqlConnection(conexao))
            {
                var times = conn.Query<Times>("Select * from TBTimes");
                foreach (var item in times)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Id do Estado na tabela principal: " + item.IdEstado);
                    Console.WriteLine("Nome do time: " + item.Nome);
                    Console.WriteLine("Cidade do time: " + item.Cidade);
                    Console.WriteLine("------------------------------------");
                }
            }
        }


    }
}