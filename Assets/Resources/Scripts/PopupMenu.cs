using UnityEngine;
using UnityEngine.UI;

public class PopupMenu : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
        this.transform.localScale = Vector3.zero;
    }

    public void Control(Toggle toggle)
    {
        Debug.Log("timeScale" + Time.timeScale);
        if (toggle.isOn)
        {
            Popup();
        }
        else
        {
            Popdown();
        }
    }

    public void Popup()
    {
        Time.timeScale = 0.0f;
        anim.Play("popup");
    }

    public void Popdown()
    {
        Time.timeScale = 1.0f;
        anim.Play("popdown");
    }
}