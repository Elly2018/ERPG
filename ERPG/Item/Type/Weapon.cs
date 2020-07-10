using ERPGCore;
using System;
using System.Xml;

namespace ERPG.Item
{
    public abstract class Weapon : ItemBase
    {
        /// <summary>
        /// Define upgrade level
        /// </summary>
        public int UpgradeLevel = 0;

        /// <summary>
        /// Get the original properties this weapon have
        /// </summary>
        /// <returns></returns>
        public abstract PropertiesList GetBasicWeaponProperties();

        /// <summary>
        /// Upgrade properties addition array size should be 20 <br />
        /// Define the amounts of change properties
        /// </summary>
        /// <returns></returns>
        public abstract PropertiesAdditionList[] GetUpgradeSet();

        /// <summary>
        /// Get after calculate properties list
        /// </summary>
        /// <returns></returns>
        public PropertiesList GetCurrentPropertiesList()
        {
            PropertiesList buffer = GetBasicWeaponProperties();
            buffer = GetUpgradeSet()[UpgradeLevel].Calculate(buffer);
            return buffer;
        }

        public override void LoadDataDatail(XmlNode root)
        {
            UpgradeLevel = Convert.ToInt32(root.SelectSingleNode("Upgrade").InnerText);
        }

        public override void SaveDataDatail(XmlDocument doc, XmlElement root)
        {
            XmlNode upgrade = doc.CreateElement("Upgrade");
            upgrade.InnerText = UpgradeLevel.ToString();
            root.AppendChild(upgrade);
        }
    }
}