using UnityEngine;

public class BirdBossAttack : MonoBehaviour
{
    public Transform attackTarget; 
    public float attackSpeed = 10f;
    public float returnSpeed = 5f;
    public float attackCooldown = 3f; 

    private Vector3 startPosition;
    private bool isAttacking = false;
    private float nextAttackTime = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isAttacking && Time.time >= nextAttackTime)
        {
            StartCoroutine(Attack());
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private System.Collections.IEnumerator Attack()
    {
        isAttacking = true;

        while (Vector3.Distance(transform.position, attackTarget.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, attackTarget.position, attackSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f); 

        while (Vector3.Distance(transform.position, startPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
            yield return null;
        }

        isAttacking = false;
    }
}