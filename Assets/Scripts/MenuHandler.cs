using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    
    public void Credits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
