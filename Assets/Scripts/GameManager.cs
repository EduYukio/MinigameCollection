using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public static int round = 1;
    [HideInInspector] public readonly List<List<GameObject>> lines = new();

    private BlockSpawner blockSpawner;
    private bool canThrow = true;

    public bool CanThrow()
    {
        return canThrow;
    }

    public void StartNextRound()
    {
        round++;
        SetCanThrow(true);

        blockSpawner.MoveLinesDown();
        blockSpawner.SpawnLineOfBlocks(round);
    }

    public void SetCanThrow(bool value)
    {
        canThrow = value;
    }

    private void Start()
    {
        blockSpawner = transform.Find("BlockSpawner").gameObject.GetComponent<BlockSpawner>(); ;
        blockSpawner.SpawnLineOfBlocks(round);
    }

    private void ManageLines(GameObject block, List<GameObject> line)
    {
        line.Remove(block);
        if (line.Count == 0)
        {
            lines.Remove(line);
        }
    }

    private void OnEnable()
    {
        Block.WillBeDestroyed += ManageLines;
    }

    private void OnDisable()
    {
        Block.WillBeDestroyed -= ManageLines;
    }
}