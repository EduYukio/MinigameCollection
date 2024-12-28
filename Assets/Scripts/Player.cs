using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public Transform launchPosition;
    const float timeBetweenLaunches = 0.1f;
    // GameManager gameManager;

    // private void Start()
    // {
    //     gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    // }

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
            StartCoroutine(ThrowBall(pointerVector));
        }
    }

    IEnumerator ThrowBall(Vector3 pointerVector)
    {
        for (int i = 0; i < GameManager.round; i++)
        {
            GameObject ballInstance = Instantiate(ball, launchPosition.position, Quaternion.identity);
            Ball ballInstanceScript = ballInstance.GetComponent<Ball>();
            ballInstanceScript.SetInitialParameters(pointerVector.normalized);
            yield return new WaitForSeconds(timeBetweenLaunches);
        }
    }
}