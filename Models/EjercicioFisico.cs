
//Estas líneas son las declaraciones de los espacios de nombres que este archivo utiliza. 
using System.ComponentModel.DataAnnotations;  // son espacios de nombres de .NET que proporcionan atributos para definir metadatos sobre clases y propiedades. 
using System.ComponentModel.DataAnnotations.Schema; // igual al de arriba 
using ProyectoJuli.Models; 

namespace ProyectoJuli.Models//Es el de nombres propio del proyecto donde se define este código.

{
    public class EjercicioFisico //se define una clase llamada EjercicioFisico dentro del espacio de nombres ProyectoJuli.Models.
    {
        [Key] // El atributo [Key] indica que la propiedad EjercicioFisicoID es la clave primaria de la entidad en la base de datos. Esta propiedad representa el ID del ejercicio físico.
        public int EjercicioFisicoID { get; set; } 
        public int TipoEjercicioID { get; set; } //Esta propiedad TipoEjercicioID almacena el ID del tipo de ejercicio físico asociado.
        public DateTime Inicio { get; set; } //Estas propiedades Inicio y Fin representan el inicio y el fin del ejercicio físico, respectivamente, utilizando el tipo de dato DateTime.
        public DateTime Fin { get; set; }  
        public EstadoEmocional EstadoEmocionalInicio {get; set; } //Representan el estado emocional al inicio y al final del ejercicio físico, utilizando el tipo enumerado EstadoEmocional.
        public EstadoEmocional EstadoEmocionalFin {get; set; } 
        public string? Observaciones {get; set; } // Permite almacenar observaciones adicionales sobre el ejercicio físico. El signo de interrogación (?) indica que el valor puede ser nulo.

        public virtual TipoEjercicio TipoEjercicios { get; set; } // TipoEjercicio representa la relación entre un ejercicio físico y su tipo correspondiente, utilizando la palabra clave virtual para habilitar la carga diferida.
    }

// { get; set; }: Define los métodos de acceso (getter y setter) para la propiedad. 
//Esto significa que se puede leer (get) y escribir (set) en la propiedad 





  public enum EstadoEmocional{

// define un enum llamado EstadoEmocional que enumera diferentes estados emocionales que una persona podría experimentar.
//Cada elemento del enum tiene un valor asignado, y si no se especifica un valor,
// el compilador asignará automáticamente el siguiente número entero disponible en secuencia,


        Feliz = 1, // Aquí se asigna el valor 1 al estado emocional "Feliz".
        Triste, //Al no especificar un valor, el compilador asigna automáticamente el valor 2 a este estado emocional, ya que sigue en secuencia después de "Feliz".
        Enojado, //Los siguientes estados emocionales siguen en la secuencia numérica asignando automáticamente valores consecutivos si no se especifica ninguno.
        Ansioso,
        Estresado,
        Relajado,
        Aburrido,
        Emocionado,
        Agobiado,
        Confundido,
        Optimista,
        Pesimista,
        Motivado,
        Cansado,
        Eufórico,
        Agitado,
        Satisfecho,
        Desanimado
    }


public class VistaEjercicios{
        public int EjercicioFisicoID { get; set; }
        public int TipoEjercicioID { get; set; }
        public string? EjercicioNombre { get; set; }
        public string InicioString { get; set; }
        public string FinString { get; set; }
        public string? EstadoInicio { get; set; }
        public string? EstadoFin { get; set; }
        public string? Observaciones { get; set; }




  
    public class VistaSumaEjercicioFisico //  Esto define una nueva clase llamada VistaSumaEjercicioFisico que es pública, 
    //lo que significa que puede ser accesible desde cualquier otro lugar del código.
    {
        public string? TipoEjercicioNombre {get; set;}
        public int TotalidadMinutos {get; set; } //Esta línea define una propiedad llamada TotalidadMinutos que es un entero y representa el total de minutos de ejercicio físico.
        public int TotalidadDiasConEjercicio {get;set;}
        public int TotalidadDiasSinEjercicio {get;set;}

        public List<VistaEjercicioFisico>? DiasEjercicios {get;set;}
    }

    public class VistaEjercicioFisico
    {   
        public int Anio {get; set; }  
        public string? Mes { get; set; }
        public int? Dia { get; set; }
        public int CantidadMinutos { get; set; }
    }

     public class VistaEstadoEmocional
    {
        public int EstadoEmocionalID { get; set; }
        public string? Descripcion { get; set; }
    }
}}