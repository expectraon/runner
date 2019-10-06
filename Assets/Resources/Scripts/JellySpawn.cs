using UnityEngine;

public class JellySpawn : MonoBehaviour
{
    public ObjectPool[] JellyPools;
    private float spawnTime = 0.0f;
    public float spawnInterval = 1.0f;
    public GameObject DeathPos;
    public GameObject Target;

    void Awake()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > spawnInterval)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        spawnTime = Time.time;
        int rnd = Random.Range(0, JellyPools.Length);
        GameObject newObj = JellyPools[rnd].ActiveObject(this.transform.localPosition);
        newObj.transform.localScale = new Vector3(1, 1, 1);
        newObj.GetComponent<EnemyScroll>().deathPos = this.DeathPos.transform;
        newObj.GetComponent<JellySetting>().Target = this.Target;
    }
}