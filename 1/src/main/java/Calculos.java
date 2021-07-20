import org.apache.spark.SparkConf;
import org.apache.spark.SparkFiles;
import org.apache.spark.api.java.JavaPairRDD;
import org.apache.spark.api.java.JavaRDD;
import org.apache.spark.api.java.JavaSparkContext;
import org.apache.spark.api.java.function.PairFunction;
import scala.Tuple2;

public class Calculos {
	
	public static void calculaMedia(String filename, JavaSparkContext sparkContext) {
		//to-do
		JavaRDD<String> rdd = sparkContext.textFile(filename);
		
		JavaRDD<String> rdd2 = rdd.mapPartitionsWithIndex((idx, iter) ->{
			if(idx == 0)
				iter.next();
			else
				return iter;
			return iter;
		},true );
		
		//captura o id e a temperatura (coluna 0 e coluna 11)
		JavaPairRDD<String, Float> pairRDD = rdd2.mapToPair(i -> {
			String[] cols = i.split(",");
			return new Tuple2<String,Float>(cols[0],Float.parseFloat(cols[11]));
		}) ;
		
		
		JavaPairRDD<String, Tuple2<Float, Float>> valueCount = pairRDD.mapValues(value -> new Tuple2<Float, Float>(value,(float) 1));
	    //add values by reduceByKey - tipo um groupby - junta os IDs de mesma chave
	    JavaPairRDD<String, Tuple2<Float, Float>> reducedCount = valueCount.reduceByKey((tuple1,tuple2) ->  new Tuple2<Float, Float>(tuple1._1 + tuple2._1, tuple1._2 + tuple2._2));
	    
	    //calculate average
	    JavaPairRDD<String, Float> averagePair = reducedCount.mapToPair(getAverageByKey);
	    
	    //print averageByKey
	    averagePair.foreach(data -> {
	        System.out.println("Key="+data._1() + " Average=" + data._2());
	    });
	}
	
	public static void calculaDesvioPadrao(String filename) {
		//TO-DO
	}
	
	public static void calculaModa(String filename) {
		//TO-DO
	}
	
	public static void calculaMediana(String filename) {
		//TO-DO
	}
		
	
	public static PairFunction<Tuple2<String, Tuple2<Float, Float>>,String,Float> getAverageByKey = (tuple) -> {
	     Tuple2<Float, Float> val = tuple._2;
	     Float total = val._1;
	     Float count = val._2;
	     Tuple2<String, Float> averagePair = new Tuple2<String, Float>(tuple._1, (float) (total / count));
	     return averagePair;
	  };
	
	
}
