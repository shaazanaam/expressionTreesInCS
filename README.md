# Expression Trees in C#

This project demonstrates the use of expression trees and delegates in C#.

## Features

- Filtering lists using LINQ and lambda expressions.
- Creating and inspecting expression trees.
- Compiling and executing expression trees.
- Using lambda expressions as delegates.

## Getting Started

### Prerequisites

- .NET 8 SDK

### Running the Program

1. Clone the repository.
2. Open the solution in Visual Studio 2022.
3. Build the solution.
4. Run the project.

### Code Overview
## License

This project is licensed under the MIT License.
#### Main Method

The `Main` method demonstrates the following:

- Filtering even numbers from a list using a lambda expression.
- Creating and inspecting an expression tree.
- Creating expression nodes and compiling them.
- Creating an expression tree from a lambda expression and compiling it.
- Compiling and executing an expression tree.
- Creating an expression tree that represents raising a number to a power and executing it.

#### Delegate Definition

The `delegateDefinition` method demonstrates how to use lambda expressions as delegates.

### Example Output

Even Numbers:
2
4
6
----Prints the name of the variable for variable access expression--The base expression class contains the NodeProperty for the purpose that you may encounter many different expression types and the base expression class returns an Expression Type which is an enumeration of the possible expression types Once you know the type of the node you perform the specific actions for the node and work with the specific types for that kind of expression 
Body and Binary Expression (a + 5)(a + 5)
a
System.Int32
This is the squareExpression Tree___
a => (a * a)
The expression tree is now compiled into a delegate
System.Func`2[System.Int32,System.Int32]
Square of 5 is : 25
True
True
The result of the expression tree is : 8
Sum: 8
Difference: 2
