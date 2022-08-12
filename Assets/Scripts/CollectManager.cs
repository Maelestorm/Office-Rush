using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform collectPoint;
    
    int paperLimit = 10;
    
    private void OnEnable()
    {
        TriggerManager.OnPaperCollect += GetPaper;
    }
    private void OnDisable()
    {
        TriggerManager.OnPaperCollect -= GetPaper;
    }
    void GetPaper()
    {
        if(paperList.Count <=paperLimit)
        {
            GameObject temp = Instantiate(paperPrefab,collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 0.5f+((float)paperList.Count/20), collectPoint.position.z);
            paperList.Add(temp);
            if (TriggerManager.printerManager != null)
            {
                TriggerManager.printerManager.RemoveLast();
            }
        }
    }
}
