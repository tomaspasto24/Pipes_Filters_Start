using System;
using CognitiveCoreUCU;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        CognitiveFace faceFilter = new CognitiveFace(true, Color.LightGoldenrodYellow);
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, @"FilterConditional.jpg");
            return image;
        }
        /// <summary>
        /// Función que llama al metodo Recognize de la API con el parámetro path de la imagen, se asume
        /// que previamente se ejecutó el método Filter.
        /// </summary>
        /// <returns>Verdadero o Falso según si se encuentra la cara o no.</returns>
        public bool ConditionalFace()
        {
            faceFilter.Recognize(@"FilterConditional.jpg");
            return faceFilter.FaceFound;
        }
    }
}