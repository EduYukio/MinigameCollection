using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject initialBlockPositionObject;

    private const int maxBlocksPerLine = 10;
    private const int maxAmountOfHoles = 7;
    private const float chanceOfSpawningHole = 0.6f;
    private const float horizontalDistanceBetweenBlocks = 0.55f;
    private const float verticalDistanceBetweenBlocks = 0.55f;

    private GameManager gameManager;
    private List<List<GameObject>> lines;

    public void SpawnLineOfBlocks(int round)
    {
        List<GameObject> line = new();

        int amountOfHoles = 0;
        for (int i = 0; i < maxBlocksPerLine; i++)
        {
            if (MustSpawnHole(amountOfHoles))
            {
                amountOfHoles++;
                continue;
            }

            Vector3 initialPosition = initialBlockPositionObject.transform.position;
            float xBlockPosition = initialPosition.x + horizontalDistanceBetweenBlocks * i;
            Vector3 position = new(xBlockPosition, initialPosition.y, 0);

            GameObject blockInstance = Instantiate(blockPrefab, position, Quaternion.identity);
            Block blockScript = blockInstance.GetComponent<Block>();
            blockScript.Initialize(round, line);

            line.Add(blockInstance);
        }

        lines.Add(line);
    }

    public void MoveLinesDown()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            var currentLine = lines[i];
            for (int j = 0; j < currentLine.Count; j++)
            {
                var block = currentLine[j];
                if (block == null) continue;

                var pos = block.transform.position;
                block.transform.position = new Vector3(pos.x, pos.y - verticalDistanceBetweenBlocks, 0);
            }
            // fazer descer mais bonito com animação/interpolação ao inves de só setar position
        }
    }

    private bool MustSpawnHole(int amountOfHoles)
    {
        if (amountOfHoles >= maxAmountOfHoles) return false;
        if (UnityEngine.Random.Range(0f, 1f) > chanceOfSpawningHole) return false;

        return true;
    }

    private void Start()
    {
        gameManager = transform.parent.GetComponent<GameManager>();
        lines = gameManager.lines;
    }
}