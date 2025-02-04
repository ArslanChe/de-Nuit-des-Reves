using UnityEngine;

public class BeeSwarmSummon : MonoBehaviour
{
    public GameObject beeMinionPrefab;
    public Transform[] spawnPoints;
    public int minionCount = 3;
    public float summonCooldown = 8f;

    private float nextSummonTime = 0f;

    void Update()
    {
        if (Time.time >= nextSummonTime)
        {
            SummonSwarm();
            nextSummonTime = Time.time + summonCooldown;
        }
    }

    void SummonSwarm()
    {
        for (int i = 0; i < minionCount; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(beeMinionPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}