using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private bool inside = false;
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && !activated)
        {
            if (Input.GetKeyDown(KeyCode.W) && !activated)
            {
                activated = true;
                if (PlayerPrefs.GetInt("CurLevel") <= 4)
                {
                    PlayerPrefs.SetInt("CurLevel", PlayerPrefs.GetInt("CurLevel") + 1);
                    SceneManager.LoadScene(PlayerPrefs.GetInt("CurLevel"));
                }
                else
                {
                    SceneManager.LoadScene("Win");
                }
            }
        }
    }
}
