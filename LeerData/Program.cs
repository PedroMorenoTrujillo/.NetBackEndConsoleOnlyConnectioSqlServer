using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData {
    class Program {
        static void Main (string[] args) {
            using (var db = new AppVentaCursosContext ()) {
                //Primera prueba para ver conexion sin FK a precio
                //var cursos = db.Curso.AsNoTracking(); //Devuelve un array de objetos Iquerable
                //foreach(var curso in cursos) {
                //    Console.WriteLine (curso.Titulo + "......" + curso.Descripcion);
                //}

                //Segunda prueba incluyendo el precio de los cursos
                //var cursos = db.Curso.Include (p => p.PrecioPromocion).AsNoTracking ();
                //foreach (var curso in cursos) {
                //    Console.WriteLine (curso.Titulo + "-----" + curso.PrecioPromocion.PrecioActual);
                //}

                //Tercera prueba incluyendo comentarios
                //var cursos = db.Curso.Include (c => c.ComentarioLista).AsNoTracking ();
                //foreach (var curso in cursos) {
                //    Console.WriteLine (curso.Titulo);
                //    foreach (var comentario in curso.ComentarioLista) {
                //        Console.WriteLine ("---------" + comentario.ComentarioTexto);
                //    }
                //}

                //Cuarta prueba incluyendo Instructor
                var cursos = db.Curso.Include (c => c.InstructorLink).ThenInclude (ci => ci.Instructor).AsNoTracking ();
                foreach (var curso in cursos) {
                    Console.WriteLine (curso.Titulo);
                    foreach (var insLink in curso.InstructorLink) {
                        Console.WriteLine ("--------" + insLink.Instructor.Nombre);
                    }
                }

            }
        }
    }
}