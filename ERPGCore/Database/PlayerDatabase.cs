using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ERPGCore
{
    /// <summary>
    /// Manage player information <br />
    /// Use xml format
    /// Quest, Skill, Inventory, Cash, Position...
    /// </summary>
    public class PlayerDatabase : DatabaseBase<Player>
    {
        public const string DataPath = "data/player";

        /// <summary>
        /// Assembly that is contain customer ERPG object <br />
        /// Usually is from calling assembly
        /// </summary>
        private Assembly ass;
        private List<Tuple<Type, string>> propertiesBuffer;

        /// <summary>
        /// Get player data by player name
        /// </summary>
        /// <param name="id">Player name</param>
        /// <returns></returns>
        public Player GetPlayerByID(string id)
        {
            foreach(var i in this.value.Elements)
            {
                if (i.PlayerName == id) return i;
            }
            return null;
        }

        /// <summary>
        /// Saving current data into xml file
        /// </summary>
        /// <param name="path">File path</param>
        public override void Save(string path)
        {
            Logger.Log("Language", "Log", "Saving at: " + path);

            if (!Directory.Exists(path)) return;

            foreach (var i in value.Elements)
            {
                string fullpath = Path.Combine(path, i.PlayerName + ".xml");
                SavingPlayer(fullpath, i);
            }
        }

        /// <summary>
        /// Loading all player data from folder
        /// </summary>
        /// <param name="path">Directory type</param>
        public override void Load(string path)
        {
            ass = Assembly.GetCallingAssembly();
            LoadPropertiesTypes();
            Logger.Log("Language", "Log", "Loading at: " + path);

            if (!Directory.Exists(path)) return;
            value = new DatabaseElement<Player>();
            
            // Get all the file under player folder
            foreach(var i in Directory.GetFiles(path))
            {
                // If it's xml, then it can be read
                if(Path.GetExtension(i) == ".xml")
                {
                    Player playerBuffer = LoadingPlayer(i);
                    if (playerBuffer != null)
                    {
                        value.Elements.Add(playerBuffer);
                    }
                }
            }
        }

        #region Save
        /// <summary>
        /// The single player data save into file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="player">Player data</param>
        private void SavingPlayer(string path, Player player)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            root.SetAttribute("Type", player.Name.ToXmlString());
            doc.AppendChild(root);

            XmlElement propertiesListRoot = doc.CreateElement("PropertiesList");
            SavingPropertiesList(doc, propertiesListRoot, player.Properties);
            root.AppendChild(propertiesListRoot);

            XmlElement effectListRoot = doc.CreateElement("EffectList");
            SavingEffectList(doc, effectListRoot, player.Effects);
            root.AppendChild(effectListRoot);

            XmlElement position = doc.CreateElement("Position");
            SavingPlayerPosition(doc, position, player.CurrentPosition);
            root.AppendChild(position);

            XmlElement itemInventory = doc.CreateElement("ItemInventory");
            SavingItemInventory(doc, itemInventory, player.PlayerItemInventory);
            root.AppendChild(itemInventory);

            XmlElement classes = doc.CreateElement("Classes");
            SavingClasses(doc, classes, player.Classes);
            root.AppendChild(classes);

            doc.Save(path);
        }

        //
        #region Utility
        private void SavingPropertiesList(XmlDocument doc, XmlElement root, PropertiesList list)
        {
            foreach(var i in list)
            {
                // Type convert
                string text = null;
                if (i.GetType().IsSubclassOf(typeof(IntPropertiesBase)))
                {
                    text = ((IntPropertiesBase)i).int_value.ToString();
                }
                else if (i.GetType().IsSubclassOf(typeof(FloatPropertiesBase)))
                {
                    text = ((FloatPropertiesBase)i).float_value.ToString();
                }
                else if (i.GetType().IsSubclassOf(typeof(BoolPropertiesBase)))
                {
                    text = ((BoolPropertiesBase)i).bool_value.ToString();
                }
                else if (i.GetType().IsSubclassOf(typeof(StringPropertiesBase)))
                {
                    text = ((StringPropertiesBase)i).string_value;
                }

                XmlElement element = doc.CreateElement(i.GetType().Name);
                element.InnerText = text;
                root.AppendChild(element);
            }
        }

        private void SavingEffectList(XmlDocument doc, XmlElement root, EffectList list) 
        {
            
        }

        private void SavingPlayerPosition(XmlDocument doc, XmlElement root, CreaturePosition position) 
        {
            XmlElement mapName = doc.CreateElement("MapName");
            XmlElement x = doc.CreateElement("X");
            XmlElement y = doc.CreateElement("Y");
            XmlElement z = doc.CreateElement("Z");

            mapName.InnerText = position.MapName;
            x.InnerText = position.Position.x.ToString("0.000");
            y.InnerText = position.Position.y.ToString("0.000");
            z.InnerText = position.Position.z.ToString("0.000");

            root.AppendChild(mapName);
            root.AppendChild(x);
            root.AppendChild(y);
            root.AppendChild(z);
        }

        private void SavingItemInventory(XmlDocument doc, XmlElement root, PlayerInventory inventory)
        {
            Tuple<ItemBase, int>[] content = inventory.GetInventory();

            root.SetAttribute("Type", inventory.Name.ToXmlString());
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == null) continue;
                if (content[i].Item1 == null || content[i].Item2 == 0) continue;

                XmlElement item = doc.CreateElement("Item");

                XmlElement count = doc.CreateElement("Count");
                count.InnerText = content[i].Item2.ToString();
                item.AppendChild(count);

                XmlElement itemSlot = doc.CreateElement("ItemSlot");
                itemSlot.InnerText = i.ToString();
                item.AppendChild(itemSlot);

                XmlElement itemInfo = doc.CreateElement("ItemInfo");
                SavingItem(doc, itemInfo, content[i].Item1);
                item.AppendChild(itemInfo);

                root.AppendChild(item);
            }
        }

        private void SavingItem(XmlDocument doc, XmlElement root, ItemBase itemBase)
        {
            XmlElement itemName = doc.CreateElement("ItemName");
            itemName.InnerText = itemBase.Name.ToXmlString();
            root.AppendChild(itemName);

            XmlElement itemDetail = doc.CreateElement("ItemDetail");
            itemBase.SaveDataDatail(doc, itemDetail);
            root.AppendChild(itemDetail);
        }

        private void SavingClasses(XmlDocument doc, XmlElement root, ClassBase[] classList) {

            foreach(var i in classList)
            {
                string firstTag = $"{i.Name.Category_Keyword}_{i.Name.Label_Keyword}";
                XmlElement classElementRoot = doc.CreateElement(firstTag);

                XmlElement classSkillPoint = doc.CreateElement("SkillPoint");
                classSkillPoint.InnerText = i.SkillPoint.ToString();
                classElementRoot.AppendChild(classSkillPoint);

                XmlElement classSkillTree = doc.CreateElement("SkillTree");
                foreach(var j in i.SkillTrees.skills)
                {
                    XmlElement skillName = doc.CreateElement(
                        $"{j.Target.Name.Category_Keyword}_{j.Target.Name.Label_Keyword}"
                        );
                    classSkillTree.AppendChild(skillName);

                    XmlElement skillLevel = doc.CreateElement("SkillLevel");
                    skillLevel.InnerText = j.Level.ToString();
                    skillName.AppendChild(skillLevel);
                }
                classElementRoot.AppendChild(classSkillTree);

                root.AppendChild(classElementRoot);
            }
        }
        #endregion

        #endregion

        #region Load
        /// <summary>
        /// Loading player data from file path
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        private Player LoadingPlayer(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList root = doc.ChildNodes.Item(0).ChildNodes;

            string[] typename = ((XmlElement)doc.ChildNodes.Item(0)).GetAttribute("Type").Split('_');
            Player playerBuffer = Player.GetPlayerInstanceBySearchterm(new SearchTerm(typename[0], typename[1]), ass);
            if (playerBuffer == null) return null;

            // File name equal player name
            playerBuffer.PlayerName = Path.GetFileNameWithoutExtension(path);

            // Check all the content this player have
            // Loop all xmlnode child root node have
            foreach (var i in root)
            {
                // buffer
                XmlNode content = ((XmlNode)i);

                switch (content.Name)
                {
                    case "PropertiesList":
                        playerBuffer.Properties = LoadPropertiesList(content);
                        break;

                    case "EffectList":
                        playerBuffer.Effects = LoadEffectList(content, playerBuffer);
                        break;

                    case "Position":
                        playerBuffer.CurrentPosition = LoadPlayerPosition(content);
                        break;

                    case "EquipInventory":
                        break;

                    case "ItemInventory":
                        playerBuffer.PlayerItemInventory = LoadItemInventory(content);
                        break;

                    case "QuestInProgress":
                        break;

                    case "QuestFinished":
                        break;

                    case "Classes":
                        playerBuffer.Classes = LoadClasses(content);
                        break;
                }
            }

            return playerBuffer;
        }

        //
        #region Utility
        private PropertiesList LoadPropertiesList(XmlNode root)
        {
            PropertiesList result = new PropertiesList();

            // Check all the properties this player have
            foreach (var i in root.ChildNodes)
            {
                // Loop the properties exist list and get the type full name
                XmlNode content = ((XmlNode)i);
                propertiesBuffer.ForEach(x =>
                {
                    // If the type full name equal the xml node name
                    // This mean it is the properties we want to create new for
                    if (x.Item2 == content.Name)
                    {
                        // Properties type initialize arg
                        object arg = null;

                        // Type convert
                        if (x.Item1.IsSubclassOf(typeof(IntPropertiesBase)))
                        {
                            arg = Convert.ToInt32(content.InnerText);
                        }
                        else if (x.Item1.IsSubclassOf(typeof(FloatPropertiesBase)))
                        {
                            arg = Convert.ToSingle(content.InnerText);
                        }
                        else if (x.Item1.IsSubclassOf(typeof(BoolPropertiesBase)))
                        {
                            arg = Convert.ToBoolean(content.InnerText);
                        }
                        else if (x.Item1.IsSubclassOf(typeof(StringPropertiesBase)))
                        {
                            arg = content.InnerText;
                        }

                        // Create properties instance
                        PropertiesBase propertyInstance = (PropertiesBase)ass.CreateInstance(x.Item1.FullName,
                            false,
                            BindingFlags.Public | BindingFlags.Instance,
                            null,
                            new object[] { arg },
                            null,
                            null);

                        // Adding to the list
                        result.Add(propertyInstance);
                    }
                });
            }
            return result;
        }

        private EffectList LoadEffectList(XmlNode root, Player player)
        {
            EffectList effects = new EffectList(player);
            return effects;
        }

        private CreaturePosition LoadPlayerPosition(XmlNode root)
        {
            CreaturePosition pos = new CreaturePosition();
            pos.MapName = root.SelectSingleNode("MapName").InnerText;
            pos.Position = new Vec3(
                Convert.ToSingle(root.SelectSingleNode("X").InnerText),
                Convert.ToSingle(root.SelectSingleNode("Y").InnerText),
                Convert.ToSingle(root.SelectSingleNode("Z").InnerText)
                );
            return pos;
        }

        private PlayerInventory LoadItemInventory(XmlNode root)
        {
            string[] typename = ((XmlElement)root).GetAttribute("Type").Split('_');
            InventoryBase result = Inventory.GetInventoryBySearchTerm(new SearchTerm(typename[0], typename[1]), ass);
            result.CleanSlot();
            foreach(var i in root.SelectNodes("Item"))
            {
                XmlNode node = (XmlNode)i;
                int count = Convert.ToInt32(node.SelectSingleNode("Count").InnerText);
                int index = Convert.ToInt32(node.SelectSingleNode("ItemSlot").InnerText);

                XmlNode info = node.SelectSingleNode("ItemInfo");
                string[] itemname = info.SelectSingleNode("ItemName").InnerText.Split('_');
                ItemBase item = Item.GetItemBaseInstanceByKeyword(new SearchTerm(itemname[0], itemname[1]), ass);
                item.LoadDataDatail(info.SelectSingleNode("ItemDetail"));

                result.SetSlot(index, item, count);
            }

            return (PlayerInventory)result;
        }

        private ClassBase[] LoadClasses(XmlNode root)
        {
            List<ClassBase> classes = new List<ClassBase>();
            foreach(var i in root.ChildNodes)
            {
                XmlNode childClassRoot = (XmlNode)i;
                string[] classesName = childClassRoot.Name.Split('_');
                ClassBase cb = Class.GetClassBaseBySearchTerm(new SearchTerm(classesName[0], classesName[1]), ass);

                foreach (var j in childClassRoot.ChildNodes)
                {
                    XmlNode childSkillInfo = (XmlNode)j;
                    switch (childSkillInfo.Name)
                    {
                        case "SkillPoint":
                            cb.SkillPoint = Convert.ToInt32(childSkillInfo.InnerText);
                            break;
                        case "SkillTree":
                            foreach(var k in childSkillInfo.ChildNodes)
                            {
                                XmlNode childSkillRoot = (XmlNode)k;
                                string[] skillsName = childSkillRoot.Name.Split('_');
                                SkillTreeElement sk = cb.SkillTrees.GetElementByTargetSkillSearchTerm(new SearchTerm(skillsName[0], skillsName[1]));
                                sk.Level = Convert.ToInt32(childSkillRoot.SelectSingleNode("SkillLevel").InnerText);
                            }
                            break;
                    }
                }

                classes.Add(cb);
            }
            return classes.ToArray();
        }

        private void LoadPropertiesTypes()
        {
            // In order to check, we need to access the assembly and get type name
            propertiesBuffer = new List<Tuple<Type, string>>();

            foreach(var i in ass.GetTypes())
            {
                if (i.IsSubclassOf(typeof(PropertiesBase)))
                {
                    propertiesBuffer.Add(new Tuple<Type, string>(i, i.Name));
                }
            }
        }
        #endregion

        #endregion
    }
}
