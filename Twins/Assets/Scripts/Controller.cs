using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Controller : MonoBehaviour
{
    public Vector2 BeganPos;
    private float tapTwiceTime;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Main();
    }


    public bool isOnNotCanvas
    {
        get
        {
            return EventSystem.current.currentSelectedGameObject == null;
        }
    }


    private void Main()
    {
        if (isTouch)
        {
            //Debug.Log(finger.rawPosition);
            // Debug.Log(finger.deltaPosition);
            

           
            

            if (isBeganPhase)
            { // Do something when began

                Began();

            }

            else if (isStationaryPhase)
            {//Do Something when stationary
                Stationary();
            }
            else if (isMovedPhase)
            {// Do Something when moved
                Moved();




            }
            else if (isEndedPhase)
            {// do something when Ended
                Ended();
            }
            else if (isCanceledPhase)
            {// do Something when Canceled
                Canceled();

            }

        





        }

        ExtraMain();




    }

    public virtual void ExtraMain()
    {

    }

    public virtual void TwiceTap()
    {

    }

    public virtual void Began()
    {
        Debug.Log("began");
        BeganPos = finger.position;
        
    }

    public virtual void Moved()
    {
        Debug.Log("moved");

    }

    public virtual void Stationary()
    {
        Debug.Log("Stationary");
    }

    public virtual void Ended()
    {
        Debug.Log("Ended");
        BeganPos = finger.position;
    }

    public virtual void Canceled()
    {
        Debug.Log("Canceled");

    }

    //dokunma var ise
    public bool isTouch
    {
        get
        {
            return Input.touchCount > 0;
        }

    }



    // 0 indeksli dokunmayi aliyor
    public Touch finger
    {
        get
        {
            return Input.GetTouch(0);
        }




    }



    private bool isBeganPhase
    {
        get
        {
            return finger.phase == TouchPhase.Began;
        }

    }

    private bool isStationaryPhase
    {
        get
        {
            return finger.phase == TouchPhase.Stationary;

        }
    }

    private bool isMovedPhase
    {
        get
        {
            return finger.phase == TouchPhase.Moved;

        }
    }

    private bool isEndedPhase
    {
        get
        {
            return finger.phase == TouchPhase.Ended;

        }
    }

    private bool isCanceledPhase
    {
        get
        {
            return finger.phase == TouchPhase.Canceled;
        }
    }


    


}
