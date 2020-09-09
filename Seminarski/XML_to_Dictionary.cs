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
   
    class XML_to_Dictionary : XML
    {
       

        void XML.Pretvori()
        {


            var doc = XDocument.Load(@"..\..\gradovi.xml");
            var rootNodes = doc.Root.DescendantNodes().OfType<XElement>();
            var keyValuePairs = from n in rootNodes
                                select new
                                {
                                    TagName = n.Name,
                                    TagValue = n.Value
                                };

            Dictionary<string, string> allItems = new Dictionary<string, string>();
            foreach (var token in keyValuePairs)
            {
                allItems.Add(token.TagName.ToString(), token.TagValue.ToString());
            }
            allItems.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);

        }

    }
    
}
