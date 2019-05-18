import java.util.Arrays;
import java.util.Scanner;

public class P09MostFrequentNumber {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int [] input = Arrays
                .stream(console.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();
        int count = 0;
        int maxCount = 0;
        int num = 0;

        for (int i = 0; i < input.length; i ++){
            for ( int j = i + 1; j < input.length; j ++){
                if (input[i] == input[j]){
                    count ++;
                }
                if (maxCount < count) {
                    maxCount = count;
                    num = input[i];
                }
                count = 0;
            }
        }
        System.out.println(num);
    }
}
