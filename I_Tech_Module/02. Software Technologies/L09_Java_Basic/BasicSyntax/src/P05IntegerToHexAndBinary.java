import java.util.Scanner;

public class P05IntegerToHexAndBinary {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int num = Integer.parseInt(console.nextLine());

        System.out.println(Integer.toHexString(num).toUpperCase());
        System.out.println(Integer.toString(num, 2));
    }
}
