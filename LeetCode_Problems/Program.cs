
using LeetCode_Problems;


var x = LeetCode.Merge(new int[][] { [1, 3], [2, 6], [8, 10], [15, 18] });
for (int i = 0; i < x.GetUpperBound(0); i++)
{
    for (int j = 0; j < x.GetUpperBound(1); j++)
    {
        Console.Write(x[i][j]+",");
    }
    Console.WriteLine();
}