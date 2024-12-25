using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public Transform launchPosition;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 direction = mousePosition - transform.position;
        //fazer player rotacionar de acordo com a direção entre o mouse e o player

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(ball, launchPosition.position, Quaternion.identity);
        }
    }
}