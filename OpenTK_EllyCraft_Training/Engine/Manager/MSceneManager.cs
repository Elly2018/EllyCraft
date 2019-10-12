using EllyCraft.Base;
using EllyCraft.GUI;
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
        public static bool UpdateEmptyEventTrigger = true;
        public static bool RenderEmptyEventTrigger = true;
        public static bool RenderGUIEmptyEventTrigger = true;

        /// <summary>
        /// Will send the update to other scene
        /// After initialization it will update the logic for each scene
        /// </summary>
        public static void SceneUpdate()
        {
            bool Invoked = false;
            foreach (var s in LoadScenes)
            {
                if(s.LoadingFinished && s.SceneOnLoadActive)
                {
                    s.Update();
                    //MLoggerManager.Log("Scene manager update log test");

                    UpdateEmptyEventTrigger = false;
                    Invoked = true;
                }
                if(s.LoadingFinished && !s.SceneOnLoadActive)
                {
                    s.Awake();
                    s.Start();
                    s.SceneOnLoadActive = true;
                    //MLoggerManager.Log("Scene manager awake start log test");

                    UpdateEmptyEventTrigger = false;
                    Invoked = true;
                }
            }

            if(!Invoked && !UpdateEmptyEventTrigger)
                MLoggerManager.LogWarning("Scene Manager Render gui does not have any event to invoke");
            UpdateEmptyEventTrigger = true;
        }
        /// <summary>
        /// 3D render for scene object
        /// </summary>
        public static void SceneRender()
        {
            bool Invoked = false;
            foreach(var s in LoadScenes)
            {
                if(s.SceneOnLoadActive)
                {
                    s.Render();
                    //MLoggerManager.Log("Scene manager render log test");

                    RenderEmptyEventTrigger = false;
                    Invoked = true;
                }
            }

            if (!Invoked && !RenderEmptyEventTrigger)
                MLoggerManager.LogWarning("Scene Manager Render does not have any event to invoke");
            RenderEmptyEventTrigger = true;
        }
        /// <summary>
        /// 2D render for scene gui
        /// </summary>
        public static void SceneGUIRender()
        {
            bool Invoked = false;
            foreach (var s in LoadScenes)
            {
                if (s.SceneOnLoadActive)
                {
                    s.RenderGUI();
                    //MLoggerManager.Log("Scene manager render gui log test");

                    RenderGUIEmptyEventTrigger = false;
                    Invoked = true;
                }   
            }

            if (!Invoked && !RenderGUIEmptyEventTrigger)
                MLoggerManager.LogWarning("Scene Manager Render gui does not have any event to invoke");
            RenderGUIEmptyEventTrigger = true;
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

        public static EScene CheckSceneObjectParentScene(ESceneObject target)
        {
            foreach(var i in LoadScenes)
            {
                ESceneObject[] allObject = i.GetAllObject(false);
                foreach(var j in allObject)
                {
                    if (j == target) return i;
                }
            }
            return null;
        }
    }
}
