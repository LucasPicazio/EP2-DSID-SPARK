using Microsoft.Spark;
using System;
using System.Collections.Generic;

namespace EP2
{
    public static class Conexoes
    {
        public static List<string> RetornaCSV(IEnumerable<int> years, IEnumerable<Station> stations, SparkContext sparkContext)
        {
            var filenames = new List<string>();
            foreach (var year in years)
            {
                foreach (var station in stations)
                {
                    try
                    {
                        var filename = $"{station.USAF}-{station.WBAN}.csv";
                        sparkContext.AddFile($"https://s3.amazonaws.com/aws-gsod/{year}/{filename}");
                        var realFileName = SparkFiles.Get(filename);
                        filenames.Add(realFileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message, ex);
                    }

                }
            }

            return filenames;
        }
    }
}
