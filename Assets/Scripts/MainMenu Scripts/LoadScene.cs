using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static void Load(string sceneName) => SceneManager.LoadSceneAsync(sceneName);
}
