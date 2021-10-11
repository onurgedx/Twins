using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerInCamera : MonoBehaviour
{
    private bool lvl = true;


    // Start is called before the first frame update
    void Start()
    {
        Speed.inHome = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Speed.inHome==2  && lvl)
        {
            lvl = false;
            Invoke("nextLVL",3f);
        }
        
    }

    public void nextLVL()
    {
        Speed.NextScene();
    }

    public void goMenu()
    {
        Speed.MenuScene();
    }
}
