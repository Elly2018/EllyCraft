using EllyCraft.Base;
using System.Collections.Generic;

namespace EllyCraft
{
    class EScene : EObject
    {
        private List<ESceneObject> entities = new List<ESceneObject>();

        private bool _LoadingFinished = false;
        public bool LoadingFinished
        {
            get { return _LoadingFinished; }
        }
        private bool _SceneOnLoadActive = false;
        public bool SceneOnLoadActive
        {
            get { return _SceneOnLoadActive; }
            set { _SceneOnLoadActive = value; }
        }

        /// <summary>
        /// Trigger which for scene use to delegate gameObject stage event
        /// </summary>
        public delegate void Awake();
        public delegate void Start();
        public delegate void Update();
        public delegate void Render();
        public delegate void RenderGUI();
        public delegate void Destroy();
        public Awake awake;
        public Start start;
        public Update update;
        public Render render;
        public RenderGUI rendergui;
        public Destroy destroy;

        public const string DefaultSceneName = "Default Scene";

        /// <summary>
        /// The scene when user enter game. the first game scene will open
        /// It will have default fps character and plane as ground</summary>
        /// <summary>
        /// <returns></returns>
        public static EScene GetDefaultScene()
        {
            EScene e = new EScene(DefaultSceneName);

            ESceneObject Floor = new ESceneObject("Floor");
            e.CreateInstance(Floor);
            Floor.AddComponent<CMeshFilter>();
            Floor.AddComponent<CMeshRender>();

            e.CompleteLoading();
            return e;
        }

        /// <summary>
        /// Scene constructor
        /// Default name will be "Empty scene"
        /// </summary>
        public EScene()
        {
            name = "Empty scene";
            MSceneManager.LoadScene(this);
        }
        /// <summary>
        /// Scene constructor
        /// </summary>
        /// <param name="name">Scene name</param>
        public EScene(string name) : base(name)
        {
            MSceneManager.LoadScene(this);
        }

        /// <summary>
        /// After scene loading finish. call this method to make it active
        /// </summary>
        public void CompleteLoading()
        {
            _LoadingFinished = true;
        }

        /// <summary>
        /// Create any gameObject in scene
        /// This will add target scene in the list and register event
        /// </summary>
        /// <param name="obj">target gameObject</param>
        /// <returns></returns>
        public ESceneObject CreateInstance(ESceneObject obj)
        {
            return CreateInstance(obj, null);
        }
        /// <summary>
        /// Create any gameObject in scene
        /// This will add target scene in the list and register event
        /// </summary>
        /// <param name="obj">target gameObject</param>
        /// <param name="parent">gameObject parent</param>
        /// <returns></returns>
        public ESceneObject CreateInstance(ESceneObject obj, ESceneObject parent)
        {
            entities.Add(obj);
            ESceneComponent[] comps = obj.GetComponents<ESceneComponent>(true);
            foreach (var i in comps)
            {
                BindBehavior(i);
            }
            obj.Parent = parent;

            MLoggerManager.Log("SceneObject: " + obj.name);
            MLoggerManager.Log("\tTo scene: " + name);
            if (parent == null) MLoggerManager.Log("\tParent: null");
            else MLoggerManager.Log("\tParent: " + parent.name);
            MLoggerManager.Log("");

            return obj;
        }
        public void BindBehavior(EllyBehavior target)
        {
            awake += target.Awake;
            start += target.Start;
            update += target.Update;
            render += target.Render;
            rendergui += target.RenderGUI;
            destroy += target.Destroy;
        }

        /// <summary>
        /// Get gameObjects in scene as array
        /// </summary>
        /// <param name="OnlyTopLayer">Choose only select first layer gameObject</param>
        /// <returns></returns>
        public ESceneObject[] GetAllObject(bool OnlyTopLayer)
        {
            if (!OnlyTopLayer) return entities.ToArray();

            List<ESceneObject> result = new List<ESceneObject>();
            foreach(var e in entities)
            {
                if (e.Parent == null) result.Add(e);
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
