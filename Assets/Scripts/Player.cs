using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public Transform launchPosition;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerCenter = transform.position;
        Vector3 pointerVector = mousePosition - playerCenter;
        double angle = Math.Acos(pointerVector.x / pointerVector.magnitude) * (180 / Math.PI);
        if (pointerVector.y < 0)
        {
            angle *= -1;
        }

        transform.eulerAngles = new Vector3(0, 0, (float)angle - 90);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject ballInstance = Instantiate(ball, launchPosition.position, Quaternion.identity);
            Ball ballInstanceScript = ballInstance.GetComponent<Ball>();
            ballInstanceScript.SetInitialParameters(pointerVector.normalized);
        }
    }
}