using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelChange()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex - 1;

        if (nextLevelIndex == -1)
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            return;
        }

        SceneManager.LoadScene(nextLevelIndex);
    }
}
