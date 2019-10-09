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
                MLoggerManager.LogWarning(MLoggerManager.LoggerMessage.OutOfRange(index));
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
                MLoggerManager.LogWarning(MLoggerManager.LoggerMessage.ObjectDoesNotExist<EScene>(name));
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
            scenes.Add(scene);

            LoadScenes = scenes.ToArray();
        }

        public static void UnloadScene(int index)
        {

        }
        public static void UnloadScene(string name)
        {

        }
    }
}
