using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Company.Function
{
    public static class ResizeHttpTrigger
    {
        [FunctionName("ResizeHttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            int w = int.Parse(req.Query["w"]);
            int h = int.Parse(req.Query["h"]);

            byte[]  targetImageBytes;
            using(var  msInput = new MemoryStream())
            {
                // Récupère le corps du message en mémoire
                await req.Body.CopyToAsync(msInput);
                msInput.Position = 0;

                // Charge l'image       
                using (var image = Image.Load(msInput)) 
                {
                    // Effectue la transformation
                    image.Mutate(x => x.Resize(w, h)); 

                    // Sauvegarde en mémoire               
                    using (var msOutput = new MemoryStream())
                    {
                        image.SaveAsJpeg(msOutput);
                        targetImageBytes = msOutput.ToArray();
                    }
                }
            }
            // Renvoie le contenu avec le content-type correspondant à une image jpeg
            return new FileContentResult(targetImageBytes, "image/jpeg");        }
    }
}
