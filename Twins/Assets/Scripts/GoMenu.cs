using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LevelManagerInCamera>().goMenu();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
