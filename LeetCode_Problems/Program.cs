
using LeetCode_Problems;
using static LeetCode_Problems.LeetCode;

var x = Construct2DArray(new int[] { 1, 2 }, 1,1);
foreach (int[] i in x)
{
    foreach (int j in i)
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
}