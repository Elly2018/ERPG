using System.Linq;
using UnityEngine;

namespace ERPG
{
    /// <summary>
    /// Contain actual prefab register data
    /// </summary>
    [System.Serializable]
    public class PrefabRegisterStruct
    {
        public string LanguageTag;
        public Items ItemsRegister;
        public Creatures CreaturesRegister;
        public Enviroment EnviromentRegister;

        public static PrefabRegisterStructHolder GetPrefabRegisterStruct()
        {
            return Resources.FindObjectsOfTypeAll<PrefabRegisterStructHolder>().FirstOrDefault();
        }
    }

    [System.Serializable]
    public class Items
    {
        public GameObject[] BaseItem;
        public GameObject[] Use;
        public GameObject[] Equip;
        public GameObject[] Weapon;
        public GameObject[] Special;
    }

    [System.Serializable]
    public class Creatures
    {
        public GameObject[] Player;
        public GameObject[] Monster;
        public GameObject[] NPC;
    }

    [System.Serializable]
    public class Enviroment
    {
        public GameObject[] Materals;
    }
}