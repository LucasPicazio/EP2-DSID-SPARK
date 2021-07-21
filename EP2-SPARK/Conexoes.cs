using Microsoft.Spark;

namespace EP2_SPARK
{
    public static class Conexoes
    {
        public static string retornaCSV(string USAF, string WBAN, int ano, SparkContext sparkContext)
        {

            //string dataSource = "https://s3.amazonaws.com/aws-gsod/" + ano + "/" + USAF + "-" + WBAN + ".csv";
            string dataSource = "https://s3.amazonaws.com/aws-gsod/1935/352290-99999.csv";
            sparkContext.AddFile(dataSource);
            //string fileName = SparkFiles.Get(USAF + "-" + WBAN + ".csv");
            string fileName = SparkFiles.Get(352290 + "-" + 99999 + ".csv");


            return fileName;
            //RETORNA FILENAME
        }
    }
}
