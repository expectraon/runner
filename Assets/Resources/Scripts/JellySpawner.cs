using UnityEngine;

public class JellySpawner : MonoBehaviour
{
    public LayerMask mask;
    public ObjectPool pool;
    public float SpawnInterval = 1.0f;
    private float spawnTimer;
    public GameObject Target;
    public Transform DeathPos;
    private Vector2 position;
    public Transform GroundScanner;

    void Awake()
    {
        spawnTimer = 0.0f;
        position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTimer > SpawnInterval)
        {
            spawnTimer = Time.time;
            GameObject newObj = pool.ActiveObject(transform.localPosition);
            newObj.transform.localScale = new Vector3(1, 1, 1);
            newObj.GetComponent<BBalyer>().target = Target;
            newObj.GetComponent<EnemyScroll>().deathPos = DeathPos;
        }
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector2(GroundScanner.position.x, GroundScanner.position.y), -Vector2.up, 20, mask.value);

        if (hit.collider != null)
        {
            Vector3 pos = hit.point;
            pos.y += 1;
            pos.z = 2;
            transform.position = pos;
        }
        else
        {
            position.y = -203;
            transform.localPosition = position;
        }
    }
}