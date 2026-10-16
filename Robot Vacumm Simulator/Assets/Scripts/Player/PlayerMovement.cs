using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject player;
    [SerializeField] float speedMultiplier;
    [SerializeField] float defaultSpeed;
    public bool canMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    void Move()
    {
       

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Rotate(0, -1, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Rotate(0, 1, 0);
        }
        else 
            if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = player.transform.forward * defaultSpeed * speedMultiplier;
        }
        else
        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = player.transform.forward * -0.75f;
        }

    }

}
