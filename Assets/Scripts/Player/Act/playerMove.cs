using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public static playerProperty property;

    public void Init(playerProperty pro)
    {
        property = pro;
    }

    public Button moveButton;

    public bool moveProtocol() {

        return !property.playerCanAttack && !property.playerCanMove;
    }

    public void movePlayer() {
        if (moveProtocol())
        {
            property.playerCanMove = true;
            Debug.Log($"이동 클릭됨 : {property.playerCanMove}");
        }
        else if (property.playerCanMove) {
            Moving();
        }
        else {
            Debug.Log($"공격 실행중 : {property.playerCanAttack},{property.playerCanMove}");
        }
    }

    public void Moving() {
        property.playerCanMove = false;
    }

    public void pannelSetting() { 

    }

    public void pannelRemove() { 

    }

    public bool summonPannelCool = true;
    public GameObject player;
    public GameObject pannel;
    public int num = 0;
    public int rot = 0;
    public int priRot = 0;
    public Transform pannelPos;
    public GameObject[] pannelSet = new GameObject[3];
    public int[] rotate = new int[3];

    void Awake()
    {
        pannelPos.position = new Vector3(0, 0, 0);
    }

    void Start()
    {
        summonPannelCool = true;
        pannelSet = new GameObject[property.spd];
        rotate = new int[property.spd];

    }

    void Update()
    {
        if (property.playerCanMove)
        {
            if (summonPannelCool)
            {
                if (Input.GetKeyDown("a") && pannelPos.position.x > 0)
                {
                    Debug.Log("왼");
                    if (priRot != 2 && num < property.spd) {
                        pannelSet[num] = Instantiate(pannel);
                        pannelSet[num].transform.position = pannelPos.position + new Vector3(-1, 0, 0);
                        pannelPos.position += new Vector3(-1, 0, 0);
                        rotate[num] = 1;
                        priRot = 1;
                        num++;
                    } else if (priRot == 2)
                    {
                        Destroy(pannelSet[num - 1]);
                        rotate[num - 1] = 0;
                        num--;
                        priRot = rotate[num];
                    }
                    StartCoroutine(pannelSetCool());

                }
                else if (Input.GetKeyDown("d"))
                {
                    Debug.Log("오");
                    if (priRot != 1 && num < property.spd)
                    {
                        pannelSet[num] = Instantiate(pannel);
                        pannelSet[num].transform.position = pannelPos.position + new Vector3(1, 0, 0);
                        pannelPos.position += new Vector3(1, 0, 0);
                        rotate[num] = 2;
                        priRot = 2;
                        num++;
                    }
                    else if (priRot == 1)
                    {
                        Destroy(pannelSet[num - 1]);
                        rotate[num - 1] = 0;
                        num--;
                        priRot = rotate[num];
                    }
                    StartCoroutine(pannelSetCool());

                }
                else if (Input.GetKeyDown("w"))
                {
                    Debug.Log("위");
                    if (priRot != 4 && num < property.spd)
                    {
                        pannelSet[num] = Instantiate(pannel);
                        pannelSet[num].transform.position = pannelPos.position + new Vector3(0, 1, 0);
                        pannelPos.position += new Vector3(0, 1, 0);
                        rotate[num] = 3;
                        priRot = 3;
                        num++;
                    }
                    else if (priRot == 4)
                    {
                        Destroy(pannelSet[num - 1]);
                        rotate[num - 1] = 0;
                        num--;
                        priRot = rotate[num];
                    }
                    StartCoroutine(pannelSetCool());
                }
                else if (Input.GetKeyDown("s") && pannelPos.position.y > 0)
                {
                    Debug.Log("아래");
                    if (priRot != 3 && num < property.spd)
                    {
                        pannelSet[num].transform.position = pannelPos.position + new Vector3(0, -1, 0);
                        pannelPos.position += new Vector3(0, -1, 0);
                        rotate[num] = 4;
                        priRot = 4;
                        num++;
                    }
                    else if (priRot == 3)
                    {
                        Destroy(pannelSet[num - 1]);
                        rotate[num - 1] = 0;
                        num--;
                        priRot = rotate[num];
                    }
                    StartCoroutine(pannelSetCool());
                }
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator pannelSetCool() {
        summonPannelCool = false;
        yield return new WaitForSeconds(0.3f);
        summonPannelCool = true;
    }
}
