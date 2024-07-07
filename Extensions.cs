using System;
using UnityEngine;

namespace HolySlimes
{
    public static class CottonExtensions
    {
        public static void RemoveComponent<T>(this GameObject obj) where T : Component
        {
            var comp = obj.GetComponent<T>();

            if (comp != null)
            {
                UnityEngine.Object.Destroy(comp);
            }
        }

        public static void Add<T>(this Array array, T obj)
        {
            var s = new T[0];
            array = HarmonyLib.CollectionExtensions.AddToArray(s, obj);
        }

        public static void AddRange<T>(this Array array, T[] obj)
        {
            foreach (var item in obj)
            {
                array.Add(item);
            }
        }
    }
}
