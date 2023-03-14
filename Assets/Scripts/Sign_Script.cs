using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sign_Script : MonoBehaviour
{
    public Game_Controller_Script gamecontroller;
    public string diolog;
    // Start is called before the first frame update
    void Start()
    {
        //gamecontroller = GetComponent<gamecontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gamecontroller.showDiolog(diolog);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gamecontroller.hideDiolog();
    }
}
