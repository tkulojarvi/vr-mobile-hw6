#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridSpawner : ScriptableWizard
{
    public Transform parent;
    public GameObject gridObject;
    public int gap = 3;
    public int safearea = 3;
    public int size = 10;
    public Vector3 offset = Vector3.zero;
    public Vector3 alternatingOffset = Vector3.zero;
    public Vector3 randomAmount = Vector3.zero;

    [MenuItem("Custom/GridSpawner")]
    static void CreateWizard()
    {
        DisplayWizard<GridSpawner>("Create");
    }

    void OnWizardCreate()
    {
        while(parent.childCount>0)
        {
            DestroyImmediate(parent.GetChild(0).gameObject);
        }
        for(int x = -size*gap-safearea; x < size*gap+safearea; x+=gap)
        {
            for (int y = -size * gap - safearea; y < size * gap + safearea; y += gap)
            {
                if (Mathf.Abs(x) <= safearea && Mathf.Abs(y) <= safearea)
                    continue;

                GameObject go = Instantiate(gridObject, parent);
                Vector3 pos = new Vector3((Mathf.Abs(y) / gap) % 2 == 1 ? x : x + alternatingOffset.x, (Mathf.Abs(x) / gap) % 2 == 1 ? y : y + alternatingOffset.y, 0) + offset;
                pos += new Vector3(Random.Range(-randomAmount.x, randomAmount.x), Random.Range(-randomAmount.y, randomAmount.y), Random.Range(-randomAmount.z, randomAmount.z));
                go.transform.localPosition = pos;
                go.transform.localScale = gridObject.transform.localScale;
            }
        }
    }
}
#endif