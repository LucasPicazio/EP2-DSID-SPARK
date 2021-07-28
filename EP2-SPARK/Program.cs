using Microsoft.Spark;
using Microsoft.Spark.Sql;
using System;

namespace EP2_SPARK
{
    class Program
    {
        public static void Main(string[] args)
        {

            string USAF = "";
            string WBAN = "";
            string filename = "";
            int operacao = int.MinValue;
            int ano = int.MinValue;


            SparkSession spark = SparkSession.Builder().AppName("EP2").Master("local").GetOrCreate();
            spark.SparkContext.SetLogLevel("ERROR");
            //MOSTRA APRESENTAÇÃO INICIAL
            showGreetings();

            Console.WriteLine("Entre com o USAF ID: ");
            USAF = Console.ReadLine();

            Console.WriteLine("Entre com o WBAN ID: ");
            WBAN = Console.ReadLine();

            Console.WriteLine("Entre com o ano: ");
            ano = int.Parse(Console.ReadLine());

            filename = Conexoes.retornaCSV(USAF, WBAN, ano, spark.SparkContext);

            Console.WriteLine("Qual operação deseja realizar?");
            showOperations();
            operacao = int.Parse(Console.ReadLine());

            switch (operacao)
            {
                case 1:
                    Console.WriteLine("MEDIA");
                    Calculos.calculaMedia(filename,spark);
                    break;
                case 3:
                    Console.WriteLine("DESVIO PADRAO");
                    Calculos.calculaDesvio(filename, spark);
                    break;
                case 4:
                    Console.WriteLine("Variancia");
                    Calculos.calculaVariancia(filename, spark);
                    break;
                case 5:
                    Console.WriteLine("METODO DOS MINIMOS QUADRADOS");
                    Calculos.calculaQuadradosMinimos(filename, spark);
                    break;
            }

        }


        public static void showGreetings()
        {
            string greetings =
                "******************************************"
            + "\n*                                        *"
            + "\n* NCDC DATA - A HELPFUL TOOL 4 CIENTISTS *"
            + "\n*      EP2 - DSID			 *"
            + "\n*  	Feito por:                       *"
            + "\n*  Hector, Lucas, KW, Paulo e Fabiano    *"
            + "\n*                                        *"
            + "\n******************************************"
            ;
            Console.WriteLine(greetings);

            Console.WriteLine("---------------------------------");
        }

        public static void showOperations()
        {
            string operations =
                "******************************************"
            + "\n*                                        *"
            + "\n* 1- MEDIA *"
            + "\n* 2- MODA			 *"
            + "\n* 3- MEDIANA                       *"
            + "\n* 4- DESVIO PADRAO   *"
            + "\n* 5- METODO DOS MINIMOS QUADRADOS   *"
            + "\n*                                        *"
            + "\n******************************************"
            ;
            Console.WriteLine(operations);

            Console.WriteLine("---------------------------------");
        }



    }
}
