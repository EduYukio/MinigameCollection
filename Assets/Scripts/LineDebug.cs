using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDebug : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Set the number of points in the line (2 for a simple line)
        lineRenderer.positionCount = 2;

        GameObject player = GameObject.Find("Player");
        Vector2 playerCenter = player.transform.position;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, playerCenter);  // Start point
        lineRenderer.SetPosition(1, mousePosition);  // End point

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.black;
    }
}
