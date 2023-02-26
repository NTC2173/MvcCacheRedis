using MvcCacheRedis.Helpers;
using MvcCacheRedis.Models;
using System.Xml.Linq;

namespace MvcCacheRedis.Repositories
{
    public class RepositoryProductos
    {
        private XDocument document;

        //NOTA: Siempre que leamos datos de una BD o un elemento físico, es un repository. Pero
        //si se leen datos desde la nube, es un service
        public RepositoryProductos(HelperPathProvider helper)
        {
            string path = helper.MapPath("productos.xml", Folders.Documents);
            this.document = XDocument.Load(path);
        }

        public List<Producto> GetProductos()
        {
            var consulta = from datos in this.document.Descendants("producto")
                           select new Producto
                           {
                               IdProducto = int.Parse(datos.Element("idproducto").Value),
                               Nombre = datos.Element("nombre").Value,
                               Descripcion = datos.Element("descripcion").Value,
                               Precio = int.Parse(datos.Element("precio").Value),
                               Imagen = datos.Element("imagen").Value
                           };

            return consulta.ToList();
        }

        public Producto FindProducto(int idproducto)
        {
            return this.GetProductos().FirstOrDefault(z => z.IdProducto == idproducto);
        }
    }
}
