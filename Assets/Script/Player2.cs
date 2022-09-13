using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    
    public float speed;
    public Rigidbody rb;
    public IPowerUps strategy;
    
    Vector3 scale = new Vector3(1.5f,0.15f,1.5f);
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        speed = Mathf.Clamp(speed,10f,20f);
        Move();
        ControlPowerUps(); 
    }

    public float GetAxis(KeyCode L, KeyCode R)
    {
        return (Input.GetKey(L) ? -1 : 0) + (Input.GetKey(R) ? 1 : 0);
    }

    public void Move()
    {
        rb.velocity = Vector3.Lerp(rb.velocity,new Vector3(GetAxis(KeyCode.UpArrow,KeyCode.DownArrow) * speed,0,GetAxis(KeyCode.LeftArrow,KeyCode.RightArrow)* speed), Time.deltaTime * 10f); 
    }
    public void ControlPowerUps()
    {
        if(GameController.instance.s2 == 1)
        {
            if(Input.GetKey(KeyCode.K))
            {
                strategy = new Expand();
                StartCoroutine(Coroutine());
            }
        }
        else if(GameController.instance.s2 == 2)
        {
            if(Input.GetKey(KeyCode.L))
            {
                print("aasa");
                strategy = new DoubleSpeed();
                StartCoroutine(Coroutine());
            }
        }
    } 

    IEnumerator Coroutine()
    {
        strategy.DoPowerUp(gameObject);
        yield return new WaitForSeconds(6f);

        strategy = new Target();
        strategy.DoPowerUp(gameObject);
    }
    
    
}
