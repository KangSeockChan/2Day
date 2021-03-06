﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recognition : MonoBehaviour
{
    int PickUpMask = 1 << 8;
    int InstallerMask = 1 << 9;

    [SerializeField]
    GameObject HoldText;
    [SerializeField]
    GameObject InstallText;
    [SerializeField]
    GameObject NPCText;

    public float deploymentHeight;
    public GameObject HandPosition;
    public Transform Rotation;
    public float distance;

    public GameObject Invent;
    public GameObject Inventory;


    [HideInInspector]
    bool Holdstuff = false;
    [HideInInspector]
    GameObject HoldingStuff;

    GameObject HitObject;



    void Update()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, transform.GetComponent<Camera>().transform.forward);

        if (!Holdstuff)
        {
            if (Physics.Raycast(landingRay, out hit, deploymentHeight, PickUpMask))
            {
                if (hit.collider.tag == "Box")
                {
                    if (!HoldText.activeInHierarchy)
                        HoldText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Holdstuff = true;
                        HoldText.SetActive(false);
                        HoldingStuff = hit.transform.gameObject;
                        HoldingStuff.GetComponent<Rigidbody>().isKinematic = true;
                        HoldingStuff.GetComponent<BoxCollider>().enabled = false;
                    }
                }
                else if (hit.collider.tag == "Inventory")
                {
                    if (hit.transform.GetComponent<ItemMng>().CheckInventory())
                    {
                        if (!HoldText.activeInHierarchy)
                            HoldText.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            //Invent.GetComponent<FadeOutInven>().FadeOut();
                            HoldText.SetActive(false);
                            hit.transform.gameObject.SetActive(false);
                            hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                            hit.transform.GetComponent<BoxCollider>().enabled = false;
                            hit.transform.GetComponent<ItemMng>().SetPosition();
                            hit.transform.GetComponent<ItemMng>()
                                .Inventory_Insert(hit.transform.GetComponent<ItemMng>().ItemType, gameObject);
                        }
                    }

                }
                else if (hit.collider.tag == "NPC")
                {
                    if (!NPCText.activeInHierarchy)
                        NPCText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {

                    }
                }
                else
                {
                    if (HoldText.activeInHierarchy)
                        HoldText.SetActive(false);
                    if (NPCText.activeInHierarchy)
                        NPCText.SetActive(false);
                }
            }
            else
            {
                if (HoldText.activeInHierarchy)
                    HoldText.SetActive(false);
                if (NPCText.activeInHierarchy)
                    NPCText.SetActive(false);
            }

        }
        else if (Holdstuff)
        {
            // 잡고잇는 물건 위치
            HoldingStuff.transform.position = HandPosition.transform.position + HandPosition.transform.forward * distance;
            HoldingStuff.transform.rotation = Rotation.rotation;

            // 설치
            if (Physics.Raycast(landingRay, out hit, deploymentHeight, InstallerMask))
            {
                if (hit.collider.tag == "Installer_Hide" && hit.transform.GetComponent<BoxColliderMng>().Object.Equals(false))
                {
                    hit.transform.GetComponent<BoxColliderMng>().BoxAlpha.SetActive(true);
                    HitObject = hit.transform.gameObject;
                    if (!InstallText.activeInHierarchy)
                        InstallText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Holdstuff = false;
                        InstallText.SetActive(false);
                        hit.transform.GetComponent<BoxColliderMng>().Box.SetActive(true);
                        HoldingStuff.GetComponent<ResetPosition>().ResetPos();
                        hit.transform.GetComponent<BoxColliderMng>().Object = true;
                    }
                }
                else
                {
                    if (InstallText.activeInHierarchy)
                        InstallText.SetActive(false);
                }
            }
            else
            {
                if (InstallText.activeInHierarchy)
                    InstallText.SetActive(false);
                if (HitObject != null)
                {
                    HitObject.GetComponent<BoxColliderMng>().BoxAlpha.SetActive(false);
                    HitObject = null;
                }
            }
        }
    }
}