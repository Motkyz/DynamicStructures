using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructures
{
    public class TreeNode
    {
        public object Data;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(object data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
    class TreeTraversal
    {
        public static string DirectPrint(TreeNode root) //Прямой обход дерева
        {
            if (root == null)
            {
                return "* ";
            }
            return root.Data + " " + DirectPrint(root.Left) + DirectPrint(root.Right);
        }

        public static string SymmetricalPrint(TreeNode root) //Симметричный обход дерева
        {
            if (root == null)
            {
                return "* ";
            }
            return SymmetricalPrint(root.Left) + root.Data + " " + SymmetricalPrint(root.Right);
        }

        public static string ReversePrint(TreeNode root) //Обратный обход дерева
        {
            if (root == null)
            {
                return "* ";
            }
            return ReversePrint(root.Left) + ReversePrint(root.Right) + root.Data + " ";
        }
    }
}
