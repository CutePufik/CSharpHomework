namespace BinaryTrees;

/// <summary>
/// Узел бинарного дерева
/// </summary>
public class TreeNode<T>
{
    /// <summary>
    /// Поле данных
    /// </summary>
    public T Data;

    /// <summary>
    /// Левое поддерево
    /// </summary>
    public TreeNode<T>? Left;

    /// <summary>
    /// Правое поддерево
    /// </summary>
    public TreeNode<T>? Right;

    /// <summary>
    /// Инициализирует узел бинарного дерева значением data поля данных
    /// и поддеревьями left, right
    /// </summary>
    /// <param name="data">Значение поля данных узла</param>
    /// <param name="left">Левое поддерево</param>
    /// <param name="right">Правое поддерево</param>
    public TreeNode(T data, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        Data = data;
        Left = left;
        Right = right;
    }
    
    
    public static bool IsEqual(TreeNode<int> node1, TreeNode<int> node2)
    {
        if (node1 == null && node2 == null)
        {
            return true;
        }
    
        if (node1 == null || node2 == null)
        {
            return false;
        }
    
        if (node1.Data != node2.Data)
        {
            return false;
        }
    
        return IsEqual(node1.Left, node2.Left) && IsEqual(node1.Right, node2.Right);
    }
}