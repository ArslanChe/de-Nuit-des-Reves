using UnityEngine;

public class BirdBossMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;
    public float attackSpeed = 10f;
    public float returnSpeed = 5f; 
    public float attackCooldown = 4f; 

    private Vector3 targetPosition; 
    private Vector3 startPosition;
    private bool isAttacking = false;
    private float nextAttackTime = 0f;

    void Start()
    {
        targetPosition = pointB.position;
        startPosition = transform.position; 
    }

    void Update()
    {
        if (!isAttacking)
        {
            MoveHorizontally();
            
            if (Time.time >= nextAttackTime) 
            {
                StartCoroutine(Attack());
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void MoveHorizontally()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }

    private System.Collections.IEnumerator Attack()
    {
        isAttacking = true;

        Vector3 attackPosition = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);

       
        while (Vector3.Distance(transform.position, attackPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, attackPosition, attackSpeed * Time.deltaTime);
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
