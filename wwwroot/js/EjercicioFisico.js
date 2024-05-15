// function GetEjerciciosFisicos() {{
//     $.ajax({
//         // la URL para la petición
//         url: '../../EjerciciosFisicos/ListadoEjercicios',
//         // la información a enviar
//         // (también es posible utilizar una cadena de datos)
//         data: {  },
//         // especifica si será una petición POST o GET
//         type: 'POST',
//         // el tipo de información que se espera de respuesta
//         dataType: 'json',
//         // código a ejecutar si la petición es satisfactoria;
//         // la respuesta es pasada como argumento a la función
//         success: function (Ejercicios) {

//             $("#ModalTipoEjercicio").modal("hide");
//             LimpiarModal();
//             let contenidoTabla = ``;
            
window.onload = ListadoEjerciciosFisicos();
function ListadoEjerciciosFisicos(){
    $.ajax({
        // la URL para la petición
        url: '../../EjerciciosFisicos/ListadoTipoEjerciciosFisicos',
        // la información a enviar
        // (también es posible utilizar una cadena de datos)
        data: {  },
        // especifica si será una petición POST o GET
        type: 'POST',
        // el tipo de información que se espera de respuesta
        dataType: 'json',
        // código a ejecutar si la petición es satisfactoria;
        // la respuesta es pasada como argumento a la función
        success: function (ejerciciosFisicos) {

            $("#ModalEjercicioFisico").modal("hide");
            // LimpiarModal()
            //$("#tbody-tipoejercicios").empty();
            let contenidoTabla = ``;



            $.each(ejerciciosFisicos, function (Index, EjerciciosFisicos) {  

        
                
               contenidoTabla += `
              <tr class="fila-resaltar">
                  <td class="borde-td align-middle"><div><p>${EjerciciosFisicos.ejercicioNombre}</p></div></td>
               <td class="borde-td align-middle" style="max-width: 8rem;"><div><p>${EjerciciosFisicos.inicioString}</p></div></td>
                   <td class="borde-td align-middle" style="max-width: 8rem;"><div><p>${EjerciciosFisicos.finString}</p></div></td>
               <td class="borde-td align-middle"><div><p>${EjerciciosFisicos.estadoInicio}</p></div></td>
                 <td class="borde-td align-middle"><div><p>${EjerciciosFisicos.estadoFin}</p></div></td>
                 <td class="borde-td align-middle" style=" max-width: 12rem;"><div><p>${EjerciciosFisicos.observaciones}</p></div></td>
                 <td class="text-center">
                <button type="button" class="btn btn-success" onclick="AbrirModalEditar(${EjerciciosFisicos.ejercicioFisicoID})">
               Editar
                </button>
                    </td>
               <td class="text-center">

             <button type="button" class="btn btn-danger" onclick="ValidacionEliminar(${EjerciciosFisicos.ejercicioFisicoID})"> Eliminar
             </button>
             </td>
             </tr>
                     `;

         });
            

         document.getElementById("tbody-EjerciciosFisicos").innerHTML = contenidoTabla;

        },


        











        // código a ejecutar si la petición falla;
        // son pasados como argumentos a la función
        // el objeto de la petición en crudo y código de estatus de la petición
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema al cargar el listado');
        }
    });

}

function NuevoRegistro()
{
    $("#ModalTitulo").text("Nuevo Tipo de Ejercicio");

}

function LimpiarModal(){
    document.getElementById("EjercicioFisicoID").value = 0;
    document.getElementById("tipoEjercicioID").value = 0;
    document.getElementById("inicio").value = "";
    document.getElementById("fin").value = "";
    document.getElementById("estadoEmocionalInicio").value = 0;
    document.getElementById("estadoEmocionalFin").value = 0;
    document.getElementById("observaciones").value = ""
}




function GuardarEjerciciosFisicos(){
    //GUARDAMOS EN UNA VARIABLE LO ESCRITO EN EL INPUT DESCRIPCION
    let EjerciciofisicoID = document.getElementById("EjercicioFisicoID").value;
    let tipoEjercicioID = document.getElementById("TipoEjercicioID").value;
    let inicio = document.getElementById("Inicio").value;
    let fin = document.getElementById("Fin").value;
    let estadoInicio = document.getElementById("EstadoEmocionalInicio").value;
    let estadoFin = document.getElementById("EstadoEmocionalFin").value;
    let observaciones = document.getElementById("Observaciones").value;

    //POR UN LADO PROGRAMAR VERIFICACIONES DE DATOS EN EL FRONT CUANDO SON DE INGRESO DE VALORES Y NO SE NECESITA VERIFICAR EN BASES DE DATOS
    //LUEGO POR OTRO LADO HACER VERIFICACIONES DE DATOS EN EL BACK, SI EXISTE EL ELEMENTO SI NECESITAMOS LA BASE DE DATOS.
    $.ajax({
        // la URL para la petición
        url: '../../EjerciciosFisicos/GuardarEjerciciosFisicos',
        // la información a enviar
        // (también es posible utilizar una cadena de datos)
        data: { EjerciciofisicoID: EjerciciofisicoID,tipoEjercicioID: tipoEjercicioID, 
                inicio: inicio, fin: fin, estadoInicio: estadoInicio, estadoFin: estadoFin, 
                observaciones: observaciones},
        // especifica si será una petición POST o GET
        type: 'POST',
        // el tipo de información que se espera de respuesta
        dataType: 'json',
        // código a ejecutar si la petición es satisfactoria;
        // la respuesta es pasada como argumento a la función
        success: function (resultado) {

            if(resultado != ""){
                alert(resultado);
            }
            ListadoEjerciciosFisicos();
        },

        // código a ejecutar si la petición falla;
        // son pasados como argumentos a la función
        // el objeto de la petición en crudo y código de estatus de la petición
        error: function (xhr, status) {
            console.log('Disculpe, existió un problema al guardar el registro');
        }
    });    
}

function GetEjerciciosFisicos() {
    $.ajax({
        url: '/EjerciciosFisicos/GetEjerciciosFisicos', // Ruta de la acción en tu controlador
        type: 'GET', // Método HTTP GET para obtener los datos
        dataType: 'json', // Tipo de datos esperados en la respuesta (JSON en este caso)
        success: function (data) { // Función que se ejecuta si la llamada AJAX es exitosa
            // 'data' contiene los ejercicios físicos devueltos por el controlador
            // Aquí puedes procesar los datos y mostrarlos en tu página
            console.log(data); // Muestra los datos en la consola del navegador (puedes quitar esta línea)
            // Por ejemplo, puedes recorrer los ejercicios físicos y mostrarlos en una tabla
            var contenidoTabla = '';
            $.each(data, function (index, ejercicio) {
                contenidoTabla += '<tr>';
                contenidoTabla += '<td>' + ejercicio.ejercicioNombre + '</td>';
                // Agrega más celdas para otras propiedades del ejercicio físico si es necesario
                contenidoTabla += '</tr>';
            });
            // Inserta el contenido de la tabla en el tbody de la tabla en tu HTML
            $('#tbody-tipoejercicios').html(contenidoTabla);
        },
        error: function (xhr, status, error) { // Función que se ejecuta si hay un error en la llamada AJAX
            console.error(error); // Muestra el error en la consola del navegador
            // Puedes agregar un mensaje de error en tu página aquí si es necesario
        }
    });


}



  


function AbrirModalEditar(ejercicioFisicoID){
    console.log(ejercicioFisicoID)
    $.ajax({
        // la URL para la petición
        url: '../../EjerciciosFisicos/EjerciciosFisicos',
        // la información a enviar
        // (también es posible utilizar una cadena de datos)
        data: { ejercicioFisicoID: ejercicioFisicoID},
        // especifica si será una petición POST o GET
        type: 'POST',
        // el tipo de información que se espera de respuesta
        dataType: 'json',
        // código a ejecutar si la petición es satisfactoria;
        // la respuesta es pasada como argumento a la función
        success: function (ejercicioFisico) {



            let ejerciciosFisicos = ejercicioFisico[0];

            console.log(ejerciciosFisicos);

            document.getElementById("EjercicioFisicoID").value = ejercicioFisicoID;
            $("#ModalTitulo").text("Editar Tipo de Ejercicio");
            document.getElementById("TipoEjercicioID").value = ejerciciosFisicos.tipoEjercicioID;
            document.getElementById("Inicio").value = ejerciciosFisicos.inicio;
            document.getElementById("Fin").value = ejerciciosFisicos.fin;
            document.getElementById("EstadoEmocionalInicio").value = ejerciciosFisicos.estadoEmocionalInicio;
            document.getElementById("EstadoEmocionalFin").value = ejerciciosFisicos.estadoEmocionalFin
            ;
            document.getElementById("Observaciones").value = ejerciciosFisicos.observaciones;

            $("#ModalEjercicioFisico").modal("show");
        },

        // código a ejecutar si la petición falla;
        // son pasados como argumentos a la función
        // el objeto de la petición en crudo y código de estatus de la petición
        error: function (xhr, status) {
            Swal.fire({
                title: "Disculpe",
                text: "existió un problema al consultar el registro para ser modificado.",
                icon: "warning",
            });
        }
    });
}



//VALIDACION PARA ELIMINAR EJERCICOS (FUNCIONA NO MODIFICAR)

function ValidacionEliminar(idEjercicioFisico) {
    
     var deseaEliminar = confirm("¿Desea Eliminar la actividad?");
  
    if (deseaEliminar == true) {
        EliminarRegistro(idEjercicioFisico);
    } 
  
//Funcion eliminar registro
function EliminarRegistro(idEjercicioFisico) {
    $.ajax({
      url: "../../EjerciciosFisicos/EliminarRegistro",
      data: { idEjercicioFisico: idEjercicioFisico },
      type: "POST",
      dataType: "Json",
  
      success: function (resultado) {
        ListadoEjerciciosFisicos();
      },
      error: function (xhr, status) {
        alert("hubo un error");
      },
    });
}}

