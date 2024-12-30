using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public Transform launchPosition;
    GameManager gameManager;

    const float timeBetweenLaunches = 0.1f;

    private void Update()
    {
        if (!gameManager.CanThrow()) return;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerCenter = transform.position;
        Vector3 pointerVector = mousePosition - playerCenter;

        FollowMouse(pointerVector);
        CheckForThrowInput(pointerVector);
    }

    private void CheckForThrowInput(Vector3 pointerVector)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(ThrowBalls(pointerVector));
            gameManager.SetCanThrow(false);
        }
    }

    private IEnumerator ThrowBalls(Vector3 pointerVector)
    {
        for (int i = 0; i < GameManager.round; i++)
        {
            GameObject ballInstance = Instantiate(ball, launchPosition.position, Quaternion.identity);
            Ball ballInstanceScript = ballInstance.GetComponent<Ball>();
            ballInstanceScript.SetInitialParameters(pointerVector.normalized);
            yield return new WaitForSeconds(timeBetweenLaunches);
        }
    }

    private void FollowMouse(Vector3 pointerVector)
    {
        double angle = Math.Acos(pointerVector.x / pointerVector.magnitude) * (180 / Math.PI);
        if (pointerVector.y < 0)
        {
            angle *= -1;
        }

        transform.eulerAngles = new Vector3(0, 0, (float)angle - 90);
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}