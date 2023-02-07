using Dapper;
using System.Data.SqlClient;

namespace ConexaoBd02
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //IncluirCategoria();
            ListarCategoria();

        }

        static string conexao = @"Data Source=(localdb)\MSSQLLocalDB; 
                                Initial Catalog=DbProdutos;
                                Integrated Security=True";


        static void ListarCategoria()
        {
            using (var conn = new SqlConnection(conexao))
            {
                var categorias = conn.Query<Categoria>("Select * from TBCategorias");
                foreach (var item in categorias)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Descrição: " + item.Descricao);
                    Console.WriteLine("------------------------------------");
                }

            }
            //static void IncluirCategoria()
            //{
            //    Console.Write("Informe a categoria: ");
            //    string categoria = Console.ReadLine();

            //    using (var conn = new SqlConnection(conexao)) {

            //        var registros = conn.Execute("Insert into TBCategorias (Descricao) values (@Descricao)",
            //        new { Descricao = categoria });
            //        Console.WriteLine("Registros inseridos: " + registros);

            //    }
            //}



        }
    }
}