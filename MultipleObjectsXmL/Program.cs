using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace MultipleObjectsXmL
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie firstMov = new Movie();
            firstMov.Title = "Shrek";
            firstMov.Rating = 2;
            firstMov.ReleaseDate = DateTime.Now;

            Movie secondMov = new Movie();
            secondMov.Title = "Hamza Anis";
            secondMov.Rating = 4;
            secondMov.ReleaseDate = DateTime.Now;

            Movies moviesObj = new Movies();
            moviesObj.movieList.Add(firstMov);
            moviesObj.movieList.Add(secondMov);
            List<Movie> movList = new List<Movie>() { firstMov, secondMov };

            SerializeToXml(moviesObj.movieList, "c:\\hamza\\1.xml");

            DeserializeFromXml("c:\\hamza\\1.xml");
        }

        // The static class and funcion that creates the xml file 
        public static void SerializeToXml(List<Movie> movies, string filePath)
        {
            XmlSerializer xls = new XmlSerializer(typeof(List<Movie>));

            TextWriter tw = new StreamWriter(filePath);
            xls.Serialize(tw, movies);
            tw.Close();
        }

        public static List<Movie> DeserializeFromXml(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Movie>));
            TextReader tr = new StreamReader(@filePath);
            List<Movie> movie;
            movie = (List<Movie>)deserializer.Deserialize(tr);
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

public class Movies
{
    public List<Movie> movieList = new List<Movie>();

}

//Movie class
public class Movie
{

    public string Title
    { get; set; }


    public int Rating
    { get; set; }


    public DateTime ReleaseDate
    { get; set; }

}

