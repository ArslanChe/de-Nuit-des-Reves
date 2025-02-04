using UnityEngine;

public class LavaAttack : MonoBehaviour
{
    public GameObject lavaPrefab;
    public float lavaDuration = 5f;
    public float cooldown = 10f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            PerformLavaAttack();
        }
    }

    void PerformLavaAttack()
    {
        nextAttackTime = Time.time + cooldown;
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        GameObject lava = Instantiate(lavaPrefab, spawnPosition, Quaternion.identity);
        Destroy(lava, lavaDuration);
    }
}