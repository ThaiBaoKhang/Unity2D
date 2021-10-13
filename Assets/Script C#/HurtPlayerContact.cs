using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HurtPlayerContact : MonoBehaviour
{
    public float knockbackPower = 100;

    public float knockbackDuration = 1;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(MoveCharacter.playerz.KnockBack(knockbackDuration, knockbackPower, this.transform));

        }
    }
    
}
