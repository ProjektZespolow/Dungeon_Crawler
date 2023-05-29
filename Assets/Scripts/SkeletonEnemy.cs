using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SkeletonEnemy : MonoBehaviour
{

    public float moveSpeed = 10f;
    Vector2 movement;
    public Rigidbody2D rb;

    public Animator animator;
    
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Died");

        animator.SetBool("IsDead", true);
        //Ta linijka przyda sie do naprawienia zadawania obrazen myAnim.SetBool("IsWalking", true)???

        GetComponent<Collider2D>().enabled = false;
        GetComponent<AIDestinationSetter>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        this.enabled = false;
    }


}
