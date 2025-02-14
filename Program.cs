using System.Linq.Expressions;
using System.Runtime.InteropServices;
public delegate int MathOperation(int a, int b);
namespace expressionTrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, };
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

            Console.WriteLine("Even Numbers: ");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }
            // we are passing the lambda expression to the where function
            // In this case the Lambda Expression that serves as a function argument to the 
            // where method which filters the list to include only the even numbers
            delegateDefinition();


            // This example shows how to check the node type then casting to a variable access expression 
            // and then checjing the properties of the specific expression type:
            // the code jsut prints the name of the variable for a variable access expression.
            // the following code shows the practice of checking the node type 
            // and then casting to a variable access expression and then checking the properties of 
            // the specific expression type


            Console.WriteLine("----Prints the name of the variable for variable access expression--" +
                "The base expression class contains the NodeProperty for the purpose" +
                "that you may encounter many different no ");
            
            Expression<Func<int,int>> addFive = a => a + 5;

            if (addFive is LambdaExpression lambdaExpression)
            {
                var parameter = lambdaExpression.Parameters[0];

                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Type);
            }


        }




        // Expression trees provide richer interaction with the 
        //arguments that are functions
        // You write function arguments typically using Lambda Expression
        //when you create the LINQ queries. In a typical LINQ query , 
        //those funtion arguments are tranformed into a delegate the compiler creates
        // below is the example for the same
        // BEhind the scenes the compiler creates an instance of  a 
        //delegate that points to the lambda expression
        // THis delegate is then used internally by the LINQ 
        //method to execute the filtering logic


        static void delegateDefinition()
        {
            // Lambda expressions can be used to create a delegate
            // or expression trees
            // A delegate is a C# type that represents the reference to a method
            // The delegate type is defined by the signature of the method it points to
            // The delegate instance is created by passing a method to the delegate constructor
            // The delegate instance can be invoked by calling the delegate instance as if it were a method

            // How a lambda expression can be Delegates
            // When you assign a Lambda expression to a delegate  you create an instant of that delegate pointing to the lambda function


            // When you use a Lambda function it can be assigned to a delegate type 
            // provided that the lambda expression matches the signature of the delegate
            // the function below shows that we are assigning the delegate
            // One of the comple

            //ASSIGNING A LAMBDA EXPRESSION TO A DELEGATE
            MathOperation add = (a, b) => a + b;
            MathOperation subtract = (a, b) => a - b; //Lambda expression for subtraction

            // Invoking the delegate

            int sum = add(5, 3);  //Calls the lambda expression that adds two numbers
            int difference = subtract(5, 3); //Calls the lambda expression that subtracts two numbers

            //Output the results
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");

        }

    }
}
