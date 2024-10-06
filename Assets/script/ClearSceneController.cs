using UnityEngine;
using UnityEngine.SceneManagement; 

public class ClearSceneController : MonoBehaviour
{
    void Update()
    {
        // 画面がタップされたらタイトルシーンに遷移
        if (Input.GetMouseButtonDown(0))  // 左クリックまたは画面タップを検出
        {
            // タイトルシーンに遷移
            SceneManager.LoadScene("TitleScenes");
        }
    }
}