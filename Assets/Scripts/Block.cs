using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameObject livesIndicator;
    int lives = 1;

    public void SetLives(int initialLives)
    {
        lives = initialLives;
    }

    private void Start()
    {
        livesIndicator = transform.Find("LivesIndicator").gameObject;
        SetLivesText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            lives--;
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                SetLivesText();
            }
        }
    }

    private void SetLivesText()
    {
        livesIndicator.GetComponent<TextMeshPro>().text = lives.ToString();
    }
}
