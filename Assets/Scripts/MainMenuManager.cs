using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame(){
         Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void QuitGame(){
       Application.Quit(); 
    }
}
