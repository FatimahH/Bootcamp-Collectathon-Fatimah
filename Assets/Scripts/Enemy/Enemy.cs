using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private string currentState = "IdleState";
    private float playerDistance;
    private float health;

    [SerializeField] private float speed;
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float maxHealth;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver())
        {
            enemyAnimator.enabled = false;

            this.enabled = false;

        }

        playerDistance = Vector3.Distance(player.transform.position, transform.position);

        if (player.GetComponent<PlayerController>().IsPlayerJumping())
        {
            currentState = "IdleState";
            enemyAnimator.SetBool("Run", false);
        }

        if (currentState == "IdleState")
        {
            if (playerDistance <= chaseRange)
            {
                currentState = "ChaseState";
                //playerDetected = true;
            }
        }
        else if (currentState == "ChaseState")
        {
            // play run animation
            enemyAnimator.SetBool("Run", true);
            enemyAnimator.SetBool("IsAttacking", false);

            if (playerDistance <= attackRange)
            {
                currentState = "AttackState";
            }

            if (player.transform.position.x > transform.position.x)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            else
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }
        }
        else if (currentState == "AttackState")
        {
            enemyAnimator.SetBool("IsAttacking", true);

            if (playerDistance > attackRange)
            {
                currentState = "ChaseState";
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;

        currentState = "ChaseState";

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //play death animation
        enemyAnimator.SetTrigger("IsDead");

        //Disable collider & script
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }
}
