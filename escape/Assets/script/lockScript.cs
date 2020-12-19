using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockScript : MonoBehaviour
{
    public GameObject lockImg;
    public InputField inputText;
    public GameObject clearPannel;
    public GameObject countText;
    public Text getText;
    public Text countresult;

    public void lockBtn()
    {
        if (inputText.text == "AESTE"|| inputText.text == "aeste")
        {
            Debug.Log("안녕 잘가");
            lockImg.SetActive(false);
            clearPannel.SetActive(true);
            countText.SetActive(false);
            countresult.text = getText.text.ToString();
        }
    }
}
