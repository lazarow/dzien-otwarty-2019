using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject mugPrefab;
    public GameObject diamondPrefab;
    [System.NonSerialized]
    public int nofLiftedMugs = 0;
    public int currentLevel = 1;
    private List<GameObject> mugs = new List<GameObject>();
    [System.NonSerialized]
    public GameObject diamond;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        if (diamond != null)
        {
            Destroy(diamond);
        }
        foreach (GameObject mug in mugs)
        {
            Destroy(mug);
        }
        mugs.Clear();

        int nofMugs = currentLevel * 4;
        int mugWithDiamond = Random.Range(0, nofMugs);
        int currentMug = 0;
        for (int row = -currentLevel + 1; row < currentLevel; row += 2)
        {
            for (int column = -3; column <= 3; column += 2)
            {
                Vector3 position = new Vector3(column, row, 0);
                mugs.Add(Instantiate(mugPrefab, position, Quaternion.identity));
                if (currentMug == mugWithDiamond) {
                    diamond = Instantiate(diamondPrefab, position, Quaternion.identity);
                }
                currentMug++;
            }
        }

        nofLiftedMugs = 0;
    }
}
