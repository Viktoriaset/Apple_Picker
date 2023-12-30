using UnityEngine;
using Random = UnityEngine.Random;


public class AppleTree : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject ApplePrefab;

    public float Speed = 1f;
    public float LeftAndRightEdge = 10f;
    public float ChanceToChangeDirection = 0.1f;
    public float SecondsBetweenAppleDrops = 1f;

    private void Start()
    {
        Invoke("DropApple", 2f);
    }

    public void SetDifficulty(DifficultySettings difficulty)
    {
        Speed = difficulty.Speed;
        ChanceToChangeDirection = difficulty.ChanceToChangeDirection;
        SecondsBetweenAppleDrops = difficulty.SecondsBetweenAppleDrops;
    }

    private void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(ApplePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", SecondsBetweenAppleDrops);
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -LeftAndRightEdge)
        {
            Speed = Mathf.Abs(Speed);
        } 
        else if (pos.x > LeftAndRightEdge)
        {
            Speed = -Mathf.Abs(Speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < ChanceToChangeDirection)
        {
            Speed *= -1;
        }
    }
}
