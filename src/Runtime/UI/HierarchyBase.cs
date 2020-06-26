using Boo.Lang;
using System;
using System.Reflection;
using UnityEngine;

namespace ERPG.Edit
{
    public abstract class HierarchyBase : MonoBehaviour
    {
        [SerializeField] private GameObject Category;
        [SerializeField] private GameObject Content;
        [SerializeField] private Transform Root;
        [SerializeField] protected ItemContentPage ContentPage;

        private List<Transform> HierarchyContent = new List<Transform>();

        /// <summary>
        /// Get all type instance that is inherit by T
        /// </summary>
        /// <typeparam name="T">The base class</typeparam>
        /// <returns>Type of instance list</returns>
        protected T[] GetAllInstance<T>()
        {
            List<T> result = new List<T>();
            Assembly ass = Assembly.GetCallingAssembly();
            Type[] ts = ass.GetTypes();
            foreach(var i in ts)
            {
                if (i.IsSubclassOf(typeof(T)))
                {
                    result.Add((T)ass.CreateInstance(i.FullName));
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Spawn a empty category <br />
        /// It will check name repeat so no worry
        /// </summary>
        /// <param name="name">Category name</param>
        protected void SpawnCategory(string name)
        {
            foreach (var i in HierarchyContent)
                if (i.name == name) return;

            GameObject g = GameObject.Instantiate(Category, Root);
            g.transform.name = name;
            HierarchyCategory gc = g.GetComponent<HierarchyCategory>();
            if (gc) gc.CategoryName.text = name;
            HierarchyContent.Add(g.transform);
        }

        /// <summary>
        /// Spawn content and put under category instance
        /// </summary>
        /// <param name="cate">Category name</param>
        /// <param name="name">Content name</param>
        /// <param name="obj">Object instance</param>
        /// <param name="click">Click call</param>
        protected void SpawnContent(string cate, string name, object obj, Action<object> click)
        {
            Transform parent = null;
            foreach (var i in HierarchyContent)
                if (i.name == cate) parent = i;
            HierarchyCategory gc = parent.GetComponent<HierarchyCategory>();
            if (gc) gc.AddContent(Content, obj, name, click);
        }
    }
}
