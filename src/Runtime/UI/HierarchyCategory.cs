using System;
using UnityEngine;
using UnityEngine.UI;

namespace ERPG.Edit
{
    public class HierarchyCategory : MonoBehaviour
    {
        public Text CategoryName;
        public Transform Root;

        /// <summary>
        /// Adding content under the category content list root
        /// </summary>
        /// <param name="template">Content use prefab</param>
        /// <param name="obj">Object instance</param>
        /// <param name="name">Content name</param>
        /// <param name="click">Click call</param>
        public void AddContent(GameObject template, object obj, string name, Action<object> click)
        {
            GameObject g = GameObject.Instantiate(template, Root);
            g.transform.name = name;
            HierarchyContent hc = g.GetComponent<HierarchyContent>();
            if (hc) hc.content = obj;
            if (hc) hc.contentName.text = name;
            if (hc) hc.Register(click);
        }
    }
}
