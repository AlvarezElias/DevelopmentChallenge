using DevelopmentChallenge.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Interfaces
{
    internal interface IFormaGeometrica
    {
        string TraducirForma(bool plural, EnumIdioma idioma);
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }
}
