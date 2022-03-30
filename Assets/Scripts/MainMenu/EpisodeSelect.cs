using UnityEngine;
using UnityEngine.SceneManagement;

public class EpisodeSelect : MonoBehaviour
{
    public void SelectLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }
}
