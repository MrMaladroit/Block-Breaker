using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
    private int totalBlockCount;

    private void CheckBlockCount()
    {
        if(totalBlockCount <= 0)
        {
            SceneLoader.LoadNextScene();
        }
    }
    public void AddToBlockCount()
    {
        totalBlockCount++;
    }

    public void SubtractFromBlockCount()
    {
        totalBlockCount--;
        CheckBlockCount();
    }
}