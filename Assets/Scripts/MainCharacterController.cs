using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCharacterController : MonoBehaviour
{
  public float speed;
  private Rigidbody rb;
  private int count;
  public GameObject door1;
  public GameObject door2;
  public int atk;
  public int def;
  public int hpValue;
  public GameObject playerBody;
  public GameObject hpBar;
  private Vector3 offset;
  private float hpScale = 0f;



  void Start()
  {
    rb = GetComponent<Rigidbody>();
    //count = 0;
    //atk = 3;
    //offset = new Vector3(0, 3, 0);
    hpScale = 3.0f / hpValue;
  }

  void FixedUpdate()
  {

    //hpBar.transform.position = playerBody.transform.position + offset;
    hpBar.transform.localScale = new Vector3(hpScale * hpValue, 0.3f, 0.3f);
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("bosses"))
    {
      print("hitten");
      hpValue -= other.gameObject.GetComponent<HpController>().atk - def;
      //rb.AddForce(new Vector3(100f, 100f ,100f));
      rb.AddForce(1, 1, 1, ForceMode.Impulse);

      if (hpValue <= 0)
        {
            SceneManager.LoadScene("GameScene");
        }
     }
    
  }

}
