using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Action<GameObject, List<GameObject>> WillBeDestroyed;

    private int lives = 1;
    private GameObject livesIndicator;
    private List<GameObject> line;

    public void Initialize(int initialLives, List<GameObject> initialLine)
    {
        lives = initialLives;
        line = initialLine;
    }

    public void GotHit()
    {
        lives--;
        if (lives <= 0)
        {
            WillBeDestroyed?.Invoke(gameObject, line);
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
