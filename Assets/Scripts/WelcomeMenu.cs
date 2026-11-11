using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main"); // must match your scene name exactly
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Quit() does nothing in the Editor
#else
        Application.Quit();
#endif
    }
}