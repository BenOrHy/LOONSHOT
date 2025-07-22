using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    public playerProperty property;

    public void Init(playerProperty pro) {
        property = pro;
    }

    public Button attackButton;
    public GameObject player;

    public bool attackProtocol() {
        return !property.playerCanAttack && !property.playerCanMove;
    }

    public void attackPlayer() {
        if (attackProtocol())
        {
            property.playerCanAttack = true;
        }
        else if (property.playerCanAttack)
        {
            if (property.mainhandItem.CompareTag("gun")) {
                attackGun(property.atk, property.mainhandItem);
            } else if (property.mainhandItem.CompareTag("baton")) {
                attackBaton(property.atk, property.mainhandItem);
            } else if (property.mainhandItem.CompareTag("blade")) {
                attackBlade(property.atk, property.mainhandItem);
            }
        }
        else
        {
            Debug.Log("이동 실행중");
        }
    }

    public void attackGun(float atk, GameObject gun) {
        int gunBulletCount = gun.GetComponent<gun>().bulletCount;
        float gunRange = gun.GetComponent<gun>().range;
        if (gunBulletCount > 1) {
            gunBulletCount -= 1;

        }
        else {
            gunBulletCount -= 1;
            property.act -= gun.GetComponent<gun>().actReduce;
        }
    }

    public void attackBaton(float atk, GameObject baton) { 

    
    }

    public void attackBlade(float atk, GameObject blade) {

    }

    void Update()
    {
        if (property.playerCanAttack)
        {
            property.mainhandItem.gameObject.SetActive(true);
            if ((property.mainhandItem.CompareTag("baton") || property.mainhandItem.CompareTag("blade")))
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            else if(property.mainhandItem.CompareTag("gun"))
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    player.transform.Rotate(0, 0, -0.2f);
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    player.transform.Rotate(0, 0, 0.2f);
                }
            }
        }
        else {
            property.mainhandItem.gameObject.SetActive(false);
        }
    }
}
