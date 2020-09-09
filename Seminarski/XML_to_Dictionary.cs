using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


namespace Seminarski
{
    public static class XMLExtend
    {
        public static string GetXPath_UsingPreviousSiblings(this XElement element)
        {
            string path = "/" + element.Name;

            XElement parentElement = element.Parent as XElement;
            if (parentElement != null)
            {
                // Gets the position within the parent element, based on previous siblings of the same name.
                // However, this position is irrelevant if the element is unique under its parent:
                XPathNavigator navigator = parentElement.CreateNavigator();

                // Climbing up to the parent elements:
                path = parentElement.GetXPath_UsingPreviousSiblings() + path;
            }

            return path;
        }
    }
    class XML_to_Dictionary : XML
    {
       

        void XML.Pretvori()
        {
           

            Dictionary<string, int> nodes = new Dictionary<string, int>();
            XDocument doc = XDocument.Load(@"..\..\gradovi.xml");

            List<string> list = new List<string>();

            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                XElement parentElement = element.Parent;
                if (!list.Contains(parentElement.Name.LocalName))
                {
                    list.Add(parentElement.Name.LocalName);
                }
            }

            foreach (var item in list)
            {
                XElement subxElement = doc.Descendants(item).FirstOrDefault();

                nodes.Add(subxElement.GetXPath_UsingPreviousSiblings(), doc.Descendants(item).Count());
                Console.WriteLine(subxElement);

            }

        }
    }
}
