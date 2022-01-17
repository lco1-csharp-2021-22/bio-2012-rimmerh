using System;
using System.Collections.Generic;

namespace bio2012
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDictionary<char, Tuple<char, char, char, bool>> map = new Dictionary<char, Tuple<char, char, char, bool>>()
            {
                {'A', new Tuple<char, char, char, bool>('E', 'F', 'D', true) },
                {'B', new Tuple<char, char, char, bool>('G', 'H', 'C', true) },
                {'C', new Tuple<char, char, char, bool>('I', 'J', 'B', true) },
                {'D', new Tuple<char, char, char, bool>('K', 'L', 'A', true) },
                {'E', new Tuple<char, char, char, bool>('M', 'N', 'A', true) },
                {'F', new Tuple<char, char, char, bool>('N', 'O', 'A', true) },
                {'G', new Tuple<char, char, char, bool>('O', 'P', 'B', true) },
                {'H', new Tuple<char, char, char, bool>('P', 'Q', 'B', true) },
                {'I', new Tuple<char, char, char, bool>('Q', 'R', 'C', true) },
                {'J', new Tuple<char, char, char, bool>('R', 'S', 'C', true) },
                {'K', new Tuple<char, char, char, bool>('S', 'T', 'D', true) },
                {'L', new Tuple<char, char, char, bool>('T', 'M', 'D', true) },
                {'M', new Tuple<char, char, char, bool>('L', 'E', 'U', true) },
                {'N', new Tuple<char, char, char, bool>('E', 'F', 'U', true) },
                {'O', new Tuple<char, char, char, bool>('F', 'G', 'V', true) },
                {'P', new Tuple<char, char, char, bool>('G', 'H', 'V', true) },
                {'Q', new Tuple<char, char, char, bool>('H', 'I', 'W', true) },
                {'R', new Tuple<char, char, char, bool>('I', 'J', 'W', true) },
                {'S', new Tuple<char, char, char, bool>('J', 'K', 'X', true) },
                {'T', new Tuple<char, char, char, bool>('K', 'L', 'X', true) },
                {'U', new Tuple<char, char, char, bool>('M', 'N', 'V', true) },
                {'V', new Tuple<char, char, char, bool>('O', 'P', 'U', true) },
                {'W', new Tuple<char, char, char, bool>('Q', 'R', 'X', true) },
                {'X', new Tuple<char, char, char, bool>('S', 'T', 'W', true) }
            };

            List<char> flipFlops = new List<char>();
            foreach (char c in Console.ReadLine()) {  flipFlops.Add(c); }
            string secondIn = Console.ReadLine();
            char departing = secondIn[0];
            char arriving = secondIn[1];
            int runTime = Int32.Parse(Console.ReadLine());

            while (runTime > 0)
            {
                if (departing == map[arriving].Item3)
                {
                    char next;
                    if (map[arriving].Item4)
                    {
                        next = map[arriving].Item1;    
                    }
                    else
                    {
                        next = map[arriving].Item2;
                    }
                    if (flipFlops.Contains(arriving))
                    {
                        if (map[arriving].Item4)
                        {
                            map[arriving] = new Tuple<char, char, char, bool>(map[arriving].Item1, map[arriving].Item2, map[arriving].Item3, false);
                        }
                        else
                        {
                            map[arriving] = new Tuple<char, char, char, bool>(map[arriving].Item1, map[arriving].Item2, map[arriving].Item3, true);
                        }
                    }
                    departing = arriving;
                    arriving = next;
                }
                else
                {
                    char next = map[arriving].Item3;
                    if (!flipFlops.Contains(arriving))
                    {
                        if (departing == map[arriving].Item1)
                        {
                            map[arriving] = new Tuple<char, char, char, bool>(map[arriving].Item1, map[arriving].Item2, map[arriving].Item3, true);
                        }
                        else
                        {
                            map[arriving] = new Tuple<char, char, char, bool>(map[arriving].Item1, map[arriving].Item2, map[arriving].Item3, false);
                        }
                    }
                    departing = arriving;
                    arriving = next;
                }
                runTime--;
                Console.WriteLine($"{departing}{arriving} - {100 - runTime}");
            }
            /*
    AFED
    BHGC
    CJIB
    DLKA
    ENMA
    FONA
    GPOB
    HQPB
    IRQC
    JSRC
    KTSD
    LMTD
    MLEU
    NEFU
    OFGV
    PGHV
    QHIW
    RIJW
    SJKX
    TKLX
    UMNV
    VOPU
    WQRX
    XSTW

            */
        }
    }
}
