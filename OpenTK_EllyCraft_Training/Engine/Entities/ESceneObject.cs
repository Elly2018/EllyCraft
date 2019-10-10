using EllyCraft.Base;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EllyCraft
{
    class ESceneObject : EObject, EllyBehavior
    {
        private List<ESceneComponent> components = new List<ESceneComponent>();

        public EObject parent;
        public List<ESceneObject> child;

        public ESceneObject(string _name) : base(_name) {
        }

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

        private T AddComponentOngameObject<T>() where T : ESceneComponent, new()
        {
            T t = new T();
            components.Add(t);
            t.sceneObject = this;
            GetCurrentScene().BindBehavior(this);
            return t;
        }
        private ESceneComponent AddComponentOngameObject(Type type)
        {
            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
            object instance = ctor.Invoke(new object[] { });
            return instance as ESceneComponent;
        }

        public ESceneComponent[] GetComponents()
        {
            return components.ToArray();
        }

        public T GetComponent<T>(bool IncludeInactive) where T : ESceneComponent
        {
            foreach (var com in components)
            {
                return (T)com;
            }
            return null;
        }

        public T[] GetComponents<T>(bool IncludeInactive) where T : ESceneComponent
        {
            List<T> EOC = new List<T>();
            foreach (var com in components)
            {
                EOC.Add((T)com);
            }
            return EOC.ToArray();
        }

        public EScene GetCurrentScene()
        {
            EObject target = this;

            while(!target.GetType().IsAssignableFrom(typeof(ESceneObject)))
            {
                target = (target as ESceneObject).parent;
            }

            return (target as ESceneObject).parent as EScene;
        }

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
