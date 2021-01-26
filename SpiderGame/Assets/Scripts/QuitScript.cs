using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitScript : MonoBehaviour
{
    public Button quitButton;
    
    void Start () {
		Button btn = quitButton.GetComponent<Button>();
		btn.onClick.AddListener(QuitGame);
	}	

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void QuitGame(){
		Application.Quit();
	}
}
