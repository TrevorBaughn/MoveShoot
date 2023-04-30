using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] private Image responsibilityImage;
    [SerializeField] private Responsibility responsibility;

    [SerializeField] private TextMeshProUGUI coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        responsibilityImage.fillAmount = responsibility.animated / responsibility.max;
        coinAmount.text = GameManager.instance.players[0].score.ToString();
    }
}
