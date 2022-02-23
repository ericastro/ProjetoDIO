using System;

namespace DIO.Series
{
    class Program
    {
        static RepositorySeries repository = new RepositorySeries();
        static void Main(string[] args)
        {
            
            string userOption = String.Empty;

            while (userOption != "X")
            {
				ScreenClear();
                userOption = GetUserOption();

                switch (userOption)
                {
                    case  "1":
						ScreenClear();
                        ListSeries();
                        break;
                    case  "2":
						ScreenClear();
                        InsertSerie();
                        break;
                    case  "3":
						ScreenClear();
                        UpadateSerie();
                        break;
                    case  "4":
						ScreenClear();
                        DeleteSerie();
                        break;
					case "5":
						ScreenClear();
						ViewSerie();
						break;
                    case  "C":
                        ScreenClear();
                        break;
                    default:
                        break;
                }
            } 

        }

        private static string GetUserOption()
        {
            Console.WriteLine("DIO Séries a seu dispor !!!");
            Console.WriteLine("Informe a série desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar uma Série");
			Console.WriteLine("4 - Excluir uma Série");
            Console.WriteLine("5 - Visualizar uma Série");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

			string userOption = Console.ReadLine();

            return userOption.ToUpper();
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar Séries");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
				Console.WriteLine();
				Console.ReadLine();
                return;
            }

			foreach (var serie in list)
			{
				Console.WriteLine("#ID: {0} - {1} {2}", serie.GetId(), serie.GetTitle(), ( serie.GetExclude() ? "*Excluido*" : "") );
			}

			Console.WriteLine();
			Console.ReadLine();

        }

        private static void InsertSerie()
        {
            foreach (int  i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string inputTitle = String.Empty;
            inputTitle = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Serie newSerie = new Serie(
                id: repository.NextId(),
                genre: (Genre)inputGenre,
                title: inputTitle,
                year: inputYear,
                description: inputDescription);
            
            repository.Insert(newSerie);

        }
    
        private static void UpadateSerie() 
		{
            Console.Write("Digite o id da série : ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Digite o gênero entre as opções acima : ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série : ");
            string inputTitle = Console.ReadLine();

			Console.Write("Digite o ano de início da série : ");
            int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição da série : ");
            string inputDescription = Console.ReadLine();

            Serie newSerie = new Serie(
                id: idSerie,
                genre: (Genre)inputGenre,
                title: inputTitle,
                year: inputYear,
                description: inputDescription);
            
            repository.Update(idSerie, newSerie);			
        }
    
		private static void DeleteSerie()
		{
			Console.Write("Digite o id da série : ");
			int idSerie = int.Parse(Console.ReadLine());

			repository.Delete(idSerie);
		}

		private static void ViewSerie()
		{
			Console.Write("Digite o id da série : ");
			int idSerie = int.Parse(Console.ReadLine());

			Console.Clear();
			Console.WriteLine(repository.ReturnById(idSerie));
			Console.ReadLine();
		}

		private static void ScreenClear()
		{
			Console.Clear();
		}
	}    

}