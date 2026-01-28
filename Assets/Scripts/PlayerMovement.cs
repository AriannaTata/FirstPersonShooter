using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController cc;
    public float speed = 12f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public float jumpHeight = 1.5f;
    bool groundedPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = cc.isGrounded;

        if (groundedPlayer && velocity.y< 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity); //sqrt è la radice quadrata, formula matematica che raggiungiamo l'altezza max con una velocità per poi scendere;
                                                                   //-3.0 e -9.8 della gravità non vanno mai cambiati
        }

        velocity.y += gravity *Time.deltaTime; 
        cc.Move(velocity*Time.deltaTime);
    }
}
