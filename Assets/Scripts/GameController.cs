using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies[0].transform.childCount == 0)
        {
            doors[0].GetComponent<Animator>().SetBool("Open", true);
            enemies[1].SetActive(true);
        }
        if (enemies[1].transform.childCount == 0)
        {
            doors[1].GetComponent<Animator>().SetBool("Open", true);
            enemies[2].SetActive(true);
        }
        if (enemies[2].transform.childCount == 0)
        {
            doors[2].GetComponent<Animator>().SetBool("Open", true);
            enemies[3].SetActive(true);
        }
        if (enemies[3].transform.childCount == 0)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
