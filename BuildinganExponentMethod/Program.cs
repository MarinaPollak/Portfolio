namespace BuildinganExponentMethod
{



    //Algorithm ExponentMethod(int baseNumber, int powerNumber)
    //Precondition:
    //baseNumber is an integer
    //powerNumber is a non-negative integer
    //Postcondition:
    //Returns baseNumber raised to the power of powerNumber
    //result<- 1
    //For i<- 0 to powerNumber - 1
    //result <- result * baseNumber
    //End For
    //Return result
    //End Algorithm

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Base Number in the Power Number");
            Console.WriteLine(ExponentMethod(3,4));
        }


        static int ExponentMethod(int baseNumber, int powerNumber)
        {
            int result = 1;

            for(int i = 0; i < powerNumber; i++)
            {
                result = result * baseNumber;
            }

            return result;

        }
    }
}
