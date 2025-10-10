# BattleCart
## BattleCartについて
プレイヤーとなるカートを操作して走行距離の記録を伸ばしていく3Dゲームです。
ステージの奥から敵が迫ってくるのであたらないように避けながら進みます。
  
どんどんスピードが速くなるので後半にいけばいくほど一気に記録が伸びる爽快感と
一瞬でクラッシュしてしまうスリルが癖になるように作りました。
  
  
## ゲームプレイ方法
[ゲームのサンプルプレイ](https://nomi161.github.io/BattleCart_web/)
  
![ゲーム画面](readmeImg/battlecart_portfolio.jpg)
  
  
### 操作方法
* Aキー（左キー）：レーンを左に移動
* Dキー（右キー）：レーンを右に移動
* スペースキー：ジャンプ
* マウス操作：視点を回転
* マウス左クリック：シュート
### ゲームルール
* 敵とぶつかってPlayerのHPがゼロになったらゲームオーバー
* 敵はシュートされた球で破壊できる
* 弾の残数は限りがある（自動回復）
* 走行距離が記録されるので、最高記録の塗り替えを目指す
* タイトルで記録をリセット可能
  
## 使用技術
* ゲームエンジン：Unity
* 使用言語：C#
* 使用ツール：VisualStudio、Affinty Photo
  
## 開発の工夫
* 開発期間：18時間
* 担当範囲：企画～アセットの導入、プログラミング、デバッグ仕上げ
* こだわった点：
シュートする時カメラの動きに合わせて視点が変わるようにした
長距離走っても永遠とステージが続くように自動生成されるプログラム
SEをつけて臨場感がでるようにした
爽快感とスリルが両立するようにして、繰り返し最高記録を塗り替えたくなるようなバランス調整をした
* 技術的な調整：
カメラの角度を変えるとシュートされる弾もカメラの角度にあわせて飛んでいくように調整するRotationの調整が大変でした
  
### スクリプトの詳細
* PlayerController.cs  
CharactorControllerコンポーネントのMoveメソッドを用いて、自動走行する
ダメージをくらった際に一定時間点滅処理するメソッド(Blinking)を用いた
```C#
   //点滅処理
   void Blinking()
   {
       //その時のゲーム進行時間で正か負かの値を算出
       float val = Mathf.Sin(Time.time * 50);
       //正の周期なら表示
       if (val >= 0) body.SetActive(true);
       //負の周期なら非表示
       else body.SetActive(false);
   }
```
  
* CameraRotation.cs  
マウスの動きに連動してカメラの視点がかわるように実装  
最大・最小の視野角を決めてそこで視点が留まるようにClampメソッドを活用した  
```C#
void Update()
{
    //プレイ状態でなければ動かせないようにしておく
    if (GameManager.gameState != GameState.playing) return;
    //マウスの動きを取得しておく
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    //その時のマウスの動きに応じた数値（横方向）
    horizontalRotation += mouseX;
    //最大・最小に絞り込みはされる
    horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle, maxHorizontalAngle);
    //その時のマウスの動きに応じた数値（縦方向）
    verticalRotation -= mouseY;
    //最大・最小に絞り込みはされる
    verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);
    //横の角度の微調整
    //基準としている角度に対してmin～maxの間でのマウス移動の積み重ね
    float yRotation = initialY + horizontalRotation;
    //そのフレームにおけるカメラの角度を最終決定
    transform.rotation = Quaternion.Euler(verticalRotation, yRotation, 0);
}
```
  
今日

坂巻　雅実 9:41
・今お配りしているのは本番作業と
ほぼ同等の試験データをお渡ししています
土～月の間に触りたければ試験データを触って
来週の本番作業に備えてください

・本番（共同開発）
4チームごとのGitHubに参画
◇基盤データをあらためてクローン
→（ブランチ）自分独自の開発環境に枝分かれ
main
・担当者Aブランチ → 自分の担当を独自開発
・担当者Bブランチ → 自分の担当を独自開発
・担当者Cブランチ → 自分の担当を独自開発
・担当者Dブランチ → 自分の担当を独自開発
A、B、C、Dの開発内容を順番に統合（マージ）
「ミーティング グループ チャット」宛てのメッセージは、チームチャットのミーティング グループ チャットにも表示されます

坂巻　雅実 10:23
「readmeImg」フォルダの用意

坂巻　雅実 10:29
## BattleCartについて
プレイヤーとなるカートを操作して走行距離の記録を伸ばしていく3Dゲームです。
ステージの奥から敵が迫ってくるのであたらないように避けながら進みます。
  
どんどんスピードが速くなるので後半にいけばいくほど一気に記録が伸びる爽快感と
一瞬でクラッシュしてしまうスリルが癖になるように作りました。

坂巻　雅実 10:34
## ゲームプレイ方法
[ゲームのサンプルプレイ](https://dyna-rise.github.io/BattleCart_web/)
![ゲーム画面](readmeImg/battlecart_portfolio.jpg)
  
### 操作方法
* Aキー（左キー）：レーンを左に移動
* Dキー（右キー）：レーンを右に移動
* スペースキー：ジャンプ
* マウス操作：視点を回転
* マウス左クリック：シュート
### ゲームルール
* 敵とぶつかってPlayerのHPがゼロになったらゲームオーバー
* 敵はシュートされた弾で破壊できる
* 弾の残数は限りがある（自動回復）
* 走行距離が記録されるので、最高記録の塗り替えを目指す
* タイトルで記録をリセット可能
## 使用技術
* ゲームエンジン：Unity
* 使用言語：C#
* 使用ツール：VisualStudio、Illustrator

坂巻　雅実 10:46
## 開発の工夫
* 開発期間：18時間
* 担当範囲：企画～アセットの導入、プログラミング、デバッグ仕上げ
* こだわった点：
シュートする時カメラの動きに合わせて視点が変わるようにした
長距離走っても永遠とステージが続くように自動生成されるプログラム
SEをつけて臨場感がでるようにした
爽快感とスリルが両立するようにして、繰り返し最高記録を塗り替えたくなるようなバランス調整をした
* 技術的な調整：
カメラの角度を変えるとシュートされる弾もカメラの角度にあわせて飛んでいくように調整するRotationの調整が大変でした
### スクリプトの詳細
* PlayerController.cs  
CharactorControllerコンポーネントのMoveメソッドを用いて、自動走行する
ダメージをくらった際に一定時間点滅処理するメソッド(Blinking)を用いた
```C#
   //点滅処理
   void Blinking()
   {
       //その時のゲーム進行時間で正か負かの値を算出
       float val = Mathf.Sin(Time.time * 50);
       //正の周期なら表示
       if (val >= 0) body.SetActive(true);
       //負の周期なら非表示
       else body.SetActive(false);
   }
```

坂巻　雅実 10:54
* CameraRotation.cs  
マウスの動きに連動してカメラの視点がかわるように実装  
最大・最小の視野角を決めてそこで視点が留まるようにClampメソッドを活用した  
```C#
void Update()
{
    //プレイ状態でなければ動かせないようにしておく
    if (GameManager.gameState != GameState.playing) return;
    //マウスの動きを取得しておく
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    //その時のマウスの動きに応じた数値（横方向）
    horizontalRotation += mouseX;
    //最大・最小に絞り込みはされる
    horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle, maxHorizontalAngle);
    //その時のマウスの動きに応じた数値（縦方向）
    verticalRotation -= mouseY;
    //最大・最小に絞り込みはされる
    verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);
    //横の角度の微調整
    //基準としている角度に対してmin～maxの間でのマウス移動の積み重ね
    float yRotation = initialY + horizontalRotation;
    //そのフレームにおけるカメラの角度を最終決定
    transform.rotation = Quaternion.Euler(verticalRotation, yRotation, 0);
}
```
  
* StageGenerator.cs  
プレハブに登録したステージオブジェクトが変数に設定した値で自動生成される  
Playerの位置に応じて新しいステージが生成されると古い物から削除されてヒエラルキーを圧迫しないよう工夫した  
```C#
// 指定のインデックス位置にStageオブジェクトをランダムに生成
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
```
```C#
    // 一番古いステージを削除
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
```
  
* StageGenerator.cs  
プレハブに登録したステージオブジェクトが変数に設定した値で自動生成される  
Playerの位置に応じて新しいステージが生成されると古い物から削除されてヒエラルキーを圧迫しないよう工夫した  
```C#
// 指定のインデックス位置にStageオブジェクトをランダムに生成
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
```
```C#
    // 一番古いステージを削除
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
```
* Shooter.cs  
カメラの向きにあわせて弾プレハブがシュートされる  
残弾を決めて、コルーチンで球数が自動回復するようにした  
```C#
//shotPowerを消費
void ConsumePower()
{
    shotPower--; //消費
    StartCoroutine(RecoverPower()); //回復コルーチン
}
//回復コルーチン
IEnumerator RecoverPower()
{
    //RecoverySeconds秒待つ
    yield return new WaitForSeconds(recoverySeconds);
    shotPower++; //１つ回復
}
```
  
## 今後の展望  
* 自動走行してPlayerを追いかける敵をNavMeshAgentなどの技術でつくれるようにする
* オプションメニューを用意して、難易度を変えたりカメラの微調整ができるような仕組みをつくれるように学習中