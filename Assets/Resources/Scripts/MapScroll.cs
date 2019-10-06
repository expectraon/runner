using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Transform leftPos;
    public Transform rightPos;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-moveSpeed * Time.deltaTime * 2.5f, 0, 0);

        if (this.transform.localPosition.x < leftPos.localPosition.x)
            this.transform.localPosition = rightPos.localPosition;
    }
}