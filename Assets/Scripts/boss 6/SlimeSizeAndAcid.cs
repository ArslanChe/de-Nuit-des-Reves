using UnityEngine;

public class SlimeSizeAndAcid : MonoBehaviour
{
    public float sizeIncreaseRate = 0.1f;
    public float maxSize = 2f;
    public GameObject acidProjectilePrefab;
    public float acidSpeed = 12f;
    public float acidCooldown = 4f;
    public int acidDamage = 20;

    private float nextAcidTime = 0f;
    //private bool isGrowing = false;

    void Update()
    {
        if (transform.localScale.x < maxSize)
        {
            transform.localScale += new Vector3(sizeIncreaseRate, sizeIncreaseRate, 0) * Time.deltaTime;
        }

        if (Time.time >= nextAcidTime)
        {
            nextAcidTime = Time.time + acidCooldown;
            ShootAcid();
        }
    }

    void ShootAcid()
    {
        GameObject acidProjectile = Instantiate(acidProjectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = acidProjectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, -acidSpeed);
    }
}