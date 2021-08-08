using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SkinsExtender
{
    public sealed class SkinsExtenderManager
    {
        // Iterate through every custom xml file for extension.
        public static XmlDocument CreateExtendedXmlFile(XmlDocument toBeExtended, List<Tuple<string, string>> extensions)
        {
            XmlDocument xmlDocument = toBeExtended;
            for (int i = 0; i < extensions.Count; i++)
            {
                XmlDocument xmlDocument2 = CreateDocumentFromXmlFile(extensions[i].Item1);
                xmlDocument = ExtendXmls(xmlDocument, xmlDocument2);
            }
            return xmlDocument;
        }
        // Append the nodes from the custom xml file to the merged xml file.
        public static XmlDocument ExtendXmls(XmlDocument xmlDocument, XmlDocument xmlDocument2)
        {
            List<XmlNode> nodes = new List<XmlNode>();
            foreach (XmlNode node in xmlDocument2.SelectNodes("//skins/skin"))
            {
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    foreach (XmlNode node3 in node2.ChildNodes)
                    {
                        nodes.Add(node3);
                    }
                }
            }
            foreach (XmlNode node in nodes)
            {
                XmlElement element = (XmlElement)node.ParentNode.ParentNode;
                XmlNode targetNode = xmlDocument.SelectSingleNode("//skins/skin[@name='" + element.GetAttribute("name") + "']/" + node.ParentNode.Name);
                XmlNode importedNode = xmlDocument.ImportNode(node, true);
                targetNode.AppendChild(importedNode);
            }
            return xmlDocument;
        }
        // Load the custom xml file.
        private static XmlDocument CreateDocumentFromXmlFile(string xmlPath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            StreamReader streamReader = new StreamReader(xmlPath);
            string xml = streamReader.ReadToEnd();
            xmlDocument.LoadXml(xml);
            streamReader.Close();
            return xmlDocument;
        }
    }
}
