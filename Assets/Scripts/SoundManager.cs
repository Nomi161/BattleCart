using UnityEngine;
using UnityEngine.SceneManagement;

//BGMタイプ
public enum BGMType
{
    None,
    Title,
    InGame,
}

//SEタイプ
public enum SEType
{
    Shot,
    Damage,
    Jump,
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;    // SoundManager自身のインスタンス（初回起動(Awake())でstatic として登録される）
    BGMType playingBGM;
    AudioSource audio;

    public AudioClip titleBGM;
    public AudioClip stageBGM;


    //現シーン取得
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンが切り替わっても破棄されないようにする
        }
        else
        {
            // SoundManagerのインスタンスが既に存在する場合は自身を削除する
            Destroy(gameObject);
            return;
        }

        audio = GetComponent<AudioSource>();

    }

    //BGM再生
    public void PlayBgm(BGMType type)
    {
        if (type != playingBGM)
        {
            playingBGM = type;

            switch (type)
            {
                case BGMType.Title:
                    audio.clip = titleBGM;
                    audio.Play();
                    break;
                case BGMType.InGame:
                    audio.clip = stageBGM;
                    audio.Play();
                    break;
            }
        }
    }


    //停止メソッド
    public void StopBgm()
    {
        audio.Stop();
        playingBGM = BGMType.None;
    }
}
