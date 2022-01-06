using System;

namespace ValueTuples.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // traditionally when a function needs to return multiple values, some of them are returned by reference 
            bool result = TraditionalMultiValueCall(out int value);
            Console.WriteLine($"Result: {result} gives the value: {value}");

            // There are tuples, but these are by reference
            // https://docs.microsoft.com/en-us/dotnet/api/system.tuple?view=net-6.0
            // (although tuples are immutable once set, which does mean methods can't change their components)
            Tuple<int, int> tup = new Tuple<int, int>(42, 94);

            Console.WriteLine($"Old value: {tup}");

            // there are also static constructors 
            Tuple<int, int> t2 = Tuple.Create(42, 94);
            Tuple<string, int, int, bool> t3 = Tuple.Create("hello", 2, 3, false);

            // because they're by reference, equality is tricky 
            Console.Write($"{tup} and {t2} are ");
            if (tup == t2) {
                Console.WriteLine("the same.");
            } else { 
                Console.WriteLine("different.");
            }

            Console.WriteLine("\nValue Tuples:");

            // but now there are ValueTuples - these are passed by value 
            ValueTuple<int, int> vt1 = new ValueTuple<int, int>(42, 94);
            ValueTuple<int, int> vt2 = new ValueTuple<int, int>(42, 94);

            Console.Write($"{vt1} and {vt2} are ");
            if (vt1 == vt2)
            {
                Console.WriteLine("the same.");
            }
            else
            {
                Console.WriteLine("different.");
            }

            // but the best thing about value tuples is that you don't need to use the new keyword any more, nor even their type name 

            (int, int) val1 = (42, 94);
            (int, int, int) val2 = ReturnSomeValues();

            // we can access the individual items within the tuple 
            int second = val2.Item2;

            // we can name them, which is nice 
            (int sum, int count, int value) val3 = ReturnSomeValues();

            int counter = val3.count;

            // we could even have the method name them for us when using the dreaded var keyword 
            var val4 = NamedValues();
            int item2 = val4.second;

            // and some OO examples 
            // ExampleClass.ExampleCalls();
        }


        static bool TraditionalMultiValueCall(out int outgoingValue)
        {
            outgoingValue = 94;
            return true;
        }

        public static (int, int, int) ReturnSomeValues()
        {
            return (3, 12, -45);
        }


        public static (int first, int second, int third) NamedValues()
        {
            return (8, 12, 15);
        }
    }
}

