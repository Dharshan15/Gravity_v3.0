using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI startText;
    Rigidbody2D rigidBody;

    public bool isTop = false;
    

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // Check for touch input 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is on the left half of the screen
            if (touch.phase == TouchPhase.Began)
            {
                //audioSource.Play();
                leftText.gameObject.SetActive(false);
                rigidBody.gravityScale *= -1;
                isTop = !isTop;
                startText.gameObject.SetActive(true);
                StartCoroutine(WaitAndLoadScene());
            }
            
        }

        if (isTop)
            transform.eulerAngles = new Vector3(0, 180, 180);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }

    IEnumerator WaitAndLoadScene()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
