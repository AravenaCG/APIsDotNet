using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Platzi;
using Entity_Framework_Platzi.Models;

namespace APIs_.NET.Services
{
    public class CategoriaService:ICategoriaService
    {

        Entity_Framework_Platzi.TareasContext contex;

        public CategoriaService(TareasContext dbContext)
        {
            contex = dbContext;

        }
        public IEnumerable<Categoria> Get()
        {
            return contex.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            contex.Add(categoria);
            await contex.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            var categoriaActual = contex.Categorias.Find(id);
            if (categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;
                await contex.SaveChangesAsync();

            }
        }

        public async Task Delete(Guid id)
        {
            var categoriaActual = contex.Categorias.Find(id);
            if (categoriaActual != null)
            {
                contex.Remove(categoriaActual);
                await contex.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Update(Guid id, Categoria categoria);
        Task Save(Categoria categoria);
        Task Delete(Guid id);

    }
}