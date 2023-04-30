using System;
using BinaryTrees;


public class myClass
{

    static void Main(string[] args)
    {
        //task 1
        var bdp = new BinarySearchTree(1, 2, 3, 4, 5);
        Console.WriteLine(bdp.Contains(5));
        Console.WriteLine(bdp.Contains(-11));
        bdp.Add(-11);
        Console.WriteLine(bdp.Contains(-11));
        
        var tree = TreeUtils.GetSampleIntTree1();
        TreeUtils.Prefix(tree);
        Console.WriteLine();
        
        
    }
    
    
    
    
    
    
}