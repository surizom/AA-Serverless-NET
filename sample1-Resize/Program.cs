using System;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open the file automatically detecting the file type to decode it.
            // Our image is now in an uncompressed, file format agnostic, structure in-memory as
            // a series of pixels.
            using (Image image = Image.Load(@"C:\Users\lvovan\Pictures\chaussures_abimees.jpg")) 
            {
                // Resize the image in place and return it for chaining.
                // 'x' signifies the current image processing context.
                image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10)); 

                // The library automatically picks an encoder based on the file extension then
                // encodes and write the data to disk.
                // You can optionally set the encoder to choose.
                image.SaveAsJpeg(@"c:\temp\bar.jpg"); 
            } // Dispose - releasing memory into a memory pool ready for the next image you wish to process.
        }
    }
}
