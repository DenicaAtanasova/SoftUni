import java.util.Scanner;

public class P07MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String [] input = console.nextLine().split("\\s+");
        int count = 1;
        int index = 0;
        int maxCount = 0;

        for (int i = 1; i < input.length; i ++) {
            if (input[i - 1].equals(input[i])){
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
