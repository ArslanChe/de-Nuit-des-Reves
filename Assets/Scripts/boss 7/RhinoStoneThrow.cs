using UnityEngine;

public class RhinoStoneThrow : MonoBehaviour
{
    public GameObject stonePrefab;
    public float throwSpeed = 10f;
    public int stoneDamage = 60;
    public float throwCooldown = 3f;
    private float nextThrowTime = 0f;

    void Update()
    {
        if (Time.time >= nextThrowTime)
        {
            ThrowStone();
        }
    }

    void ThrowStone()
    {
        nextThrowTime = Time.time + throwCooldown;
        GameObject stone = Instantiate(stonePrefab, transform.position, Quaternion.identity);
        Vector3 direction = (FindObjectOfType<PlayerHealth>().transform.position - transform.position).normalized;
        Rigidbody2D stoneRb = stone.GetComponent<Rigidbody2D>();
        stoneRb.linearVelocity = direction * throwSpeed;
        Stone stoneScript = stone.GetComponent<Stone>();
        stoneScript.InitializeStone(stoneDamage);
    }
}