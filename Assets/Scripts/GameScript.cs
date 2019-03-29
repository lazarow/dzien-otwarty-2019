using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject mugPrefab;
    [System.NonSerialized]
    public int nofLiftedMugs = 0;
    [System.NonSerialized]
    public int nofClicks = 0;
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
        for (int row = currentLevel - 1; row > -currentLevel; row -= 2)
        {
            for (int column = -3; column <= 3; column += 2)
            {
                Vector3 position = new Vector3(column, row, 0);
                GameObject mug = Instantiate(mugPrefab, position, Quaternion.identity);
                mug.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = indexOfMug + 1;
                mug.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = indexOfMug == indexOfMugWithDiamond;
                mugs.Add(mug);
                indexOfMug++;
            }
        }

        // resets some properties
        nofLiftedMugs = 0;
    }

    public void SwapInit()
    {
        int row = Random.Range(1, currentLevel) - 1;
        int col = Random.Range(0, 2);

        int mugIdx = row * 4 + col;

        mugs[mugIdx].SendMessage("InitAnim", true);
        mugs[mugIdx + 1].SendMessage("InitAnim", false);

        var temp = mugs[mugIdx];

        mugs[mugIdx] = mugs[mugIdx + 1];
        mugs[mugIdx + 1] = temp;
    }
}
