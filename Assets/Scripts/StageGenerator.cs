using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Rendering;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 120;  // 生成したチップを配置するにあたってのチップの大きさ

    int currentChipIndex;           // 現在どのチップまで作ったか

    Transform player;               // プレイヤーのTransform情報の取得
                                    // （Transform:オブジェクトの位置、回転、スケールを扱うクラス）

    public GameObject[] stageChips; // 生成すべきオブジェクトを配列に格納

    public int startChipIndex;      // チップ番号の開始
    public int preInstantiate;      // 余分に作っておく数

    // 現在生成したオブジェクトの管理用
    public List<GameObject> generatedStageList = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // プレイヤーのTransformを獲得
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentChipIndex = startChipIndex - 1;

        // 指定のIndexまでのステージチップを生成して、管理下に置く
        UpdateStage(preInstantiate);

    }


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // キャラクターの位置から現在のステージチップのインデックスを計算
            int charaPositionIndex = (int)(player.position.z / StageChipSize);

            // 次のステージチップに入ったらステージチップの更新処理をおこなう
            if (charaPositionIndex + preInstantiate > currentChipIndex)
            {
                // 指定のIndexまでのステージチップを生成して、管理下に置く
                UpdateStage(charaPositionIndex + preInstantiate);
            }
        }    
    }

    /// <summary>
    /// 指定のIndexまでのステージチップを生成して、管理下に置く
    /// </summary>
    /// <param name="toChipIndex">生成するチップのインデックス</param>
    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;

        // 指定のステージチップまでを作成
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);

            // 生成したステージチップを管理リストに追加
            generatedStageList.Add(stageObject);
        }

        // ステージ保持上限内になるまで古いステージを削除
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

        currentChipIndex = toChipIndex;
    }


    /// <summary>
    /// 指定のインデックス位置にStageオブジェクトをランダムに生成 
    /// </summary>
    /// <param name="chipIndex"></param>
    /// <returns></returns>
    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

        GameObject stageObject = Instantiate(
            stageChips[nextStageChip],
            new Vector3(0, 0, chipIndex * StageChipSize),
            Quaternion.identity
            );

        return stageObject;
    }

    // 一番古いステージを削除
    void DestroyOldestStage()
    {
        // 一番古いステージ（リストの先頭にあるオブジェクト）をリストから除いて削除する
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
