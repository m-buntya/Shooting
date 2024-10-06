using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public Button button;  // UIボタンをアタッチ
    private void Start()
    {
        // ボタンを無効化
        button.interactable = false;
        // シーン遷移後の短時間入力を無効化する
        StartCoroutine(DisableInputTemporarily(1.0f));
    }
    // 入力を一定時間無効化するコルーチン
    private IEnumerator DisableInputTemporarily(float duration)
    {
        // 入力を無効化する
        InputManager.Instance.SetInputEnabled(false);
        // 指定した時間待つ
        yield return new WaitForSeconds(duration);
        // 入力を有効化する
        InputManager.Instance.SetInputEnabled(true);
        // ボタンを再び有効化
        button.interactable = true;
    }
}
