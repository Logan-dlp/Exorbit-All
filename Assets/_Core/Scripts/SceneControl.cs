using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void LoadScene(string sceneLoaded)
    {
        SceneManager.LoadScene(sceneLoaded);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
