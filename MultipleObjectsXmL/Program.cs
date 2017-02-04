using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace MultipleObjectsXmL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var firstMov = new Movie();
            firstMov.Title = "Shrek";
            firstMov.Rating = 2;
            firstMov.ReleaseDate = DateTime.Now;

            var secondMov = new Movie();
            secondMov.Title = "Hamza Anis";
            secondMov.Rating = 4;
            secondMov.ReleaseDate = DateTime.Now;

            var movieClssObj = new MovieClss();
            movieClssObj.movieList.Add(firstMov);
            movieClssObj.movieList.Add(secondMov);
            var movList = new List<Movie>() {firstMov, secondMov};

            WritetoXml(movieClssObj.movieList, "c:\\hamza\\1.xml");
            Console.WriteLine("written");
            Console.Read();

            //   ReadFromXml("c:\\hamza\\1.xml");
        }

        // The static class and funcion that creates the xml file 
        public static void WritetoXml(List<Movie> movies, string filePath)
        {
            var xls = new XmlSerializer(typeof(List<Movie>));

            TextWriter tw = new StreamWriter(filePath);
            xls.Serialize(tw, movies);
            tw.Close();
        }

        public static List<Movie> ReadFromXml(string filePath)
        {
            var deserializer = new XmlSerializer(typeof(List<Movie>));
            TextReader tr = new StreamReader(@filePath);
            List<Movie> movie;
            movie = (List<Movie>) deserializer.Deserialize(tr);
            tr.Close();

            foreach (var value in movie)
            {
                Console.WriteLine(value.Rating);
                Console.WriteLine(value.ReleaseDate);
                Console.WriteLine(value.Title);
                Console.WriteLine("__________");
            }

            Console.Read();
            return movie;
        }
    }
}

public class MovieClss
{
    public List<Movie> movieList = new List<Movie>();
}

//Movie class
public class Movie
{
    public string Title { get; set; }


    public int Rating { get; set; }


    public DateTime ReleaseDate { get; set; }
}

