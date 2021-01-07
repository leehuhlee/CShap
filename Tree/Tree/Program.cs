using System;
using System.Collections.Generic;

namespace Tree
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    class Program
    {
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 Development" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "Design" };
                    node.Children.Add(new TreeNode<string>() { Data = "Battle" });
                    node.Children.Add(new TreeNode<string>() { Data = "Business" });
                    node.Children.Add(new TreeNode<string>() { Data = "Story" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "Programming" };
                    node.Children.Add(new TreeNode<string>() { Data = "Server" });
                    node.Children.Add(new TreeNode<string>() { Data = "Client" });
                    node.Children.Add(new TreeNode<string>() { Data = "Engine" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "Art" };
                    node.Children.Add(new TreeNode<string>() { Data = "Background" });
                    node.Children.Add(new TreeNode<string>() { Data = "Character" });
                    root.Children.Add(node);
                }
            }
            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            //Access
            Console.WriteLine(root.Data);

            foreach (TreeNode<string> child in root.Children)
                PrintTree(child);
        }

        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;
            
            foreach (TreeNode<string> child in root.Children)
            {
                int newHeight = GetHeight(child) + 1;
                height = Math.Max(height, newHeight);
            }

            return height;
        }

        static void Main(string[] args)
        {
            TreeNode<string> root = MakeTree();

            PrintTree(root);

            Console.WriteLine(GetHeight(root));
        }
    }
}
