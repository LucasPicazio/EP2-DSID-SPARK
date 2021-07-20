import java.util.Scanner;

import org.apache.spark.SparkConf;
import org.apache.spark.SparkFiles;
import org.apache.spark.api.java.JavaPairRDD;
import org.apache.spark.api.java.JavaRDD;
import org.apache.spark.api.java.JavaSparkContext;
import org.apache.spark.api.java.function.PairFunction;
import scala.Tuple2;


public class Main {
	
	public static void showGreetings() {
		String greetings =
			"******************************************"
		+ "\n*                                        *"
		+ "\n* NCDC DATA - A HELPFUL TOOL 4 CIENTISTS *"
		+ "\n*      EP2 - DSID			 *"
		+ "\n*  	Feito por:                       *"
		+ "\n*  Hector, Lucas, KW, Paulo e Fabiano    *"
		+ "\n*                                        *"
		+ "\n******************************************"
		;
		System.out.print(greetings);
		
		System.out.println();
		System.out.print("---------------------------------");
		System.out.println();
	}
	
	public static void showOperations() {
		String operations =
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
		System.out.print(operations);
		
		System.out.println();
		System.out.print("---------------------------------");
		System.out.println();
	}
	
	public static void main(String[] args) {
		
		String USAF = "";
		String WBAN = "";
		String filename = "";
		int operacao = Integer.MIN_VALUE;
		int ano = Integer.MIN_VALUE;
		
		Scanner scanner = new Scanner(System.in);
		
		SparkConf sparkConf = new SparkConf().setMaster("local").setAppName("EP2");
		JavaSparkContext sparkContext = new JavaSparkContext(sparkConf);
		
		//MOSTRA APRESENTAÇÃO INICIAL
		showGreetings();
		
		System.out.println("Entre com o USAF ID: ");
		USAF = scanner.next();
		
		System.out.println("Entre com o WBAN ID: ");
		WBAN = scanner.next();
		
		System.out.println("Entre com o ano: ");
		ano = scanner.nextInt();
		
		filename = Conexoes.retornaCSV(USAF, WBAN, ano, sparkContext);
		
		System.out.println("Qual operação deseja realizar?");
		showOperations();
		operacao = scanner.nextInt();
		
		switch (operacao) {
		  case 1:
		    System.out.println("MEDIA");
		    Calculos.calculaMedia(filename, sparkContext);
		    break;
		  case 2:
		    System.out.println("MODA");
		    break;
		  case 3:
		    System.out.println("MEDIANA");
		    break;
		  case 4:
		    System.out.println("DESVIO PADRAO");
		    break;
		  case 5:
		    System.out.println("METODO DOS MINIMOS QUADRADOS");
		    break;
		} 
		
		
	
		//stop sc
		sparkContext.stop();
		sparkContext.close();
	}
	
	
	
}
	
	