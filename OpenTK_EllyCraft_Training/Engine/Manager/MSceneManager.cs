using EllyCraft.Base;
using System;
using System.Collections.Generic;

namespace EllyCraft
{
    sealed class MSceneManager : SceneManagerBase
    {
        public static ESceneObject FindSceneObjectByName(string name)
        {
            foreach(var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject();
                foreach (var obj in EO)
                {
                    if (obj.name == name) return obj;
                }
            }
            return null;
        }

        public static ESceneObject[] FindSceneObjectsByName(string name)
        {
            List<ESceneObject> EOResult = new List<ESceneObject>();
            foreach (var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject();
                foreach (var obj in EO)
                {
                    if (obj.name == name) EOResult.Add(obj);
                }
            }
            return EOResult.ToArray();
        }

        public static ESceneComponent FindComponent<T>(bool IncludeInactive)
        {
            foreach (var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject();
                foreach (var obj in EO)
                {
                    ESceneComponent t = obj.GetComponent<T>(IncludeInactive);
                    if (t != null) return t;
                }
            }

            return null;
        }

        public static ESceneComponent[] FindComponents<T>(bool IncludeInactive)
        {
            List<ESceneComponent> EOCResult = new List<ESceneComponent>();
            foreach (var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject();
                foreach (var obj in EO)
                {
                    EOCResult.AddRange(obj.GetComponents<T>(IncludeInactive));
                }
            }
            return EOCResult.ToArray();
        }
    }
}
