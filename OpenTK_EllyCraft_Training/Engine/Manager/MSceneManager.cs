using EllyCraft.Base;
using System;
using System.Collections.Generic;

namespace EllyCraft
{
    /// <summary>
    /// The manager which handle multiple scenes
    /// Work will handle the stage call awake, start, update, render, rendergui, destroy.
    /// And these event will pass through delegate to every gameObject and components.
    /// Easily say, it's a master multi-scene worker
    /// </summary>
    sealed class MSceneManager : SceneManagerBase
    {
        /// <summary>
        /// Will send the update to other scene
        /// After initialization it will update the logic for each scene
        /// </summary>
        public static void SceneUpdate()
        {
            foreach (var s in LoadScenes)
            {
                if(s.update != null && s.LoadingFinished && s.SceneOnLoadActive)
                    s.update.Invoke();
                if(s.update != null && s.LoadingFinished && !s.SceneOnLoadActive)
                {
                    s.awake();
                    s.start();
                    s.SceneOnLoadActive = true;
                }
            }
        }
        /// <summary>
        /// 3D render for scene object
        /// </summary>
        public static void SceneRender()
        {
            foreach(var s in LoadScenes)
            {
                if(s.render != null)
                    s.render.Invoke();
            }
        }
        /// <summary>
        /// 2D render for scene gui
        /// </summary>
        public static void SceneGUIRender()
        {
            foreach (var s in LoadScenes)
            {
                if (s.rendergui != null)
                    s.rendergui.Invoke();
            }
        }

        /// <summary>
        /// It will find match name gameObject.
        /// it could return null, if nothing is be found.
        /// </summary>
        /// <param name="name">gameObject name</param>
        /// <returns></returns>
        public static ESceneObject FindSceneObjectByName(string name)
        {
            foreach(var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject(true);
                foreach (var obj in EO)
                {
                    if (obj.name == name) return obj;
                }
            }
            return null;
        }
        /// <summary>
        /// It will find match name gameObjects and store as array.
        /// it could return null, if nothing is be found.
        /// </summary>
        /// <param name="name">gameObject name</param>
        /// <returns></returns>
        public static ESceneObject[] FindSceneObjectsByName(string name)
        {
            List<ESceneObject> EOResult = new List<ESceneObject>();
            foreach (var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject(true);
                foreach (var obj in EO)
                {
                    if (obj.name == name) EOResult.Add(obj);
                }
            }
            return EOResult.ToArray();
        }

        public static T FindComponent<T>(bool IncludeInactive) where T : ESceneComponent
        {
            foreach (var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject(true);
                foreach (var obj in EO)
                {
                    T t = obj.GetComponent<T>(IncludeInactive);
                    if (t != null) return t;
                }
            }

            return null;
        }
        public static T[] FindComponents<T>(bool IncludeInactive) where T : ESceneComponent
        {
            List<T> EOCResult = new List<T>();
            foreach (var scene in LoadScenes)
            {
                ESceneObject[] EO = scene.GetAllObject(true);
                foreach (var obj in EO)
                {
                    EOCResult.AddRange(obj.GetComponents<T>(IncludeInactive));
                }
            }
            return EOCResult.ToArray();
        }
    }
}
