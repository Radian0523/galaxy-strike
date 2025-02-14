using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Startは、そのオブジェクトが生成されたときだけ呼ばれる。シーンがロードされた時ではないことを意識する。
    //一番最初のMusicPlayerオブジェクトは、ずっと生き残るが、シーンがロードされるごとに新しいMusicPlayerオブジェクトが生成されて、音楽が重複してしまう。
    //ここで、新しく生成されたオブジェクトの方だけは、Startが呼び出され、MusicPlayerが二つあることを検知して、自身を破壊する。
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
