using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Part2
{
    internal class Task1
    {
        public static void Main()
        {
            int?[] arr = new int?[] { 3, 9, 20, null, null, 15, 7 };
            TreeNode root = BuildTree(arr);
            int depth = MaxDepth(root);
            Console.WriteLine("Глубина дерева: " + depth);
        }

        static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        static TreeNode BuildTree(int?[] arr)
        {
            if (arr == null || arr.Length == 0) return null;

            TreeNode root = new TreeNode(arr[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (i < arr.Length)
            {
                TreeNode current = queue.Dequeue();

                if (arr[i] != null)
                {
                    current.left = new TreeNode(arr[i].Value);
                    queue.Enqueue(current.left);
                }

                i++;

                if (i >= arr.Length) break;

                if (arr[i] != null)
                {
                    current.right = new TreeNode(arr[i].Value);
                    queue.Enqueue(current.right);
                }

                i++;
            }

            return root;
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

}
