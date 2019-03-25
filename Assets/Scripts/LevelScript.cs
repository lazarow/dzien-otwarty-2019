using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public GameObject mug;
    public int currentLevel = 1;
    private List<GameObject> mugs = new List<GameObject>();

    void Start()
    {
        Init();
    }

    public void Init()
    {
        foreach (GameObject mug in mugs)
        {
            Destroy(mug);
        }
        mugs.Clear();

        for (int row = -currentLevel + 1; row < currentLevel; row += 2)
        {
            for (int column = -3; column <= 3; column += 2)
            {
                mugs.Add(Instantiate(mug, new Vector3(column, row, 0), Quaternion.identity));
            }
        }
    }

    void Update()
    {
        
    }
}
