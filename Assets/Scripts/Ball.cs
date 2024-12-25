using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Vector2 direction;

    private void Start()
    {
        GameObject launchPositionObject = GameObject.Find("LaunchPosition");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 launchPosition = transform.TransformPoint(launchPositionObject.transform.position);
        direction = (mousePosition - launchPosition).normalized;
        Debug.Log("");
        Debug.Log(mousePosition);
        Debug.Log(launchPosition);
        Debug.Log(direction);
        Debug.Log("");
        GameObject gameObject = transform.gameObject;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    // private void Update()
    // {

    // }
}