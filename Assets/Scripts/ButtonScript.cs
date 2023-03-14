using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void replay()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurLevel"));
    }

    public void startGame()
    {
        PlayerPrefs.SetInt("CurLevel", 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurLevel"));
    }

    public void quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
