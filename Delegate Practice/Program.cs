using System;

MyMethod(Square);

void MyMethod(Action<int> action)
{
    int A = 5;
    action(A);
}

void Square(int number)
{
  Console.WriteLine(number * number);
} 


 

