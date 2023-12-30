using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in inspetor")]
    public GameObject BasketPrefab;
    public int NumBuskets = 3;
    public float BasketBottomY = -14f;
    public float BasketSpacingY = 2f;
    public List<GameObject> BasketList;

    
    private void Start()
    {
        BasketList = new List<GameObject>();
        for (int i = 0; i < NumBuskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(BasketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = BasketBottomY + (BasketSpacingY * i);
            tBasketGO.transform.position = pos;
            BasketList.Add(tBasketGO);
        }
    }

    public void AppleDestroid()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tApple in tAppleArray)
            Destroy(tApple);

        int basketIndex = BasketList.Count - 1;
        GameObject tBasketGO = BasketList[basketIndex];
        BasketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (BasketList.Count == 0)
        {
            Debug.Log("Reloud scene");
            SceneManager.LoadScene(0);
        }
    }
}
