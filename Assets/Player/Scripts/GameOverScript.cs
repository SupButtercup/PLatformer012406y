using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void gameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
