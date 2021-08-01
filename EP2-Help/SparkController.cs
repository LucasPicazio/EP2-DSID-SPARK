using Microsoft.Spark;
using Microsoft.Spark.Sql;
using System;
using System.Collections.Generic;

namespace EP2
{
    public class SparkController : ISparkController
    {
        private readonly Calculos CalculosController;
        private readonly SparkSession spark;

        public SparkController()
        {
            this.spark = SparkSession.Builder().AppName("EP2").Master("local").GetOrCreate();
            spark.SparkContext.SetLogLevel("ERROR");
            this.CalculosController = new Calculos();

        }

        public List<Tuple<string, float?>> calculaMedia(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group)
        {
            var filenames = Conexoes.RetornaCSV(years, stations, spark.SparkContext).ToArray();
            return CalculosController.calculaMedia(filenames, spark, data, group);
        }

        public List<Tuple<string, float?>> calculaVar(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group)
        {
            var filenames = Conexoes.RetornaCSV(years, stations, spark.SparkContext).ToArray();
            return CalculosController.calculaVariancia(filenames, spark, data, group);
        }

        public List<Tuple<string, float?>> calculaDesvio(IEnumerable<int> years, IEnumerable<Station> stations, string data, string group)
        {
            var filenames = Conexoes.RetornaCSV(years, stations, spark.SparkContext).ToArray();
            return CalculosController.calculaDesvio(filenames, spark, data, group);
        }

        public Tuple<float, float, List<float>, List<float>> calculaQuadrados(IEnumerable<int> years, IEnumerable<Station> stations, string data, string data2)
        {
            var filenames = Conexoes.RetornaCSV(years, stations, spark.SparkContext).ToArray();
            return CalculosController.calculaQuadradosMinimos(filenames, spark, data, data2);
        }
    }
}
