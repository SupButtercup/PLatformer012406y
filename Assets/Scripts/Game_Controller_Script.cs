using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Game_Controller_Script : MonoBehaviour
{
    public TextMeshProUGUI diolog_text;
    public GameObject diolog_panel;
    
    public int levelNum;
    // Start is called before the first frame update
    void Start()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void next_level()
    {
        SceneManager.LoadScene(levelNum + 1);
    }
    public void showDiolog(string text)
    {
        diolog_text.SetText(text);
        diolog_panel.SetActive(true);
    }
    public void hideDiolog()
    {
        diolog_panel.SetActive(false);
    }
}
