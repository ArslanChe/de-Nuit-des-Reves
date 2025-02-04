using UnityEngine;

public class ElectricAttack : MonoBehaviour
{
    public GameObject electricBoltPrefab;
    public float electricAttackCooldown = 5f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            PerformElectricAttack();
        }
    }

    void PerformElectricAttack()
    {
        nextAttackTime = Time.time + electricAttackCooldown;
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        GameObject electricBolt = Instantiate(electricBoltPrefab, transform.position, Quaternion.identity);
        electricBolt.GetComponent<ElectricBolt>().SetDirection(randomDirection);
    }
}