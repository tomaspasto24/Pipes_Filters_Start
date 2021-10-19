using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            //Los Pipe respetan el enunciado de la letra. Se agregan más Pipes con filtros para comprobar
            // que las demás partes del ejercicio funcionen.
            PipeNull pipeN = new PipeNull();
            PipeSerial pipeS5 = new PipeSerial(new FilterSave(), pipeN);
            PipeConditional pipeS1 = new PipeConditional(new FilterConditional(), new FilterTwitter(), new FilterSave(), pipeS5);
            // PipeSerial pipeS3 = new PipeSerial(new FilterTwitter(), pipeS4);
            // PipeSerial pipeS2 = new PipeSerial(new FilterNegative(), pipeS3);
            // PipeSerial pipeS1 = new PipeSerial(new FilterGreyscale(), pipeS2);
            picture = pipeS1.Send(picture);

            provider.SavePicture(picture, @"Ejemplo.jpg");
        }
    }
}
