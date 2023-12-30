using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController: MonoBehaviour
{
    static public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    static public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
