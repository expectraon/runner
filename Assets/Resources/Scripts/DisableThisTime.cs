using UnityEngine;

public class DisableThisTime : MonoBehaviour
{
    public float DisableTime = 1.0f;
    void OnEnable()
    {
        Invoke("Disable", DisableTime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}