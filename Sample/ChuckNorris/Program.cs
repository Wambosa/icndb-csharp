using System;
using ChuckNorris;
using System.Text.RegularExpressions;

namespace Sample {
    class Program {
        static void Main(string[] args) {

            var response = ChuckNorris.API.Random(exclude: new string[] {"explicit"}, isHTML: false);
            var joke = response.Result;
            string clean_joke = "test message";

            try {

                clean_joke = Regex.Replace(joke.Text, @"[^\w\.\s-_]|(quot)|(q uot)", "");
            
            }catch (ArgumentNullException) {
                // baha do nothing
            }

            Console.WriteLine(clean_joke);
        }
    }
}
