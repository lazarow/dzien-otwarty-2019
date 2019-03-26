using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public void OnZoomInCompleted()
    {
        GameScript gameScript = (GameScript)FindObjectOfType(typeof(GameScript));
        if (gameScript.currentLevel < 4) {
            gameScript.currentLevel += 1;
        }
        gameScript.Init();
    }
}
