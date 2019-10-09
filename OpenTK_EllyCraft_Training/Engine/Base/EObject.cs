namespace EllyCraft.Base
{
    class EObject
    {
        public string name;
        public bool Active;

        public EObject()
        {
            name = "Empty gameObject";
        }

        public EObject(string _name)
        {
            name = _name;
        }
    }
}
