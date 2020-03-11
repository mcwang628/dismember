using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyHpController : MonoBehaviour
{
    public int atk;
    public int def;
    public int hpValue;
    public GameObject Player;
    public GameObject hpBar;

    private Rigidbody rb;
    private float hpScale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hpScale = hpBar.transform.localScale.x / hpValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("weapon"))
        {
            //print("hit");
            hpValue -= (Player.GetComponent<PlayerHP>().atk - def);
            hpBar.transform.localScale = new Vector3(hpScale * hpValue, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            rb.AddForce(3, 3, 3, ForceMode.Impulse);
        }
        if (hpValue <= 0)
        {
            Destroy(gameObject);
        }

    }

}


