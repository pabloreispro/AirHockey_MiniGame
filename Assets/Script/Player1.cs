using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Player1 : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public IPowerUps strategy;
    
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
        rb.velocity = Vector3.Lerp(rb.velocity,new Vector3(GetAxis(KeyCode.W,KeyCode.S) * speed,0,GetAxis(KeyCode.A,KeyCode.D)* speed), Time.deltaTime * 10f); 
    }

    public void ControlPowerUps()
    {
        if(GameController.instance.s1 == 1)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                strategy = new Expand();
                StartCoroutine(Coroutine());
            }
        }
        else if(GameController.instance.s1 == 2)
        {
            if(Input.GetKey(KeyCode.E))
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




