import org.apache.spark.SparkFiles;
import org.apache.spark.api.java.JavaSparkContext;

public class Conexoes {
	
	public static String retornaCSV (String USAF, String WBAN, int ano, JavaSparkContext sparkContext) {
		
		String anoString = Integer.toString(ano);
		
		String dataSource = "https://s3.amazonaws.com/aws-gsod/" + anoString + "/" + USAF + "-" + WBAN + ".csv";
		sparkContext.addFile(dataSource);
		String fileName = SparkFiles.get(USAF + "-" + WBAN + ".csv");
		
		return fileName;
		//RETORNA FILENAME
	}
	
	
	
	
}
