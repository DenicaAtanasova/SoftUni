import java.util.Scanner;

public class P02BooleanVariable {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        boolean bool = Boolean.parseBoolean(console.nextLine());
        System.out.println(bool ? "Yes" : "No");
    }
}
