using System;
using System.Collections.Generic;

/*
 * Problem Description:
 * Given a Binary Tree(complete/incomplete), implement a function which takes in a pointer to the root node of the tree
 * and marks the next right neighbor of the node at each level.
 * If there is no neighbor to the node, it should be marked as null by default.
*/
namespace Problems
{
    //Node class representing a node in the Binary tree
    public class Node
    {
        public char Val { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        //Represents Neighbor to the Node's right 
        public Node Neighbor { get; set; }

        public Node(char data)
        {
            Val = data;
            Left = Right = Neighbor = null;
        }

    }

    //Binary Tree to instantiate and use the "Node" class
    public class BinaryTree
    {
        private Node Root { get; set; }

        public BinaryTree(Node root)
        {
            if (root == null)
                throw new ArgumentNullException("A root node is needed to initialize the tree!");
            Root = root;
        }      

        //Function uses 'modified' BFS Traversal of Tree
        //First visit or mark neighbor
        //Then Enqueue the left node if present, and the right node
        //If after the above operation, there are nodes present in the queue,
        //that means we have covered the current level. So move on to the next level
        //Time complexity = O(n) where n = number of nodes in the tree
        //Space complexity = O(n) for tree + O(n) for queue = O(n)
        public void ConnectNeighbor(Node root)
        {
            //Use a queue to maintain nodes on the same level
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);

            //'null' here marks end of current level. Can also be a "special" node instead of null
            nodes.Enqueue(null);

            while(nodes.Count!=0)
            {
                //First retrieve the node and then remove it from the queue to be processed
                Node node = nodes.Peek();
                nodes.Dequeue();

                if (node != null)
                {
                    //Next element in queue = neighbor at current level
                    node.Neighbor = nodes.Peek();

                    //If there are left and right children, push them to the queue
                    if (node.Left != null)
                    {
                        nodes.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        nodes.Enqueue(node.Right);
                    }
                }
                //If there are nodes in the queue, that means we are done with the current level
                //move on to the next level
                else if (nodes.Count != 0)
                    nodes.Enqueue(null);
            }
        }
    }

    public class TreeNeighborSolution
    {
        /*public static void Main()
        {
            char termination = '.';
            Node root = null;
            BinaryTree binaryTree = null;

            Console.WriteLine("---------------");
            Console.WriteLine("Begin Example 1");
            Console.WriteLine("---------------");

            #region Example1 */
            /*Example 1
              Binary Tree Structure
                     A  
                    / \  
                   B   C 
                  /   / \  
                 D   E   F  
                /   /     \
               G   H       I
            */

            /*Example 2
            Binary Tree Structure
                   A  
                  / \  
                 B   C 
                /   / \  
               D   E   F  
              /         \
             G           I
          */

            /*
            root = new Node('A');           
            
            root.Left = new Node('B');
            root.Right = new Node('C');

            root.Left.Left = new Node('D');
            root.Left.Left.Left = new Node('G');

            root.Right.Left = new Node('E');
            root.Right.Left.Left = new Node('H');

            root.Right.Right = new Node('F');
            root.Right.Right.Right = new Node('I');

            binaryTree = new BinaryTree(root);

            binaryTree.ConnectNeighbor(root);

            Console.WriteLine("Tree structure after Neighbor's are populated in the tree ('.' is printed if there is no Neighbor)");
            Console.WriteLine("Neighbor of " + root.Val + " is " + ((root.Neighbor != null) ? root.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Left.Val + " is " + ((root.Left.Neighbor != null) ? root.Left.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Right.Val + " is " + ((root.Right.Neighbor != null) ? root.Right.Neighbor.Val : termination));

            Console.WriteLine("Neighbor of " + root.Left.Left.Val + " is " + ((root.Left.Left.Neighbor != null) ? root.Left.Left.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Right.Left.Val + " is " + ((root.Right.Left.Neighbor != null) ? root.Right.Left.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Right.Right.Val + " is " + ((root.Right.Right.Neighbor != null) ? root.Right.Right.Neighbor.Val : termination));

            Console.WriteLine("Neighbor of " + root.Left.Left.Left.Val + " is " + ((root.Left.Left.Left.Neighbor != null) ? root.Left.Left.Left.Neighbor.Val : termination));           
            Console.WriteLine("Neighbor of " + root.Right.Left.Left.Val + " is " + ((root.Right.Left.Left.Neighbor != null) ? root.Right.Left.Left.Neighbor.Val : termination));           
            Console.WriteLine("Neighbor of " + root.Right.Right.Right.Val + " is " + ((root.Right.Right.Right.Neighbor != null) ? root.Right.Right.Right.Neighbor.Val : termination));

            root = null;
            binaryTree = null;

            Console.WriteLine("---------------");
            Console.WriteLine(" End Example 1 ");
            Console.WriteLine("---------------");

            #endregion

            #region Example2
            /*Example 2
              Binary Tree Structure
                     A  
                    / \  
                   B   C 
                  /   / \  
                 D   E   F  
                /         \
               G           I
            */
            /*
            Console.WriteLine("---------------");
            Console.WriteLine("Begin Example 2");
            Console.WriteLine("---------------");

            root = new Node('A');

            root.Left = new Node('B');
            root.Right = new Node('C');

            root.Left.Left = new Node('D');
            root.Left.Left.Left = new Node('G');

            root.Right.Left = new Node('E');            

            root.Right.Right = new Node('F');
            root.Right.Right.Right = new Node('I');

            binaryTree = new BinaryTree(root);

            binaryTree.ConnectNeighbor(root);

            Console.WriteLine("Tree structure after Neighbor's are populated in the tree ('.' is printed if there is no Neighbor)");
            Console.WriteLine("Neighbor of " + root.Val + " is " + ((root.Neighbor != null) ? root.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Left.Val + " is " + ((root.Left.Neighbor != null) ? root.Left.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Right.Val + " is " + ((root.Right.Neighbor != null) ? root.Right.Neighbor.Val : termination));

            Console.WriteLine("Neighbor of " + root.Left.Left.Val + " is " + ((root.Left.Left.Neighbor != null) ? root.Left.Left.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Right.Left.Val + " is " + ((root.Right.Left.Neighbor != null) ? root.Right.Left.Neighbor.Val : termination));
            Console.WriteLine("Neighbor of " + root.Right.Right.Val + " is " + ((root.Right.Right.Neighbor != null) ? root.Right.Right.Neighbor.Val : termination));

            Console.WriteLine("Neighbor of " + root.Left.Left.Left.Val + " is " + ((root.Left.Left.Left.Neighbor != null) ? root.Left.Left.Left.Neighbor.Val : termination));            
            Console.WriteLine("Neighbor of " + root.Right.Right.Right.Val + " is " + ((root.Right.Right.Right.Neighbor != null) ? root.Right.Right.Right.Neighbor.Val : termination));

            root = null;
            binaryTree = null;

            Console.WriteLine("---------------");
            Console.WriteLine(" End Example 2 ");
            Console.WriteLine("---------------");
            #endregion
        }*/
    }
}
