using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Speed 
{

    public static float speed =160f;
    public static float tapTwiceDuration = 0.0f;

    public static int inHome = 0;
    //bu speed degerine herkes ulasabilir Speed.speed diyerek 
    //bu static  in bir ozellgidir.

    
    // Start is called before the first frame update
    void Start()
    {
        inHome = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void speedChange(float newSpeed)
    {
        speed = newSpeed;
        
    }

    public static void insideHome()
    {
        inHome += 1;
        if (inHome==2)
        {
            Debug.Log("insideHome");

            GameObject.FindGameObjectWithTag("Hearth").GetComponent<Animator>().SetTrigger("hearth");
            
            


            //next level
        }

    }
    public static void outsideHome()
    {
        inHome -= 1;
        Debug.Log("outsideHome");
    }

    public static void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
            
            
            }
    
   public static void NextScene()
    {
        Debug.Log("lvlup");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1 );
    }

    public static void MenuScene()
    {
        SceneManager.LoadScene(0);
    }


   

}
