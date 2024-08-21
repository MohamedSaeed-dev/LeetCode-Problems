
using LeetCode_Problems;


var x = LeetCode.Merge(new int[][] { [1, 3], [2, 6], [8, 10], [15, 18] });
foreach (int[] subArray in x)
{
    Console.WriteLine(string.Join(", ", subArray));
}