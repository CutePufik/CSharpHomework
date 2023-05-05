using BinaryTrees;
using NUnit.Framework.Internal;

namespace TestHomework9;

public class Tests
{
     
    [Test]
    public void TestCopy()
    {
        var tree = new TreeNode<int>(1,new TreeNode<int>(3,new TreeNode<int>(4)),new TreeNode<int>(5,new TreeNode<int>(10)));
        var copyTree = tree.Copy();
        Assert.That(TreeNode<int>.IsEqual(tree,copyTree));
    }
    
    
    [Test]
    public void TestLeafSum1()
    {
        var tree = new TreeNode<int>(10, new TreeNode<int>(5, new TreeNode<int>(1), new TreeNode<int>(3)),
            new TreeNode<int>(20,
                null,
                new TreeNode<int>(30,
                    new TreeNode<int>(15),
                    new TreeNode<int>(25))));
    
        Assert.That(myClass.sumLeaves(tree), Is.EqualTo(44));
    }
    
    [Test]
    public void TestLeafSum2()
    {
        var tree = new TreeNode<int>(10);
        Assert.That(myClass.sumLeaves(tree), Is.EqualTo(10));
    }
    
    [Test]
    public void TestLeafSum3()
    {
        TreeNode<int> tree = null;
        Assert.That(myClass.sumLeaves(tree), Is.EqualTo(0));
    }
    
    
    [Test]
    public void TestisBinarySumTree1()
    {
        TreeNode<int> root = new TreeNode<int>(30,new TreeNode<int>(10),new TreeNode<int>(20));
        Assert.IsTrue(myClass.isBinarySumTree(root));
    }
    
    [Test]
    public void TestisBinarySumTree2()
    {
        TreeNode<int> root = new TreeNode<int>(30);
        root.Left = new TreeNode<int>(10);
        root.Right = new TreeNode<int>(10);
        root.Right.Left = new TreeNode<int>(5);
        root.Right.Right = new TreeNode<int>(5);
        Assert.IsTrue(myClass.isBinarySumTree(root));
    }
    
    [Test]
    public void TestisBinarySumTree3()
    {
        TreeNode<int> root = new TreeNode<int>(10,new TreeNode<int>(5,new TreeNode<int>(3)),new TreeNode<int>(5,null,new TreeNode<int>(5)));
        Assert.IsFalse(myClass.isBinarySumTree(root));
    }

    
    [Test]
    public void TestLevelWidth()
    {
        TreeNode<int> qwetree = new TreeNode<int>(1, new TreeNode<int>(2, new TreeNode<int>(4), new TreeNode<int>(5)), new TreeNode<int>(3,
            new TreeNode<int>(6),
            new TreeNode<int>(7)));
        Assert.That(myClass.GetLevelWidth(qwetree,2),Is.EqualTo(4));
    }    
    
    [Test]
    public void TestLevelWidth1()
    {
        TreeNode<int> qwetree = new TreeNode<int>(1, new TreeNode<int>(2, new TreeNode<int>(4), new TreeNode<int>(5)), new TreeNode<int>(3,
            new TreeNode<int>(6),
            new TreeNode<int>(7)));
        Assert.That(myClass.GetLevelWidth(qwetree,3),Is.EqualTo(0));
    }
    [Test]
    public void TestMax1()
    {
        var treemin = new BinarySearchTree(6, 1, 8, 3, 0, 3, 8, 1);
        Assert.That(treemin.Max(),Is.EqualTo(8));
    }
    [Test]
    public void TestMax2()
    {
        
        var treemin = new BinarySearchTree(0,-1,5,1,8,2,19);
        Assert.That(treemin.Max(),Is.EqualTo(19));
    }

    [Test]
    public void TestMin1()
    {
        var treemin = new BinarySearchTree(6, 1, 8, 3, 0, 3, 8, 1);
        Assert.That(treemin.Min(),Is.EqualTo(0));
    }
    [Test]
    public void TestMin2()
    {
        var treemin = new BinarySearchTree(0,-1,5,1,8,2,19);
        Assert.That(treemin.Min(),Is.EqualTo(-1));
    }


    [Test]
    public void getMinSum()   // тут два теста :)
    {
        BinarySearchTree bst6 = new BinarySearchTree(0, 2, 1, 32, 6, 1, 100, -1, -2, 6);
        Assert.That(bst6.GetMinSum(5),Is.EqualTo(-1));
        Assert.That(bst6.GetMinSum(2),Is.EqualTo(-3));
        
    }

    [Test]
    public void getSortedArray()
    {
        var v = new BinarySearchTree(1, 4, 6, 1, 8, 2, 7, 1, 9, 24);
        var array = new int[] { 1,1,1,2,4,6,7,8,9,24};
        Assert.That(v.ToSortedArray(),Is.EqualTo(array));
    }
    
    
}