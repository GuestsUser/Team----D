using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reset : MonoBehaviour
{
   
    public void replay()
    {
        
        SceneManager.LoadScene("GameMain");
    }

// Update is called once per frame
void Update()
    {
        
    }
}
