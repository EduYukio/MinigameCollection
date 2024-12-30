using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    public void SetInitialParameters(Vector2 direction)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"DBG: OnTriggerEnter2D other = {other}");

        switch (other.tag)
        {
            case "Block":
                other.gameObject.GetComponent<Block>().GotHit();
                break;
            case "TopBotWall":
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
                break;
            case "SideWall":
                rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
                break;
                // default:
                //     break;
        }

        //checar se dá pra fazer um switch
        // if (other.CompareTag("Block"))
        // {
        //     other.gameObject.GetComponent<Block>().GotHit();
        // }
        // else if (other.CompareTag("TopBotWall"))
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
        // }
        // else if (other.CompareTag("SideWall"))
        // {
        //     rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
        // }
    }
}