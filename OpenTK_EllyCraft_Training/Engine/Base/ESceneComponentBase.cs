using System.Collections.Generic;

namespace EllyCraft.Base
{
    abstract class ESceneComponentBase : EObject
    {
        public ESceneObject sceneObject;

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Render() { }
        public virtual void RenderGUI() { }

        public void Reset()
        {

        }
    }
}
