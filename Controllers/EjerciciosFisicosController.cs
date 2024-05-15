using Microsoft.AspNetCore.Mvc;
using ProyectoJuli.Models;
using ProyectoJuli.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoJuli.Controllers;


// [Authorize]
public class EjerciciosFisicosController : Controller
{
    private ApplicationDbContext _context;

    //CONSTRUCTOR
    public EjerciciosFisicosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() 
    {
        // Crear una lista de SelectListItem que incluya el elemento adicional
        var selectListItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "[SELECCIONE...]" }
        };

        // Obtener todas las opciones del enum
        var enumValues = Enum.GetValues(typeof(EstadoEmocional)).Cast<EstadoEmocional>();

        // Convertir las opciones del enum en SelectListItem
        selectListItems.AddRange(enumValues.Select(e => new SelectListItem
        {
            Value = e.GetHashCode().ToString(),
            Text = e.ToString().ToUpper()
        }));

        // Pasar la lista de opciones al modelo de la vista
        ViewBag.EstadoEmocionalInicio = selectListItems.OrderBy(t => t.Text).ToList();
        ViewBag.EstadoEmocionalFin = selectListItems.OrderBy(t => t.Text).ToList();

        var tipoEjercicios = _context.TipoEjercicios.ToList();
        tipoEjercicios.Add(new TipoEjercicio { TipoEjercicioID = 0, Descripcion = "[SELECCIONE...]" });
        ViewBag.TipoEjercicioID = new SelectList(tipoEjercicios.OrderBy(c => c.Descripcion), "TipoEjercicioID", "Descripcion");

        return View();
    }

    public JsonResult ListadoTipoEjerciciosFisicos(int? id)
    {
        List<VistaEjercicios> EjerciciosMostrar = new List<VistaEjercicios>();

        var EjerciciosFisicos = _context.EjerciciosFisicos.ToList();

        if (id != null)
        {
            EjerciciosFisicos = EjerciciosFisicos.Where(e => e.EjercicioFisicoID == id).ToList();
        }

        var Ejercicio = _context.TipoEjercicios.ToList();

        foreach (var EjercicioFisico in EjerciciosFisicos)

        {
            var ejercicio = Ejercicio.Where(e => e.TipoEjercicioID == EjercicioFisico.TipoEjercicioID).Single();

            var EjercicioMostrar = new VistaEjercicios
            {
                EjercicioFisicoID = EjercicioFisico.EjercicioFisicoID,
                 TipoEjercicioID = EjercicioFisico.TipoEjercicioID,
                EjercicioNombre = ejercicio.Descripcion,
                InicioString = EjercicioFisico.Inicio.ToString("dd/MM/yyyy HH:mm"),
                FinString = EjercicioFisico.Fin.ToString("dd/MM/yyyy HH:mm"),
                EstadoInicio = Enum.GetName(typeof(EstadoEmocional), EjercicioFisico.EstadoEmocionalInicio),
                EstadoFin = Enum.GetName(typeof(EstadoEmocional), EjercicioFisico.EstadoEmocionalFin),
                Observaciones = EjercicioFisico.Observaciones

            };
            EjerciciosMostrar.Add(EjercicioMostrar);
        }

        return Json(EjerciciosMostrar);
}



    public JsonResult EjerciciosFisicos(int? EjercicioFisicoID)
    {
        //DEFINIMOS UNA VARIABLE EN DONDE GUARDAMOS EL LISTADO COMPLETO DE TIPOS DE EJERCICIOS
        var ejerciciosFisicos = _context.EjerciciosFisicos.ToList();
        
        //LUEGO PREGUNTAMOS SI EL USUARIO INGRESO UN ID
        //QUIERE DECIR QUE QUIERE UN EJERCICIO EN PARTICULAR
        if (EjercicioFisicoID != null)
        {
        //FILTRAMOS EL LISTADO COMPLETO DE EJERCICIOS POR EL EJERCICIO QUE COINCIDA CON ESE ID
            ejerciciosFisicos = ejerciciosFisicos.Where(e => e.EjercicioFisicoID == EjercicioFisicoID).ToList();    
        }

        return Json(ejerciciosFisicos.ToList());
    }
    


public JsonResult GuardarEjerciciosFisicos(int EjercicioFisicoID, int TipoEjercicioID, DateTime Inicio, DateTime Fin, EstadoEmocional EstadoInicio, EstadoEmocional EstadoFin, string Observaciones)
    {
        //1- VERIFICAMOS SI REALMENTE INGRESO ALGUN CARACTER Y LA VARIABLE NO SEA NULL
        // if (descripcion != null && descripcion != "")
        // {
        //     //INGRESA SI ESCRIBIO SI O SI
        // }         
        string resultado = "";
        if (EjercicioFisicoID != null)
        {
            //2- VERIFICAR SI ESTA EDITANDO O CREANDO NUEVO REGISTRO
            if (EjercicioFisicoID == 0)
            {
                var EjercicioFisico = new EjercicioFisico
                {
                    EjercicioFisicoID = EjercicioFisicoID,
                    TipoEjercicioID = TipoEjercicioID,
                    Inicio = Inicio,
                    Fin = Fin,
                    EstadoEmocionalInicio = EstadoInicio,
                    EstadoEmocionalFin = EstadoFin,
                    Observaciones = Observaciones
                };
                _context.Add(EjercicioFisico);
                _context.SaveChanges();
                  resultado = "Ejercicio físico guardado correctamente";
            }   

            else{
                var ejercicioFisicoEditar = _context.EjerciciosFisicos.Where(e => e.EjercicioFisicoID == EjercicioFisicoID).SingleOrDefault();
                
                {
                    var existeEjercicioFisico = _context.EjerciciosFisicos.Where(e => e.EjercicioFisicoID == EjercicioFisicoID).Count(); {
                        ejercicioFisicoEditar.TipoEjercicioID = TipoEjercicioID;
                        ejercicioFisicoEditar.Inicio = Inicio;
                        ejercicioFisicoEditar.Fin = Fin;
                        ejercicioFisicoEditar.EstadoEmocionalInicio = EstadoInicio;
                        ejercicioFisicoEditar.EstadoEmocionalFin = EstadoFin;
                        ejercicioFisicoEditar.Observaciones = Observaciones;
                        _context.SaveChanges();
                          resultado = "Ejercicio físico actualizado correctamente";
                    }
                }
            }
        }
        return Json(resultado);
    }

      public JsonResult EliminarRegistro (int idEjercicioFisico) 
    {
         var ejercicio = _context.EjerciciosFisicos.Find(idEjercicioFisico);
        _context.Remove(ejercicio);
        _context.SaveChanges();
        return Json(true);

}
}