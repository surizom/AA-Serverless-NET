using System;
using System.Linq;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Threading.Tasks;

namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCollection = Enumerable.Repeat(@"C:\Users\lvovan\Pictures\chaussures_abimees.jpg", 20);
            Parallel.ForEach (myCollection, (nomFichier) =>
            {
                using (Image image = Image.Load(nomFichier))
                {
                    Console.WriteLine("Retaillage...");
                    image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10)); 
                    // Pour la démo nous ne sauvegarderons pas pour éviter les verrouillages                
                    // image.SaveAsJpeg(@"c:\temp\bar.jpg"); 
                    Console.WriteLine("Fin du retaillage...");
                }
            });
        }
    }
}
