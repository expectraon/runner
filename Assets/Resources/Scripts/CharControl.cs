using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class CharControl : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public bool isGrounded = false;
    public int jumpCount = 1;
    public LayerMask mask;
    private float currentHp;
    private float showHp;
    public float maxHp;
    public GameObject HpBar;

    private float twinkleStartTime;
    private float twinkleTime = 0;
    private bool isTwinkle = false;
    public float twinkleInterval = 0.1f;
    public float totalTwinkleTime = 1.0f;

    public Toggle toggle;
    public PopupMenu panel;

    private Image image;

    private void Awake()
    {
        currentHp = showHp = maxHp;
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            toggle.enabled = false;
            panel.Popup();
        }
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        Vector3 pos = this.transform.position;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector2(pos.x, pos.y), -Vector2.up, this.GetComponent<BoxCollider2D>().bounds.size.y / 2 + 1, mask.value);
        Debug.DrawLine(pos, pos - (Vector3.up * (this.GetComponent<BoxCollider2D>().bounds.size.y / 2) + new Vector3(0, 1, 0)));
        if (hit.collider != null)
        {
            isGrounded = true;
            jumpCount = 1;
        }
        else
        {
            isGrounded = false;
        }
        if (showHp > currentHp)
        {
            showHp -= Time.deltaTime;
        }
        HpBar.GetComponent<Image>().fillAmount = showHp / maxHp;
        if (isTwinkle && Time.time - twinkleStartTime > totalTwinkleTime)
        {
            isTwinkle = false;
            image.enabled = true;
        }
        if (isTwinkle)
        {
            if (Time.time - twinkleTime > twinkleInterval)
            {
                twinkleTime = Time.time;
                if (image.enabled)
                {
                    image.enabled = false;
                }
                else
                {
                    image.enabled = true;
                }
            }
        }
    }

    public void Jump()
    {
        if (jumpCount > 0)
        {
            jumpCount--;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Damage()
    {
        if (!isTwinkle)
        {
            twinkleStartTime = Time.time;
            isTwinkle = true;

            Debug.Log("맞았다..");
            currentHp -= 1;
        }
    }
}