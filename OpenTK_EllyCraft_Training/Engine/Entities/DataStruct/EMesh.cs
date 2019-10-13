using FileFormatWavefront;
using FileFormatWavefront.Model;
using EllyCraft.IO;
using System.IO;
using System.Collections.Generic;
using EllyCraft.Base;

namespace EllyCraft
{
    class EMesh : EObject
    {
        public EVertex2D[] _uv;
        public EVertex3D[] _vert;
        public EVertex3D[] _normal;

        public enum DefaultMeshType
        {
            Cube, Plane, Sphere, Cone
        }

        public static EMesh GetDefaultMesh(DefaultMeshType defaultMeshType)
        {
            string FileName = "";
            switch (defaultMeshType)
            {
                case DefaultMeshType.Cube:
                    FileName = "Cube.obj";
                    break;
                case DefaultMeshType.Plane:
                    FileName = "Plane.obj";
                    break;
                case DefaultMeshType.Sphere:
                    FileName = "Sphere.obj";
                    break;
                case DefaultMeshType.Cone:
                    FileName = "Cone.obj";
                    break;
            }

            if (File.Exists(Path.Combine(EPath.GetResourcePath(), FileName)))
            {
                bool successfully = false;
                FileLoadResult<Scene> scene = FileFormatObj.Load(Path.Combine(EPath.GetResourcePath(), FileName), successfully);

                if (successfully)
                {
                    return LoaderObjToEMesh(scene);
                }
            }
            ELogger.LogError(ELogger.LoggerMessage.CannotGetResource(FileName, EPath.GetResourcePath()));

            return null;
        }

        private static EMesh LoaderObjToEMesh(FileLoadResult<Scene> scene)
        {
            EMesh e = new EMesh();

            List<EVertex3D> vert = new List<EVertex3D>();
            for (int i = 0; i < scene.Model.Vertices.Count; i++)
            {
                vert.Add(new EVertex3D(scene.Model.Vertices[i].x, scene.Model.Vertices[i].y, scene.Model.Vertices[i].z));
            }

            List<EVertex3D> normal = new List<EVertex3D>();
            for (int i = 0; i < scene.Model.Normals.Count; i++)
            {
                vert.Add(new EVertex3D(scene.Model.Normals[i].x, scene.Model.Normals[i].y, scene.Model.Normals[i].z));
            }

            List<EVertex2D> uv = new List<EVertex2D>();
            for (int i = 0; i < scene.Model.Uvs.Count; i++)
            {
                vert.Add(new EVertex3D(scene.Model.Uvs[i].u, scene.Model.Uvs[i].v));
            }

            e._vert = vert.ToArray();
            e._normal = normal.ToArray();
            e._uv = uv.ToArray();
            e.name = scene.Model.ObjectName;

            return e;
        }
    }
}
