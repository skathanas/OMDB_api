using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace Movie_API
{
    class getMovie
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name a movie you want info about:");
            GetMovie();

        }

        public static void GetMovie() {

            string apiKey = "c80152e7";
            string baseUri = $"http://www.omdbapi.com/?apikey={apiKey}";

            string name = Console.ReadLine().ToLower();
            string type = "movie";

            var sb = new StringBuilder(baseUri);
            sb.Append($"&s={name}");
            sb.Append($"&type={type}");
            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
            request.Timeout = 1000;
            request.Method = "GET";
            request.ContentType = "application/json";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Info fInfo = JsonConvert.DeserializeObject<Info>(response);
                Console.WriteLine(response);
               
            /* kood mis ei tööta:
                Console.WriteLine(fInfo.Title);
                Console.WriteLine(fInfo.Year);
                Console.WriteLine(fInfo.Rated);
                Console.WriteLine(fInfo.Released);
                Console.WriteLine(fInfo.Runtime);
                Console.WriteLine(fInfo.Genre);
                Console.WriteLine(fInfo.Director);
                Console.WriteLine(fInfo.Writer);
                Console.WriteLine(fInfo.Actors);
                Console.WriteLine(fInfo.Plot);
                Console.WriteLine(fInfo.Language);
                Console.WriteLine(fInfo.Country);
                Console.WriteLine(fInfo.Awards);
                Console.WriteLine(fInfo.Poster);
                Console.WriteLine(fInfo.Metascore);
                Console.WriteLine(fInfo.imdbRating);
                Console.WriteLine(fInfo.imdbVotes);
                Console.WriteLine(fInfo.imdbID);
                Console.WriteLine(fInfo.Type);
                Console.WriteLine(fInfo.Response);
                */

                
            }



        }

    }
}