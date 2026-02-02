using UnityEngine;

public class Task2_Bookstore : MonoBehaviour
{
    // Variable list

    // Inputs
    public float coverPrice; // X - float allows for decimals
    public int copiesSold; // Y - int makes sure input is integer

    // Constants
    private float discountRate = 0.40f; // 40% discount
    private float firstCopyShipping = 3.00f; // $3 shipping fee - first copy
    private float additionalCopyShipping = 0.75f; // $0.75 shipping fee - all other copies

    // Outputs
    private float wholesaleCost;
    private float revenue;
    private float profit;

    private bool isValid = true;

    // Start the process of calculation
    void Start()
    {
        ProfitBreakdown();
    }

    // Main function
    void ProfitBreakdown()
    {
        ValidateInput();
        if (isValid == false) return; // Stops the function and the calculation from happening

        CalculateWholesaleCost();
        CalculateRevenue();
        CalculateProfit();
        PrintResult();
    }

    // Validate input function - makes sure user inputs a positive number only
    void ValidateInput()
    {
        if (coverPrice < 0 || copiesSold < 0)
        {
            isValid = false;
            Debug.LogError("Cover price and number of copies must be zero or greater.");
        }
        else
        {
            isValid = true;
        }
    }

    // Wholesales calculation function - how much the bookstore pays for the books
    void CalculateWholesaleCost()
    {
        float discountedPrice = coverPrice * (1 - discountRate); // Applies the discount
        float booksCost = discountedPrice * copiesSold; // Price for Y number of books bought
        float shippingCost = CalculateShippingCost(); // Shipping costs

        wholesaleCost = booksCost + shippingCost; // Total wholesales cost
    }

    // Shipping cost calculation function - adds shipping prices depending on how many books bought
    float CalculateShippingCost()
    {
        if (copiesSold == 0) // No books
        {
            return 0f;
        }
        else if (copiesSold == 1) // First book fee
        {
            return firstCopyShipping;
        }
        else // Fees for more than one book
        {
            return firstCopyShipping + (additionalCopyShipping * (copiesSold - 1));
        }
    }

    // Revenue calculation function - amount of money made just by selling books (no other fees subtracted yet)
    void CalculateRevenue()
    {
        revenue = coverPrice * copiesSold;
    }

    // Profit calculation function - how much bookstore made after taking in account the revenue and wholesales values
    void CalculateProfit()
    {
        profit = revenue - wholesaleCost;
    }

    // Print function - prints resulted wholesale costs and profit values calculated above
    void PrintResult()
    {
        Debug.Log(
            "Bookstore Results\n" +
            "Cover Price: $" + coverPrice + "\n" +
            "Copies Sold: " + copiesSold + "\n" +
            "Wholesale Cost: $" + wholesaleCost + "\n" +
            "Profit: $" + profit
        );
    }
}
