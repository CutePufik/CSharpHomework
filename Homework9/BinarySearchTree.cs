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
    
    
    public int Min()
    {
        var min = Int32.MaxValue;
        var node = root;
        while (node != null)
        {
            min = Math.Min(min, node.Data);
            node = min <= node.Data ? node.Left : node.Right;
        }
        return min;
    }
    
    public int Max()
    {
        var max = Int32.MinValue;
        var node = root;
        while (node != null)
        {
            max = Math.Max(max, node.Data);
            node = max < node.Data ? node.Left : node.Right;
        }

        return max;
    }
    
    
    public int GetMinSum(int n)
    {
        try    // я считаю,это гениально (нет)
        {
            var minValues = new List<int>();

            values(root);

            return minValues.Take(n).Sum();
        
            void values(TreeNode<int> r)
            {
                if (r == null)
                    return;
                values(r.Left);
                minValues.Add(r.Data);
                values(r.Right);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public int[] ToSortedArray()
    {
        List<int> result = new List<int>();
        addArray(root);
        return result.ToArray();
        void addArray(TreeNode<int> node)
        {
            if (node != null)
            {
                addArray(node.Left);
                result.Add(node.Data);
                addArray(node.Right);
            }
        }
    }
    
    
    
    
    
    
   
}