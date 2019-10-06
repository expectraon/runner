using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EatJelly : MonoBehaviour
{
    private ObjectPool effects;

    void Awake()
    {
        effects = GameObject.Find("EffectPool").GetComponent<ObjectPool>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.CompareTo("Player") == 0)
        {
            effects.ActiveObject(this.transform.position);
            this.gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(50);
        }
    }
}