using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpandWin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameOverUI;
    public float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 0f, 1f), 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
            EndGame();
        }
    }
    public void EndGame()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
