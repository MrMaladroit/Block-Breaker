using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
    private int totalBlockCount;
    private SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void CheckBlockCount()
    {
        if(totalBlockCount <= 0)
        {
            sceneLoader.LoadNextScene();
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