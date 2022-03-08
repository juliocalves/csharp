using System;

namespace dioSeries
{
    class Program
    {
        static serieRepository repository = new serieRepository();
        static void Main(string[] args)
        {
               string optionUser = getOptionUser();

               while (optionUser.ToUpper()!="X")
               {
                   switch (optionUser)
                   {
                        case "1":
                            listSeries();
                            break;
                        case "2":
                            insertSerie();
                            break;
                        case "3":
                            updateSerie();
                            break;
                        case "4":
                            deleteSerie();
                            break;
                        case "5":
                            viewSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                   }

                   optionUser = getOptionUser();
               }         
        }

        private static void viewSerie()
        {
            Console.WriteLine("Insira o id da série:");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnForId(indexSerie);
            Console.WriteLine(serie); 
        }


        private static void deleteSerie()
        {
            Console.WriteLine("Insira o id da série:");
            int indexSerie = int.Parse(Console.ReadLine());

            repository.Delet(indexSerie);

            //adicionar confirmação de exclusão

        }

        //adicionar método padrão para update e creat
        private static void listSeries()
        {
            Console.WriteLine("Listar series");

            var list = repository.ListSeries();

            if (list.Count ==0)
            {
                Console.WriteLine("Não há séries cadastradas");
                return;
            }

            foreach (var serie in list)
            {   
                var deleted = serie.returnDeleted();
                
                Console.WriteLine("#ID {0}: . {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "Excluido":""));
            }
        }

        private static void insertSerie()
        {
            Console.WriteLine("Insira nova série:");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} . {1}", i, Enum.GetName(typeof(Genre),i));
            }
            Console.WriteLine("Digite o genero entre as opções listadas: ");
             int getGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série: ");
            string getTitle = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int getYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string getDescription = Console.ReadLine();

            series newSerie = new series(id: repository.NextId(),
                                        genre:(Genre)getGenre,
                                        title:getTitle,
                                        year:getYear,
                                        description:getDescription);
            repository.Insert(newSerie);

        }

        private static void updateSerie()
        {
            Console.WriteLine("Insira o id da série:");
            int indexSerie = int.Parse(Console.ReadLine());



            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} . {1}", i, Enum.GetName(typeof(Genre),i));
            }
            Console.WriteLine("Digite o genero entre as opções listadas: ");
            int getGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série: ");
            string getTitle = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int getYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string getDescription = Console.ReadLine();

            series updateserie = new series(id: indexSerie,
                                        genre:(Genre)getGenre,
                                        title:getTitle,
                                        year:getYear,
                                        description:getDescription);
            repository.Update(indexSerie, updateserie); 
        }

        private static string getOptionUser()
        {
            Console.WriteLine();
            Console.WriteLine("Serial Man!");
            Console.WriteLine("Informe sua opção:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Vizualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string getOptionUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return getOptionUser;
        }
    }
}
