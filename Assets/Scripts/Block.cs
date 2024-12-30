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

    public void GotHit()
    {
        lives--;
        if (lives <= 0)
        {
            Destroy(gameObject, 0.01f);
        }
        else
        {
            UpdateLivesText();
        }
    }

    private void Start()
    {
        livesIndicator = transform.Find("LivesIndicator").gameObject;
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        livesIndicator.GetComponent<TextMeshPro>().text = lives.ToString();
    }
}
