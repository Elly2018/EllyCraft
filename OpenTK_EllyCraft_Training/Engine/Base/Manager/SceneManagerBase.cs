using System.Collections.Generic;

namespace EllyCraft.Base
{
    class SceneManagerBase
    {
        public static EScene[] LoadScenes;

        public static void SetActiveScene(int index)
        {
            if(index >= LoadScenes.Length || index < 0)
            {
                ELogger.LogWarning(ELogger.LoggerMessage.OutOfRange(index));
                return;
            }

            mSetActiveScene(index);
        }
        public static void SetActiveScene(string name)
        {
            int index = -1;
            for(int i = 0; i < LoadScenes.Length; i++)
            {
                if(LoadScenes[i].name == name)
                {
                    index = i;
                    break;
                }
            }

            if(index == -1)
            {
                ELogger.LogWarning(ELogger.LoggerMessage.ObjectDoesNotExist<EScene>(name));
                return;
            }

            mSetActiveScene(index);
        }
        private static void mSetActiveScene(int index)
        {
            EScene scene = LoadScenes[index];
            LoadScenes[index] = LoadScenes[0];
            LoadScenes[0] = scene;
        }

        public static void LoadScene(EScene scene)
        {
            m_LoadScene(scene);
        }
        public static void LoadScene(string name)
        {

        }
        private static void m_LoadScene(EScene scene)
        {
            List<EScene> scenes = new List<EScene>();
            if(LoadScenes != null)
                scenes.AddRange(LoadScenes);
            scenes.Add(scene);

            LoadScenes = scenes.ToArray();
            ELogger.Log("Scene loading: " + scene.name);
            ELogger.Log("");
        }

        public static void UnloadScene(int index)
        {
            m_UnloadScene(index);
        }
        public static void UnloadScene(string name)
        {
            for(int i = 0; i < LoadScenes.Length; i++)
            {
                if (LoadScenes[i].name == name) {
                    m_UnloadScene(i);
                    return;
                } 
            }
            ELogger.LogWarning("Cannot find scene by name: " + name);
        }
        private static void m_UnloadScene(int index)
        {
            if (index >= LoadScenes.Length || index < 0)
            {
                ELogger.LogWarning(ELogger.LoggerMessage.OutOfRange(index));
                return;
            }
            List<EScene> local = new List<EScene>(LoadScenes);
            local[index].Destroy();
            local.RemoveAt(index);
            LoadScenes = local.ToArray();
        }
    }
}
