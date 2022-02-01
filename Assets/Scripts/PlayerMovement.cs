using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forvardForce = 2000;
    public float sidewaysForce = 500;

    void Update()
    {
        rb.AddForce(0, 0, forvardForce * Time.deltaTime);

        if ( Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if ( Input.GetKey("a") )
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }
        if (rb.position.y < -1)
        { 
                FindObjectOfType<GameManager>().EndGame();


        }
    }


}
