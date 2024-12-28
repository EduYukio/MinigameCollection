using UnityEngine;


public class GameManager : MonoBehaviour
{
    BlockSpawner blockSpawner;
    [HideInInspector] public static int round = 1;

    public void StartNextRound()
    {
        round++;

        blockSpawner.MoveLinesDown();
        blockSpawner.SpawnLineOfBlocks(round);
    }

    private void Start()
    {
        blockSpawner = GetComponent<BlockSpawner>();
        blockSpawner.SpawnLineOfBlocks(round);
    }
}