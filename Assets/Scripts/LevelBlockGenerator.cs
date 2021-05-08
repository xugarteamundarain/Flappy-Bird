using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockGenerator : MonoBehaviour
{
    public LevelBlock levelBlock; // Bloque de nivel a generar
    public LevelBlock lastLevelBlock; // Ultimo bloque colocado
    public LevelBlock currentLevelBlock; // Nuevo bloque generado

    private void Start()
    {
        AddNewBlock();
    }

    private void Update()
    {
        float camera_x = Camera.main.transform.position.x;
        float old_x = lastLevelBlock.exitPoint.position.x;

        if (camera_x > old_x + lastLevelBlock.width)
        {
            RemoveOldBlock();
            AddNewBlock();
        }
    }

    public void AddNewBlock()
    {
        LevelBlock block = (LevelBlock)Instantiate(levelBlock);
        block.transform.SetParent(this.transform, false); 
        block.transform.position = new Vector2(lastLevelBlock.exitPoint.position.x + lastLevelBlock.width / 2, lastLevelBlock.exitPoint.position.y);
        currentLevelBlock = block;
    }

    public void RemoveOldBlock()
    {
        Destroy(lastLevelBlock.gameObject);
        lastLevelBlock = currentLevelBlock;
    }
}
