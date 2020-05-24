using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.AlgoExpert.Medium
{
    class BSTConstruction
    {
        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }

            public BST Insert(int value)
            {
                // Write your code here.
                // Do not edit the return statement of this method.
                if(value < this.value)
                {
                    if (left == null)
                    {
                        BST node = new BST(value);
                        left = node;
                    }
                    else
                        left.Insert(value);
                }
                else
                {
                    if (right == null)
                    {
                        BST node = new BST(value);
                        right = node;
                    }
                    else
                        right.Insert(value);
                }
                return this;
            }

            //Average: O(log(n)) time | O(log(n)) space
            //Worst: O(n) time | O(n) space
            public bool Contains(int value)
            {
                // Write your code here.
                if (value < this.value)
                {
                    if (left == null)
                        return false;
                    else
                        return left.Contains(value);
                }
                else if (value > this.value)
                {
                    if (right == null)
                        return false;
                    return right.Contains(value);
                }
                else
                    return true; 
            }

            public void Remove(int value, BST parent = null)
            {
                // Write your code here.
                // Do not edit the return statement of this method.
                if(value < this.value)
                {
                    if (left != null)
                        left.Remove(value, this);                    
                }
                else if(value > this.value)
                {
                    if (right != null)
                        right.Remove(value, this);
                }
                //we have found the node to delete, now handle all the special cases
                else
                {
                    if(left!=null && right!=null)
                    {
                        this.value = right.GetMinValue();
                        right.Remove(this.value, this);
                    }
                    //Deleting the root node
                    else if(parent == null)
                    {
                        if(left!=null)
                        {
                            this.value = left.value;
                            left = left.left;
                            right = left.right;                            
                        }
                        else if(right!=null)
                        {
                            this.value = right.value;
                            left = right.left;
                            right = right.right;
                        }
                        //this means we are removing the head
                        else
                        {
                            value = 0;
                        }
                    }
                    //Deleting a left leaf node
                    else if(parent.left == this)
                    {
                        parent.left = left != null ? left : right;
                    }
                    //Deleting a right leaf node
                    else if(parent.right == this)
                    {
                        parent.right = left != null ? left : right;
                    }
                }                
            }

            private int GetMinValue()
            {
                if (left == null)
                    return this.value;
                else
                    return left.GetMinValue();
            }

            /*public static void Main(string[] args)
            {
                BST bst = new BST(10);
                bst.Insert(7);
                bst.Insert(2);
                bst.Insert(8);
                bst.Insert(15);
                bst.Insert(12);
                bst.Insert(20);
                bst.Remove(10, null);
                Console.WriteLine(bst.Contains(15));
                Console.Read();
            }*/
        }
    }
}
