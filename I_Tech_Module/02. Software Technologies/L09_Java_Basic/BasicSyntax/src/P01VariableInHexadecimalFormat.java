import java.util.Scanner;

public class P01VariableInHexadecimalFormat {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int num = Integer.parseInt(console.nextLine(), 16);
        System.out.println(num);
    }
}
