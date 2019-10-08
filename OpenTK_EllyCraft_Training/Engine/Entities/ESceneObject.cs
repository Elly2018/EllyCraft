using EllyCraft.Base;
using System.Collections.Generic;

namespace EllyCraft
{
    class ESceneObject : EObject
    {
        private List<ESceneComponent> components = new List<ESceneComponent>();

        public ESceneObject parent;
        public List<ESceneObject> child;

        public ESceneComponent[] GetComponents()
        {
            return components.ToArray();
        }

        public ESceneComponent GetComponent<T>(bool IncludeInactive)
        {
            foreach(var com in components)
            {
                if(com.GetType() == typeof(T))
                {
                    return com;
                }
            }
            return null;
        }

        public ESceneComponent[] GetComponents<T>(bool IncludeInactive)
        {
            List<ESceneComponent> EOC = new List<ESceneComponent>();
            foreach (var com in components)
            {
                if (com.GetType() == typeof(T))
                {
                    EOC.Add(com);
                }
            }
            return EOC.ToArray();
        }
    }

    [System.Serializable]
    class ESceneObjectJsonFormat
    {

    }
}
