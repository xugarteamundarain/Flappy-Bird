using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class LevelBlockGenerator : MonoBehaviour
{
    #region LevelBlock
    public LevelBlock levelBlock; // Bloque de nivel a generar
    public LevelBlock lastLevelBlock; // Ultimo bloque colocado
    public LevelBlock currentLevelBlock; // Nuevo bloque generado
    #endregion
    #region BlockPipe
    public Transform blockPipe;
    public float blockGenerationTime;
    #endregion
    
    private void Start()
    {
        AddNewBlock();
        
        InvokeRepeating("GenerateNewBlockPipe", 0, blockGenerationTime);
    }

    private void Update()
    {
        float camera_x = Camera.main.transform.position.x;
        float old_x = lastLevelBlock.exitPoint.position.x;
        
        if (camera_x > old_x + lastLevelBlock.width / 2)
        {
            RemoveOldBlock();
            // AddNewBlock();
        }
    }

    public void AddNewBlock()
    {
        LevelBlock block = (LevelBlock)Instantiate(levelBlock);
        block.transform.SetParent(this.transform, false); 
        Vector3 blockPosition = Vector3.zero;
        blockPosition = new Vector3(lastLevelBlock.exitPoint.position.x + block.width / 2, 
            lastLevelBlock.exitPoint.position.y, 
            lastLevelBlock.exitPoint.position.z);

        block.transform.position = blockPosition;
        currentLevelBlock = block;
    }

    public void RemoveOldBlock()
    {
        lastLevelBlock.transform.position += 2 * Vector3.right * lastLevelBlock.width;

        LevelBlock temp = lastLevelBlock;
        lastLevelBlock = currentLevelBlock;
        currentLevelBlock = temp;
    }

    public void GenerateNewBlockPipe()
    {
        float distanceToGenerate = levelBlock.width / 2;
        float y_random = Random.Range(-2, 4);
        Transform pipeBlock = Instantiate(blockPipe);
        Vector3 pipePosition = Vector3.zero;
        pipePosition = new Vector3(
            Camera.main.transform.position.x + distanceToGenerate,
            y_random,
            0);
        pipeBlock.GetComponent<PipeMovement>().speed = Random.Range(4, 10);
        pipeBlock.transform.position = pipePosition;
    }
}
