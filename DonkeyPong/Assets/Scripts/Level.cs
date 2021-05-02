using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int remainingBlocks;

    void Start()
    {
         remainingBlocks = GameObject.FindGameObjectsWithTag("Breakable").Length;
    }

    public void CountBlocks()
    {
        remainingBlocks--;
        if (remainingBlocks == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
