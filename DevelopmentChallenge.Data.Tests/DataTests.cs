using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EnumIdioma.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EnumIdioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), EnumIdioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new Cuadrado(5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, EnumIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCirculo()
        {
            var circulos = new List<FormaGeometrica> { new Circulo(8) };

            var resumen = FormaGeometrica.Imprimir(circulos, EnumIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Círculo | Area 50,27 | Perimetro 25,13 <br/>TOTAL:<br/>1 formas Perimetro 25,13 Area 50,27", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrianguloEnItaliano()
        {
            var triangulos = new List<FormaGeometrica> { new TrianguloEquilatero(8) };

            var resumen = FormaGeometrica.Imprimir(triangulos, EnumIdioma.Italiano);

            Assert.AreEqual("<h1>Reporté de Formas</h1>1 Triangolo | Area 27,71 | Perimetro 24 <br/>TOTAL:<br/>1 forme Perimetro 24 Area 27,71", resumen);
        }
        
        [TestCase]
        public void TestResumenListaConUnTrapecioEnCastellano()
        {
            var trapecios = new List<FormaGeometrica> { new Trapecio(3,5) };

            var resumen = FormaGeometrica.Imprimir(trapecios, EnumIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 12,5 | Perimetro 15 <br/>TOTAL:<br/>1 formas Perimetro 15 Area 12,5", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, EnumIdioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }
        
        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
                new Trapecio(2,6),
                new Trapecio(2,4)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EnumIdioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>2 trapezoids | Area 15 | Perimeter 26 <br/>TOTAL:<br/>9 shapes Perimeter 123,66 Area 106,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
                new Trapecio(2,6),
                new Trapecio(2,4)
            };

            var resumen = FormaGeometrica.Imprimir(formas, EnumIdioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>2 Trapecios | Area 15 | Perimetro 26 <br/>TOTAL:<br/>9 formas Perimetro 123,66 Area 106,65",
                resumen);
        }
    }
}
