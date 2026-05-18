// Christoph Van Jaarsveld 50143956
import java.io.*;
import java.util.*;

public class StartGame
{
    public static MyArrayList<SWChar> secretWord = new MyArrayList<>();
    public static MyArrayList<String> allWords = new MyArrayList<>();
    public static MyArrayList<SWChar> scrambledWord = new MyArrayList<>();
    public static MyArrayList<SWChar> guessedWord = new MyArrayList<>();
    public static MyArrayList<Integer> hiddenPos = new MyArrayList<>();
    public static int MAX_ATTEMPTS = 5;

    public static void readTextFile(String file)
    {
        // Read text file
        try (BufferedReader br = new BufferedReader(new FileReader(file)))
        {
            String line;
            while ((line = br.readLine()) != null)
            {
                // Store words in text file in array list
                allWords.add(allWords.getsize(), line);
            }
        }
        catch (IOException ex)
        {
            System.out.println("\nError, could not read file: " + ex.getMessage());
        }
    }

    public static String getRandomWord()
    {
        // Get random word from array list
        Random rand = new Random();
        int randomIndex = rand.nextInt(allWords.getsize());
        return allWords.get(randomIndex);
    }

    public static MyArrayList<SWChar> loadWord(String word)
    {
        // load original word into SWChar list
        secretWord.clear();

        for (int i = 0; i < word.length(); i++)
        {
            secretWord.add(secretWord.getsize(), new SWChar(word.charAt(i)));
        }

        return secretWord;
    }

    public static void shuffleWord(MyArrayList<SWChar> word)
    {
        // Shuffle words
        Random rand = new Random();
        int n = word.getsize();

        for (int i = 0; i < n; i++)
        {
            int j = rand.nextInt(n);
            word.swap(i, j);
        }
    }

    public static void showHint()
    {
        // Get all positions of unguessed letters
        hiddenPos.clear();

        for (int p = 0; p < secretWord.getsize(); p++)
        {
            if (!secretWord.get(p).isGuessed())
            {
                hiddenPos.add(hiddenPos.getsize(), p);
            }
        }

        // Only give a hint if more than 1 letter is still hidden
        if (hiddenPos.getsize() > 1)
        {
            Random rand = new Random();
            int randomIndex = hiddenPos.get(rand.nextInt(hiddenPos.getsize()));

            secretWord.get(randomIndex).Guessed();

            System.out.println("\nHint: Letter revealed!");
        }
        else if (hiddenPos.getsize() == 1)
        {
            System.out.println("\nNo more hints!, Try to guess the final letter.");
        }
    }

    public static void startGame(String randomWord, MyArrayList<SWChar> secretWord)
    {
        Scanner input = new Scanner(System.in);

        MAX_ATTEMPTS = 5;

        // Heading display
        System.out.println("\n--------WORD SHUFFLE--------");

        System.out.println("\nLoading words:");
        System.out.println("\n" + allWords.toString());

        while (MAX_ATTEMPTS > 0 && !verifyWinner())
        {
            System.out.print("\nShuffled Word: ");
            for (int i = 0; i < scrambledWord.getsize(); i++)
            {
                System.out.print(scrambledWord.get(i).getValue());
            }

            System.out.println();

            System.out.println("\nYour Progress: " + secretWord.toString());
            System.out.println("Attempts left: " + MAX_ATTEMPTS);

            String guess = "";

            while (true)
            {
                System.out.print("Guess the word: ");
                guess = input.nextLine().trim();

                if (guess.length() == secretWord.getsize())
                    break;

                System.out.println("Please enter a " + secretWord.getsize() + " letter word:\n");
            }

            guessedWord.clear();

            // Convert guess to MyArray SWChar
            for (int j = 0; j < guess.length(); j++)
            {
                guessedWord.add(guessedWord.getsize(), new SWChar(guess.charAt(j)));
            }

            // Compare guess against secret word
            checkGuess(guessedWord);

            // Check for win
            if (verifyWinner())
            {
                System.out.println("\nCongratulations! You guessed the word: " + randomWord);
                return;
            }

            // Use one attempt if guess incorrect
            MAX_ATTEMPTS--;

            // Show hint
            showHint();
        }

        if (!verifyWinner())
        {
            System.out.print("\nOut of attempts! The word was: " + randomWord + "\n");
        }
    }

    public static void checkGuess(MyArrayList<SWChar> guess)
    {
        for (int i = 0; i < secretWord.getsize(); i++)
        {
            if (secretWord.get(i).getValue() == guess.get(i).getValue())
            {
                secretWord.get(i).Guessed();
            }
        }
    }

    public static boolean verifyWinner()
    {
        for (int i = 0; i < secretWord.getsize(); i++)
        {
            if (!secretWord.get(i).isGuessed())
                return false;
        }
        return true;
    }

    public static void main(String[] args)
    {
        readTextFile("word7.txt");

        String randomWord = getRandomWord();

        secretWord = loadWord(randomWord);

        scrambledWord.clear();
        for (int i = 0; i < secretWord.getsize(); i++)
        {
            scrambledWord.add(scrambledWord.getsize(),
                    new SWChar(secretWord.get(i).getValue()));
        }

        shuffleWord(scrambledWord);

        startGame(randomWord, secretWord);
    }
}