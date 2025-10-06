using UnityEngine;

public class Bom : MonoBehaviour
{
    public float deleteTime = 3.0f; // 削除されるまでの時間

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 生成されて数秒後に削除
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
