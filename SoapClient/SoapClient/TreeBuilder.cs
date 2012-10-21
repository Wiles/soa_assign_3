/// TreeBuilder.cs
/// Thomas Kempton 2012
///

namespace SoapClient
{
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Helper class for building a tree view.
    /// </summary>
    public static class TreeBuilder
    {
        /// <summary>
        /// Builds the tree view.
        /// </summary>
        /// <param name="soap">The SOAP response.</param>
        public static TreeNode BuildTreeView(string soap)
        {
            var xml = new XmlDocument();
            var bytes = Encoding.ASCII.GetBytes(soap);
            using (var mem = new MemoryStream(bytes))
            {
                xml.Load(mem);
            }

            var tree = new TreeNode("Response");
            var envelope = xml.LastChild.LastChild;

            AddTreeNode(tree, envelope.FirstChild);

            return tree;
        }

        /// <summary>
        /// Adds the tree node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="text">The text.</param>
        private static void AddTreeNode(TreeNode node, XmlNode xml)
        {
            TreeNode n;
            if (xml.NodeType == XmlNodeType.Text)
            {
                n = node.Nodes.Add(
                        string.Format(xml.Value));
            }
            else
            {
                n = node.Nodes.Add(xml.Name);
            }

            if (xml.HasChildNodes)
            {
                foreach (var child in xml.ChildNodes)
                {
                    // recursion!
                    AddTreeNode(n, child as XmlNode);
                }
            }
        }
    }
}
