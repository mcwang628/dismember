using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] enemies;
    public int enemiesDefeated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDefeated == 1)
        {
            doors[0].GetComponent<Animator>().SetBool("Open", true);
            enemies[1].SetActive(true);
        }
        if (enemiesDefeated == 2)
        {
            doors[1].GetComponent<Animator>().SetBool("Open", true);
            enemies[2].SetActive(true);
        }
        if (enemiesDefeated == 3)
        {
            doors[2].GetComponent<Animator>().SetBool("Open", true);
            enemies[3].SetActive(true);
        }
        if (enemiesDefeated == 4)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
