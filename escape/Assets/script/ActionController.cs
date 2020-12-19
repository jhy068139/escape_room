using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{


    public Text talk_txt;
    public GameObject talkImg;

    public bool talk_check= false;

    public TalkText talk;

    [SerializeField]
    private float range; // 습득 가능한 최대 거리.
    private int handlebool = 0;
    private bool pickupActivated = false; // 습득 가능할 시 true.

    private RaycastHit hitInfo; // 충돌체 정보 저장.


    // 아이템 레이어에만 반응하도록 레이어 마스크를 설정.
    [SerializeField]
    private LayerMask layerMask;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Inventory theInventory;

    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    public void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "handle")
                {
                    Debug.Log("테스투");
                    if (handlebool == 0 )
                    {
                        talk_check = true;
                        talk.SetText();
                        InfoDisappear();
                        handlebool++;
                    }
                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "bird")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = "새 인형을 찾았다";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();

                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "dragon")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = "용 인형을 찾았다";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "elephant")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = "코끼리 인형을 찾았다";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "panda")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = "판다 인형을 찾았다";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();

                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "rabit")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = "토끼 인형을 찾았다";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "match")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = "오 성냥이잖아! 불을 붙여 봐야겠다.";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Rhinoceros")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = "귀여운 코뿔소 인형이네!";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "key")
                {
                    talkImg.SetActive(true);
                    talk_txt.text = " 열쇠다! 이걸로 나갈수 있을까?!";

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "doorkey")
                {

                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    Destroy(hitInfo.transform.gameObject);
                    InfoDisappear();
                }
                Invoke("noShow", 3);
            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
            InfoDisappear();
    }

    private void ItemInfoAppear()
    {
        if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "handle")
        {
            pickupActivated = true;
            actionText.gameObject.SetActive(true);
            actionText.text = "문들 밀어보자";
        }
        else
        {
            pickupActivated = true;
            actionText.gameObject.SetActive(true);
            actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>";

        }
        
    }
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }


    public void noShow()
    {
        talkImg.SetActive(false);
    }


}
