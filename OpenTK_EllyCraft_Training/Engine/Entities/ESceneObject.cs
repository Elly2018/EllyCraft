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
                if (com.GetType() == typeof(T))
                {
                    return (T)com;
                }
            }
            return null;
        }

        public T[] GetComponents<T>(bool IncludeInactive) where T : ESceneComponent
        {
            List<T> EOC = new List<T>();
            foreach (var com in components)
            {
                if (com.GetType() == typeof(T))
                {
                    EOC.Add((T)com);
                }
            }
            return EOC.ToArray();
        }

        public EScene GetCurrentScene()
        {
            EObject target = this;

            while((target as ESceneObject).parent.GetType() != typeof(EScene))
            {
                target = (target as ESceneObject).parent;
            }

            return (target as ESceneObject).parent as EScene;
        }

        public void Awake()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        public void Render()
        {
        }

        public void RenderGUI()
        {
        }

        public void Destroy()
        {
        }
    }

    [System.Serializable]
    class ESceneObjectJsonFormat
    {

    }
}
