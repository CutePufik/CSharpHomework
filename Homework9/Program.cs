using System;
using BinaryTrees;


public class myClass
{
    static void Main(string[] args)
    {
        //task 1
        // var bdp = new BinarySearchTree(1, 2, 3, 4, 5);
        // Console.WriteLine(bdp.Contains(5));
        // Console.WriteLine(bdp.Contains(-11));
        // bdp.Add(-11);
        // Console.WriteLine(bdp.Contains(-11));
        //
        // var tree = TreeUtils.GetSampleIntTree1();
        // TreeUtils.Prefix(tree);
        // Console.WriteLine();

//<<<<<<< HEAD    откуда
        var tree = TreeUtils.GetSampleIntTree1();
        TreeUtils.Prefix(tree);
        Console.WriteLine();

        // //task 3
        TreeNode<int> treenode = TreeUtils.GetSampleIntTree1();
        var copied = treenode.Copy();
        TreeUtils.Prefix(copied);
        Console.WriteLine(TreeNode<int>.IsEqual(treenode, copied));
        Console.WriteLine(treenode == copied); // сравнение по ссылке
        

        //task4
        Console.WriteLine(sumLeaves(TreeUtils.GetSampleIntTree1()));
        Console.WriteLine(sumLeaves(TreeUtils.GetSampleIntTree2()));
        Console.WriteLine(sumLeaves(TreeUtils.GetSampleIntTree3()));

        
        //task 5
        TreeNode<int> qwetree = new TreeNode<int>(1, new TreeNode<int>(2, new TreeNode<int>(4), new TreeNode<int>(5)), new TreeNode<int>(3,
            new TreeNode<int>(6),
            new TreeNode<int>(7)));
        Console.WriteLine(GetLevelWidth(qwetree, 2));
        
        TreeNode<int> qwetree2 = new TreeNode<int>(1, new TreeNode<int>(2, new TreeNode<int>(4), new TreeNode<int>(5)), new TreeNode<int>(3,
            new TreeNode<int>(6),
            new TreeNode<int>(7)));
        Console.WriteLine(GetLevelWidth(qwetree2, 3));

        //task6
        Console.WriteLine();
        TreeNode<int> intTree = new TreeNode<int>(data: 26, left: new TreeNode<int>(10, new
                TreeNode<int>(4), new TreeNode<int>(6)),
            right: new TreeNode<int>(3, null, new TreeNode<int>(3)));
        Console.WriteLine(isBinarySumTree(intTree));
        
        
       
//=======

        //task 8
        // var treemin = new BinarySearchTree(6, 1, 8, 3, 0, 3, 8, 1);
        // Console.WriteLine(treemin.Min());
        // Console.WriteLine(treemin.Max());
        
        //task 9
        // BinarySearchTree bst5 = new BinarySearchTree(5, 1, 7, 2, 8, 3, 9, 1, 0);
        // Console.WriteLine(bst5.GetMinSum(5));
        // Console.WriteLine(bst5.GetMinSum(2));
        //
        // var q = new BinarySearchTree(0, 3, 6, 1, 8, 5);
        // Console.WriteLine(q.GetMinSum(5));
        //
        // BinarySearchTree bst6 = new BinarySearchTree(0, 2, 1, 32, 6, 1, 100, -1, -2, 6);
        // Console.WriteLine(bst6.GetMinSum(5));
        // Console.WriteLine(bst6.GetMinSum(2));
        
        // task 10
        var v = new BinarySearchTree(1, 4, 6, 1, 8, 2, 7, 1, 9, 24);
        var p = v.ToSortedArray();
        foreach (var i in p)
        {
            Console.Write(i + " ");
        }
        
        
//>>>>>>> bst-upgrade      что это такое???
    }
    
    
        
    public static int sumLeaves(TreeNode<int> root)
    {
        if (root is null) return 0;
        if (root.Left is null && root.Right is null)
            return root.Data;
    
        return sumLeaves(root.Left) + sumLeaves(root.Right);
    }
    
    public static bool isBinarySumTree(TreeNode<int> root)
    {
        if (root == null || (root.Left == null && root.Right == null))
        {
            return true;
        }
        return (root.Data == sum(root.Left) + sum(root.Right)) && isBinarySumTree(root.Left) && isBinarySumTree(root.Right);
            
        int sum(TreeNode<int> node)
        {
            if (node == null)
            {
                return 0;
            }
            return sum(node.Left) + node.Data + sum(node.Right);
        }
    }
    
    public static int GetLevelWidth<T>(TreeNode<T> root, int level)
    {
        if (root == null || level < 0) 
        {
            return 0;
        }
        if (level == 0) 
        {
            return 1;
        }
        int leftWidth = GetLevelWidth(root.Left, level - 1);
        int rightWidth = GetLevelWidth(root.Right, level - 1);
        return leftWidth + rightWidth;
    }


}