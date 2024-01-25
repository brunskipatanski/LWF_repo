using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOptionsScene : MonoBehaviour
{
    public void LoadOptionsMenu()
    {
        Debug.Log("Button Clicked - Loading Options_Menu scene");
        SceneManager.LoadScene("Options_Menu");
    }
}
