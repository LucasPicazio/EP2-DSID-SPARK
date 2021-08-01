using Microsoft.Spark;
using Microsoft.Spark.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.Spark.Sql.Functions;


namespace EP2
{
    public class Calculos
    {
        private const string SchemaString = "ID STRING, USAF STRING, WBAN STRING, Elevation FLOAT, Country_Code STRING, Latitude FLOAT, Longitude FLOAT, Date DATE, Year INT, Month INT, Day INT, Mean_Temp FLOAT, Mean_Temp_Count INT, Mean_Dewpoint FLOAT, Mean_Dewpoint_Count FLOAT, Mean_Sea_Level_Pressure FLOAT, Mean_Sea_Level_Pressure_Count INT, Mean_Station_Pressure FLOAT, Mean_Station_Pressure_Count INT, Mean_Visibility FLOAT,Mean_Visibility_Count INT, Mean_Windspeed FLOAT, Mean_Windspeed_Count INT, Max_Windspeed FLOAT, Max_Gust FLOAT, Max_Temp FLOAT, Max_Temp_Quality_Flag INT, Min_Temp FLOAT, Min_Temp_Quality_Flag INT, Precipitation FLOAT,Precip_Flag STRING,Snow_Depth FLOAT, Fog INT,Rain_or_Drizzle INT, Snow_or_Ice INT, Hail INT, Thunder INT, Tornado INT";
        private readonly string[] columns = new string[] { "ID", "USAF", "WBAN", "Elevation", "Country_Code", "Latitude", "Longitude", "Date", "Year", "Month", "Day", "Mean_Temp", "Mean_Temp_Count", "Mean_Dewpoint", "Mean_Dewpoint_Count", "Mean_Sea_Level_Pressure", "Mean_Sea_Level_Pressure_Count", "Mean_Station_Pressure", "Mean_Station_Pressure_Count", "Mean_Visibility", "Mean_Visibility_Count", "Mean_Windspeed", "Mean_Windspeed_Count", "Max_Windspeed", "Max_Gust", "Max_Temp", "Max_Temp_Quality_Flag", "Min_Temp", "Min_Temp_Quality_Flag", "Precipitation", "Precip_Flag", "Snow_Depth", "Fog", "Rain_or_Drizzle", "Snow_or_Ice", "Hail", "Thunder", "Tornado" };
        public List<Tuple<string, float?>> calculaMedia(string[] filenames, SparkSession spark, string analyze, string groupBy)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filenames);

            var columnsToDrop = columns.Where(x => x != analyze && x != groupBy).ToArray();
            var cleanedDF = projectsDf.Drop(columnsToDrop);

            DataFrame groupedDF = cleanedDF
                .GroupBy(groupBy)
                .Agg(Avg(projectsDf[analyze]));

            groupedDF.Show();

            return groupedDF.Collect().Select(x => Tuple.Create(x.Get(0) as string, x.Get(1) as float?)).ToList();
        }


        public List<Tuple<string, float?>> calculaDesvio(string[] filenames, SparkSession spark, string analyze, string groupBy)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filenames);

            var columnsToDrop = columns.Where(x => x != analyze && x != groupBy).ToArray();
            var cleanedDF = projectsDf.Drop(columnsToDrop);

            DataFrame groupedDF = cleanedDF
                .GroupBy(groupBy)
                .Agg(Stddev(projectsDf[analyze]));
            return groupedDF.Collect().Select(x => Tuple.Create(x.Get(0) as string, x.Get(1) as float?)).ToList();
        }

        public List<Tuple<string, float?>> calculaVariancia(string[] filenames, SparkSession spark, string analyze, string groupBy)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filenames);

            var columnsToDrop = columns.Where(x => x != analyze).ToArray();
            var cleanedDF = projectsDf.Drop(columnsToDrop);

            DataFrame groupedDF = cleanedDF
                  .GroupBy(groupBy)
                  .Agg(Variance(cleanedDF[analyze]));

            return groupedDF.Collect().Select(x => Tuple.Create(x.Get(0) as string, x.Get(1) as float?)).ToList();

        }

        public Tuple<float, float, List<float>, List<float>> calculaQuadradosMinimos(string[] filenames, SparkSession spark, string xAxis, string yAxis)
        {

            // Create initial DataFrame
            DataFrame projectsDf = spark
                .Read()
                .Schema(SchemaString)
                .Csv(filenames);

            var columnsToDrop = columns.Where(x => x != xAxis && x != yAxis).ToArray();
            var cleanedDF = projectsDf.Drop(columnsToDrop);

            var averageRowX = cleanedDF
                  .Agg(Avg("Mean_Windspeed")).Select(xAxis).Collect().ToList();
            var averageX = averageRowX[0].Get(0) as float? ?? 0;

            var averageRowY = cleanedDF
                  .Agg(Avg("Mean_Sea_Level_Pressure")).Select(yAxis).Collect().ToList();
            var averageY = averageRowY[0].Get(0) as float? ?? 0;

            var dfWithAveragex = cleanedDF.WithColumn("differX", projectsDf[yAxis] * (projectsDf[xAxis] - averageX));
            var dfWithAverageY = dfWithAveragex.WithColumn("differY", projectsDf[xAxis] * (projectsDf[yAxis] - averageY));

            var sum1 = dfWithAverageY.Agg(Sum("differX")).Select("differX").Collect().ToList()[0].Get(0) as float? ?? 0;
            var sum2 = dfWithAverageY.Agg(Sum("differY")).Select("differY").Collect().ToList()[0].Get(0) as float? ?? 0;

            var b = sum1 / sum2;
            var a = averageY - (b * averageX);

            var xValues = cleanedDF.Select(xAxis).Collect().Select(x => x.Get(0) as float? ?? 0).ToList();
            var yValues = cleanedDF.Select(yAxis).Collect().Select(x => x.Get(0) as float? ?? 0).ToList();

            return Tuple.Create(a, b,xValues,yValues);


        }


    }


}
