using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in inspetor")]
    public GameObject BasketPrefab;
    public int NumBuskets = 3;
    public float BasketBottomY = -14f;
    public float BasketSpacingY = 2f;

    private void Start()
    {
        for (int i = 0; i < NumBuskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(BasketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = BasketBottomY + (BasketSpacingY * i);
            tBasketGO.transform.position = pos;
        }
    }
}
