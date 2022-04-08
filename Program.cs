using System;
using Cadastro_Series.src;

namespace Series
{
    class Program
    {
        private static string GetFirstUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Séries");
            Console.WriteLine("2 - Filmes");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string firstUserOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return firstUserOption;
        }
         private static string SeriesMenu()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userSerieOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userSerieOption;

        }

        private static string MoviesMenu()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userMovieOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userMovieOption;

        }
                
    
        static SerieRepository repositorySerie = new SerieRepository();
        
        static MovieRepository repositoryMovie = new MovieRepository();

        static void Main(string[] args)
        {
            string firstUserOption = GetFirstUserOption();
            while (firstUserOption.ToUpper() != "X")
            {
                if (firstUserOption == "1")
                {
                    string userSerieOption = SeriesMenu();
                    while (userSerieOption.ToUpper() != "X")
                    {
                                switch (userSerieOption)
                                {
                                    case "1":
                                        ListSeries();
                                        break;
                                    case "2":
                                        InsertSerie();
                                        break;
                                    case "3":
                                        UpdateSerie();
                                        break;
                                    case "4":
                                        DeleteSerie();
                                        break;
                                    case "5":
                                        ViewSerie();
                                        break;
                                    case "C":
                                        Console.Clear();
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }

                        userSerieOption = SeriesMenu();
                    }
                }
                else if(firstUserOption == "2")
                {
                    string userMovieOption = MoviesMenu();
                    while (userMovieOption.ToUpper() != "X")
                    {
                                switch (userMovieOption)
                                {
                                    case "1":
                                        ListMovies();
                                        break;
                                    case "2":
                                        InsertMovie();
                                        break;
                                    case "3":
                                        UpdateMovie();
                                        break;
                                    case "4":
                                        DeleteMovie();
                                        break;
                                    case "5":
                                        ViewMovie();
                                        break;
                                    case "C":
                                        Console.Clear();
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }

                        userMovieOption = MoviesMenu();
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
                firstUserOption = GetFirstUserOption();
            }
                Console.WriteLine ("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repositorySerie.catalog();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var excluded = serie.returnExcluded();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (excluded ? "*Excluído*" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine ("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write ("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write ("Digite o título da série: ");
            string inputTitle = Console.ReadLine();

            Console.Write ("Digite o ano de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write ("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Serie newSerie = new Serie (id: repositorySerie.NextId(),
                                        genre: (Genres)inputGenre,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription);

            repositorySerie.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.Write ("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write ("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write ("Digite o título da série: ");
            string inputTitle = Console.ReadLine();

            Console.Write ("Digite o ano de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write ("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Serie updateSerie = new Serie (id: indexSerie,
                                        genre: (Genres)inputGenre,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription);

            repositorySerie.Update(indexSerie, updateSerie);
        }

        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            repositorySerie.Delete(indexSerie);
        }

        private static void ViewSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repositorySerie.ReturnById(indexSerie);

            Console.WriteLine(serie);
        }


    private static void ListMovies()
        {
            Console.WriteLine("Listar filmes");

            var list = repositoryMovie.catalog();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var movie in list)
            {
                var excluded = movie.returnExcluded();

                Console.WriteLine("#ID {0}: - {1} {2}", movie.returnId(), movie.returnTitle(), (excluded ? "*Excluído*" : ""));
            }
        }

        private static void InsertMovie()
        {
            Console.WriteLine ("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write ("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write ("Digite o título do filme: ");
            string inputTitle = Console.ReadLine();

            Console.Write ("Digite o ano do filme: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write ("Digite a descrição do filme: ");
            string inputDescription = Console.ReadLine();

            Movie newMovie = new Movie (id: repositoryMovie.NextId(),
                                        genre: (Genres)inputGenre,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription);

            repositoryMovie.Insert(newMovie);
        }

        private static void UpdateMovie()
        {
            Console.Write ("Digite o id do filme: ");
            int indexMovie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genres), i));
            }
            Console.Write ("Digite o gênero entre as opções acima: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write ("Digite o título do filme: ");
            string inputTitle = Console.ReadLine();

            Console.Write ("Digite o ano do filme: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write ("Digite a descrição do filme: ");
            string inputDescription = Console.ReadLine();

            Movie updateMovie = new Movie (id: indexMovie,
                                        genre: (Genres)inputGenre,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription);

            repositoryMovie.Update(indexMovie, updateMovie);
        }

        private static void DeleteMovie()
        {
            Console.Write("Digite o id do filme: ");
            int indexMovie = int.Parse(Console.ReadLine());

            repositoryMovie.Delete(indexMovie);
        }

        private static void ViewMovie()
        {
            Console.Write("Digite o id do filme: ");
            int indexMovie= int.Parse(Console.ReadLine());

            var movie = repositoryMovie.ReturnById(indexMovie);

            Console.WriteLine(movie);
        }

        
    }
}
