namespace BinaryTrees;

public class BinarySearchTree
{
    private TreeNode<int> root;

    public void Add(int x)
    {
        if (root == null)
        {
            root = new TreeNode<int>(x);
            return;
        }
        add(root);

        void add(TreeNode<int> node)
        {
            if (x < node.Data)
            {
                if (node.Left == null)
                    node.Left = new TreeNode<int>(x);
                else
                    add(node.Left);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new TreeNode<int>(x);
                else
                    add(node.Right);
            }
        }
    }



    public BinarySearchTree(params int[] arr)
    {
        foreach (var number in arr)
        {
            Add(number);
        }
    }
    
  
    
    public bool Contains(int x)
    {
        var currentNode = root;
        while (currentNode != null)
        {
            if (x == currentNode.Data)
                return true;
            currentNode = x < currentNode.Data ? currentNode.Left : currentNode.Right;
        }
        
        return false;
    }

    
   
    
    public void PrintTreeInfix<T>()
    {
        TreeUtils.Infix(root);
    }
    
    public void PrintTreePrefix<T>()
    {
        TreeUtils.Prefix(root);
    }
    
    public void PrintTreePostfix<T>()
    {
        TreeUtils.Postfix(root);
    }
    
    
    
    
    
    
   
}