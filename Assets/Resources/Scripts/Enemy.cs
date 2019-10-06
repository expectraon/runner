using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.CompareTo("Player") == 0)
        {
            col.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
        }
    }
}