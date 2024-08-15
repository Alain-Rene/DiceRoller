
/*
Program that asks the user to enter the number of sides on 2 die, afterwards
rolls the die that the user specified in their input. Prompts user if they
would like to roll again
*/

//DnD 20 sided die
//2 quarters, flip 'em at the same time and if they land on the side you called
//You can be creative, whatever you want as long as it works
using System.Net.WebSockets;

int dieSides = 0;
do 
{
    try 
    {
        //Ask user for how many sides on the die they want
        System.Console.WriteLine("Please enter the number of sides you'd like on each die");
        dieSides = int.Parse(Console.ReadLine());
        if (dieSides < 2)
        {
            //If they choose a value less than 2
            throw new Exception("Cannot be less than 2");
        }
    }
    // Catch any exception such as invalid input or if the input doesn't fit the file size limit
    catch (Exception e)
    {
        System.Console.WriteLine(e.Message);
    }
} while(dieSides < 2);

//Random object to roll dice
Random rnd = new Random();

int rollCounter = 1;
int dice1;
int dice2;
bool continueChoice = true;


do 
{
    //Use roll dice method to roll each dice, add one because the outer range is exclusive
    dice1 = RollDice(rnd, dieSides+1);
    dice2 = RollDice(rnd, dieSides+1); 

    //Display what number roll the user is on
    System.Console.WriteLine($"Roll #{rollCounter}");
    
    //6 sided die method
    if (dieSides == 6)
    {
        System.Console.WriteLine($"You rolled a {dice1} and a {dice2}!");
        System.Console.WriteLine(SixSidedDie(dice1, dice2));
        System.Console.WriteLine(SixSidedDieResult(dice1, dice2));
    }
    //2 sided die method
    else if (dieSides == 2)
    {
        System.Console.WriteLine("Since you chose a 2 sided die, this will pretend to be a coin toss instead!");
        System.Console.WriteLine("Lets see if you can match!");
        string flip1;
        string flip2;

        if(dice1 == 1)
        {
            flip1 = "Heads";
        }
        else
        {
            flip1 = "Tails";
        }
        if (dice2 == 1)
        {
            flip2 = "Heads";
        }
        else
        {
            flip2 = "Tails";
        }
        System.Console.WriteLine($"Your first roll was {flip1} and your second was {flip2}");
        System.Console.WriteLine(TwoSidedDie(dice1, dice2));
    }
    //If the user picks any other sided die
    else
    {
        System.Console.WriteLine($"You rolled a {dice1} and a {dice2}!");
    }
    rollCounter++;
    //Ask user if they want to continue rolling
    continueChoice = QuestionUser(continueChoice);
}
while(continueChoice);

//Roll dice method, generate a random int and return it
static int RollDice(Random rnd, int max)
{
    int result = rnd.Next(1, max);

    return result;
}

//6 sided die method
static string SixSidedDie(int dice1, int dice2)
{
    string result = "";
    if (dice1 == 1 && dice2 == 1)
    {
        result = "Snake Eyes!";
        return result;
    }
    if ((dice1 == 1 && dice2 == 2) || (dice1 == 2 && dice2 == 1))
    {
        result = "Ace Deuce!";
        return result;
    }
    if (dice1 == 6 && dice2 == 6)
    {
        result = "Box Cars!";
        return result;
    }
    else
    {
        return result;
    }
}
//Result method which displays if user won or not
static string SixSidedDieResult(int dice1, int dice2)
{
    string result = "";
    if (dice1 + dice2 == 7 || dice1 + dice2 == 11)
    {
        result = "You win!";
        return result;
    }
    if(dice1 + dice2 == 2 || dice1 + dice2 == 3 || dice1 + dice2 == 12)
    {
        result = "Craps!";
        return result;
    }
    else 
    {
        return result;
    }
}
//Two sided die method
static string TwoSidedDie(int dice1, int dice2)
{
    string result = "";

    if ((dice1 == 1 && dice2 == 1) || (dice1 == 2 && dice2 == 2))
    {
        result = "You Win!";
        return result;
    }
    else
    {
        result = "You lost...";
        return result;
    }
}

static bool QuestionUser(bool answer){
    while(true){
        System.Console.WriteLine("Would you like to continue? Please enter yes or no");
        string choice = Console.ReadLine();
        if (choice.ToLower().Trim() == "yes"){
            answer = true;
            break;
        } 
        else if (choice.ToLower().Trim() == "no"){
            answer = false;
            break;
        } 
        else {
            System.Console.WriteLine("Invalid response");
        }
    }
    return answer;
}