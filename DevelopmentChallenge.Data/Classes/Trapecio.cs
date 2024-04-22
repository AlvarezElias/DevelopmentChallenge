using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {

        private readonly decimal _alto;

        public decimal Alto { get { return _alto; } }

        public Trapecio(decimal ancho, decimal alto) : base(ancho)
        {
            _alto = alto;
        }

        public override decimal CalcularArea()
        {
            return  (Lado + (Lado - 1) ) * Alto  / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado + (Lado - 1) + Alto + Alto;
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
                    return plural ? "Trapecios" : "Trapecio";
                case EnumIdioma.Ingles:
                    return plural ? "trapezoids" : "trapeze";
                case EnumIdioma.Italiano:
                    return plural ? "trapezi" : "trapezio";
            }
            return string.Empty;
        }
    }
}
