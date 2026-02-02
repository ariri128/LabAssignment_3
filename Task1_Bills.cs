using UnityEngine;

public class Task1_Bills : MonoBehaviour
{
    // Variable list

    // Inputs
    public int amount; // int makes sure no decimals can be input

    // Outputs
    private int hundreds;
    private int fifties;
    private int twenties;
    private int tens;
    private int fives;
    private int ones;

    private bool isValid = true;

    // Starts the process of calculation
    void Start()
    {
        BillsBreakdown();
    }

    // Main function
    void BillsBreakdown()
    {
        ValidateInput();
        if (isValid == false) return; // Stops the function and the calculation from happening

        ResetBills();
        CalculateBills();
        PrintResult();
    }

    // Validate input function - makes sure user inputs a positive number only
    void ValidateInput()
    {
        if (amount < 0)
        {
            isValid = false;
            Debug.LogError("Amount must be zero or greater.");
        }
        else
        {
            isValid = true;
        }
    }

    // Resets function - resets bill amount for clean start for new input
    void ResetBills()
    {
        hundreds = 0;
        fifties = 0;
        twenties = 0;
        tens = 0;
        fives = 0;
        ones = 0;
    }

    // Calculate function - takes the input amount and figures out how many of each bill are needed to pay it
    void CalculateBills()
    {
        int remaining = amount;

        hundreds = remaining / 100;
        remaining %= 100;

        fifties = remaining / 50;
        remaining %= 50;

        twenties = remaining / 20;
        remaining %= 20;

        tens = remaining / 10;
        remaining %= 10;

        fives = remaining / 5;
        remaining %= 5;

        ones = remaining;
    }

    // Print function - prints the results calculated in the CalculateBills function
    void PrintResult()
    {
        Debug.Log(
            "Dollar Bills Breakdown\n" +
            "Amount: $" + amount + "\n" +
            "$100 Bills: " + hundreds + "\n" +
            "$50 Bills: " + fifties + "\n" +
            "$20 Bills: " + twenties + "\n" +
            "$10 Bills: " + tens + "\n" +
            "$5 Bills: " + fives + "\n" +
            "$1 Bills: " + ones
        );
    }
}
