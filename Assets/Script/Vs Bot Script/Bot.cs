using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bot : MonoBehaviour
{

    public Transform ball;
    public Transform enemy;
    [SerializeField] private float BotSpeed = 1f;
    private Vector2 destination;

    private Animator anim;

    [Header("SFX")]
    [SerializeField] private AudioSource bonkSFX;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void MoveToBall()
    {
        destination = new Vector2(enemy.transform.position.x, ball.position.y);
        transform.position = Vector2.Lerp(enemy.transform.position, destination, BotSpeed * Time.deltaTime);
        anim.SetBool("isMoving", ball.position.y != 0);
    }

    void Update()
    {
        MoveToBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            
            anim.SetTrigger("goAttack");
            bonkSFX.Play();
        }
    }

}
