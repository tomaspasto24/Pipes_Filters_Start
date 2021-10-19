using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            //Se guarda la imagen para poder tener un path el cual pasar como parámetro.
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, "FilterTwitter.jpg");

            TwitterImage imageTwitter = new TwitterImage();
            System.Console.WriteLine(imageTwitter.PublishToTwitter("Prueba1", @"FilterTwitter.jpg"));
            return image;
        }
    }
}