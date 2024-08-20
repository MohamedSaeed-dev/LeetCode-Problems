using System.Numerics;
using System.Text;

namespace LeetCode_Problems
{
    public class LeetCode
    {
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
        public static int[] TwoSums()
        {
            var nums = new int[] { 3, 2, 4 };
            var target = 6;

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
        public bool HasPathSum(TreeNode root, int targetSum)
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
