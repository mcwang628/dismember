using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class HpController : MonoBehaviour
{

  public int atk;
  public int def;
  public int hpValue;
  public GameObject boss;
  public GameObject player;
  public GameObject hp;
  private Vector3 offset;
  private Rigidbody rb;
  private float hpScale = 0f;

  void Start()
  {
    hpScale = 3.0f / hpValue;
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    hp.transform.localScale = new Vector3(hpScale * hpValue, 0.3f, 0.3f);
  }

  private void OnTriggerEnter(Collider other)
  {
        if (other.gameObject.CompareTag("weapon"))
        {
            print("hit");
            hpValue -= GameObject.Find("CS4455MC").GetComponent<MainCharacterController>().atk - def;
            // boss.transform.position -= new Vector3(0, 0, 3.0f);
            rb.AddForce(3, 3, 3, ForceMode.Impulse);
        }
        if (hpValue <= 0)
        {
            boss.gameObject.SetActive(false);
            hp.gameObject.SetActive(false);
            FindObjectOfType<GameController>().enemiesDefeated += 1;
        }

    }

}


