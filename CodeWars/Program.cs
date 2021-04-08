using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
    static void Main()
    {
        Console.WriteLine(XO("xxOoog"));    
    }
    public static int PositiveSum(int[] arr)
    {
        return arr.Aggregate(0, (sum, x) => x > 0 ? sum + x: sum);
    }
    public static bool XO(string input)
    {
        return input.ToLower().Count(x => x == 'o') == input.ToLower().Count(x => x == 'x');
    }
    public static string Order(string words)
    {
       return string.IsNullOrEmpty(words)? "" : String.Join(' ', words.Split().OrderBy(x => x.Single(char.IsDigit)));
    }
    public static string AlphabetPosition(string text)
    {
        return string.Join(' ', text.ToLower().Where(char.IsLetter).Select(x => x - 96));
    }
    public static string CreatePhoneNumber(int[] numbers)
    {
        return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");
    }
    public static bool IsIsogram(string str)
    {
        return str.ToLower().Distinct().Count() == str.Length;
        //return str.All(x => str.ToLower().Count(y => y == char.ToLower(x)) == 1);
    }
    public static int FindShort(string s)
    {
        return s.Split().Min(x => x.Length);
    }
    public static int CountBits(int n)
    {
        return Convert.ToString(n, 2).Count(x => x == '1');
    }
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        return a.Where(x => !b.Contains(x)).ToArray();
    }
    public static bool IsValidWalk(string[] walk)
    {
        if (walk.Length != 10) return false;
        else
        {
            int[] pos = new int[2] { 0, 0 };
            foreach (var e in walk)
            {
                switch (e)
                {
                    case "n":
                        pos[1]++;
                        break;
                    case "s":
                        pos[1]--;
                        break;
                    case "w":
                        pos[0]--;
                        break;
                    case "e":
                        pos[0]++;
                        break;
                }
            }
            return pos.All(x => x == 0);
        }
    }
    public static string DuplicateEncode(string word)
    {
        return new string(word.ToLower().Select(x => word.ToLower() .Count(y => y == x) > 1 ? ')' : '(').ToArray());
    }
    public static string Disemvowel(string str)
    {
        return new string(str.Where(x => !"aeiou".Contains(x.ToString().ToLower())).ToArray());
    }
    public static int Find(int[] integers)
    {
        return integers.Where(x => x % 2 == (integers[0..3].Count(x => x % 2 == 0) > 1 ? 1 : 0)).First();
    }
    public static int SquareDigits(int n)
    {
        return Convert.ToInt32(String.Join("",n.ToString().Select(x => (int)(x - '0') * (int)(x - '0'))));
    }
    //public static string Decode(string morseCode)
    //{
    //    return String.Join(" ", morseCode.Trim().Split("   ").Select(x => String.Join("", x.Split(" ").Select(y => MorseCode.Get(y)))));
    //}
    public static string HighAndLow(string numbers)
    {
        var p = numbers.Split().Select(x => int.Parse(x));
        return p.Max() + " " + p.Min();
    }
    public static int DuplicateCount(string str)
    {
        return str.ToUpper().GroupBy(x => x).Count(y => y.Count() > 1);
        return str.ToUpper().Where(x => str.ToUpper().Count(y => y == x) > 1).Distinct().Count();
    }
    public static string Likes(string[] name)
    {
        return (name.Length > 0? name.Length>1? name.Length>2? name.Length > 3? $"{name[0]}, {name[1]} and {name.Length-2} others like this" : $"{name[0]}, {name[1]} and {name[2]} like this" : $"{name[0]} and {name[1]} like this" : $"{name[0]} likes this" : "no one likes this");
    }
    public static string SpinWords(string sentence)
    {
        return String.Join(" ", sentence.Split(" ").Select(x => x.Length >= 5 ? new string(x.Reverse().ToArray()) : x));
    }
    static long getProduct(long n)
    {
        long product = 1;
        while (n != 0)
        {
            product = product * (n % 10);
            n = n / 10;
        }
        return product;
    }
    public static int Persistence(long n)
    {
        for(int i = 0; ; i++)
        {
            if (n < 10) return i; 
            else n = getProduct(n);
        }
    }
    public static string EvenOrOdd(int number)
    {
        return number % 2 == 0 ? "Even" : "Odd";
    }
    public static int DigitalRoot(long n)
    {
        while (n > 9) { n = n.ToString().Select(x => x-'0').Sum(); }
        return Convert.ToInt32(n);
    }
    public static int GetVowelCount(string str)
    {
        return str.Count(x => "aeiou".Contains(x));
    }
    public static int find_it(int[] seq)
    {
        return seq.First(x => seq.Count(y => y == x)%2==1);
    }
    public static int Solution(int value)
    {
        return value>0? Enumerable.Range(1, value-1).Where(x => (x % 3 == 0) || (x % 5 == 0)).Sum() : 0;
    }
    public static int NbDig(int n, int d)
    {
        return Enumerable.Range(0, n + 1).Select(x => (x * x).ToString().Count(y => y.ToString() == d.ToString())).ToList().Sum();
    }
    public static String solve(String s)
    {
        List<int> spaces = new List<int>();
        for(int i = 0; i < s.Length; i++) if (s[i] == ' ') spaces.Add(i);
        s = string.Join("",s.ToCharArray().Reverse().Where(x => x != ' '));
        for (int i = 0; i < spaces.Count; i++) s = s.Insert(spaces[i], " ");
        return s;
    }
    public static string[] dup(string[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            string str = arr[i];
            for (int j = 0; j < str.Length - 1; j++)
                if (str[j] == str[j + 1])
                {
                    str = str.Remove(j + 1, 1);
                    j--;
                }
            arr[i] = str;
        }
        return arr; 
    }
    public static string[] TowerBuilder(int nFloors)
    {
        string[] str = new string[nFloors];
        for(int i = 0; i < nFloors; i++)
        {
            for (int j = i; j < nFloors - 1; j++) str[i] += " ";
            for (int j = 0; j < i; j++) str[i] += "*";
            str[i] += "*";
            for (int j = 0; j < i; j++) str[i] += "*";
            for (int j = i; j < nFloors - 1; j++) str[i] += " ";
        }
        
        return str;
    }

    public static bool IsSquare(int n)
    {
        return Math.Sqrt(n) == (int)Math.Sqrt(n);
    }
    public static string[] Solution(string str)
    {
        string[] str_a = new string[(str.Length + 1)/2];
        for(int i = 0; i < str.Length; i+=2)
        {
            if (i == str.Length - 1) str_a[i / 2] = str[i] + "_";
            else str_a[i / 2] = str[i..(i + 2)];
        }

        return str_a;
    }

    public static String Accum(string s)
    {
        List<string> str = new List<string>();
        for(int i = 0; i < s.Length; i++)
        {
            if (i > 0) str.Add("-"); 
            for (int j = 0; j <= i; j++) str.Add((j == 0? char.ToUpper(s[i]) : char.ToLower(s[i])).ToString());
        }
        return String.Join("",str.ToArray());
    }
}