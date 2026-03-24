using UnityEngine.Internal;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader
    {
        public static void Load(GameScene scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }

        public static void Load(GameScene scene, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
        {
            SceneManager.LoadScene(scene.ToString(), mode);
        }

        public static void UnloadAsync(GameScene scene)
        {
            SceneManager.UnloadSceneAsync(scene.ToString());
        }
    }
}
