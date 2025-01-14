﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// The binary tree.
    /// </summary>
    public class BinaryTree<T> : IEnumerable<T> //where T : IComparable<T>, IComparable
    {
        public int Count { get; private set; }
        public BinaryTreeNode<T> Root { get; private set; }

        private BinaryTreeNode<T> current;
        private IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        public BinaryTree()
        {
            this.comparer = Comparer<T>.Default;
            Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="System.ArgumentNullException">comparer</exception>
        public BinaryTree(IComparer<T> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException($"The {nameof(comparer)} cannot be null.");
            }

            this.comparer = comparer;
            Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public BinaryTree(IEnumerable<T> source) : this(source, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="System.ArgumentNullException">
        /// source
        /// or
        /// comparer
        /// </exception>
        public BinaryTree(IEnumerable<T> source, IComparer<T> comparer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            if (comparer is null)
            {
                throw new ArgumentNullException($"The {nameof(comparer)} cannot be null.");
            }

            this.comparer = comparer;

            foreach (var item in source)
            {
                AddNode(item);
            }
        }

        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="data">The data.</param>
        public void AddNode(T data)
        {
            if (current == null)
            {
                Root = new BinaryTreeNode<T>(data);
                current = Root;
            }
            else
            {
                AddChild(current, data);
            }

            Count++;
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T value)
        {
            return FindWithParent(value, out BinaryTreeNode<T> parent) != null;
        }

        /// <summary>
        /// A in-order traversal iterator.
        /// </summary>
        /// <returns>Collection of elements of the <see cref="BinaryTree{T}"/></returns>
        public IEnumerator<T> InOrderTraversal()
        {
            if (Root == null)
            {
                yield break;
            }

            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = Root;

            bool goLeftNext = true;

            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
            
        }

        /// <summary>
        /// The pre-order traversal iterator.
        /// </summary>
        /// <returns>Collection of elements of the <see cref="BinaryTree{T}"/></returns>
        public IEnumerator<T> PreOrderTraversal()
        {
            if (Root == null)
            {
                yield break;
            }

            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = Root;
            
            stack.Push(current);

            while (stack.Count > 0)
            {
                current = stack.Pop();

                yield return current.Value;

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
        }

        /// <summary>
        /// The post-order traversal iterator.
        /// </summary>
        /// <returns>Collection of elements of the <see cref="BinaryTree{T}"/></returns>
        public IEnumerator<T> PostOrderTraversal()
        {
            if (Root == null)
            {
                yield break;
            }

            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = Root;
            bool goRightNext = true;

            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goRightNext)
                {
                    while (current.Right != null)
                    {
                        stack.Push(current);
                        current = current.Right;
                    }
                }

                yield return current.Value;

                if (current.Left != null)
                {
                    current = current.Left;
                    goRightNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goRightNext = false;
                }
            }
        }

        /// <summary>
		/// Deletes a value from the Binary Tree, if it exists.
		/// </summary>
		/// <param name="value">The value to delete.</param>
        public void Delete(T value)
        {
            BinaryTreeNode<T> nodeToDelete = null;
            BinaryTreeNode<T> currentParent = null;

            // Find the node to delete.
            var currentNode = this.Root;
            while (currentNode != null && nodeToDelete == null)
            {
                if (comparer.Compare(currentNode.Value, value) == 0)
                {
                    nodeToDelete = currentNode;
                }
                else
                {
                    currentParent = currentNode;
                    currentNode = comparer.Compare(value, currentNode.Value) < 0 ? currentNode.Left : currentNode.Right;
                }
            }

            if (nodeToDelete == null)
            {
                throw new InvalidOperationException("Couldn't find the node in the tree.");
            }

            // Now that the node has been found, do the deletion.
            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                DeleteLeafNode(nodeToDelete, currentParent);
            }
            else if (nodeToDelete.Left == null || nodeToDelete.Right == null)
            {
                DeleteNodeWithOneChild(nodeToDelete, currentParent);
            }
            else
            {
                DeleteNodeWithTwoChildren(nodeToDelete, currentParent);
            }

            Count--;
        }

        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrderTraversal();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Private methods

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = Root;
            parent = null;

            while (current != null)
            {
                int result = comparer.Compare(current.Value, value);// current.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void AddChild(BinaryTreeNode<T> node, T value)
        {
            if (comparer.Compare(value, node.Value) == 0)
            {
                throw new InvalidOperationException("Cannot insert node into tree. Value already exists.");
            }

            if (comparer.Compare(value, node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddChild(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddChild(node.Right, value);
                }
            }
        }

        private void DeleteLeafNode(BinaryTreeNode<T> nodeToDelete, BinaryTreeNode<T> nodeToDeleteParent)
        {
            if (nodeToDeleteParent == null)
            {
                // Deleting the root.
                this.Root = null;
            }
            else if (IsLeftChild(nodeToDeleteParent, nodeToDelete))
            {
                nodeToDeleteParent.Left = null;
            }
            else
            {
                nodeToDeleteParent.Right = null;
            }
        }

        private void DeleteNodeWithOneChild(BinaryTreeNode<T> nodeToDelete, BinaryTreeNode<T> nodeToDeleteParent)
        {
            var childNode = nodeToDelete.Left ?? nodeToDelete.Right;

            if (nodeToDeleteParent == null)
            {
                // Deleting the root.
                this.Root = childNode;
            }
            else if (IsLeftChild(nodeToDeleteParent, nodeToDelete))
            {
                nodeToDeleteParent.Left = childNode;
            }
            else
            {
                nodeToDeleteParent.Right = childNode;
            }
        }

        private void DeleteNodeWithTwoChildren(BinaryTreeNode<T> nodeToDelete, BinaryTreeNode<T> nodeToDeleteParent)
        {
            var replacementNode = MinimumChild(nodeToDelete.Right) ?? nodeToDelete.Right;

            // Reassign children to replacement node, avoiding any circular references.
            replacementNode.Right = (replacementNode != nodeToDelete.Right) ?
                nodeToDelete.Right : null;
            replacementNode.Left = (replacementNode != nodeToDelete.Left) ?
                nodeToDelete.Left : null;

            if (nodeToDeleteParent == null)
            {
                // Deleting the root.
                this.Root = replacementNode;
            }
            else if (IsLeftChild(nodeToDeleteParent, nodeToDelete))
            {
                nodeToDeleteParent.Left = replacementNode;
            }
            else
            {
                nodeToDeleteParent.Right = replacementNode;
            }
        }

        // Returns minimum-valued node under the given node,
        // and then removes the reference to that node. Useful for node deletion.
        private BinaryTreeNode<T> MinimumChild(BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> next = null;
            BinaryTreeNode<T> parent = null;

            while (node != null)
            {
                if (node.Left != null)
                {
                    parent = node;
                    next = node.Left;
                }
                node = node.Left;
            }

            if (parent != null)
            {
                parent.Left = null;
            }

            return next;
        }

        private bool IsLeftChild(BinaryTreeNode<T> parent, BinaryTreeNode<T> child)
        {
            return parent.Left != null && (comparer.Compare(parent.Left.Value, child.Value) == 0);
        }

        #endregion
    }
}
