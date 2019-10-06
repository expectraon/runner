using UnityEngine;

public class EnemyScroll : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Transform deathPos;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-moveSpeed * Time.deltaTime * 2.5f, 0, 0);
        if (deathPos != null)
        {
            if (this.transform.localPosition.x <= deathPos.localPosition.x)
                this.gameObject.SetActive(false);
        }
    }
}