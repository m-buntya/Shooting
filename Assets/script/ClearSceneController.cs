using UnityEngine;
using UnityEngine.SceneManagement; 

public class ClearSceneController : MonoBehaviour
{
    void Update()
    {
        // ��ʂ��^�b�v���ꂽ��^�C�g���V�[���ɑJ��
        if (Input.GetMouseButtonDown(0))  // ���N���b�N�܂��͉�ʃ^�b�v�����o
        {
            // �^�C�g���V�[���ɑJ��
            SceneManager.LoadScene("TitleScenes");
        }
    }
}