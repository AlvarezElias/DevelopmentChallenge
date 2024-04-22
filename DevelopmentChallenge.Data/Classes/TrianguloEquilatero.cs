using DevelopmentChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(decimal ancho) : base(ancho)
        {
        }
        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 3;
        }

        public static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, EnumIdioma idioma)
        {
            return $"{cantidad} {ObtenerNombre(cantidad > 1, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
        }

        public static string ObtenerNombre(bool plural, EnumIdioma idioma)
        {
            switch (idioma)
            {
                case EnumIdioma.Castellano:
                    return plural ? "Triángulos" : "Triángulo";
                case EnumIdioma.Ingles:
                    return plural ? "Triangles" : "Triangle";
                case EnumIdioma.Italiano:
                    return plural ? "triangoli" : "Triangolo";
            }
            return string.Empty;
        }
    }
}
