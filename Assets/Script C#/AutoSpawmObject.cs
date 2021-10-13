using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawmObject : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject gameObjectUI;

    [SerializeField] private GameOverUI gameUI;

    public Transform[] sprite_spawnPoint;

    public GameObject[] sprite_pic;

    public static bool Easy;

    public bool IsEasy
    {
        get
        {
            return Easy;
        }
        set
        {
            Easy = value;
        }
    }

    public void Start()
    {
        IsEasy = gameUI.curreEasy;

        if (IsEasy)
        {
            StartCoroutine(spawnSwordEasy());
        }
        else
        {
            StartCoroutine(spawnSwordHard());
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private IEnumerator spawnSwordEasy()
    {

        while (true)
        {
            yield return new WaitForSeconds(2f);
            int randSpritepic = Random.Range(0, sprite_pic.Length);
            int randomSpawnPoint = Random.Range(0, sprite_spawnPoint.Length);
            Instantiate(sprite_pic[randSpritepic], sprite_spawnPoint[randomSpawnPoint].position, sprite_spawnPoint[randSpritepic].rotation);

        }
           
    }

    private IEnumerator spawnSwordHard()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            int randSpritepic = Random.Range(0, sprite_pic.Length);
            int randomSpawnPoint = Random.Range(0, sprite_spawnPoint.Length);
            Instantiate(sprite_pic[randSpritepic], sprite_spawnPoint[randomSpawnPoint].position, sprite_spawnPoint[randSpritepic].rotation);

        }

    }

}


