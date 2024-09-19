using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TabController : MonoBehaviour
{
    public TMPro.TMP_InputField[] orderOfSelect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Looking for focused element");
            for (int k = 0; k < orderOfSelect.Length; k++)
            {
                if (orderOfSelect[k].isFocused)
                {

                    int nextK = (k + 1) % orderOfSelect.Length;
                    Debug.Log($"Going from {k} to {nextK}");
                    orderOfSelect[nextK].Select();
                    return;
                }
            }
        }
    }
}
