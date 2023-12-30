using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DifficultySettings
{
    public float Speed;
    public float ChanceToChangeDirection;
    public float SecondsBetweenAppleDrops;
}


public class ApplePicker : MonoBehaviour
{
    [Header("Set in inspetor")]
    public GameObject BasketPrefab;

    public int NumBuskets = 3;
    public float BasketBottomY = -14f;
    public float BasketSpacingY = 2f;

    public List<GameObject> BasketList;

    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private AppleTree appleTree;
    [SerializeField] private float timeBeetwenIncreaseDifficalty = 10f;
    [SerializeField] private List<DifficultySettings> difficultySettings = new List<DifficultySettings>();
    private int currentDifficulty = 0;

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

        Invoke("IncreaseDifficulty", 10f);
    }

    public void IncreaseDifficulty()
    {
        if (currentDifficulty >= difficultySettings.Count - 1)
        {
            return;
        }

        currentDifficulty++;
        appleTree.SetDifficulty(difficultySettings[currentDifficulty]);

        Invoke("IncreaseDifficulty", timeBeetwenIncreaseDifficalty);
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
            GameOverPanel.SetActive(true);
        }
    }
}
