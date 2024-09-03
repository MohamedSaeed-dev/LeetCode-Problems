using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace LeetCode_Problems
{
    public static class LeetCode
    {
        public static int GetLucky(string s, int k)
        {
            StringBuilder convert = new();
            int aIndex = 'a';
            for (int i = 0; i < s.Length; i++)
            {
                convert.Append((int)s[i] - aIndex + 1);
            }
            int sum = 0;
            while(k >= 1)
            {
                for (int i = 0; i < convert.Length; i++)
                {
                    sum += int.Parse(convert[i].ToString());
                }
                if(k == 1) break;
                convert.Clear();
                convert.Append(sum);
                sum = 0;
                k--;
            }

            return sum;
        }
        public static bool IsPowerOfTwo(int n)
        {
            double result = 0;
            int i = 0;
            while (result <= n)
            {
                result = Math.Pow(2, i);
                if (result.Equals(n)) return true;
                i++;
            }
            return false;
        }
        public static int DaysBetweenDates(string date1, string date2)
        {
            var date_1 = DateTime.Parse(date1);
            var date_2 = DateTime.Parse(date2);
            return Math.Abs((date_2 - date_1).Days);
        }
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string word1_string = string.Join("", word1);
            string word2_string = string.Join("", word2);
            return word1_string.Equals(word2_string);
        }
        public static int ChalkReplacer(int[] chalk, int k)
        {
            int i = 0;
            while(k >= chalk[i])
            {
                k -= chalk[i];
                if (i == chalk.Length - 1)
                {
                    i = 0; continue;
                }
                i++;
            }
            return i;
        }
        public static int Reverse(int x)
        {
            string num = x.ToString();
            bool hasDash = num.Any(x => x ==  '-');
            num = string.Join("",num.Where(char.IsDigit));
            string reversed = string.Join("", num.Reverse().ToArray());
            string withDash = hasDash ? $"-{reversed}" : reversed;
            if(int.TryParse(withDash, out int res))
            {
                return res;
            }
            return 0;
        }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            list.AddRange(nums1);
            list.AddRange(nums2);
            list.Sort();
            int length = list.Count;
            if (length % 2 != 0)
            {
                int mid = length / 2;
                return list[mid];
            }
            int med = length / 2;
            double sum = (list[med]+list[med-1]);
            double half = sum / 2;
            return half;
        }
        public static void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            Array.Reverse(nums);
            int start = 0;
            int end = k-1;
            while(start < end)
            {
                var temp = nums[start]; 
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
            start = k;
            end = nums.Length-1;
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
            foreach (var i in nums)
            {
                Console.Write(i + " ");
            }
        }
        private static int[] Insert(ref int[] array, int index, int value)
        {
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = value;
            return array;
        }
        private static int[] Remove(ref int[] array, int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = default;
            return array;
        }
        public static int[][] Construct2DArray(int[] original, int m, int n)
        {
            if(m*n != original.Length) return Array.Empty<int[]>();
            var current = 0;
            var arr = new int[m][];
            for (int i = 0; i < m; i++)
            {
                var row = new int[n];
                for (int j = 0; j < n; j++)
                {
                    row[j] = original[current];
                    current++;
                }
                arr[i] = row;
            }
            return arr;
        }
        public static int MinOperations(string[] logs)
        {
            var ops = new Stack<string>();
            for (int i = 0; i < logs.Length; i++)
            {
                switch(logs[i])
                {
                    case "../":
                        if(ops.Count > 0) ops.Pop();
                        break;
                    case "./":
                        break;
                    default:
                        ops.Push(logs[i]);
                        Console.WriteLine(ops.Peek());
                        break;
                }
            }
            return ops.Count;
        }
        public static int CalPoints(string[] operations)
        {
            var record = new Stack<int>();
            for (int i = 0; i < operations.Length; i++)
            {
                if (int.TryParse(operations[i], out int num)) record.Push(num);
                else
                {
                    switch (operations[i])
                    {
                        case "+":
                            var num1 = record.Pop();
                            var num2 = record.Pop();
                            var sum = num1 + num2;
                            record.Push(num2);
                            record.Push(num1);
                            record.Push(sum);
                            break;
                        case "D":
                            var top = record.Peek();
                            var doubled = top * 2;
                            record.Push(doubled);
                            break;
                        case "C":
                            record.Pop();
                            break;
                        default: break;
                    }
                }
            }
            return record.Sum();
        }
        public static int MaxNumberOfBalloons(string text)
        {
            var map = new Dictionary<char, int>();
            string ballon = "ballon";

            foreach (var i in text)
            {
                if (map.ContainsKey(i) ) map[i]++;
                else if(ballon.Contains(i)) map[i] = 1;
            }

            if (map.Any(x => !ballon.Contains(x.Key))) return 0;
            int l = map['l'] / 2;
            int o = map['o'] / 2;
            return new int[] { map['b'], map['a'], l, o, map['n'] }.Min();
        }
        public static void SortColors(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var min = i;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] < nums[min])
                    {
                        min = j;
                    }
                }
                var temp = nums[i];
                nums[i] = nums[min];
                nums[min] = temp;
            }
            foreach (var i in nums)
            {
                Console.Write(i + " ");
            }
        }
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var mapNote = new Dictionary<char, int>();
            var mapMag = new Dictionary<char, int>();
            foreach(var i in ransomNote)
            {
                if (mapNote.ContainsKey(i)) mapNote[i]++;
                else mapNote[i] = 1;
            }
            foreach (var i in magazine)
            {
                if (mapMag.ContainsKey(i)) mapMag[i]++;
                else mapMag[i] = 1;
            }
            foreach (var pair in mapNote)
            {
                if (!mapMag.ContainsKey(pair.Key) || (pair.Value > mapMag[pair.Key])) return false;
            }
            return true;
        }
        public static int MajorityElement(int[] nums)
        {
            int times = nums.Length / 2;
            var map = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i])) map[nums[i]]++;
                else map[nums[i]] = 1;
            }
            var num = map.FirstOrDefault(x => x.Value > times);
            return num.Key;
        }
        public static bool IsAnagram(string s, string t)
        {
            if(s.Length !=  t.Length) return false;
            var mapS = new Dictionary<char, int>();
            var mapT = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if (mapS.ContainsKey(c)) mapS[c]++;
                else mapS[c] = 1;
            }
            foreach (char c in t)
            {
                if (mapT.ContainsKey(c)) mapT[c]++;
                else mapT[c] = 1;
            }
            foreach(var pair in mapS)
            {
                if (!mapT.ContainsKey(pair.Key) || (pair.Value != mapT[pair.Key])) return false;
            }
            return true;
        }
        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }
        public static long[] Digitize(long n)
        {
            var stringify = n.ToString();
            var reversedArray = new long[stringify.Length];
            for (int i = stringify.Length-1; i >=0; i--)
            {
                reversedArray[stringify.Length-1 - i] = long.Parse(stringify[i].ToString());
            }
            return reversedArray;
        }
        public static bool ContainsDuplicate(int[] nums)
        {
            var map = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.Contains(nums[i]))
                {
                    map.Add(nums[i]);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public static int MaxProfitI(int[] prices)
        {
            int i = 0;
            int low = prices[0], 
                high = prices[0], 
                profit = 0;
            while(i < prices.Length-1)
            {
                while(i < prices.Length-1 && prices[i] >= prices[i + 1])
                {
                    i++;
                }
                low = prices[i];
                while (i < prices.Length - 1 && prices[i] <= prices[i + 1])
                {
                    i++;
                }
                high = prices[i];
                profit += high - low;
            }
            return profit;
        }
        public static bool IsPalindromeI(string s)
        {
            string parsedS = string.Join("", s.Where(x => char.IsLetterOrDigit(x)).Select(x => char.ToLower(x)));
            StringBuilder palindrome = new StringBuilder();
            for (int i = parsedS.Length - 1; i >= 0; i--)
            {
                palindrome.Append(parsedS[i]);
            }
            return parsedS == palindrome.ToString();
        }
        public static int[] SortedSquares(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i];    
            }
            Array.Sort(nums);
            return nums;
        }
        public static void ReverseStringI(char[] s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;

                left++;
                right--;
            }
            foreach (var i in s)
            {
                Console.Write(i + " ");
            }
        }
        public static int[] TwoSum(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;
            while(left < right)
            {
                int sum = numbers[left] + numbers[right];
                if(sum == target)
                {
                    return new int[] { left+1, right+1 };
                }
                else if(sum > target)
                {
                    right--;
                }
                else if(sum < target)
                {
                    left++;
                }
            }
            return new int[] {};
        }
        public static int RemoveDuplicatesII(int[] nums)
        {
            int k = 0;
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    if (map[nums[i]] < 2)
                    {
                        map[nums[i]]++;
                        nums[k] = nums[i];
                        k++;
                    }
                }
                else
                {
                    map.Add(nums[i], 1);
                    nums[k] = nums[i];
                    k++;
                }
            }
            foreach (var item in nums)
            {
                Console.Write(item+" ");
            }
            return k;
        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if(n > 0)
            {
                for (int i = nums1.Length - n; i < nums1.Length; i++)
                {
                    nums1[i] = nums2[i-m];
                }
            }
            Array.Sort(nums1,(a, b) =>
            {
                return a.CompareTo(b);
            });

            foreach (int i in nums1)
            {
                Console.Write(i+" ");
            }
        }
        public static int RemoveElementI(int[] nums, int val)
        {
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }
        public static int RemoveDuplicatesI(int[] nums)
        {
            var hash = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!hash.Contains(nums[i]))
                {
                    hash.Add(nums[i]);
                }
            }
            for (int i = 0; i < hash.Count; i++)
            {
                nums[i] = hash[i];
            }
            return hash.Count;
        }
        public static void Rotate(int[][] matrix)
        {
            // Transpose A[i][j] = A[j][i]
            for (int i = 0; i < matrix.Length; i++)
            {
                for(int j = i; j < matrix[i].Length; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            // Reflection A[i][0] = A[i][length-1]
            for (int i = 0; i < matrix.Length; i++)
            {
                int start = 0;
                int end = matrix[i].Length-1;
                while (start < end)
                {
                    int temp = matrix[i][start];
                    matrix[i][start] = matrix[i][end];
                    matrix[i][end] = temp;
                    start++;
                    end--;
                }
            }

            PrintMatrix(matrix);
            
            static void PrintMatrix(int[][] matrix)
            {
                foreach (var i in matrix)
                {
                    foreach (var j in i)
                    {
                        Console.Write(j + ",");
                    }
                    Console.WriteLine();
                }
            }

        }
        public static ListNode MiddleNode(ListNode head)
        {
            var curr = head;
            int count = 0;
            while (curr != null)
            {
                count++;
                curr = curr.next;
            }

            double half = count / 2;
            int n = (int)Math.Ceiling(half);
            curr = head;
            for (int i = 0; i < n; i++)
            {
                curr = curr.next;
            }
            return curr;
        }
        public static int NumberOfSteps(int num)
        {
            int numOfSteps = 0;
            while (num != 0)
            {
                if (num % 2 == 0) num /= 2;
                else num--;
                numOfSteps++;
            }
            return numOfSteps;
        }
        public static IList<string> FizzBuzz(int n)
        {
            string[] answer = new string[n];
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) answer[i-1] = "FizzBuzz";
                else if (i % 3 == 0) answer[i-1] = "Fizz";
                else if (i % 5 == 0) answer[i-1] = "Buzz";
                else answer[i-1] = i.ToString();
            }
            return answer;
        }
        public static int[] RunningSum(int[] nums)
        {
            int sum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                nums[i] = sum;
            }
            return nums;
        }
        public static int MaximumWealth(int[][] accounts)
        {
            int maxSum = 0; 
            for (int i = 0; i < accounts.Length; i++)
            {
                maxSum = Math.Max(maxSum, accounts[i].Sum());
            }
            return maxSum;
        }
        public static int NumIdenticalPairs(int[] nums)
        {
            // 1,2,3,1,1,3
            int left = 0;
            int right = nums.Length - 1;
            int count = 0;
            while (left <= right)
            {
                if(left == right)
                {
                    left++;
                    right = nums.Length - 1;
                    continue;
                }
                if(nums[left] == nums[right])
                {
                    count++;
                }
                right--;
            }
            return count;
        }
        public static int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) =>
            {
                return a[0].CompareTo(b[0]);
            });
            var ans = new List<int[]>() { intervals[0] };
            
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= ans[ans.Count - 1][1])
                {
                    ans[ans.Count - 1][1] = Math.Max(ans[ans.Count - 1][1], intervals[i][1]);
                }
                else
                {
                    ans.Add(intervals[i]);
                }
            }
            return ans.ToArray();
        }
        public static int[] ProductExcept(int[] nums)
        {
            // 1,2,3,4
            // 1, 1, 2, 6
            var ans = new int[nums.Length];
            var left = new int[nums.Length];
            var right = new int[nums.Length];
            left[0] = 1;
            right[right.Length-1] = 1;
            var prod_left = 1;
            var prod_right = 1;
            for (int i = 0; i < left.Length-1; i++)
            {
                prod_left *= nums[i];
                left[i+1] = prod_left;
            }
            for (int i = right.Length-1 ;i > 0 ; i--)
            {
                prod_right *= nums[i];
                right[i - 1] = prod_right;
            }
            for(int i = 0; i < nums.Length ; i++)
            {
                ans[i] = left[i]*right[i];
            }
            return ans;
        }
        public static int MaxProfit(int[] prices)
        {
            int max_profit = 0;
            int min_price = int.MaxValue;

            for(int i = 0; i < prices.Length; i++)
            {
                min_price = Math.Min(min_price, prices[i]);
                max_profit = Math.Max(max_profit, prices[i]-min_price);
            }
            return max_profit;
        }
        public static IList<string> SummaryRanges(int[] nums)
        {
            var list = new List<string>();
            int i = 0;
            while(i < nums.Length)
            {
                int start = nums[i];
                while (i < nums.Length - 1 && nums[i + 1] == nums[i] + 1)
                {
                    i++;
                }
                if(start != nums[i])
                {
                    list.Add($"{start}->{nums[i]}");
                }
                else
                {
                    list.Add($"{nums[i]}");
                }
                i++;
            }
            return list;
        }
        public static int FindClosestNumber(int[] nums)
        {
            var hashSet = new HashSet<int>();
            for(int i = 0; i < nums.Length; i++)
            {
                hashSet.Add(Math.Abs(nums[i]));
            }
            if (nums.Contains(hashSet.Min()))
            {
                return hashSet.Min();
            }
            return -hashSet.Min();
        }
        public static int[] MoveZeros(int[] nums)
        {
            var list = nums.ToList();
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 0)
                {
                    list.Remove(nums[i]);
                    list.Add(nums[i]);
                }
            }
            return list.ToArray();
        }
        public static int NumJewelsInStones(string jewels, string stones)
        {
            int count = 0;
            for (int i = 0; i < jewels.Length; i++)
            {
                count += stones.Count(x => x == jewels[i]);
            }
            return count;
        }
        public static string DefangIPaddr(string address)
        {
            var defangedIP = new StringBuilder();
            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == '.') defangedIP.Append("[.]");
                else defangedIP.Append(address[i]);
            }
            return defangedIP.ToString();
        }
        public static int FinalValueAfterOperations(string[] operations)
        {
            var operationsDict = new Dictionary<string, int>() { { "X++", 1 }, { "++X", 1 }, { "X--", -1 }, { "--X", -1 } };
            int X = 0;
            for (int i = 0; i < operations.Length; i++)
            {
                var operation = operationsDict[operations[i]];
                X = X + operation;
            }
            return X;
        }
        public static int MinimumOperations(int[] nums)
        {
            int numOps = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] % 3 > 0)
                {
                    numOps++;
                }
            }
            return numOps;
        }
        public static double[] ConvertTemperature(double celsius)
        {
            double feh = celsius * 1.80 + 32.00;
            double kelv = celsius + 273.15;
            return new double[] { kelv, feh };
        }
        public static int[] Shuffle(int[] nums, int n)
        {
            int a = 0;
            int b = n;
            var arr = new int[nums.Length];
            for (var i = 0; i < nums.Length; i+=2)
            {
                arr[i] = nums[a];
                arr[i+1] = nums[b];
                a += 1;
                b += 1;
            }
            return arr;
        }
        public static int[] BuildArray(int[] nums)
        {
            var arr = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                arr[i] = nums[nums[i]];
            }
            return arr;
        }
        public static string LargestNumber(int[] nums)
        {
            var list = Array.ConvertAll(nums, x => x.ToString()).ToList();
            list.Sort((x, y) =>
            {
                var o1 = x + y;
                var o2 = y + x;
                return o2.CompareTo(o1);
            });
            var list2 = string.Join("", list);
            return list2.All(x => x == '0') ? "0" : list2;
        }
        public static bool BackspaceCompare(string s, string t)
        {
            string s1 = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    s1 = s1.Length > 0 ? s1.Substring(0, s1.Length-1) : s1;
                }
                else
                {
                    s1 += s[i];
                }
            }
            string t1 = "";
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == '#')
                {
                    t1 = t1.Length > 0 ? t1.Substring(0, t1.Length - 1): t1;
                }
                else
                {
                    t1 += t[i];
                }
            }
            return s1 == t1;
        }
        public static int LongestOnes(int[] nums, int k)
        {
            //1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0
            int maxx = 0;
            int left = 0;
            int num_zeros = 0;
            for (int right = 0;  right < nums.Length; right++)
            {
                if(nums[right] == 0)
                {
                    num_zeros++;
                }
                while(num_zeros > k)
                {
                    if(nums[left] == 0)
                    {
                        num_zeros--;
                    }
                    left++;
                }
                maxx = Math.Max(maxx, right-left+1);
            }
            return maxx;
        }
        public static int TheMaximumAchievableX(int num, int t)
        {
            return num + 2 * t;
        }
        public static bool LemonadeChange(int[] bills)
        {
            // [5, 5, 10, 10, 20]
            var list = new Dictionary<int, int>() { { 5, 0 }, { 10, 0 }};
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    list[5] += 1;
                }
                else if (bills[i] == 10)
                {
                    if (list[5] > 0)
                    {
                        list[5] -= 1;
                        list[10] += 1;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (bills[i] == 20)
                {
                    if (list[10] > 0 && list[5] > 0)
                    {
                        list[10] -= 1;
                        list[5] -= 1;
                    }
                    else if (list[5] > 2)
                    {
                        list[5] -= 3;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool isSubsequence(string s, string t)
        {
            int j = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (j == s.Length) break;
                if(s[j] == t[i])
                {
                    j++;
                }
            }
            if (j == s.Length) return true;
            return false;
        }
        public static void hexToStr()
        {
            string hex = "8E2";
            string[] chars = hex.Split(' ');

            foreach (var c in chars)
            {
                var str = (char)Convert.ToInt32(c, 16);
                Console.Write(str);
            }
        }
        // 1
        public static int[] TwoSums(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var res = target - nums[i];
                if (dic.ContainsKey(res))
                {
                    return new int[] { dic[res], i };
                }

                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], i);
                }
            }
            return Array.Empty<int>();
        }
        public static int LogestOnes(int[] nums, int k)
        {
            // [1,0,0],0,1,1,1], 2
            int left = 0, num_zeros = 0, max_len = 0;
            for (int r = 0; r < nums.Length; r++)
            {
                if(nums[r] == 0)
                {
                    num_zeros += 1;
                }
                while (num_zeros > k)
                {
                    if (nums[left] == 0)
                    {
                        num_zeros -= 1;
                    }
                    left++;
                }
                int length = r - left + 1;
                max_len = Math.Max(max_len, length);
            }
            return max_len;
        }
        // 13
        public static string IntToRoman(int num)
        {
            var map = new Dictionary<int, string> { {1, "I" }, {4, "IV"}, {5, "V"}, {9, "IX"}, {10, "X"}, {40, "XL"}, {50, "L"}, {80, "LXXX"}, { 90, "XC" }, { 100, "C"}, {400, "CD"}, {500, "D"}, {900, "CM"}, {1000, "M"} };
            var newRoman = "";
            foreach(var i in map.Reverse())
            {
                while(num >= i.Key)
                {
                    newRoman += i.Value.ToString();
                    num -= i.Key;
                }
            }
            return newRoman;
        }
        public static int RomanToInt(string roman)
        {
            var map = new Dictionary<char, int> { { 'M', 1000 }, { 'D', 500 }, { 'C', 100 }, { 'L', 50 }, { 'X', 10 }, { 'V', 5 }, { 'I', 1 } };
            var newNum = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && map[roman[i]] < map[roman[i + 1]])
                {
                    newNum -= map[roman[i]];
                }
                else
                {
                    newNum += map[roman[i]];
                }
            }
            return newNum;

        }
        // 26
        public static int RemoveDuplicates(int[] nums)
        {
            int k = 0;
            var list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!list.Contains(nums[i]))
                {
                    list.Add(nums[i]);
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }
        // 58
        public static int LengthOfLastWord(string s)
        {
            var word = s.Trim().Split(" ");
            return word[word.Length - 1].Length;
        }
        public static int StrStr(string haystack, string needle)
        {
            var m = haystack.ToLower().Length;
            var n = needle.ToLower().Length;
            for (int i = 0; i < m - n + 1; i++)
            {
                var sub = haystack.Substring(i, n);
                if (sub == needle)
                {
                    return i;
                }
            }
            return -1;
        }
        public static bool IsPalindrome(string s)
        {
            var word = string.Join(" ", s.Where(x => char.IsLetterOrDigit(x)));
            var palindrome = word.ToLower();
            var newWord = new StringBuilder();
            for (int i = palindrome.Length - 1; i >= 0; i--)
            {
                newWord.Append(palindrome[i]);
            }
            return palindrome == newWord.ToString();
        }
        static bool IsNumberPalindrome(int x)
        {
            var num = x.ToString();
            var newNum = new StringBuilder();
            for (int i = num.Length - 1; i >= 0; i--)
            {
                newNum.Append(num[i]);
            }
            return (num == newNum.ToString());
        }

        public static bool IsValid(string s)
        {
            var dic = new Dictionary<char, string> { { ')', "(" }, { '}', "{" }, { ']', "[" } };
            var stack = new Stack<string>();
            foreach (var item in s)
            {
                if (dic.ContainsKey(item))
                {
                    var top = stack.Count != 0 ? stack.Pop() : null;
                    if (dic[item] != top)
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(item.ToString());
                }
            }
            return stack.Count == 0;

        }
        public static int RemoveElement(int[] nums, int val)
        {
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;

        }
        // ["Object","Oriented", "Programming"] -> "OOP"
        public static bool isAcronym(string word, string s)
        {
            var wordList = word.Split(" ");
            if (wordList.Length != s.Length) return false;

            for (int i = 0; i < wordList.Length; i++)
            {
                if (wordList[i][0] != s[i]) return false;
            }
            return true;
        }

        public static int CountKeyChanges(string s)
        {
            int changes = 0;
            char lastUsed = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (char.ToLower(s[i]) != char.ToLower(lastUsed))
                {
                    changes++;
                    lastUsed = s[i];
                }
            }
            return changes;
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            // [1, 1, 2]
            var dummy = new ListNode(0);
            dummy.next = head;
            var curr = dummy;
            var lis = new List<int>();
            while (curr != null)
            {
                if (!lis.Contains(curr.val))
                {
                    lis.Add(curr.val);
                    curr.next = curr;
                }

                curr = curr.next;
            }
            return dummy;
        }

        public static bool CanJump(int[] nums)
        {
            // [2,3,1,1,4]
            // [3,2,1,0,4]
            int target = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int diff = target - i;
                if (nums[i] >= diff)
                {
                    target = i;
                }
            }

            if (target != 0) return false;
            return true;
        }

        public static string GenerateCode()
        {
            var chars = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            StringBuilder code = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                code.Append(chars[Random.Shared.Next(0, chars.Length)]);
            }
            return code.ToString();
        }
        public static string ShortenEmail(string email)
        {
            // power123@gmail.com
            // pow*****@gmail.com
            var halfEmail = email.Split("@");
            var length = halfEmail[0].Length;
            var firstThree = halfEmail[0].Substring(0, 3);
            var newEmail = firstThree.PadRight(length, '*');
            return newEmail + halfEmail[1];
        }
        public static void ReverseString(char[] s)
        {
            // ["h","e","l","l","o"]
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
            foreach (char c in s)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
        public static string MergeAlternately(string word1, string word2)
        {
            var longest = word1.Length > word2.Length ? word1 : word2;
            var shortest = word1.Length <= word2.Length ? word1 : word2;
            var result = "";
            for (int i = 0; i < longest.Length; i++)
            {
                if (i > shortest.Length - 1)
                {
                    result += longest[i];
                }
                else
                {
                    result += word1[i];
                    result += word2[i];
                }
            }
            return result;
        }
        public static bool IsPerfectSquare(int num)
        {
            // 17
            double left = 1;
            double right = num;
            while (left <= right)
            {
                double mid = (left + right) / 2;
                if (mid * mid == num) return true;

                else if (mid * mid < num)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return false;
        }
        public static int NumWaterBottles(int numBottles, int numExchange)
        {
            // 9, 3
            int total = numBottles;

            int exchanged = 1;
            while (exchanged > 0)
            {
                exchanged = numBottles / numExchange;
                int reminder = numBottles % numExchange;

                total += exchanged;

                numBottles = exchanged + reminder;
            }

            return total;
        }
        public static string LongestCommonPrefix(string[] strs)
        {
            // "gun", "flower", "flow", "map", "flight"
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            var shortest = strs.Aggregate((minStr, nextStr) => minStr.Length < nextStr.Length ? minStr : nextStr);
            for (int i = 0; i < shortest.Length; i++)
            {
                foreach (var str in strs)
                {
                    if (str[i] != shortest[i])
                    {
                        return shortest.Substring(0, i);
                    }
                }
            }
            return shortest;
        }
        public static int ClimbStairs(int n, Dictionary<int, int> memo = null!)
        {
            var steps = new int[] { 1, 2 };
            memo = memo ?? new Dictionary<int, int>();
            if (memo.ContainsKey(n)) return memo[n];
            if (n < 0) return 0;
            if (n == 0) return 1;

            var total = 0;
            for (int i = 0; i < steps.Length; i++)
            {
                total += ClimbStairs(n - steps[i], memo);
            }
            memo.Add(n, total);
            return total;

            /*return ClimbStairs(n - 1) + ClimbStairs(n - 2) ;*/
        }
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var p1 = list1;
            var p2 = list2;
            var dummy = new ListNode(0);
            var curr = dummy;
            while (p1 != null && p2 != null)
            {
                if (p1?.val <= p2?.val)
                {
                    curr.next = p1;
                    p1 = p1.next;
                }
                else
                {
                    curr.next = p2!;
                    p2 = p2?.next;
                }
                curr = curr.next;
            }
            if (p1 != null) curr.next = p1;
            if (p2 != null) curr.next = p2;
            return dummy.next;


        }
        public static int SearchInsert(int[] nums, int target)
        {
            var index = nums.ToList().IndexOf(target);
            if (index != -1) return index;

            int big = 0;
            for (int i = 0; nums.Length > i; i++)
            {
                if (target > nums[i]) big = i + 1;
            }
            return big;
        }
        public static int PassThePillow(int n, int time)
        {
            int t = 1;
            int m = 1;
            while (t <= time)
            {
                if (m == n)
                {
                    m = -m;
                }
                if (m == -1)
                {
                    m = 1;
                }

                m++;
                t++;

            }
            return Math.Abs(m);
        }
        public static bool HasCycle(ListNode head)
        {
            var hash = new HashSet<ListNode>();
            var curr = head;
            while (!hash.Contains(curr) && curr.next != null)
            {
                curr = curr.next;
                hash.Add(curr);
            }
            if (curr.next == null || curr == null) return false;
            return true;
        }
        public static int LongestConsecutive(int[] nums)
        {
            var hash = new HashSet<int>(nums);
            int longest = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!hash.Contains(nums[i] - 1))
                {
                    int length = 1;
                    while (hash.Contains(nums[i] + length))
                    {
                        length++;
                    }
                    longest = Math.Max(longest, length);
                }
            }
            return longest;
        }
        public static int[] ProductExceptSelf(int[] nums)
        {
            // 0, 0

            var n = nums.Length;
            var answers = new int[n];

            var left = new int[n];
            left[0] = 1;
            for (int i = 1; i < n; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
            }
            var right = new int[n];
            right[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                answers[i] = left[i] * right[i];
            }

            return answers;
        }
        public static bool isValidWord(string word)
        {
            const string VOWLES = "auioe";
            if (word.Length < 3) return false;
            for (int i = 0; i < word.Length; i++) if (!char.IsLetterOrDigit(word[i])) return false;
            if (!word.Where(x => !char.IsDigit(x)).Any(x => VOWLES.Contains(char.ToLower(x)))) return false;
            if (!word.Where(x => !char.IsDigit(x)).Any(x => !VOWLES.Contains(char.ToLower(x)))) return false;
            return true;
        }
        public static ListNode MergeNodes(ListNode head)
        {
            var dummy = new ListNode(0);
            dummy.next = head;
            var curr = dummy;
            while (curr != null && curr.next != null)
            {
                if (curr.next.val == 0)
                {
                    int x = 0;
                    var curr1 = curr.next;
                    while (curr1 != null && curr1.val != 0)
                    {
                        x += curr1.val;
                        curr1 = curr1.next;
                    }
                    curr.next.val = x;
                    curr.next.next = curr1!;
                }
                curr = curr.next;
            }
            return dummy.next;
        }
        public static string ReverseWords(string s)
        {
            var newS = s.Split(" ");
            for (int i = 0; i < newS.Length; i++)
            {
                newS[i] = new string(newS[i].Reverse().ToArray());
            }
            return string.Join(" ", newS);
        }
        public static string ReverseStr(string s, int k)
        {
            var newWord = new StringBuilder();
            for (int i = 0; i < s.Length; i += 2 * k)
            {
                int reverseLength = Math.Min(k, s.Length - i);

                newWord.Append(new string(s.Substring(i, reverseLength).Reverse().ToArray()));

                if (i + k < s.Length)
                {
                    int nextPartLength = Math.Min(k, s.Length - i - k);
                    newWord.Append(s.Substring(i + k, nextPartLength));
                }
            }
            return newWord.ToString();

        }
        public static bool IsHappy(int n)
        {
            var seen = new HashSet<int>();
            while (n != 1 && !seen.Contains(n))
            {
                seen.Add(n);
                var x = 0;
                while (n > 0)
                {
                    var m = n % 10;
                    x += (m * m);
                    n /= 10;
                }
                n = x;
            }
            return n == 1;
        }
        public static bool IsIsomorphic(string s, string t)
        {
            // egg - add
            if (s.Length != t.Length) return false;

            var dic1 = new Dictionary<char, char>();
            var dic2 = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dic1.ContainsKey(s[i]))
                {
                    if (dic1[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    dic1.Add(s[i], t[i]);
                }

                if (dic2.ContainsKey(t[i]))
                {
                    if (dic2[t[i]] != s[i])
                    {
                        return false;
                    }
                }
                else
                {
                    dic2.Add(t[i], s[i]);
                }

            }
            return true;

        }
        public static int HammingWeight(int n)
        {
            var bits = Convert.ToString(n, 2);
            var ones = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '1') ones++;
            }
            return ones;
        }
        public static int SingleNumber(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, 1);
                }
                else
                {
                    dic[i] = dic[i] + 1;
                }
            }
            return dic.Where(x => x.Value == 1).FirstOrDefault().Value;
        }
        public static int MySqrt(int x)
        {
            int right = x;
            int left = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (mid * mid == x)
                {
                    return mid;
                }

                else if (mid * mid < x)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }


            }
            return right;
        }
        public static bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null) return root.val == targetSum;
            int sum = targetSum - root.val;
            return HasPathSum(root.left!, sum) || HasPathSum(root.right, sum);
        }
        public static int[] PlusOne(int[] digits)
        {
            var digit = BigInteger.Parse(string.Join("", digits));
            ++digit;
            int[] digitsPlus = digit.ToString().ToArray().Select(x => (int)char.GetNumericValue(x)).ToArray();
            return digitsPlus;
        }
        public static int ScoreOfString(string s)
        {
            int total = 0;
            for (int i = 1; i < s.Length; i++)
            {
                int a = s[i - 1];
                int b = s[i];
                total += Math.Abs(a - b);
            }
            return total;
        }
        static void GenerateBinaryNumbers(int N)
        {
            if (N <= 0)
            {
                Console.WriteLine("N should be a positive integer.");
                return;
            }

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("1");

            for (int i = 1; i <= N; i++)
            {
                string element = queue.Dequeue();

                Console.WriteLine(element);

                queue.Enqueue(element + "0");
                queue.Enqueue(element + '1');
            }
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
