using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using UnityEngine;

namespace ERPG
{
    /// <summary>
    /// Manage player information <br />
    /// Use xml format
    /// Quest, Skill, Inventory, Cash, Position...
    /// </summary>
    public class PlayerDatabase : DatabaseBase<Player>
    {
        public const string DataPath = "data/player";

        private Assembly ass;
        private List<Tuple<Type, string>> propertiesBuffer;

        public Player GetPlayerByID(string id)
        {
            return null;
        }

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
        private void SavingPlayer(string path, Player player)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);

            XmlElement propertiesListRoot = doc.CreateElement("PropertiesList");
            SavingPropertiesList(doc, player.Properties, propertiesListRoot);
            root.AppendChild(propertiesListRoot);

            doc.Save(path);
        }

        private void SavingPropertiesList(XmlDocument doc, PropertiesList list, XmlElement root)
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
        #endregion

        #region Load
        private Player LoadingPlayer(string path)
        {
            Player playerBuffer = new DataBasePlayer();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList root = doc.ChildNodes.Item(0).ChildNodes;

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
                        break;

                    case "Position":
                        break;

                    case "EquipInventory":
                        break;

                    case "ItemInventory":
                        break;

                    case "QuestInProgress":
                        break;

                    case "QuestFinished":
                        break;

                    case "Classes":
                        break;
                }
            }

            return playerBuffer;
        }

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
    }

    /// <summary>
    /// Use for buffer that contain player database element
    /// </summary>
    public class DataBasePlayer : Player
    {
        public override void Attacked(CreatureBase target) { }

        public override void Death() { }

        public override CharacterInventory InitializeCharacterInventory() { return null; }

        public override PlayerInventory InitializePlayerInventory() { return null; }

        public override void Spawn() { }

        public override void Update(float Delta) { }
    }
}
