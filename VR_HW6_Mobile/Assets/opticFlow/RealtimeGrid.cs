using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealtimeGrid : MonoBehaviour
{
    public bool refresh = false;
    public GameObject gridObject;
    public int gap = 2;
    public int safearea = 2;
    public int size = 10;
    public Vector3 offset = Vector3.zero;
    public Vector3 alternatingOffset = Vector3.one;
    public Vector3 randomAmount = Vector3.zero;

    void Update()
    {
        if(refresh) {
            Respawn();
            refresh = false;
        }
    }

    void Respawn()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for(int x = -size*gap-safearea; x < size*gap+safearea; x+=gap)
        {
            for (int y = -size * gap - safearea; y < size * gap + safearea; y += gap)
            {
                if (Mathf.Abs(x) <= safearea && Mathf.Abs(y) <= safearea)
                    continue;

                GameObject go = Instantiate(gridObject, transform);
                Vector3 pos = new Vector3((Mathf.Abs(y) / gap) % 2 == 1 ? x : x + alternatingOffset.x, (Mathf.Abs(x) / gap) % 2 == 1 ? y : y + alternatingOffset.y, 0) + offset;
                pos += new Vector3(Random.Range(-randomAmount.x, randomAmount.x), Random.Range(-randomAmount.y, randomAmount.y), Random.Range(-randomAmount.z, randomAmount.z));
                go.transform.localPosition = pos;
                go.transform.localScale = gridObject.transform.localScale;
            }
        }
    }
}