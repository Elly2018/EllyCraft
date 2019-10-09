using EllyCraft.Base;
using System.Collections.Generic;

namespace EllyCraft
{
    class ESceneObject : EObject, EllyBehavior
    {
        private List<ESceneComponent> components = new List<ESceneComponent>();

        public EObject parent;
        public List<ESceneObject> child;

        public ESceneObject(string _name) : base(_name) {
        }

        public T AddComponent<T>(T t) where T : ESceneComponent
        {
            components.Add(t);
            t.sceneObject = this;
            GetCurrentScene().BindBehavior(this);
            return t;
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
