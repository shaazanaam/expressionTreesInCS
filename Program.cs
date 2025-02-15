using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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
                "that you may encounter many different expression types and the base expression class returns " +
                "an Expression Type which is an enumeration of the possible expression types " +
                "Once you know the type of the node you perform the specific actions for the node and " +
                "work with the specific types for that kind of expression ");

            Expression<Func<int, int>> addFive = a => a + 5;

            if (addFive is LambdaExpression lambdaExpression)
            {
                var parameter = lambdaExpression.Parameters[0];
                var body = lambdaExpression.Body;
                var binaryExpression = (BinaryExpression)body;

                Console.WriteLine("Body and Binary Expression " + body + binaryExpression);





                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Type);
            }


            // Demonstration for the static methods to create the expressions nodes . These methods create an expression 
            //node using the arguments supplied for its children 
            //In this way you build up an expression from its leaf nodes .

            // Addition is an add expression for the "1+2"
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);

            // The expression is then compiled into a delegate and invoked
            //Below example shows how do we create an expression tree from a Lambda Expression

            Expression<Func<int, int>> squareExpression = a => a * a;
            //Display the expression tree

            Console.WriteLine("This is the squareExpression Tree___");
            Console.WriteLine(squareExpression);

            //Compile the expression tree into a delegate
            Func<int, int> square = squareExpression.Compile();

            Console.WriteLine(" The expression tree is now compiled into a delegate");
            Console.WriteLine(square);

            //invoke the delegate
            int result = square(5);
            Console.WriteLine("Square of 5 is : " + result);
            // Execute the expression Trees
            // You need to convert it into executable IL instructions.
            // Only the expression tree that represents a lambda expression can be executed
            // if the expressions dont have the lambda expression you can create  new lambda expression
            //that has the original expression tree as its body 
            // this is done by calling the Lambda<TDelegate>(Expression,IEnumerable<ParameterExpression>)

            //LAMBDA EXPRESSIONS
            //In most cases a simple mapping between an expression and its corresponding delegate exists
            // For example an expression tree represented by the Expression<Func<int>> would be converted 
            // into a delegate of the type Func<int> for a lambda expression with any return type and aregument list 
            // there exists a delagate type that is the target type for the executable code represented by that 
            //lambda expression

            // How to compile and execute an expression tree using the concrete type

            Expression<Func<int, bool>> expr = num => num < 5;

            // Compiling the expression tree into a delegate
            Func<int, bool> myExpressionDelegate = expr.Compile();
            Console.WriteLine(myExpressionDelegate(4));

            //Prints true
            // You can also use simplified syntax
            //to compile and run an expression tree


            Console.WriteLine(expr.Compile()(4));



            // Lets create an expression tree that represents the raising a number to a power
            // then we will create a labda expression out of it 

            BinaryExpression be = Expression.Power(Expression.Constant(2.0), Expression.Constant(3.0));

            //Create a Lambda Expression 
            Expression<Func<double>> lambda = Expression.Lambda<Func<double>>(be);

            // Compile the lambda expression into a delegate

            Func<double> compiledLambda = lambda.Compile();

            //Now execute that lambda

            double myExpressionToLambdaToComiledresult = compiledLambda();

            //Display the result
            Console.WriteLine("The result of the expression tree is : " + myExpressionToLambdaToComiledresult);

            CreateBoundFunc();
            

            // Below  function execution will generate an object out of bounds exception 

            var boundFunctionResource =Resource.CreateBoundResource();

            //Invoke the delegate with an integer argument
            int input = 10;
            int myBoundFunctionResult =boundFunctionResource(input);
            Console.WriteLine($"Result of thebound dunction with input {input} : {myBoundFunctionResult}");


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


        private static Func<int, int> CreateBoundFunc()
        {
            // constant is capured by the expression tree
            var constant = 5;
            Expression<Func<int, int>> expression = a => a + constant;
            var rValue = expression.Compile();
            return rValue;

            // the delegate has captured a reference to the local variable constant.
            // the variable is accessed at any time later , when the function returned 
            // by the CreateBoundFunc executes

        }

    }

    public class Resource : IDisposable
    {
        private bool __isDisposed = false;
        public int Argument
        {
            get
            {
                if (!__isDisposed)
                {
                    return 5;
                }
                else throw new ObjectDisposedException("Resource");
            }
        }
        public void Dispose()
        {
            __isDisposed = true;
        }

        public static Func<int, int> CreateBoundResource()
        {
            using (var constant = new Resource()) //Constant is captured by the expression tree
            {
                Expression<Func<int, int>> expression = a => a + constant.Argument;
                var rValue = expression.Compile();
                return rValue;
            }
        }



    }
}


