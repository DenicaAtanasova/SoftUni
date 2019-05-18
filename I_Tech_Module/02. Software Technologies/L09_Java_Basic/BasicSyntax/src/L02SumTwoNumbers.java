import java.util.Scanner;

public class L02SumTwoNumbers {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double num1 = Double.parseDouble(console.nextLine());
        double num2 = Double.parseDouble(console.nextLine());
        System.out.println(num1 + num2);
    }
}
