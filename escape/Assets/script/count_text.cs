using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count_text : MonoBehaviour
{
    public Text countTxt;
    float timer=0;
    float fps=1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countTxt.text = System.Math.Truncate(timer / fps)  + "초";
        timer += Time.deltaTime;
    }
}
