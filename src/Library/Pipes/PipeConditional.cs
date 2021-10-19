using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;

namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        protected IFilter filtroTrue;
        protected IFilter filtroFalse;
        protected FilterConditional filtroConditional;
        protected IPipe nextPipe;
        protected PictureProvider provider = new PictureProvider();

        
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtroConditional">Filtro condicional que debe ser aplicado</param>
        /// <param name="filtroTrue">Filtro que se debe aplicar sobre la imagen en caso de verdadero</param>
        /// <param name="filtroFalse">Filtro que se debe aplicar sobre la imagen en caso de falso</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeConditional(FilterConditional filtroConditional, IFilter filtroTrue, IFilter filtroFalse, IPipe nextPipe)
        {
            this.nextPipe = nextPipe;
            this.filtroTrue = filtroTrue;
            this.filtroFalse = filtroFalse;
            this.filtroConditional = filtroConditional;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>
        public IFilter FilterTrue
        {
            get { return this.filtroTrue; }
        }       
        public IFilter FilterFalse
        {
            get { return this.filtroFalse; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filtroConditional.Filter(picture);
            if(this.filtroConditional.ConditionalFace())
                picture = this.filtroTrue.Filter(provider.GetPicture(@"tmpFace.jpg"));
            else 
                picture = this.filtroFalse.Filter(picture);
            return this.nextPipe.Send(picture);
        }
    }
}