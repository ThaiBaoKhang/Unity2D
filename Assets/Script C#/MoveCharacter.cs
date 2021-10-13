using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCharacter : MonoBehaviour
{
    // Start is called before the first frame update

    public static MoveCharacter playerz;
    public float speed = 10f;
    private Animator amt;
    private Rigidbody2D rb2;
    [SerializeField] private LayerMask platformsLayerMask;
    private BoxCollider2D bc2;
    private bool IsKnocked = false;

    public Killplayer isDead;

    private void Awake()
    {
        playerz = this;
    }
    void Start()
    {
        rb2 = transform.GetComponent<Rigidbody2D>();
        amt = gameObject.GetComponent<Animator>();
        bc2 = transform.GetComponent<BoxCollider2D>();
        isDead.isDeadPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(!isDead.isDeadPlayer)
        {
            if (IsKnocked == false && IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                float jumpVelocity = 80f;
                rb2.velocity = Vector2.up * jumpVelocity;
            }

            handlemovement();

            if (IsGrounded())
            {
                amt.SetInteger("AniJump", 0);

            }
            else
            {
                amt.SetInteger("AniJump", 1);
            }
        }
        else
        {
            StartCoroutine(Dead());
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(bc2.bounds.center, bc2.bounds.size, 0f, Vector2.down, 1f , platformsLayerMask);
        return raycast.collider != null;
    }

    private void handlemovement()
    {
        float movespeed = 10f;
        if (Input.GetKey(KeyCode.A))
        {
            rb2.velocity = new Vector2(-movespeed, rb2.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
            amt.SetInteger("AniWalk", 1);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb2.velocity = new Vector2(+movespeed, rb2.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);
                amt.SetInteger("AniWalk", 1);
            }
            else
            {
                rb2.velocity = new Vector2(0, rb2.velocity.y);
                amt.SetInteger("AniWalk", 0);
            }
        }

    }

    public IEnumerator KnockBack(float knockbackDuration, float knockbackPower,Transform obje)
    {
        float timer = 0;
        while (knockbackDuration > timer)
        {
            IsKnocked = true;
            timer += Time.deltaTime;
            Vector2 direction = (obje.transform.position - this.transform.position);
            rb2.AddForce(-direction * knockbackPower/6);
        }
        IsKnocked = false;
        yield return 0;
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2f);
        
    }
}
   


