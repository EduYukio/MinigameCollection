using UnityEngine;


public class GameManager : MonoBehaviour
{
    BlockSpawner blockSpawner;
    [HideInInspector] public static int round = 1;
    bool canThrow = true;

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
        blockSpawner = GetComponent<BlockSpawner>();
        blockSpawner.SpawnLineOfBlocks(round);
    }
}