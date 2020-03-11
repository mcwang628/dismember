using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int atk;
    public int def;
    public int hpValue;
    public GameObject hpBar;

    private Rigidbody rb;
    private float hpScale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hpScale = hpBar.transform.localScale.x / hpValue;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bosses"))
        {
            //print("hitten");
            hpValue -= (other.gameObject.GetComponent<EnemyHpController>().atk - def);
            hpBar.transform.localScale = new Vector3(hpScale * hpValue, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            rb.AddForce(1, 1, 1, ForceMode.Impulse);

            if (hpValue <= 0)
            {
                SceneManager.LoadScene("GameScene");
            }
        }

    }

}
