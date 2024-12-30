using UnityEngine;

public class BallKiller : MonoBehaviour
{
    int ballsKilledThisRound = 0;
    GameManager gameManager;

    private void Start()
    {
        gameManager = transform.parent.gameObject.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //talvez melhorar isso transformando o GameManager em um manager 'global', igual o AudioManager no MP1
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            ballsKilledThisRound++;

            if (ballsKilledThisRound == GameManager.round)
            {
                gameManager.StartNextRound();
                ballsKilledThisRound = 0;
            }
        }
    }
}
