using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public enum Player
    {
        Player1,
        Player2,
        Player3,
    }
    Player player = Player.Player1;

    [Header("[PlayerName Setting]")]
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject gameStartPanel;

    [Header("[Time Setting]")]
    [SerializeField] TMP_Text nowTimeText;

    [Header("[GameMenuSetting]")]
    [SerializeField] GameObject playerChangePanel;
    [SerializeField] Image playerImage;
    public List<Sprite> playerImageList;
    [SerializeField] Animator playerAnimator;
    public List<RuntimeAnimatorController> playerAnimatorList;
 

    private void Awake()
    {
        Time.timeScale = 0f;
        //playerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetNowTime", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerNameInput()
    {
        playerNameText.text = inputField.text;
    }

    public void EnterButton()
    {
        if(playerNameText.text.Length >= 2 && playerNameText.text.Length <= 10)
        {
            Time.timeScale = 1f;

            switch (player)
            {
                case Player.Player1:
                    playerAnimator.runtimeAnimatorController = playerAnimatorList[0];
                    break;
                case Player.Player2:
                    playerAnimator.runtimeAnimatorController = playerAnimatorList[1];
                    break;
                case Player.Player3:
                    playerAnimator.runtimeAnimatorController = playerAnimatorList[2];
                    break;
                default:
                    break;
            }

            gameStartPanel.SetActive(false);
        }
    }

    public static string GetNowTime()
    {
        return DateTime.Now.ToString(("HH : mm"));
    }

    public void SetNowTime()
    {
        nowTimeText.text = GetNowTime();
    }

    public void SettingButton()
    {
        Time.timeScale = 0f;
        gameStartPanel.SetActive(true);
    }

    public void PlayerChangeButton()
    {
        playerChangePanel.SetActive(true);
    }

    public void Player1Button()
    {
        player = Player.Player1;
        playerImage.sprite = playerImageList[0];
        playerChangePanel.SetActive(false);
    }

    public void Player2Button()
    {
        player = Player.Player2;
        playerImage.sprite = playerImageList[1];
        playerChangePanel.SetActive(false);
    }

    public void Player3Button()
    {
        player = Player.Player3;
        playerImage.sprite = playerImageList[2];
        playerChangePanel.SetActive(false);
    }
}
