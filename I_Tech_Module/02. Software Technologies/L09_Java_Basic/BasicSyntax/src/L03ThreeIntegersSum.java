import java.util.Arrays;
import java.util.Scanner;

public class L03ThreeIntegersSum {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int [] nums = Arrays
                .stream(console.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        if (nums[0] + nums [1] == nums[2]){
            System.out.printf(nums[0] <= nums[1] ? "%1$d + %2$d = %3$d" : "%2$d + %1$d = %3$d", nums[0], nums[1], nums[2]);
        } else if (nums[0] + nums [2] == nums[1]){
            System.out.printf(nums[0] <= nums[2] ? "%1$d + %2$d = %3$d" : "%2$d + %1$d = %3$d", nums[0], nums[2], nums[1]);
        } else if (nums[1] + nums [2] == nums[0]){
            System.out.printf(nums[1] <= nums[2] ? "%1$d + %2$d = %3$d" : "%2$d + %1$d = %3$d", nums[1], nums[2], nums[0]);
        } else {
            System.out.printf("No");
        }
        System.out.println();
    }
}