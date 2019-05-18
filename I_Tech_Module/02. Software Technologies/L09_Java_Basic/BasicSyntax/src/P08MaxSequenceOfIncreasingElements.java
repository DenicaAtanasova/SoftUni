import java.util.Arrays;
import java.util.Scanner;

public class P08MaxSequenceOfIncreasingElements {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int [] input = Arrays
                .stream(console.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();
        int count = 1;
        int index = 0;
        int maxCount = 0;

        for (int i = 1; i < input.length; i ++) {
            if (input[i - 1] < (input[i])){
                count ++;
                if (maxCount < count) {
                    maxCount = count;
                    index = i - maxCount + 1;
                }
            } else {
                count = 1;
            }
        }
        for (int j = index; j < index + maxCount; j ++){
            System.out.printf(input[j] + " ");
        }
    }
}
