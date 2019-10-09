using System;

namespace EllyCraft
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class RequireComponent : Attribute
    {
        public Type type;
        public RequireComponent(Type Component)
        {

        }
    }
}
