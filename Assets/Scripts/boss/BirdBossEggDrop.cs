using UnityEngine;

public class BirdBossEggDrop : MonoBehaviour
{
    public GameObject eggPrefab;
    public Transform dropPoint; 
    public float dropInterval = 2f;

    private float nextDropTime = 0f;

    void Update()
    {
        if (Time.time >= nextDropTime)
        {
            DropEgg();
            nextDropTime = Time.time + dropInterval;
        }
    }

    private void DropEgg()
    {
        Instantiate(eggPrefab, dropPoint.position, Quaternion.identity);
    }
}