using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] enemies;

    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Start is called before the first frame update
    void Start()
    { 
        for (int i = 4; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        StartCoroutine(LoadNextLevel());
    }

    // load nextlevel couroutine
    IEnumerator LoadNextLevel()
    {
        Debug.Log("Loading next level");
        yield return new WaitForSeconds(3);
        Debug.Log("Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
