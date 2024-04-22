/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{

    public class FormaGeometrica
    {
        private readonly decimal _lado;

        public decimal Lado { get { return _lado; } }

        public FormaGeometrica(decimal ancho)
        {
            _lado = ancho;
        }

        public static string Imprimir(List<FormaGeometrica> formas, EnumIdioma idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == EnumIdioma.Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else if (idioma == EnumIdioma.Ingles)
                    sb.Append("<h1>Empty list of shapes!</h1>");
                else
                    sb.Append("<h1>Elenco vuoto di forme!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == EnumIdioma.Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>"); 
                else if(idioma == EnumIdioma.Ingles)
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");
                else
                    sb.Append("<h1>Reporté de Formas</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecios = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTrapecios = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTrapecios = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i] is Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    else if (formas[i] is Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    else if (formas[i] is TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                    else if (formas[i] is Trapecio)
                    {
                        numeroTrapecios++;
                        areaTrapecios += formas[i].CalcularArea();
                        perimetroTrapecios += formas[i].CalcularPerimetro();
                    }
                }
                
                if(numeroCuadrados > 0)
                    sb.Append(Cuadrado.ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, idioma));
                
                if(numeroCirculos > 0)
                    sb.Append(Circulo.ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, idioma));
                
                if(numeroTriangulos > 0)
                    sb.Append(TrianguloEquilatero.ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, idioma));

                if (numeroTrapecios > 0)
                    sb.Append(Trapecio.ObtenerLinea(numeroTrapecios, areaTrapecios, perimetroTrapecios, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + " " + TraducirForma(idioma) + " ");
                sb.Append(TraducirPerimetro(idioma) + " " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTrapecios).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaTrapecios).ToString("#.##"));
            }

            return sb.ToString();
        }

        public static string TraducirPerimetro(EnumIdioma idioma)
        {
            return idioma == EnumIdioma.Castellano ? "Perimetro" :
                idioma == EnumIdioma.Ingles ? "Perimeter" :
                idioma == EnumIdioma.Italiano ? "Perimetro" :
                string.Empty;
        }

        public static string TraducirForma(EnumIdioma idioma)
        {
            return idioma == EnumIdioma.Castellano ? "formas" :
                idioma == EnumIdioma.Ingles ? "shapes" :
                idioma == EnumIdioma.Italiano ? "forme" : 
                string.Empty;
        }

        public virtual decimal CalcularArea()
        {
            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        }

        public virtual decimal CalcularPerimetro()
        {
            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        }
    }
}
