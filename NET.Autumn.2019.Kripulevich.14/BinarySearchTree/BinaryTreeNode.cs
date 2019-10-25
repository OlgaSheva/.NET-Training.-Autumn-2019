using System;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary tree node.
    /// </summary>
    public class BinaryTreeNode<TNode>
    {
        private readonly BinaryTreeNode<TNode> parent;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public TNode Value { get; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>
        /// The left.
        /// </value>
        public BinaryTreeNode<TNode> Left { get; set; }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        /// <value>
        /// The right.
        /// </value>
        public BinaryTreeNode<TNode> Right { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parent">The parent.</param>
        public BinaryTreeNode(TNode value, BinaryTreeNode<TNode> parent = null)
        {
            Value = value;
            this.parent = parent;
        }
    }
}
