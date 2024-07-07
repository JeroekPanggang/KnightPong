using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private CapsuleCollider2D col;

    [Header("SFX")]
    public AudioSource SlashSFX;

    [Header("Kecepatan Player")]
    public float runSpeed = 10f;
    [Header("Lama Collider")]
    [SerializeField] private float attacktime = 0.3f;

    [Header("Batas Pergerakan")]
    public float boundUp = 3.8f;
    public float boundDown = 2.7f;

    public KeyCode Slash = KeyCode.Space;
    public KeyCode MoveUp = KeyCode.W;
    public KeyCode MoveDown = KeyCode.S;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();

        col.enabled = false;
    }

    private void Update()
    {

        // <----- MOVEMENT -----> ||   \\
        float verticalMove = 0f;
        if (Input.GetKey(MoveUp))
        {
            verticalMove = 1f; // Move Up
        } else if (Input.GetKey(MoveDown))
        {
            verticalMove -= 1f; // Move Down
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x, verticalMove * runSpeed);
        anim.SetBool("isMoving", verticalMove != 0);


        var pos = transform.position;
        if (pos.y > boundUp)
        {
            pos.y = boundUp;
        }
        else if (pos.y < -boundDown)
        {
            pos.y = -boundDown;
        }
        transform.position = pos;

        if (Input.GetKeyDown(Slash))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Debug.Log("Nyerang");
        anim.SetTrigger("goAttack");
        SlashSFX.Play();
        col.enabled = true;
        Invoke("offAttack", attacktime);
    }

    private void offAttack()
    {
        col.enabled = false;
    }
}
