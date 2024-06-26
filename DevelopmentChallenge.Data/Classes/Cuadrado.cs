﻿using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(decimal ancho) : base(ancho)
        {
        }

        public override decimal CalcularArea()
        {
            return Lado * Lado; 
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 4;
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
                    return plural ? "Cuadrados" : "Cuadrado";
                case EnumIdioma.Ingles:
                    return plural ? "Squares" : "Square";

                case EnumIdioma.Italiano:
                    return plural ? "Piazze" : "Piazza";
            }
            return string.Empty;
        }
    }
}
