using UnityEngine;

public class JellySetting : MonoBehaviour
{
    private Vector3[] childsPos;
    private Transform[] childs;
    public GameObject Target;

    void Awake()
    {
        childs = this.GetComponentsInChildren<Transform>();
        childsPos = new Vector3[childs.Length];
        for (int i = 1; i < childs.Length; i++)
        {
            childsPos[i - 1] = childs[i].gameObject.transform.localPosition;
        }
    }

    void Reset()
    {
        for (int i = 1; i < childs.Length; i++)
        {
            childs[i].gameObject.transform.localPosition = childsPos[i - 1];
            childs[i].gameObject.SetActive(true);
            childs[i].GetComponent<BBalyer>().target = this.Target;
        }
    }

    void OnEnable()
    {
        Reset();
    }

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }
}