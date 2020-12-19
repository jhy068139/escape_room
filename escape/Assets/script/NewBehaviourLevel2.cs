using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourLevel2 : MonoBehaviour
{
    //불값
    private bool wodo=true;
    private bool mando = true;
    private bool lockbool = true;

    //움직일 오브젝트
    public GameObject Woman_door;
    public GameObject man_door;
    public GameObject Woman_door_open;
    public GameObject man_door_open;

    public GameObject lockUI;

    public Text talk_txt;
    public GameObject talkImg;

    public bool talk_check = false;

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
                if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "phone")
                {
                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    hitInfo.transform.gameObject.SetActive(false);
                    talkImg.SetActive(true);
                    talk_txt.text = "종이에 무늬와 문뒤의 무늬를 잘 매치해 보세요.";
                    Invoke("noShow", 3);
                    InfoDisappear();

                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "woman_door")
                {
                    if (wodo)
                    {
                        wodo = false;
                        Woman_door.SetActive(false);
                        Woman_door_open.SetActive(true);
                    }
                    else
                    {
                        wodo = true;
                        Woman_door.SetActive(true);
                        Woman_door_open.SetActive(false);
                    }

                    InfoDisappear();

                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "man_door")
                {
                    if (mando)
                    {
                        mando = false;
                        man_door.SetActive(false);
                        man_door_open.SetActive(true);
                    }
                    else
                    {
                        mando = true;
                        man_door.SetActive(true);
                        man_door_open.SetActive(false);
                    }
                    InfoDisappear();

                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "lock")
                {
                    if (lockbool)
                    {
                        lockbool = false;
                        lockUI.SetActive(true);
                        Cursor.lockState = CursorLockMode.None; // 게임 창 밖으로 마우스가 안나감
                        InfoDisappear();
                    }
                    else
                    {
                        lockbool = true;
                        lockUI.SetActive(false);
                        Cursor.lockState = CursorLockMode.Locked;
                        InfoDisappear();
                    }


                }
                else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "hint")
                {
                    theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                    hitInfo.transform.gameObject.SetActive(false);
                    InfoDisappear();
                }
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
                actionText.text = "문을 열자";


        }
        else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "woman_door")
        {
            if (wodo)
            {
                pickupActivated = true;
                actionText.gameObject.SetActive(true);
                actionText.text = "문을 열자";
            }
            else
            {
                pickupActivated = true;
                actionText.gameObject.SetActive(true);
                actionText.text = "문을 닫자";
            }
        }
        else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "man_door")
        {
            if (mando)
            {
                pickupActivated = true;
                actionText.gameObject.SetActive(true);
                actionText.text = "문을 열자";
            }
            else
            {
                pickupActivated = true;
                actionText.gameObject.SetActive(true);
                actionText.text = "문을 닫자";
            }
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
