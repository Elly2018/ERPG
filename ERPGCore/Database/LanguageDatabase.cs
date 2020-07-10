using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ERPGCore
{
    /// <summary>
    /// Contain one language struct <br />
    /// Have categories, labels <br />
    /// User need to input the right keyword poition to get the string data
    /// </summary>
    [System.Serializable]
    public class LanguageDatabase : DatabaseBase<Category>
    {
        public string GetLanguagePath(string tag)
        {
            if (!Directory.Exists("language")) Directory.CreateDirectory("language");
            return $"language/{tag}.xml";
        }

        /// <summary>
        /// Loop list get target label instance
        /// </summary>
        /// <param name="keyword">Key</param>
        /// <returns></returns>
        public Category GetCategory(string keyword)
        {
            foreach (var i in value.Elements)
                if (i.key == keyword) return i;
            return null;
        }

        /// <summary>
        /// Getter action
        /// </summary>
        /// <param name="category">Category keyword</param>
        /// <param name="label">Label keyword</param>
        /// <returns></returns>
        public string GetStringData(string category, string label)
        {
            Category c = GetCategory(category);
            if (c == null) return null;
            Label l = c.GetLabel(label);
            if (l == null) return null;
            return l.value;
        }

        /// <summary>
        /// Loading xml file
        /// </summary>
        /// <param name="path"></param>
        public override void Load(string path)
        {
            Logger.Log("Language", "Log", "Loading at: " + path);

            if (!File.Exists(path)) return;
            value = new DatabaseElement<Category>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList root = doc.ChildNodes.Item(0).ChildNodes;
            foreach(var i in root)
            {
                string cate = ((XmlNode)i).Name;
                Category c = new Category();
                c.key = cate;
                c.labels = new List<Label>();
                value.Elements.Add(c);

                foreach(var j in ((XmlNode)i).ChildNodes)
                {
                    string lab = ((XmlNode)j).Name;
                    Label l = new Label();
                    l.key = lab;
                    l.value = ((XmlNode)j).InnerText;
                    c.labels.Add(l);
                }
            }
        }

        /// <summary>
        /// Saving to xml file
        /// </summary>
        /// <param name="path"></param>
        public override void Save(string path)
        {
            Logger.Log("Language", "Log", "Writing at: " + path);

            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            foreach(var i in value.Elements)
            {
                XmlElement cate = doc.CreateElement(i.key);
                root.AppendChild(cate);
                foreach(var j in i.labels)
                {
                    XmlElement lab = doc.CreateElement(j.key);
                    lab.InnerText = j.value;
                    cate.AppendChild(lab);
                }
            }
            doc.Save(path);
        }

        /// <summary>
        /// Create empty xml file
        /// </summary>
        /// <param name="path"></param>
        public void CreateNew(string path)
        {

        }
    }
}