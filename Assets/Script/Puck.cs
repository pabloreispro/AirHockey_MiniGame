using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puck : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Right"))
        {
            GameController.instance.ScoreLeft(1);
            Destroy(gameObject);
        }
        if(other.CompareTag("Left"))
        {
            GameController.instance.ScoreRight(1);
            Destroy(gameObject);
        }

    }
}
