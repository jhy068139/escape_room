using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkText : MonoBehaviour
{



    public NewBehaviourLevel2 ab;

    public bool check = true;
    public int count=0;
    public Text talk;
    public Text name;
    public GameObject talkImg;
    void Start()
    {
        Show();
        name.text = "me";
        talk.text = "여긴 어디지?\n여기는 처음 보는 곳인데?";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)&& count<6)
        {
            SetText();
        }

    }


    public void SetText()
    {
        if (count == 0)
        {
            name.text = "me";

            talk.text = "음...!?\n뒷편에 문이 출구같은데?!";


            count++;
        }
        else if (count == 1)
        {

            noShow();
            count++;

        }
        else if(count ==2&&ab.talk_check)
        {
            Show();
            name.text = "me";

            talk.text = "아!!?\n혹시 이 문으로 나가면 되는 건가?";
            count++;

        }
        else if (count == 3 && ab.talk_check)
        {
            name.text = "me";

            talk.text = "역시 열리지 않는다";
            count++;

        }
        else if (count == 4 && ab.talk_check)
        {
            name.text = "me";

            talk.text = "일단 앞의 선반을 뒤져보자";
            count++;

        }
        else if (count == 5 && ab.talk_check)
        {
            noShow();
            count++;
        }
    }



    public void noShow()
    {
        talkImg.SetActive(false);
    }

    public void Show()
    {
        talkImg.SetActive(true);
    }

}
