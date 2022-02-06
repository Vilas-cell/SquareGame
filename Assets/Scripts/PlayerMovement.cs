using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forvardForce = 1500;
    public float sidewaysForce = 500;
    public bool isGrounded;
    
    void OnCollisionEnter()
    {
        isGrounded = true;
    }
       
    void Update()
    {
        
        rb.AddForce(0, 0, forvardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
         
            isGrounded =false;
            rb.AddForce(new Vector3(0, 800, 0));

        }
        if(isGrounded == false)
        {
            sidewaysForce = 0;
        }
        else
        {
            sidewaysForce = 100;
        }
        
        if (rb.position.y < -1)
        { 
                FindObjectOfType<GameManager>().EndGame();
        }
    }


}
