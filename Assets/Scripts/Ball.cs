using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    Rigidbody2D rb;

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