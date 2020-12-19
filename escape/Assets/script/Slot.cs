using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private bool hintbool = true;

    public GameObject exitcolider;
    public GameObject exitdoor;
    public GameObject exitdoor2;

    public int talkcnt=0;

    public GameObject hintPannel;


    public Scene sc;

    public GameObject box_move;
    public GameObject box_stay;

    public int dollcnt = 0;

    public Text talk_txt;
    public GameObject talkImg;

    public GameObject key;
    public Text name;
    public Item item; // 획득한 아이템.
    public int itemCount; // 획득한 아이템의 개수.
    public Image itemImage; // 아이템의 이미지.

    private bool onetimelight = true;

    public bool check = true;

    public GameObject box;

    public GameObject doorkey;

    private TalkText talk;
    public Transform player;
    public Transform box_upper;
    public Light mat_light;
    public Light mat_light2;
    public Light mat_light3;
    public Light mat_light4;
    public Light mat_light5;
    public Light mat_light6;

    private bool talk1= true;

    public GameObject finalPannel;

    public GameObject handle;

    //움직일 오브젝트
    public GameObject phone;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    private void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main_game")
        {
            if (mat_light.intensity == 0.5f && mat_light2.intensity == 0.5f && mat_light3.intensity == 0.5f && mat_light4.intensity == 0.5f && mat_light5.intensity == 0.5f && mat_light6.intensity == 0.5f && onetimelight)
            {
                setlightUp();
                onetimelight = false;
                key.SetActive(true);
            }
        }


    }

    void Start()
    {

    }
    public void setlightUp()
    {
        talkImg.SetActive(true);
        name.text = "me";

        talk_txt.text = "모든 불이다 켜졌다!";
        Invoke("noShow", 3);
    }

    public void Show()
    {
        talkImg.SetActive(true);
    }
    public void noShow()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main_game")
        {
            talkImg.SetActive(false);
            if (Vector3.Distance(box_stay.transform.position, box_move.transform.position) == 10f&& talk1)
            {
                talk1 = false;
                Show();
                name.text = "빡빡이";
                talk_txt.text = "축하한다.수고 했구나!!\n이로써 모든 인형들을 잘받았다.\n축하선물로 이방을 나갈수 있는\n핑크 열쇠를 주겠다.";
                doorkey.SetActive(true);
                box_move.transform.Translate(0f, 1f, 0f);
                Invoke("noShow", 3f);
            }
            
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level2")
        {
            talkImg.SetActive(false);
        }


    }


    // 이미지의 투명도 조절.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;

    }

    // 아이템 획득
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }

    // 아이템 개수 조정.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // 슬롯 초기화.
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
    private void backbacktalk()
    {
        if (talkcnt == 0)
        {

            Debug.Log(" 첫번째 함수");
            talkImg.SetActive(true);
            name.text = "빡빡이";
            talk_txt.text = "열어줘서 고맙네, 자네 이방에서 나가고 싶은가?";
            talkcnt++;
            Invoke("backbacktalk", 3f);


        }
        else if(talkcnt == 1)
        {
            Debug.Log(" 두번째 함수");

            name.text = "빡빡이";
            talk_txt.text = "옆에 책장에서 6개의 인형을 가져다 주면\n나갈수 있는 방열쇠를 주지";
            talkcnt++;
            Invoke("backbacktalk", 3f);


        }
        else if (talkcnt == 2)
        {
            Debug.Log(" 세번째 함수");

            noShow();
            talkcnt++;

        }




    }
    


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                if (item.itemType == Item.ItemType.Equipment)
                {

                }
                else
                {
                    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main_game")
                    {
                        if (Vector3.Distance(player.position, box_upper.position) <= 2f && item.itemName.ToString() == "key")
                        {

                            Debug.Log(item.itemName + " 을 사용했습니다");
                            SetSlotCount(-1);
                            box_upper.transform.Translate(0f, 1f, 0f);
                            Debug.Log(" 첫번째 대화");
                            Invoke("backbacktalk", 3f);


                        }
                        else if (Vector3.Distance(player.position, handle.transform.position) <= 1f && item.itemName.ToString() == "doorkey")
                        {
                            //나가는문열기
                            Debug.Log(item.itemName + " 을 사용했습니다");
                            talkImg.SetActive(true);
                            talk_txt.text = "야호! 드디어 나갔다!!";
                            exitdoor2.SetActive(true);
                            exitdoor.SetActive(false);
                            handle.GetComponent<BoxCollider>().enabled = false;
                            exitcolider.SetActive(false);
                            finalPannel.SetActive(true);
                            Invoke("noShow", 3);

                        }
                       

                        else if (Vector3.Distance(player.position, handle.transform.position) <= 2f && item.itemName.ToString() == "key")
                        {
                            name.text = "me";

                            talkImg.SetActive(true);
                            talk_txt.text = "이쪽열쇠가 아닌가봐,,";
                            Invoke("noShow", 3);
                        }
                        else if (Vector3.Distance(player.position, mat_light.transform.position) <= 1f && item.itemName.ToString() == "match")
                        {
                            Debug.Log(item.itemName + " 을 사용했습니다");

                            mat_light.intensity = 0.5f;


                        }
                        else if (Vector3.Distance(player.position, mat_light2.transform.position) <= 1f && item.itemName.ToString() == "match")
                        {
                            Debug.Log(item.itemName + " 을 사용했습니다");
                            mat_light2.intensity = 0.5f;

                        }
                        else if (Vector3.Distance(player.position, mat_light3.transform.position) <= 1f && item.itemName.ToString() == "match")
                        {
                            Debug.Log(item.itemName + " 을 사용했습니다");
                            mat_light3.intensity = 0.5f;

                        }
                        else if (Vector3.Distance(player.position, mat_light4.transform.position) <= 1f && item.itemName.ToString() == "match")
                        {
                            Debug.Log(item.itemName + " 을 사용했습니다");
                            mat_light4.intensity = 0.5f;
                        }
                        else if (Vector3.Distance(player.position, mat_light5.transform.position) <= 1f && item.itemName.ToString() == "match")
                        {
                            Debug.Log(item.itemName + " 을 사용했습니다");
                            mat_light5.intensity = 0.5f;
                        }
                        else if (Vector3.Distance(player.position, mat_light6.transform.position) <= 1f && item.itemName.ToString() == "match")
                        {
                            Debug.Log(item.itemName + " 을 사용했습니다");
                            mat_light6.intensity = 0.5f;
                        }

                        else if (Vector3.Distance(box_upper.position, box.transform.position) >= 1f && Vector3.Distance(player.position, box_upper.position) <= 2f)
                        {
                            if (item.itemName.ToString() == "rabit")
                            {
                                Show();
                                name.text = "빡빡이";
                                talk_txt.text = "귀여워지게 만드는 토끼 인형 이구나~!";
                                Debug.Log(item.itemName + " 을 사용했습니다");
                                SetSlotCount(-1);
                                Debug.Log(" 토끼 대화");
                                Invoke("noShow", 3f);
                                box_move.transform.Translate(0f, 1f, 0f);

                            }
                            else if (item.itemName.ToString() == "panda")
                            {
                                Show();
                                name.text = "빡빡이";
                                talk_txt.text = "유머를 늘려주는 팬더 인형 이구나!";
                                Debug.Log(item.itemName + " 을 사용했습니다");
                                SetSlotCount(-1);
                                Debug.Log(" 판다 대화");
                                Invoke("noShow", 3f);
                                box_move.transform.Translate(0f, 1f, 0f);


                            }
                            else if (item.itemName.ToString() == "Rhinoceros")
                            {
                                Show();
                                name.text = "빡빡이";
                                talk_txt.text = "용기가 생기는 코뿔소 인형 이구나~!";
                                Debug.Log(item.itemName + " 을 사용했습니다");
                                SetSlotCount(-1);
                                Debug.Log(" 코뿔소 대화");
                                Invoke("noShow", 3f);
                                box_move.transform.Translate(0f, 1f, 0f);


                            }
                            else if (item.itemName.ToString() == "elephant")
                            {

                                Show();
                                name.text = "빡빡이";
                                talk_txt.text = "힘이 쎄지는 코끼리 인형 이구나~!";
                                Debug.Log(item.itemName + " 을 사용했습니다");
                                SetSlotCount(-1);
                                Debug.Log(" 코끼리 대화");
                                Invoke("noShow", 3f);

                                box_move.transform.Translate(0f, 1f, 0f);

                            }
                            else if (item.itemName.ToString() == "dragon")
                            {
                                Show();
                                name.text = "빡빡이";
                                talk_txt.text = "지혜가 생기는 용 인형 이구나!";
                                Debug.Log(item.itemName + " 을 사용했습니다");
                                SetSlotCount(-1);
                                Debug.Log(" 용 대화");
                                Invoke("noShow", 3f);
                                box_move.transform.Translate(0f, 1f, 0f);

                            }
                            else if (item.itemName.ToString() == "bird")
                            {
                                Show();
                                name.text = "빡빡이";
                                talk_txt.text = "행운을 가져다 주는 파랑새 인형 이구나~!";
                                Debug.Log(item.itemName + " 을 사용했습니다");
                                SetSlotCount(-1);
                                Debug.Log(" 새 대화");
                                Invoke("noShow", 3f);

                                box_move.transform.Translate(0f, 1f, 0f);

                            }

                        }

                        else
                        {
                            Debug.Log(dollcnt);
                            Debug.Log("아이템 을 사용하기엔 거리가 너무 멀다");
                        }

                    }else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level2")
                    {
                        if (Vector3.Distance(player.position, phone.transform.position) <= 2f && item.itemName.ToString() == "phone")
                        {

                            Debug.Log("전화기를 내려 놨다. ");
                            phone.SetActive(true);
                            SetSlotCount(-1);

                        }
                        else if (item.itemName.ToString() == "hint")
                        {
                            if (hintbool)
                            {
                                hintbool = false;

                                Debug.Log("힌트 보기");
                                hintPannel.SetActive(true);
                            }
                            else
                            {
                                hintbool = true;
                                Debug.Log("힌트 보기");
                                hintPannel.SetActive(false);
                            }


                        }
                    }
 
                }
            }
        }
    }

    private  void cnt()
    {
        dollcnt++;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);

            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
        Debug.Log("드레그");

    }

    public void OnDrop(PointerEventData eventData)
    {

        if (DragSlot.instance.dragSlot != null)
            ChangeSlot();
        Debug.Log("드랍");
    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        else
            DragSlot.instance.dragSlot.ClearSlot();
    }



}
