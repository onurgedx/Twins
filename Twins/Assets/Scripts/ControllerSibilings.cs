using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSibilings : Controller
{



    public override void ExtraMain()
    {
        base.ExtraMain();
        
        // Anim();
    }

    public override void TwiceTap()
    {
        gameObject.layer = 6 + 7 - gameObject.layer;
        GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,2) - GetComponent<SpriteRenderer>().material.color;
    }

    public override void Began()
    {
        base.Began();

        
        
    }

    public override void Stationary()
    {
        base.Stationary();
        //Move();
    }

    public override void Moved()
    {
        base.Moved();

       // Move();


    }



    public override void Ended()
    {
        base.Ended();
        DontMove();
    }

    public override void Canceled()
    {
        base.Canceled();
    }

    

    private float moveX
    {
        get
        {
            float xy = -BeganPos.x + finger.position.x;
            if (Mathf.Abs(xy) < 1)
            { xy = 0; }
            return xy;
           
        }
    }

    private float moveY
    {
        get
        {
            float xy =-BeganPos.y + finger.position.y;
            if(Mathf.Abs(xy)<1)
            { xy = 0; }
            return xy;
        }
    }

    private Vector2 MoveAmount
    {
        get
        {
            return new Vector2(moveX, moveY).normalized*Time.fixedDeltaTime*Speed.speed;
        }
    }

    private void Move()
    {
        rg2d.velocity = MoveAmount;


    }
    private void DontMove()
    {
        rg2d.velocity = Vector2.zero;
    }

    private Rigidbody2D rg2d
    {
        get
        {
            return GetComponent<Rigidbody2D>();
        }
    }

    private Animator animator
    {
        get
        {
            return GetComponent<Animator>();
        }
    }


    private void FixedUpdate()
    {
        if (isTouch && isOnNotCanvas)
        {
            Move();
        }

        Anim();
            
    }

    private float degreeOfVelo
    {
        get
        {// gidilen yonun acisal karsýlgýný veriyo
            return Mathf.Rad2Deg*Mathf.Atan2(moveY, moveX);
        }
    }

    public IEnumerator AnimateDying()
    {   
        rg2d.freezeRotation = false;
        animator.SetInteger("statu", 5);
        
        yield return new WaitForSeconds(2f);
        Speed.Reset();
    }

    public bool isDying
    {
        get
        {
            return animator.GetInteger("statu") == 5;
        }
    }
     private void Anim()
    {
        if(!isDying)
        {

        
        int a;
        if(!isTouch)
        {
            a = 0;
        }
        else
        {
            if(Mathf.Abs(degreeOfVelo)<=45)
            { a = 1; }
            else if( Mathf.Abs(degreeOfVelo)>=135)
            {
                a = 3;
            }
            else if(degreeOfVelo>0)
            { a = 2; }
            else { a = 4; }

           
        }
        
        animator.SetInteger("statu", a);
        }

    }
     


}
