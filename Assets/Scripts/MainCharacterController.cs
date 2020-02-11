using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public GameObject door1;
    public GameObject door2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUp = 0;
        if (Input.GetKeyDown("space") && transform.position.y == 0.5)
        {
            moveUp = 20.0f;
        }
        Vector3 movement = new Vector3(moveHorizontal, moveUp, moveVertical);
        rb.AddForce(movement * speed);
        if (transform.position.y < 0)
        {
            gameObject.SetActive(false);
        }
        if(count >= 2)
        {
            door1.SetActive(false);
        }
        if(count >= 4)
        {
            door2.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
        }

        if (other.gameObject.CompareTag("parts"))
        {
            other.transform.parent = transform;
        }
    }

}
