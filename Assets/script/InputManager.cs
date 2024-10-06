using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private bool isInputEnabled = true;  // 入力が有効か無効かを管理する

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("InputManager");
                    instance = go.AddComponent<InputManager>();
                }
            }
            return instance;
        }
    }

    // 入力が有効かどうかをチェック
    public bool IsInputEnabled()
    {
        return isInputEnabled;
    }

    // 入力を有効化する
    public void SetInputEnabled(bool enabled)
    {
        isInputEnabled = enabled;
    }

    // タップやクリックの入力をチェックする
    public bool IsInputPressed()
    {
        if (!isInputEnabled)
            return false;

        // タップやクリックをここで確認する
        return Input.GetMouseButtonDown(0) || Input.touchCount > 0;
    }
}