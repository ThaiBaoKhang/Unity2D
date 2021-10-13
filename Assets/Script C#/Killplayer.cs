using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killplayer : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;
    public Animator amt;
    public bool isDeadPlayer = false;
    public bool invincible = false;
    public float invincibilityTime = 5f;
    private static int lives = 3;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject[] livesimage;

    public int RemainsLives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }
    public Killplayer(int livesRemain)
    {
        this.RemainsLives = livesRemain;
    }

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible)
        {
            if (isDeadPlayer == false && collision.transform.CompareTag("Player"))
            {
                amt.SetInteger("AniWalk", 0);
                amt.SetInteger("AniJump", 0);
                amt.SetInteger("AniDie", 1);
                isDeadPlayer = true;
                RemainsLives -= 1;
                if (RemainsLives <= 0)
                {
                    updateHealthUI();
                    EndGame();
                }
                else
                {
                    updateHealthUI();
                    StartCoroutine(SpawnPlayer());
                }
            }
        }

    }

    IEnumerator SpawnPlayer()
    {
        StartCoroutine(Pause(3));
        yield return new WaitForSeconds(2);
        amt.SetInteger("AniDie", 0);
        isDeadPlayer = false;
        StartCoroutine(Invulnerability());
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }

    IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void updateHealthUI()
    {
        for (int i = 0; i < livesimage.Length; i++)
        {
            if (i >= RemainsLives)
                livesimage[i].SetActive(false);
            else
                livesimage[i].SetActive(true);
        }
    }
}
