using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarski
{
    class Pretvarac
    {
        private XML xml_to_dictionary;

        public Pretvarac()
        {
            xml_to_dictionary = new XML_to_Dictionary();
        }
        public void Pretvori_XML_To_Dictionary()
        {
            xml_to_dictionary.Pretvori();
        }
    }

}
