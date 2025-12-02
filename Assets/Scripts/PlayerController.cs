using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform inventoryUI;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("xSpeed", rb.linearVelocity.x);
        anim.SetFloat("ySpeed", rb.linearVelocity.y);

        if (rb.linearVelocity.magnitude < 0.1)
            anim.speed = 0.0f;
        else
            anim.speed = 1.0f;

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.gameObject.activeSelf == true)
            {
                inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                string inventoryList = GetComponent<Inventory>().GetInventoryString();
                inventoryUI.GetChild(1).GetComponent<TextMeshProUGUI>().text = inventoryList;
                inventoryUI.gameObject.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        float speed = 4.0f;
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }
}
