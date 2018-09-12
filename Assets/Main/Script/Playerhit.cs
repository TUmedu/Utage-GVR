using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerhit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionStay(Collision other)
    {
        Debug.Log("sushi");
        if (other.gameObject.tag == "寿司")
        {
            //GetComponent<Canvas>().enabled = enabled;
            SceneManager.LoadScene("quiz");
        }
    }
}