using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyPopup : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private int FadeDuration = 2;

    // Start is called before the first frame update
    void Start()
    {
        message.CrossFadeAlpha(0, FadeDuration, false);
        Destroy(gameObject, FadeDuration);
    }

}
