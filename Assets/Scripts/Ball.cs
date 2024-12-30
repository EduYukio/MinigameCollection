using System;
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
        switch (other.tag)
        {
            case "Block":
                other.gameObject.GetComponent<Block>().GotHit();
                Vector2 ballCenter = transform.position;
                Vector2 blockCenter = other.transform.position;

                Vector2 pointerVector = blockCenter - ballCenter;

                float x = Math.Abs(pointerVector.x);
                float y = Math.Abs(pointerVector.y);

                if (Math.Abs(x - y) < 0.1)
                {
                    //quina
                    bool vectorsHaveSameXSign = (rb.velocity.x > 0 && pointerVector.x > 0) || (rb.velocity.x < 0 && pointerVector.x < 0);
                    bool vectorsHaveSameYSign = (rb.velocity.y > 0 && pointerVector.y > 0) || (rb.velocity.y < 0 && pointerVector.y < 0);
                    if (vectorsHaveSameXSign && vectorsHaveSameYSign)
                    {
                        rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y * -1);
                    }
                    else
                    {
                        bool vectorsDifferOnX = (rb.velocity.x > 0 && pointerVector.x < 0) || (rb.velocity.x < 0 && pointerVector.x > 0);
                        if (vectorsDifferOnX)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
                        }
                        else
                        {
                            rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
                        }
                    }
                }
                else if (y > x)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
                }
                else if (x > y)
                {
                    rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
                }
                break;
            case "TopBotWall":
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
                break;
            case "SideWall":
                rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
                break;
        }
    }
}