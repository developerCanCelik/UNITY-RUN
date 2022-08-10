using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishPanel : MonoBehaviour
{
    public void yes(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void no(){
        Application.Quit();
    }
}
