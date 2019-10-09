using EllyCraft.Base;
using System.Collections.Generic;

namespace EllyCraft
{
    class EScene : EObject
    {
        private List<ESceneObject> entities = new List<ESceneObject>();

        protected delegate void Awake();
        protected delegate void Start();
        protected delegate void Update();
        protected delegate void Render();
        protected delegate void RenderGUI();
        protected Awake awake;
        protected Start start;
        protected Update update;
        protected Render render;
        protected RenderGUI rendergui;


        /*
         * The scene when user enter game. the first game scene will open
         * It will have default fps character and plane as ground
        */
        public static EScene GetDefaultScene()
        {
            EScene e = new EScene("Default Scene");

            return e;
        }

        /*
         * Scene constructor
        */
        public EScene() { }
        public EScene(string name) : base(name) { }

        /*
         * Create any gameObject in scene
         * This will add it in the list
        */
        public ESceneObject CreateInstance(ESceneObject obj)
        {
            entities.Add(obj);
            ESceneComponent[] comps = obj.GetComponents<ESceneComponent>(true);
            foreach(var i in comps)
            {
                awake += i.Awake;
                start += i.Start;
                update += i.Update;
                render += i.Render;
                rendergui += i.RenderGUI;
            }
            obj.parent = this;
            return obj;
        }
        public ESceneObject CreateInstance(ESceneObject obj, ESceneObject parent)
        {
            entities.Add(obj);
            ESceneComponent[] comps = obj.GetComponents<ESceneComponent>(true);
            foreach (var i in comps)
            {
                awake += i.Awake;
                start += i.Start;
                update += i.Update;
                render += i.Render;
                rendergui += i.RenderGUI;
            }
            obj.parent = parent;
            return obj;
        }

        /*
         * Get all gameObject as array
        */
        public ESceneObject[] GetAllObject(bool OnlyTopLayer)
        {
            if (!OnlyTopLayer) return entities.ToArray();

            List<ESceneObject> result = new List<ESceneObject>();
            foreach(var e in entities)
            {
                if (e.parent.GetType() == typeof(EScene)) result.Add(e);
            }
            return result.ToArray();
        }
    }

    [System.Serializable]
    class ESceneJsonFormat
    {
        public string name;
        public ESceneObject[] sceneObjects;
    }
}
