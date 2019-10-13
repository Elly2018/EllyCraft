using EllyCraft.Base;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EllyCraft
{
    class ESceneObject : EObject, EllyBehavior
    {
        public ESceneObject Parent;
        public List<ESceneObject> child = new List<ESceneObject>();

        private List<ESceneComponent> components = new List<ESceneComponent>();

        public int ChildCount
        {
            get { return child.Count; }
        }

        /// <summary>
        /// SceneObject constructor
        /// </summary>
        /// <param name="_name">The name of this sceneObject</param>
        public ESceneObject(string _name) : base(_name) {
        }


        /// <summary>
        /// Apply component by type
        /// It will apply the component to this sceneObject
        /// </summary>
        /// <typeparam name="T">Target component</typeparam>
        /// <returns></returns>
        public T AddComponent<T>() where T : ESceneComponent, new()
        {
            foreach(var i in typeof(T).GetProperties())
            {
                var require = i.GetCustomAttributes(typeof(RequireComponent), true);
                if(require.Length > 0)
                {
                    foreach(RequireComponent e in require)
                    {
                        if (e.type.IsAssignableFrom(typeof(ESceneComponent)))
                            AddComponent(e.type);
                    }
                }
            }

            return AddComponentOngameObject<T>();
        }
        /// <summary>
        /// Apply component by type field
        /// It will apply the component to this sceneObject
        /// </summary>
        /// <param name="component">Target component</param>
        /// <returns></returns>
        public ESceneComponent AddComponent(Type component) 
        {
            foreach (var i in component.GetType().GetProperties())
            {
                var require = i.GetCustomAttributes(typeof(RequireComponent), true);
                if (require.Length > 0)
                {
                    foreach (RequireComponent e in require)
                    {
                        if (e.type.IsAssignableFrom(typeof(ESceneComponent)))
                            AddComponent(e.type);
                    }
                }
            }

            return AddComponentOngameObject(component);
        }
        /// <summary>
        /// Local method for apply component to sceneObject
        /// It will apply the event
        /// </summary>
        /// <typeparam name="T">Target component</typeparam>
        /// <returns></returns>
        private T AddComponentOngameObject<T>() where T : ESceneComponent, new()
        {
            T t = new T();
            components.Add(t);
            t.sceneObject = this;
            return t;
        }
        /// <summary>
        /// Local method for apply component to sceneObject
        /// It will apply the event
        /// </summary>
        /// <param name="type">Target component</param>
        /// <returns></returns>
        private ESceneComponent AddComponentOngameObject(Type type)
        {
            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
            object instance = ctor.Invoke(new object[] { });
            return instance as ESceneComponent;
        }
        

        /// <summary>
        /// Get all components in this sceneObject
        /// </summary>
        /// <returns></returns>
        public ESceneComponent[] GetComponents()
        {
            return components.ToArray();
        }


        /// <summary>
        /// Search compent with this sceneObject by type
        /// </summary>
        /// <typeparam name="T">Target component</typeparam>
        /// <param name="IncludeInactive">Include inactive or not</param>
        /// <returns></returns>
        public T GetComponent<T>(bool IncludeInactive) where T : ESceneComponent
        {
            foreach (var com in components)
            {
                if(com.GetType().IsAssignableFrom(typeof(T)))
                    return com as T;
            }
            return null;
        }
        /// <summary>
        /// Search components with this sceneObject and store as array type return
        /// </summary>
        /// <typeparam name="T">Target component</typeparam>
        /// <param name="IncludeInactive">Include inactive or not</param>
        /// <returns></returns>
        public T[] GetComponents<T>(bool IncludeInactive) where T : ESceneComponent
        {
            List<T> EOC = new List<T>();
            foreach (var com in components)
            {
                EOC.Add((T)com);
            }
            return EOC.ToArray();
        }


        /// <summary>
        /// Get scene by asking scene manager
        /// </summary>
        /// <returns></returns>
        public EScene GetCurrentScene()
        {
            return MSceneManager.CheckSceneObjectParentScene(this);
        }

        public void MoveToTop()
        {
            SetSibling(0, this);
        }
        public void MoveToBottom()
        {
            SetSibling(child.Count - 1, this);
        }
        public void SetSibling(int index, ESceneObject target)
        {
            if (index > child.Count || index < 0)
            {
                ELogger.LogError(ELogger.LoggerMessage.OutOfRange(index));
                return;
            }

            if (!child.Contains(target))
            {
                ELogger.LogError("The object child does not contain argument target ");
                return;
            }

            int i = child.IndexOf(target);
            ESceneObject local = child[i];
            child[i] = child[index];
            child[index] = local;
        }

        public ESceneObject[] GetAllChild()
        {
            return child.ToArray();
        }
        public ESceneObject[] GetAllChildIncludingSubChild()
        {
            List<ESceneObject> result = new List<ESceneObject>(child);
            foreach(var i in result)
            {
                if(i.ChildCount > 0)
                    result.AddRange(i.GetAllChildIncludingSubChild());
                else
                    result.AddRange(i.GetAllChild());
            }
            return result.ToArray();
        }

        public ESceneObject GetChild(int index)
        {
            if(index > child.Count || index < 0)
            {
                ELogger.LogError(ELogger.LoggerMessage.OutOfRange(index));
                return null;
            }
            return child[index];
        }

        public T GetComponentFromChild<T>(bool IncludeInactive) where T : ESceneComponent, new()
        {
            ESceneObject[] allObject = GetAllChildIncludingSubChild();
            foreach(var i in allObject)
            {
                if (i.GetComponent<T>(IncludeInactive) != null) return i.GetComponent<T>(IncludeInactive);
            }
            return null;
        }
        public T[] GetComponentsFromChild<T>(bool IncludeInactive) where T : ESceneComponent, new()
        {
            List<T> result = new List<T>();
            ESceneObject[] allObject = GetAllChildIncludingSubChild();
            foreach (var i in allObject)
            {
                result.AddRange(i.GetComponents<T>(IncludeInactive));
            }
            return result.ToArray();
        }

        /// <summary>
        /// The stage event
        /// </summary>
        public void Awake()
        {
            foreach(var i in components)
            {
                i.Awake();
            }
        }
        public void Start()
        {
            foreach (var i in components)
            {
                i.Start();
            }
        }
        public void Update()
        {
            foreach (var i in components)
            {
                i.Update();
            }
        }
        public void Render()
        {
            foreach (var i in components)
            {
                i.Render();
            }
        }
        public void RenderGUI()
        {
            foreach (var i in components)
            {
                i.RenderGUI();
            }
        }
        public void Destroy()
        {
            foreach (var i in GetComponents())
            {
                i.Destroy();
            }
        }
    }

    [System.Serializable]
    class ESceneObjectJsonFormat
    {

    }
}
