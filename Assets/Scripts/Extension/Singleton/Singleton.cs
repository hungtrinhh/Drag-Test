using System;
using UnityEngine;

namespace Extension.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    var objs = GameObject.FindObjectsOfType<T>();
                    if (objs.Length > 0)
                    {
                        instance = objs[0];
                    }

                    if (objs.Length > 2)
                    {
                        Debug.LogWarning($"have {objs.Length} {typeof(T)} in this scene ");
                    }

                    if (instance == null)
                    {
                        var newOj = new GameObject(typeof(T).ToString());
                        instance = newOj.AddComponent<T>();
                    }
                }

                return instance;
            }
            private set { }
        }

        private void OnApplicationQuit()
        {
            instance = null;
        }
    }
}