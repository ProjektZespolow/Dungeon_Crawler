using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public GameObject potion;
    public int health;
    public int maxHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        potion = GameObject.FindGameObjectWithTag("PotionHP");
    }
    

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
        animator.SetTrigger("PlayerHurt");

        if(health <= 0)
        {
            health = 0;
            animator.SetBool("isDead", true);
            OnPlayerDeath?.Invoke();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

        }
    }
    public void Heal(int amount)
    {
        Debug.Log("leczenie");
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
            //GetComponent<Collider2D>().enabled = false;
            //GetComponent<PlayerMovement>().enabled = false;
        }
    }


}
