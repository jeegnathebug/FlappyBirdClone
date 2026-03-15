using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader
    {
        public static void Load(GameScene scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}
