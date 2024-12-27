using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    Rigidbody2D rb;

    private void Start()
    {
        // rb = gameObject.GetComponent<Rigidbody2D>();
        // GameObject launchPositionObject = GameObject.Find("LaunchPosition");
        // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector2 launchPosition = transform.TransformPoint(launchPositionObject.transform.position);
        // direction = (mousePosition - launchPosition).normalized;
        // GameObject gameObject = transform.gameObject;
        // rb = gameObject.GetComponent<Rigidbody2D>();
        // rb.velocity = direction * speed;
    }

    public void SetInitialParameters(Vector2 direction)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TopBotWall"))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
        }
        else if (other.CompareTag("SideWall"))
        {
            rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
        }
    }
}