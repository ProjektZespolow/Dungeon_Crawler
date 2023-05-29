using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioSource swing;

    public Animator myAnim;

    public bool isAttacking = false;
    public static PlayerController instance;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    static public int attackDamage = 20;
    //-----------------------------------------------------------

    private float attackTimer = 0;
    private float attackCd = .35f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Attack();

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            
            attackTimer = attackCd;

            if (isAttacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    isAttacking = false;
                }

            }

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<SkeletonEnemy>().TakeDamage(attackDamage);
            }

            Debug.Log("Atakuje " + attackDamage);
            swing.Play();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator Waiter()
    {

        yield return new WaitForSeconds(0.4f);
    }


}
