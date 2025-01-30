using System;

public class OTPGenerator
{
	private static Random random = new Random();

    // Method to generate a 6-digit OTP
    public int Generate6DigitOTP()
    {
        return random.Next(100000, 1000000); // Generate a 6-digit number (100000 to 999999)
    }

    // Method to validate if the OTP numbers in an array are unique
    public bool AreOTPsUnique(int[] otps)
    {
        for (int i = 0; i < otps.Length; i++)
        {
            for (int j = i + 1; j < otps.Length; j++)
            {
                if (otps[i] == otps[j]) // Check for duplicate OTPs
                {
                    return false;
                }
            }
        }
        return true;
    }
}

class OTPGenerate
{
    public static void Main(string[] args)
    {
        OTPGenerator generator = new OTPGenerator();

        // Array to store the 10 generated OTPs
        int[] otps = new int[10];

        Console.WriteLine("Generating 10 unique 6-digit OTPs:");

        // Generate 10 unique OTPs
        for (int i = 0; i < 10; i++)
        {
            otps[i] = generator.Generate6DigitOTP();
            Console.WriteLine("OTP {0}: {1}", i+1, otps[i]);
        }

        // Validate if all generated OTPs are unique
        bool areUnique = generator.AreOTPsUnique(otps);

        if (areUnique)
        {
            Console.WriteLine("\nAll generated OTPs are unique.");
        }
        else
        {
            Console.WriteLine("\nDuplicate OTPs were found. Regenerate the OTPs.");
        }
    }
}