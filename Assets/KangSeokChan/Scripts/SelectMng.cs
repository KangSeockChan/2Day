using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMng : MonoBehaviour
{

    public int MySelectPos = 0;
    float Unit_Pos = 70f;
    public GameObject SelectObj;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (MySelectPos.Equals(0))
    //        {
    //            MySelectPos = 1;
    //        }
    //        else if (MySelectPos.Equals(1))
    //        {
    //            MySelectPos = 2;
    //        }
    //        else if (MySelectPos.Equals(2))
    //        {
    //            MySelectPos = 3;
    //        }
    //        else if (MySelectPos.Equals(3))
    //        {
    //            MySelectPos = 0;
    //        }
    //        transform.parent.GetComponent<FadeOutInven>().FadeOut();
    //        StartCoroutine(SelMove(Mathf.Abs(0f - (MySelectPos * 70f) - SelectObj.transform.localPosition.y)));
    //    }
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        if (MySelectPos.Equals(0))
    //        {
    //            MySelectPos = 3;
    //        }
    //        else if (MySelectPos.Equals(1))
    //        {
    //            MySelectPos = 0;
    //        }
    //        else if (MySelectPos.Equals(2))
    //        {
    //            MySelectPos = 1;
    //        }
    //        else if (MySelectPos.Equals(3))
    //        {
    //            MySelectPos = 2;
    //        }
    //        transform.parent.GetComponent<FadeOutInven>().FadeOut();
    //        StartCoroutine(SelMove(Mathf.Abs(0f - (MySelectPos * 70f)- SelectObj.transform.localPosition.y)));
    //    }
    //}

    //IEnumerator SelMove(float Distance)
    //{
    //    if (0 - (MySelectPos*70) < SelectObj.transform.localPosition.y)
    //    {
    //        while (0f - (MySelectPos * 70f) <= SelectObj.transform.localPosition.y)
    //        {
    //            SelectObj.transform.Translate(Vector3.down * Time.deltaTime * (Distance/70f) * 600f);
    //            yield return null;
    //        }
    //    }
    //    else if(0 - (MySelectPos * 70) > SelectObj.transform.localPosition.y)
    //    {
    //        while (0 - (MySelectPos * 70) >= SelectObj.transform.localPosition.y)
    //        {
    //            SelectObj.transform.Translate(Vector3.up * Time.deltaTime * (Distance / 70f) * 600f);
    //            yield return null;
    //        }
    //    }
    //    SelectObj.transform.localPosition = new Vector3(SelectObj.transform.localPosition.x, 0 - (MySelectPos * 70), SelectObj.transform.localPosition.z);
    //}
}
