using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public Button button;  // UI�{�^�����A�^�b�`
    private void Start()
    {
        // �{�^���𖳌���
        button.interactable = false;
        // �V�[���J�ڌ�̒Z���ԓ��͂𖳌�������
        StartCoroutine(DisableInputTemporarily(1.0f));
    }
    // ���͂���莞�Ԗ���������R���[�`��
    private IEnumerator DisableInputTemporarily(float duration)
    {
        // ���͂𖳌�������
        InputManager.Instance.SetInputEnabled(false);
        // �w�肵�����ԑ҂�
        yield return new WaitForSeconds(duration);
        // ���͂�L��������
        InputManager.Instance.SetInputEnabled(true);
        // �{�^�����ĂїL����
        button.interactable = true;
    }
}
