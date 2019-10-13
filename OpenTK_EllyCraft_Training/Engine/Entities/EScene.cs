using EllyCraft.Base;
using System.Collections.Generic;

namespace EllyCraft
{
    class EScene : EObject
    {
        public enum StageCall
        {
            Awake, Start, Update, Render, RenderGUI, Destroy
        }

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
        public const string DefaultSceneName = "Default Scene";

        /// <summary>
        /// Trigger which for scene use to delegate gameObject stage event
        /// </summary>
        public void Awake()
        {

            List<ESceneObject> local = new List<ESceneObject>(entities);
            while (local.Count != 0)
            {
                local = EventCall(local, StageCall.Awake);
            }
        }
        public void Start()
        {
            List<ESceneObject> local = new List<ESceneObject>(entities);
            while (local.Count != 0)
            {
                local = EventCall(local, StageCall.Start);
            }
        }
        public void Update()
        {
            List<ESceneObject> local = new List<ESceneObject>(entities);
            while (local.Count != 0)
            {
                local = EventCall(local, StageCall.Update);
            }
        }
        public void Render()
        {
            List<ESceneObject> local = new List<ESceneObject>(entities);
            while (local.Count != 0)
            {
                local = EventCall(local, StageCall.Render);
            }
        }
        public void RenderGUI()
        {
            List<ESceneObject> local = new List<ESceneObject>(entities);
            while (local.Count != 0)
            {
                local = EventCall(local, StageCall.RenderGUI);
            }
        }
        public void Destroy()
        {
            List<ESceneObject> local = new List<ESceneObject>(entities);
            while (local.Count != 0)
            {
                local = EventCall(local, StageCall.Destroy);
            }
        }
        public List<ESceneObject> EventCall(List<ESceneObject> dele, StageCall sc)
        {
            List<ESceneObject> result = new List<ESceneObject>();
            foreach(ESceneObject objc in dele)
            {
                result.AddRange(objc.child);

                switch (sc)
                {
                    case StageCall.Awake:
                        objc.Awake();
                        break;
                    case StageCall.Start:
                        objc.Start();
                        break;
                    case StageCall.Update:
                        objc.Update();
                        break;
                    case StageCall.Render:
                        objc.Render();
                        break;
                    case StageCall.RenderGUI:
                        objc.RenderGUI();
                        break;
                    case StageCall.Destroy:
                        objc.Destroy();
                        break;
                }
            }
            return result;
        }

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
            if(parent == null)
                entities.Add(obj);

            if(parent != null)
            {
                obj.Parent = parent;
                parent.child.Add(obj);
            }

            ELogger.Log("SceneObject: " + obj.name);
            ELogger.Log("\tTo scene: " + name);
            if (parent == null) ELogger.Log("\tParent: null");
            else ELogger.Log("\tParent: " + parent.name);
            ELogger.Log("");

            return obj;
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
