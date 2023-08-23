using System.Linq;
using System.Text;

namespace machineTestCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //Calculating the average of the given array
            int[] intArray = { 9, -5, -3, 8, -8, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
            int sum = 0;
            foreach (int element in intArray)
            {
                sum += element;
            }
            int avg = sum / intArray.Length;
            Console.WriteLine(avg);

            //Reverse the input string
            string inputString = "abcdef";
            Console.WriteLine("string is" + inputString);
            ReverseString(inputString);

            //Reverse the input string words
            string inputStringWords = "abcdef ghijk lmnop qrst";
            Console.WriteLine("Word is" + inputStringWords);
            ReverseWords(inputStringWords);

            // Reverse the input string words
            string inputStringEachWords = "abcdef ghijk lmnop qrst";
            Console.WriteLine("Word is" + inputStringEachWords);
            ReverseEachWords(inputStringEachWords);

            //Palindrome
            string inputStringForPalindrome = "1223";
            Console.WriteLine("Palindrome String is " + inputStringForPalindrome);
            Palindrome(inputStringForPalindrome);

            //Count of character occurence..
            string inputStringForCharacterCount = "abcdabcdABCDABCD";
            Console.WriteLine("Character Count String is " + inputStringForCharacterCount);
            GetCountOfCharacters(inputStringForCharacterCount);

            //Removal of duplicate characters occured..
            string inputStringForDuplicateCharacters = "abcdefghabcdABCDABCD";
            Console.WriteLine(" String is " + inputStringForDuplicateCharacters);
            RemovingDuplicateCharacters(inputStringForDuplicateCharacters);

            //All possible Substring..
            string inputStringForpossibleSubstring = "abcd";
            Console.WriteLine(" String is " + inputStringForpossibleSubstring);
            PossibleSubstring(inputStringForpossibleSubstring);

            //Circular left rotator..
            int[]  circularArray = {1,2,3,4,5};
            Console.WriteLine(" String is " + circularArray);
            RotateLeft(circularArray);

            //Circular right rotator..
            int[] circularRightArray = { 1, 2, 3, 4, 5 };
            Console.WriteLine(" String is " + circularRightArray);
            RotateRight(circularRightArray);

            //Check wheater its prime Number or not..
            Console.WriteLine("Please Enter Number for checking wheather its prime or not");
            var primeNumberCheckingVariable = int.Parse(Console.ReadLine());
            Console.WriteLine("the Variable is " + primeNumberCheckingVariable);
            CheckPrimeNumber(primeNumberCheckingVariable);

            //Sum of Digits
            var sumOfDigitsVariable = 4747;
            Console.WriteLine("the Variable is " + sumOfDigitsVariable);
            SumofDigits(sumOfDigitsVariable);


            //Second Largest 
            int[] inputArrayForFindingSecondLargestValue = {4,2,1,3,5,7,6,8,9};
            Console.WriteLine(" array given was");
            foreach (int i in inputArrayForFindingSecondLargestValue)
            {
                Console.Write(i+" ");
            }
            //Console.WriteLine("the Variable is " + sumOfDigitsVariable);
            FindSecondLargestNumber(inputArrayForFindingSecondLargestValue);

            //Find the number of pairs in the given integer
            int[] arrayToFindPairOfNumbers = { 1, 2,-2, 1, 6, -5, -6, 5 ,3,-3,-9 };
            Console.WriteLine(" array given was");
            foreach (int i in arrayToFindPairOfNumbers)
            {
                Console.Write(i + " ");
            }
            IntegerSumEqualsToTarget(arrayToFindPairOfNumbers, 3);

            //Find the Majority of element in given integer Array
            int[] arrayToFindMajorityOfNumbers = { 1, 2, 2, 3, 4, 2, 2};
            Console.WriteLine(" array given was");
            foreach (int i in arrayToFindMajorityOfNumbers)
            {
                Console.Write(i + " ");
            }
            CheckingMajorityElement(arrayToFindMajorityOfNumbers);

        }

        // file:///C:/Users/User/Downloads/aspnet-core-environment-tag-helper.html
        // https://csharp-video-tutorials.blogspot.com/2019/03/aspnet-core-image-tag-helper.html

        //Function for Reverse String
        public static void ReverseString(string inputString)
        {
            char[] chars = inputString.ToCharArray();
            char[] result = new char[inputString.Length];
            for(int i = inputString.Length - 1, j = 0 ; i >= 0 ; i--, j++)
            {
                result[j] = chars[i];
            }
            string resultString = new string(result);
           Console.WriteLine(resultString);
        }

        //Function for reversing words..
        public static void ReverseWords(string inputString)
        {
            var result = string.Empty;
            string[] stringList = inputString.Split(" ");
            string[] resultList = new string[stringList.Length];
            for (int i = stringList.Length -1 , j = 0 ; i >= 0 ; i--, j++)
            {
                resultList[j] = stringList[i];
            }

            foreach (string str in resultList)
            {
                result += str + " ";
            }

            Console.WriteLine(result);
        }

        //Function for reversing each words..
        public static void ReverseEachWords(string inputString)
        {
            var result = string.Empty;
            string[] stringList = inputString.Split(" ");
            string[] resultList = new string[stringList.Length];
            for (int i = stringList.Length - 1, j = 0; i >= 0; i--, j++)
            {
                char[] chars = stringList[i].ToCharArray();
                char[] resultChars = new char[chars.Length];
                for (int x = stringList[i].Length-1,y = 0 ; x >= 0; x--,y++  )
                {
                    resultChars[y] = chars[x];
                }
                string stringResult = new string(resultChars);
                resultList[j] = stringResult;
            }

            foreach (string str in resultList)
            {
                result += str + " ";
            }

            Console.WriteLine(result);
        }

        //Function for Palindrome
        public static void Palindrome(string inputString)
        {
            bool flag = false;
            
            for (int i = 0 ,j= inputString.Length - 1; i < inputString.Length / 2 ; i++, j--)
            {
                if (inputString[i] != inputString[j])
                {
                    flag = false;
                    break;
                }else
                {
                    flag = true;
                }
                
            }
            if (flag)
            {
            Console.WriteLine("palindrome");

            }
            else
            {
                Console.WriteLine("Not Palindrome");
            }
        }
    
        //Function for counting occurence of each letter in a string
        public static void GetCountOfCharacters(string inputString)
        {
            Dictionary<char, int> characterCount = new Dictionary<char,int>();
            
            foreach(var str in inputString)
            {
                if (!characterCount.ContainsKey(str))
                {
                    characterCount.Add(str,1);
                }
                else
                {
                    characterCount[str]++;
                }
            }
            
            foreach(var str in characterCount)
            {
                Console.WriteLine($"Character :{str.Key}, count: {str.Value}");
            }
        }
        
        //Removing Duplicate characters from String 
        public static void RemovingDuplicateCharacters(string inputString)
        {
            var resultString = string.Empty;
            for (var i = 0; i < inputString.Length; i++)
            {
                if (!resultString.Contains(inputString[i]))
                {
                    resultString += inputString[i];
                }
            }
            Console.WriteLine(resultString);
        }

        //input = abcd, output = a ab abc abcd b bc bcd c cd d
        public static void PossibleSubstring(string inputString)
        {
            for (var i = 0; i<= inputString.Length; i++)
            {
                StringBuilder subString = new StringBuilder(inputString.Length - i);
                for (int j = i; j < inputString.Length; ++j)
                {
                    subString.Append(inputString[j]);
                    Console.Write(subString + " ");
                }
            }
        }

        //input: 1 2 3 4 5, output: 2 3 4 5 1
        public static void RotateLeft(int[] array)
        {
            int size = array.Length; //stored length of array in size
            int lastElementIndex = size - 1; // As array starts from 0 we gave last Element by substracting with size
            int temp; //temp variable where we will be storing our last element for swapping.
            //We will be looping through the array for getting the array to be rotated left by 1 element.
            for (int j = lastElementIndex; j > 0; j--)
            {
                temp = array[lastElementIndex]; // storing last elements value to temp variable
                array[lastElementIndex] = array[j - 1]; // substracting index of j element by 1 and storing the element to last element of array  
                array[j - 1] = temp; // in the j element space we will be storing the value of temp
            }

            //looping through the array to print the elements.
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
        }

        //input : 1 2 3 4 5, output: 5 1 2 3 4
        public static void RotateRight(int[] array)
        {
            int size = array.Length; // length of array in size
            int temp; // temp value to be stored

            //Looping through the array
            for (int val = 0; val < size -1 ; val++)
            {
                temp = array[0]; //storing the first element in temporary variable
                array[0] = array[val + 1]; // by increasing the index by 1 will store the element in first index of element
                array[val + 1] = temp; //then the temp variable value will get stored in elment of incresed index 
            }

            //looping through the element to print the elements of the array.
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
        }
    
        //Check wheater the input number is prime or not.
        public static void CheckPrimeNumber(int inputNumber)
        {
            int quotient = inputNumber/2;
            Console.WriteLine("Quotient for checking the prime Number is " + quotient);
            for (int i = 2; i <= quotient; i++)
            {
                if (inputNumber % i == 0)
                {
                    Console.WriteLine("not a Prime Number");
                    break;
                }
                else
                {
                    Console.WriteLine("Its a prime Number");
                    break;
                }
            }
        }
   
        //Sum of digits of a number..
        public static void SumofDigits(int inputNumber)
        {
            int sum = 0;
            while(inputNumber > 0)
            {
                sum += inputNumber % 10;
                inputNumber /= 10;
            }
            Console.WriteLine(sum);

            // 8383 % 10 = 838.3  input: 838  sum:3;
            // 838 % 10 = 83.8  input:83 sum: 11; by adding 3 to 8
            // 83 % 10 = 8.3 input: 8  sum: 14; by adding 11 to 3
            // 8 % 10 = 0.8 input:0 sum: 22; by adding 14 to 8
            // 10
        }
    
        //Find Second Largest Number from the input array.
        public  static void FindSecondLargestNumber(int[] inputArray)
        {
            //int[] resultArray = new int[inputArray.Length];

            //int highestVariable = inputArray.Max();

            //int result = inputArray.Where(x => x < highestVariable).Max();

            //By(x => x < inputArray.Max());

            int max1 = int.MinValue;
            int max2 = int.MinValue;


            foreach (var i in inputArray)
            {
                if (i > max1)
                {
                    max1 = max2;
                    max1 = i;
                }
                else if(i >= max2 && i != max1)
                {
                    max2 = i;
                }
            }

            Console.WriteLine(max2);
            
        }
        
        //Find the Pair of Number from the input array whose sum will be the given integer. 
        public static void FindPairOfNumbers(int[] inputArray, int x )
        {
            //for (int i = 0, j = inputArray.Length - 1; i < inputArray.Length; i++, j--)
            //{
            //    //if(inputArray[j] + inputArray[i] == x)
            //    //{
            //    //    Console.WriteLine($"{inputArray[i]}, {inputArray[j]}");
            //    //}

            //    //if (inputArray[i] + inputArray[j] == x)
            //    //{
            //    //    Console.WriteLine($"{inputArray[j]}, {inputArray[i]}");
            //    //}

            //    for (int y = i+1; y < inputArray.Length; y++ )
            //    {
            //        if (inputArray[i] + inputArray[y] == x)
            //        {
            //            Console.WriteLine($"{inputArray[i]}, {inputArray[y]}");
            //        }
            //        else if(inputArray[y] + inputArray[i] == x)
            //        {
            //            Console.WriteLine($"{inputArray[y]}, {inputArray[i]}");
            //        }
            //    }
            //}

            List<(int,int)> pairs = new List<(int,int)>();
            int startIndex = 0;
            int lastIndex = inputArray.Length - 1;
          
            while (startIndex < lastIndex)
            {
                int sum = inputArray[startIndex] + inputArray[lastIndex];
                if(sum == x)
                {
                    pairs.Add((inputArray[startIndex], inputArray[lastIndex]));
                    startIndex++;
                    lastIndex--;

                }else if (sum > x)
                {
                    lastIndex--;
                }
                else
                {
                   startIndex++;
                }

            }
           // var allPairs = FindAllPairs(arr, desiredSum);
            Console.WriteLine("All matching pairs are:");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.Item1}, {pair.Item2}");
            }

        }
    
        //Find the Pair of Number from the input array whose sum will be the given integer. 
        public static void IntegerSumEqualsToTarget(int[] inputArray, int target)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if(i != j)
                    {
                        int sum = inputArray[i] + inputArray[j];
                        if (sum == target)
                        {
                            Console.WriteLine($"{inputArray[i]},{inputArray[j]}");
                        }
                    }
                }
            }
        }
    
        //Find the Majority of element from an array given 
        public static void CheckingMajorityElement(int[] inputArray)
        {

            Dictionary<int,int> dict = new Dictionary<int,int>();
           
            foreach (var i in inputArray)
            {
                if (dict.ContainsKey(inputArray[i]) )
                {
                    dict[i]++;

                }
                else
                {
                    dict.Add(i, 1);
                }
            }

             var maxValue = dict.Values.Max();
            var n = dict.FirstOrDefault(x => x.Value >= maxValue); 

            Console.WriteLine($"Majority of the number is {n.Key} which occurs {n.Value} times");

        }
    

    }
}