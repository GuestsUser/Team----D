

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class UI_pause : MonoBehaviour

{
    private
    int i;
    
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    public object Button1 { get; private set; }

    private void Start(){ pauseUI.SetActive(false); }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown("joystick button 7"))
        {
         
            pauseUI.SetActive(!pauseUI.activeSelf);
            i = (i + 1) % 2;
        }

        if (pauseUI.activeSelf) { Time.timeScale = 0f; }
        else { Time.timeScale = 1f; }

        if (i==1) 
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            if (Input.GetKey(KeyCode.Alpha1)){SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
        }
    }
}
 

