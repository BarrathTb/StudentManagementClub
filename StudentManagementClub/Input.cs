
namespace Helper
{
    internal class Input
    {
        public static char GetCharWithPrompt(string prompt, string promptError)
        {
            if (!string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine(prompt);
            }
            bool isChar = false;
            char returnCharacter = ' ';
            do
            {


                string input = GetStringWithPrompt(prompt, promptError);
                // I want to make sure that the input has something entered
                if (!string.IsNullOrEmpty(input) && input.Length == 1)
                {
                    isChar = true;
                    returnCharacter = input[0];
                }
                else
                {
                    Console.WriteLine(promptError);
                }
            } while (!isChar);
            return returnCharacter;

            
        }
        public static int GetIntWithPrompt(string prompt, string promptError)
        {
            Console.WriteLine(prompt);
            bool validInput = false;
            int userIntInput = 0;
            do
            {
                string? userInput = Console.ReadLine();
                if (userInput == null || userInput == "")
                {
                    Console.WriteLine(promptError);
                    continue;
                }

                validInput = int.TryParse(userInput, out userIntInput);
                if (!validInput)
                {
                    Console.WriteLine(promptError);
                }
            } while (!validInput);

            return userIntInput;

        }
        public static string GetStringWithPrompt(string? prompt, string? promptError)
        {
            if (!String.IsNullOrEmpty(prompt))
            Console.WriteLine(prompt);
            

            do
            {
                string? userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }
                else
                {
                    if (!String.IsNullOrEmpty(promptError))
                    Console.WriteLine(promptError);
                }
            } while (true);
            //need to change this later
            
        }
    }
}
