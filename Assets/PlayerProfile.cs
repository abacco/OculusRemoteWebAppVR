using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer croce_rossa, croce_nera;

    public void OpenPlayerProfile() {
        GameObject.Find("PlayerProfile").GetComponent<SpriteRenderer>().enabled = true;
        croce_nera.enabled = true;
        croce_rossa.enabled = true;
    }
    public void ClosePlayerProfile() {
        GameObject.Find("PlayerProfile").GetComponent<SpriteRenderer>().enabled = false;
        croce_nera.enabled = false;
        croce_rossa.enabled = false;
    }
}
