using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private bool isInputEnabled = true;  // ���͂��L�������������Ǘ�����

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

    // ���͂��L�����ǂ������`�F�b�N
    public bool IsInputEnabled()
    {
        return isInputEnabled;
    }

    // ���͂�L��������
    public void SetInputEnabled(bool enabled)
    {
        isInputEnabled = enabled;
    }

    // �^�b�v��N���b�N�̓��͂��`�F�b�N����
    public bool IsInputPressed()
    {
        if (!isInputEnabled)
            return false;

        // �^�b�v��N���b�N�������Ŋm�F����
        return Input.GetMouseButtonDown(0) || Input.touchCount > 0;
    }
}