using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject mugPrefab;
    [System.NonSerialized]
    public int nofLiftedMugs = 0;
    public int currentLevel = 1;
    private List<GameObject> mugs = new List<GameObject>();

    void Start()
    {
        Init();
    }

    public void Init()
    {
        // clears all mugs before level restarting
        foreach (GameObject mug in mugs)
        {
            Destroy(mug);
        }
        mugs.Clear();

        // generates mugs for the current level
        int nofMugs = currentLevel * 4;
        int indexOfMugWithDiamond = Random.Range(0, nofMugs);
        int indexOfMug = 0;
        for (int row = -currentLevel + 1; row < currentLevel; row += 2)
        {
            for (int column = -3; column <= 3; column += 2)
            {
                Vector3 position = new Vector3(column, row, 0);
                mugs.Add(Instantiate(mugPrefab, position, Quaternion.identity));
                if (indexOfMug == indexOfMugWithDiamond) {
                    // @todo: show diamond
                }
                indexOfMug++;
            }
        }

        // resets some properties
        nofLiftedMugs = 0;
    }
}
