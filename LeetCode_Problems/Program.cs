
using LeetCode_Problems;
using static LeetCode_Problems.LeetCode;

var root = new TreeNode(1);
root.left = new TreeNode(3);
root.left.left = new TreeNode(3);
root.right = new TreeNode(2);

var x = PostorderTraversal(root);
foreach (var item in x)
{
    Console.WriteLine(item + " ");
}