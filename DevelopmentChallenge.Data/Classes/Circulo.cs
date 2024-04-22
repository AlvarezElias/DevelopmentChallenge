using DevelopmentChallenge.Data.Enums;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        public Circulo(decimal ancho) : base(ancho)
        {
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (Lado / 2) * (Lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Lado;
        }


        public static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, EnumIdioma idioma)
        {
            return $"{cantidad} {ObtenerNombre(cantidad > 1, idioma)} | Area {area:#.##} | {TraducirPerimetro(idioma)} {perimetro:#.##} <br/>";
        }

        public static string ObtenerNombre(bool plural, EnumIdioma idioma)
        {
            switch (idioma)
            {
                case EnumIdioma.Castellano:
                    return plural ? "Círculos" : "Círculo";
                case EnumIdioma.Ingles:
                    return plural ? "Circles" : "Circle";

                case EnumIdioma.Italiano:
                    return plural ? "Cerchi" : "Cerchio";
            }
            return string.Empty;
        }
    }
}
