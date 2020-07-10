using ERPGCore;
using System;
using System.Xml;

namespace ERPG.Item
{
    public class WoodenShield : Equip
    {
        public override SearchTerm Description()
        {
            throw new NotImplementedException();
        }

        public override string GetIconPath()
        {
            throw new NotImplementedException();
        }

        public override void LoadDataDatail(XmlNode root)
        {
            throw new NotImplementedException();
        }

        public override void SaveDataDatail(XmlDocument doc, XmlElement root)
        {
            throw new NotImplementedException();
        }

        public override Tuple<SearchTerm, int>[] UseLimit()
        {
            throw new NotImplementedException();
        }
    }
}
