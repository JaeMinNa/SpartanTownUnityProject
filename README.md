
# SpartanTownProject 스파르타 타운 만들기 (게더 클론) 개인 프로젝트

## 프로젝트 소개
유니티 스파르타 타운 만들기 (게더 클론) 개인 프로젝트  
<br/>


##  기술 스택
<img src="https://img.shields.io/badge/c%23-512BD4?style=plastic&logo=c%23&logoColor=black">
<img src="https://img.shields.io/badge/unity-000000?style=plastic&logo=unity&logoColor=black">
<br/>


## 구현 기능
* 필수요구사항
   * 캐릭터 만들기
   * 캐릭터 이동
   * 방 만들기
   * 카메라 따라가기
<br/>
 
* 선택요구사항
     * 캐릭터 애니메이션 추가
     * 이름 입력 시스템
     * 캐릭터 선택 시스템
     * 인게임 캐릭터 선택
     * 인게임 이름 바꾸기
     * 시간 표시
 
<br/>

      
## 구현 기능 세부 설명

### 캐릭터 만들기
* 무료 에셋을 이용해서 2D 캐릭터 구현
<br/>


### 캐릭터 이동
* Input.GetKey() 로 캐릭터 이동 구현
* Camera.main.ScreenToWorldPoint(Input.mousePosition) 로 마우스 위치에 따라 flip.X로 캐릭터가 바라보는 방향 설정
```
private void Move()
{
    // 오른쪽 이동
    if (Input.GetKey(KeyCode.D))
    {
        transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * speed;
    }

    // 왼쪽 이동
    else if (Input.GetKey(KeyCode.A))
    {
        transform.position += new Vector3(-1f, 0, 0) * Time.deltaTime * speed;
    }

    // 위쪽 이동
    else if (Input.GetKey(KeyCode.W))
    {
        transform.position += new Vector3(0, 1f, 0) * Time.deltaTime * speed;
    }

    // 아래쪽 이동
    else if (Input.GetKey(KeyCode.S))
    {
        transform.position += new Vector3(0, -1f, 0) * Time.deltaTime * speed;
    }

    // 마우스 방향 바라보기
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
    if(mousePos.x < transform.position.x)
    {
        sr.flipX = true;
    }
    else
    {
        sr.flipX = false;
    }
}
```
<br/>


### 방만들기
* 타일맵 사용해서 각각 방 구현
<br/>


### 카메라 따라가기
* MainCamera가 캐릭터를 따라다니도록 구현
 ``` 
[SerializeField] private Transform target; // 카메라가 쫓아다닐 대상 (플레이어)
[SerializeField] private float smoothTime = 0.3f; // 부드럽게 이동하는 시간

private Vector3 velocity = Vector3.zero; // 값의 변화량 (=현재 속도)

private void LateUpdate()
{
    // 월드 좌표 = TransformPoint (로컬 좌표)
    Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10f));

    // 목표 위치까지 부드럽게 이동할 때 사용하는 메소드
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
}
  ```
<br/>


### 캐릭터 애니메이션 추가
* Animator, Animation 사용해서 각각 캐릭터 Idle 구현
<br/>


### 이름 입력 시스템
* InputField 로 이름 입력 시스템 구현
* if문으로 2~10 글자 사이만 적용되도록 구현
```
using UnityEngine.UI;
using TMPro;

[SerializeField] TMP_Text text;
[SerializeField] TMP_InputField inputField;
[SerializeField] GameObject gameStartPanel;

// 매개변수는 string만 사용 가능
public void PlayerNameInput()
{
	tmpText.text = inputField.text;
}

public void EnterButton()
{
	gameStartPanel.SetActive(false);
}
```
<br/>


### 캐릭터 선택 시스템
* Button 으로 캐릭터 선택 시, Image와 enum 값 변경
* enum 값에 따라, 캐릭터의 AnimatorController 변경
```
public enum Player
{
    Player1,
    Player2,
    Player3,
}

Player player = Player.Player1;

[SerializeField] Animator playerAnimator;	// 캐릭터 Animator 연결
public List<RuntimeAnimatorController> playerAnimatorList;	// 변경할 캐릭터 AnimatorController List

[SerializeField] Image playerImage;
public List<Sprite> playerImageList;

public void EnterButton()
{

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
```
<br/>


### 인게임 캐릭터 선택, 이름 바꾸기
* Setting 버튼 클릭으로 캐릭터 선택, 이름 바꾸기 가능
<br/>


### 시간표시
* DateTime.Now 로 현재 시간 표시
```
using System;

public static string GetNowTime()
{
    return DateTime.Now.ToString(("HH : mm"));
}

// [yyyy : 년도] [MM: 월] [dd : 일] [HH : 시] [mm : 분] [ss : 초] [tt : 오전, 오후]
```
<br/>


## 게임 화면

### 캐릭터 선택
<img src="https://github.com/JaeMinNa/SpartanTownProject/assets/149379194/bf09b180-0db6-4ec6-9679-dd501fc8472e" width="1000">
<img src="https://github.com/JaeMinNa/SpartanTownProject/assets/149379194/488f7d77-cfa9-45ef-8901-ed85d971d0be" width="1000">
<img src="https://github.com/JaeMinNa/SpartanTownProject/assets/149379194/e43e2a13-b81b-484a-951e-d872aff035c6" width="1000">
<br/>



### 이름 입력 시스템
<img src="https://github.com/JaeMinNa/SpartanTownProject/assets/149379194/7b79b368-22ce-4316-a544-f1f4dbc9e58c" width="1000">
<img src="https://github.com/JaeMinNa/SpartanTownProject/assets/149379194/1c31cc16-8deb-4893-969e-5a199b69188c" width="1000">
<br/>



### 이름 변경, 캐릭터 변경
<img src="https://github.com/JaeMinNa/SpartanTownProject/assets/149379194/7524e001-774f-418b-bf19-5e2758b6b4b8" width="1000">
<img src="https://github.com/JaeMinNa/SpartanTownProject/assets/149379194/4cb5d3f4-5cfb-4625-90d3-318cf7b8fc80" width="1000">
<br/>



## 프로젝트 시 일어난 문제와 해결  

### 캐릭터 선택 시스템

캐릭터 선택 시스템을 처음 구현해봐서 고민을 오랫동안 했다. 제일 처음 생각한 방법은 다른 스프라이트의 캐릭터를 3가지 만들고 각각 프리팹을 생성해서 게임을 시작할 때, enum 값에 맞는 캐릭터가 생성되도록 하는 방법이었다. 

이 방법의 문제점은 내가 한가지 씬에서 모두 작업을 했기 때문에 게임 시작 시, 캐릭터가 존재하지 않는다면, 기존에 캐릭터와 연결했던 NameTag나 Camera 등이 모두 문제가 되었다. 

그래서 생각한 방법은 캐릭터를 한가지로 고정하고 AnimatorController만 바꾸는 것이었다. 각각 AnimatorController를 생성해서 캐릭터 선택 시, 바뀌도록 설정했다.

AnimatorController를 받을 때, RuntimeAnimatorController로 받아야 한다는 것도 몰랐기 때문에 많은 검색을 통해서 겨우 구현할 수 있었다.
<br/>



### 이름 입력 시스템

InputFiled 역시 처음 알았기 때문에 구글링을 통해서 구현했다. InputFiled를 처음 생성하니까 인스펙터 창에 내용이 너무 많아서 기능을 공부하는데 시간이 엄청 걸렸다.

그리고 입력창에 입력받은 정보를 불러오는 방법에 대해서 고민을 많이 했다. 

제일 처음에는 On End Edit 을 써서, 입력을 하고 입력창을 벗어났을 때, 적용이 되도록 구현했는데, 이 방법은 별도의 확인 버튼을 만들 이유가 없기때문에 On Value Changed 를 사용했다.

이 방법은 입력창에 입력이 될때마다 바로바로 정보를 불러가는 방식이었다. On End Edit 를 썻을 때는 확인 버튼을 만들지 않아도 아무 곳이나 클릭을 하면 입력창이 사라졌지만, 이 방법에서는 버튼을 사용해서 입력창이 닫아지도록 구현했다.

처음 본 기능이었고, 기능이 엄청 많았지만 핵심 기능만 알면 충분히 사용 가능했다.
<br/>



## 프로젝트 소감

혼자서 유니티의 이정도의 기능을 구현한적은 처음이었다. 애니메이션, 이동 정도는 예전에 구현해 본적이 있었지만 이름 입력, 캐릭터 선택 등 많은 기능을 구현할 수 있었다.

처음에는 필수요구사항 정도만 구현을 해야겠다고 생각했는데, 점점 구현을 하다보니 욕심이 많이 생겼다.

추가요구사항을 하나, 둘 씩 진행하면서 몰랐던 내용을 정리할 수 있었고, 다음에는 더 많은 기능을 구현하고 싶다라는 욕심까지 생겼다.

그래서 모르는 내용이라도 차근차근 하나씩 연습하고, 직접 해보는 것이 중요하다라는 것을 알게되었다.

프로젝트를 진행하면서 조금 아쉬웠던 점은, 기능 별로 스크립트를 많이 나누지않고, GameManger 스크립트에서 거의 모든 기능을 처리하도록 구현한 점이다.

이 부분은 아직 경험이 많이 부족하기 때문에 점점 큰 프로젝트를 진행하면서 연습해야 된다고 생각한다.

