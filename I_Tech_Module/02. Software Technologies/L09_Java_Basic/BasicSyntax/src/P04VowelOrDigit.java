import java.util.Arrays;
import java.util.Scanner;

public class P04VowelOrDigit {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String input = console.nextLine();
        String [] vowels = {"a", "o", "u", "i", "e"};

        if(Character.isDigit(input.charAt(0))){
            System.out.println("digit");
        } else if (Arrays.asList(vowels).contains(input)){
            System.out.println("vowel");
        } else {
            System.out.println("other");
        }
    }
}
