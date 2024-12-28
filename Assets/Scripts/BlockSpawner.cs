using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject initialBlockPositionObject;

    const int maxBlocksPerLine = 10;
    const float horizontalDistanceBetweenBlocks = 0.55f;
    const float verticalDistanceBetweenBlocks = 0.625f;

    readonly List<List<GameObject>> lines = new();

    public void SpawnLineOfBlocks(int round)
    {
        List<GameObject> line = new();

        for (int i = 0; i < maxBlocksPerLine; i++)
        {
            //adicionar um random continue pra ter buracos na linha
            Vector3 initialPosition = initialBlockPositionObject.transform.position;
            float xBlockPosition = initialPosition.x + horizontalDistanceBetweenBlocks * i;
            Vector3 position = new(xBlockPosition, initialPosition.y, 0);

            GameObject blockInstance = Instantiate(blockPrefab, position, Quaternion.identity);
            Block blockScript = blockInstance.GetComponent<Block>();
            blockScript.SetLives(round);

            line.Add(blockInstance);
        }

        lines.Add(line);
    }

    public void MoveLinesDown()
    {
        Debug.Log($"MoveLinesDown, amount of lines: {lines.Count}");
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
}