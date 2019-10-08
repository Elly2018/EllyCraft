using EllyCraft.Base;
using System.Collections.Generic;

namespace EllyCraft
{
    class EScene : EObject
    {
        private List<ESceneObject> entities = new List<ESceneObject>();

        public delegate void Awake();
        public delegate void Start();
        public delegate void Update();
        public delegate void Render();

        public EScene()
        {

        }

        public EScene(string name) : base(name) { }

        public void CreateInstance(ESceneObject obj)
        {

        }

        public ESceneObject[] GetAllObject()
        {
            return entities.ToArray();
        }
    }

    [System.Serializable]
    class ESceneJsonFormat
    {
        public string name;
        public ESceneObject[] sceneObjects;
    }
}
