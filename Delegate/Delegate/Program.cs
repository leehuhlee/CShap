using System;

namespace Delegate
{
    class Program
    {
        delegate int OnClicked();

        static void ButtonPressed(OnClicked clickedFunction)
        {
            clickedFunction();
        }


        static int TestDelegate()
        {
            Console.WriteLine("Hello Delegate!");
            return 0;
        }
        static int TestDelegate2()
        {
            Console.WriteLine("Hello Delegate 2!");
            return 0;
        }

        static void Main(string[] args)
        {
            OnClicked clicked = new OnClicked(TestDelegate);
            clicked += TestDelegate2;

            ButtonPressed(clicked);
        }
    }
}
