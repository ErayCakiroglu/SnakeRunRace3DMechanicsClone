using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContactController : MonoBehaviour
{
    private int gemCount = 10;
    private TextMeshPro gemText;
    void Start()
    {
        gemText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        gemText.text = gemCount.ToString();
    }
    /*The method that increases the gemCount number as a result of the interaction of the game object with the gem and destroys the gem it has touched, and runs the SetPlayerSpeedToZero() method as a result of the interaction with the end.*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            gemCount++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("End"))
        {
            SetPlayerSpeedToZero();
        }
    }
    /*Method that controls the interaction of the game object with the enemy by controlling the number of diamonds of the enemy.*/
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(gemCount < other.gameObject.GetComponent<AIController>().enemyGemCount)
            {
                SetPlayerSpeedToZero();
            }
            else if(gemCount > other.gameObject.GetComponent<AIController>().enemyGemCount)
            {
                gemCount += other.gameObject.GetComponent<AIController>().enemyGemCount;
                Destroy(other.gameObject);
            }
            
        }
    }
    /*A method that resets the speed of the player on the x-axis and z-axis and prints the text 'Game Over' on the console window.*/
    private void SetPlayerSpeedToZero()
    {
        PlayerController.instance.speed = 0;
        PlayerController.instance.xSpeed = 0;
        Debug.Log("Game Over");
    }
}
