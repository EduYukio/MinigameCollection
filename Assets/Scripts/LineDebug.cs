using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDebug : MonoBehaviour
{
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        // Get or add the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Set the number of points in the line (2 for a simple line)
        lineRenderer.positionCount = 2;

        GameObject player = GameObject.Find("Player");
        Vector2 playerCenter = player.transform.position;
        // Set the positions for the start and end points

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, playerCenter);  // Start point
        lineRenderer.SetPosition(1, mousePosition);  // End point

        // Optionally, you can customize the line's appearance
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.blue;
    }
}
