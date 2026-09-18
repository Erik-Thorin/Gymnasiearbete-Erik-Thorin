using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
            rb.linearVelocity = player.transform.forward;
        }

    }

}
