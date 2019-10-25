using System;
using System.Collections.Generic;
using BinarySearchTree;

namespace BinarySearchTreeCA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example 1:");
            var nodeData = new[] { 5, 4, 9, 3, 8, 15, 1, 6, 10, 7 };
            var tree = new BinaryTree<int>();
            foreach (var data in nodeData)
            {
                tree.AddNode(data);
            }
            tree.Root.Print();

            Console.WriteLine("inorder: ");
            foreach (var item in tree)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\npreorder: ");
            var e = tree.PreOrderTraversal();
            while (e.MoveNext())
            {
                Console.Write(e.Current + " ");
            }

            Console.WriteLine("\npostorder: ");
            e = tree.PostOrderTraversal();
            while (e.MoveNext())
            {
                Console.Write(e.Current + " ");
            }

            Console.WriteLine("\nExample 2:");
            nodeData = new[] { 5, 4, 15, 3, 8, 30, -30, 0, 1, 2 };
            tree = new BinaryTree<int>();
            foreach (var data in nodeData)
            {
                tree.AddNode(data);
            }
            tree.Root.Print();

            Console.WriteLine("inorder: ");
            foreach (var item in tree)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\npreorder: ");
            e = tree.PreOrderTraversal();
            while (e.MoveNext())
            {
                Console.Write(e.Current + " ");
            }

            Console.WriteLine("\npostorder: ");
            e = tree.PostOrderTraversal();
            while (e.MoveNext())
            {
                Console.Write(e.Current + " ");
            }

            Console.ReadKey();
        }
    }

    public static class BinaryTreePrinter
    {
        class NodeInfo<T> where T : IComparable<T>
        {
            public BinaryTreeNode<T> Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo<T> Parent, Left, Right;
        }

        public static void Print<T>(this BinaryTreeNode<T> root, int topMargin = 0, int leftMargin = 1) where T : IComparable<T>
        {
            if (root == null) { return; }
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo<T>>();
            var next = root;

            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo<T> { Node = next, Text = next.Value.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print<T>(NodeInfo<T> item, int top) where T : IComparable<T>
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
            {
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            }
            if (item.Right != null)
            {
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
            }
        }

        private static void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            int r = right;
            if (r < 0) { r = left + s.Length; }
            while (Console.CursorLeft < r) { Console.Write(s); }
        }

        private static void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    }
}
