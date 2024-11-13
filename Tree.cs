using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructures
{
    class Tree : TreeTraversal
    {
        public TreeNode root;
        public Tree(TreeNode root)
            { 
            this.root = root; 
        }

        public Tree()
        {
            root = new TreeNode("A");
            root.Left = new TreeNode("B");
            root.Left.Left = new TreeNode("D");
            root.Left.Left.Right = new TreeNode("G");
            root.Right = new TreeNode("C");
            root.Right.Left = new TreeNode("E");
            root.Right.Right = new TreeNode("F");
            root.Right.Right.Left = new TreeNode("H");
            root.Right.Right.Right = new TreeNode("J");
        }

    }
}
