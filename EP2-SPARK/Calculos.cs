using Microsoft.Spark;
using Microsoft.Spark.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.Spark.Sql.Functions;


namespace EP2_SPARK
{
    class Calculos
    {
        private const string SchemaString = "ID STRING, USAF STRING, WBAN STRING, Elevation FLOAT, Country_Code STRING, Latitude FLOAT, Longitude FLOAT, Date DATE, Year INT, Month INT, Day INT, Mean_Temp FLOAT, Mean_Temp_Count INT, Mean_Dewpoint FLOAT, Mean_Dewpoint_Count FLOAT, Mean_Sea_Level_Pressure FLOAT, Mean_Sea_Level_Pressure_Count INT, Mean_Station_Pressure FLOAT, Mean_Station_Pressure_Count INT, Mean_Visibility FLOAT,Mean_Visibility_Count INT, Mean_Windspeed FLOAT, Mean_Windspeed_Count INT, Max_Windspeed FLOAT, Max_Gust FLOAT, Max_Temp FLOAT, Max_Temp_Quality_Flag INT, Min_Temp FLOAT, Min_Temp_Quality_Flag INT, Precipitation FLOAT,Precip_Flag STRING,Snow_Depth FLOAT, Fog INT,Rain_or_Drizzle INT, Snow_or_Ice INT, Hail INT, Thunder INT, Tornado INT";

        public static void calculaMedia(string filename, SparkSession spark)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filename);

            // Implementar
            //cleanedProjects = cleanedProjects.Drop("id", "url", "owner_id");

            // Average number of times each language has been forked
            DataFrame groupedDF = projectsDf
                .GroupBy("ID")
                .Agg(Avg(projectsDf["Mean_Windspeed"]));

            groupedDF.OrderBy(Desc("avg(Mean_Windspeed)")).Filter(groupedDF["avg(Mean_Windspeed)"].IsNotNull()).Show();
        }

        public static void calculaModa(string filename, SparkSession spark)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filename);

            // Implementar
            //cleanedProjects = cleanedProjects.Drop("id", "url", "owner_id");

            // Average number of times each language has been forked
            DataFrame groupedDF = projectsDf
                .GroupBy("Mean_Windspeed_Count")
                .Agg(Count(projectsDf["ID"]));
            groupedDF.OrderBy(Desc("count(ID)")).Show(1);

        }

        public static void calculaDesvio(string filename, SparkSession spark)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filename);

            // Implementar
            //cleanedProjects = cleanedProjects.Drop("id", "url", "owner_id");

            // Average number of times each language has been forked
            DataFrame groupedDF = projectsDf
                .Agg(Stddev(projectsDf["Mean_Windspeed"]));
            groupedDF.Show();

        }

        public static void calculaMediana(string filename, SparkSession spark)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filename);

            // Implementar
            //cleanedProjects = cleanedProjects.Drop("id", "url", "owner_id");

            // Average number of times each language has been forked
            DataFrame groupedDF = projectsDf
                .Agg(Stddev(projectsDf["Mean_Windspeed"]));
            groupedDF.Show();

        }


    }


}
