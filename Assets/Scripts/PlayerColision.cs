using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public PlayerMovement movement;
    public bool isImmortal = false;
   
    public void OnCollisionEnter(Collision collisionInfo)
    {
       
        if (collisionInfo.collider.tag == "BonusShield")
        {
            StartCoroutine(ShieldBonus());
            Destroy(collisionInfo.collider.gameObject);
        }
       if (collisionInfo.collider.tag == "Obstacle" && isImmortal)
        {
           
            Destroy(collisionInfo.collider.gameObject);
            
        }
       else
       if (collisionInfo.collider.tag == "Obstacle" || collisionInfo.collider.tag == "Wall")
           {
           
            movement.enabled = false;
           
            FindObjectOfType<GameManager>().EndGame();
           }     
    }

    public IEnumerator ShieldBonus()
    {
        Debug.Log("start");
        isImmortal = true;
        yield return new WaitForSeconds(10);
        isImmortal = false;
    }

}
