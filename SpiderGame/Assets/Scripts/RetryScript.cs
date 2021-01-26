using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryScript : MonoBehaviour
{
    public Button retryButton;
    
    void Start () {
		Button btn = retryButton.GetComponent<Button>();
		btn.onClick.AddListener(RestartLevel);
	}	

    void RestartLevel(){
		SceneManager.LoadScene(0);
	}
}
