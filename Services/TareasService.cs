using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Platzi;
using Entity_Framework_Platzi.Models;


namespace APIs_.NET.Services
{
    public class TareasService:ITareasService
    {
        TareasContext tareasContext;
        public TareasService(TareasContext dbContext){
            tareasContext=dbContext;
        }

        public IEnumerable<Tarea> Get(){
            return tareasContext.Tareas;
        }

        public async Task Save(Tarea tarea){
             tareasContext.Add(tarea);
             await tareasContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea){
            var tareaActual = tareasContext.Tareas.Find(id);
            if(tareaActual != null){
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.Categoria = tarea.Categoria;
                await tareasContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id ){
            var tareaActual= tareasContext.Tareas.Find(id);
            if(tareaActual != null){
                tareasContext.Remove(id);
                await tareasContext.SaveChangesAsync();
            }
        }

    }

        public interface ITareasService{
        IEnumerable<Tarea> Get();

        Task Update(Guid id, Tarea tarea);
        Task Save(Tarea tarea);
        Task Delete(Guid id);    
    }
}