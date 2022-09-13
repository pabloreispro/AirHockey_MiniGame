using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUps
{
    void DoPowerUp(GameObject playerGameObject);
}

public class Expand : IPowerUps 
{
    public void DoPowerUp(GameObject playerGameObject)
    {
        Vector3 newScale = new Vector3(2.5f,0.15f,2.5f);
        playerGameObject.transform.localScale = newScale;
    }
}
public class DoubleSpeed : IPowerUps
{
    public void DoPowerUp(GameObject playerGameObject)
    {   
        string nameGameObject = playerGameObject.name;

        if(nameGameObject == "Player1")
        {
            float vel = (playerGameObject.GetComponent<Player1>().speed * 2f);
            playerGameObject.GetComponent<Player1>().speed = vel;
        }
        else if(nameGameObject == "Player2")
        {
            float vel = (playerGameObject.GetComponent<Player2>().speed * 2f);
            playerGameObject.GetComponent<Player2>().speed = vel;
        }
        
    }
}
public class Target : IPowerUps
{
    public void DoPowerUp(GameObject playerGameObject)
    {
        string nameGameObject = playerGameObject.name;

        if(nameGameObject == "Player1")
        {
            Vector3 scaleTarget = new Vector3(2f,0.15f,2f);
            playerGameObject.transform.localScale = scaleTarget;
            float vel = (playerGameObject.GetComponent<Player1>().speed /2);
            playerGameObject.GetComponent<Player1>().speed = vel;
        }
        else if(nameGameObject == "Player2")
        {
            Vector3 scaleTarget = new Vector3(2f,0.15f,2f);
            playerGameObject.transform.localScale = scaleTarget;
            float vel = (playerGameObject.GetComponent<Player2>().speed /2);
            playerGameObject.GetComponent<Player2>().speed = vel;
        }
        
    }
}
