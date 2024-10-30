# README - 3D 프로젝트 (이름 미정)
본 레포지토리는 3D 학습을 위해 제작되었습니다.<br>
기능별 참고한 사항들에 대해 링크를 걸어 놓았으니<br> 
학습/이해하는 데 도움이 되길 바랍니다.<br>
---
### 목차

1. 게임 개요
2. 구현 및 기능 설명
3. 개발 환경 소개
4. 사용 에셋 목록 소개
---

# 1. 게임 개요

### 게임 제목: (미정)

### 장르 : 3D 어드벤처 게임 (싱글 플레이)

### 스토리 : 

---
 
# 2. 구현 기능 설명

### 기본 키 세팅 
W, A, S, D 이동
스페이스 바 - 점프

### 필수 구현 기능

- **기본 이동 및 점프**
   input System 활용
- 
- **체력바 UI**
-  플레이어의 체력이 변할 때마다 UI 갱신.
-  
- **동적 환경 조사** 
    - Raycast를 통해 플레이어가 조사하는 오브젝트의 정보 UI에 표시.
- **점프대**
    - 캐릭터가 밟을 때 위로 높이 튀어 오르는 점프대 구현
    - OnCollisionEnter 트리거 와 ForceMode.Impulse 사용.
    - 
- **아이템 데이터**
    - 다양한 아이템 데이터를 `ScriptableObject`로 관리
    - 
- **아이템 사용**
    - 특정 아이템 사용 후 효과가 일정 시간 동안 지속되는 시스템 구현
   
### 도전 기능 구현

**3인칭 시점 구현**

카메라를 추가해 활성화/비활성화 시키는 방식.<br>
https://youtu.be/_yR9FL4LXGE?si=U4KMy4UHsZiVwOyg


**움직이는 플랫폼 구현**

https://youtu.be/rO19dA2jksk?si=M3xOVhlV7FUYRnG4


### 추가 기능 구현

**카메라 줌 기능**

**투명화 아이템 추가** 
쉐이더 그래프 활용 시도.<br>
https://youtu.be/1fQzBYepKrY?si=mCIrkuXUPwGwAw9d


### 추가 기능 구현 시도하면서 참고했던 자료

**캐릭터 장비 바꾸기**.<br>
https://youtu.be/yK0ojJSoHds?si=UnB1Wz1n5tswoWb-

**네비 매쉬 기능**.<br>
https://youtu.be/A0nsAjsJqHg?si=H7MKRO5swbgUgo9z

**벽타기(원형 겯기)**.<br>
https://youtu.be/M7MRg0YvdSs?si=sdoVrbnd_BcHxwnY

**상호작용 가능 오브젝트**.<br>
https://youtu.be/THmW4YolDok?si=oDYjNOAGUnW4CNLH

### 그 외 

**Static Batching 적용**.<br>
배경 오브젝트들에 Static Batching 적용 시도 .<br>
https://rootdev.tistory.com/51

-----

# 3. 개발 환경 소개

 **게임 엔진**
    - Unity - 2022.3.17f1
- **버전 관리**
    - GitHub
- **개발 환경**
    - **IDE**
        - VisualStudio
    - **OS**
        - Window 10


# 4. 사용 에셋 목록 소개

**유니티 에셋 스토어 내 무료 에셋 사용**

Translucent Crystals.<br>
https://assetstore.unity.com/packages/3d/environments/fantasy/translucent-crystals-106274

POLY STYLE - Platformer Starter Pack.<br>
https://assetstore.unity.com/packages/3d/environments/poly-style-platformer-starter-pack-284167

Starter Assets - ThirdPerson | Updates in new CharacterController package : 캐릭터만 사용.<br>
https://assetstore.unity.com/packages/essentials/starter-assets-thirdperson-updates-in-new-charactercontroller-pa-196526

Treasure Set - Free Chest.<br>
https://assetstore.unity.com/packages/3d/props/interior/treasure-set-free-chest-72345

Food Props.<br>
https://assetstore.unity.com/packages/3d/food-props-163295

Surveillance Camera.<br>
https://assetstore.unity.com/packages/3d/props/surveillance-camera-264577

**기타** 
Meshy 사이트에서 생성해 사용 - AI 3D 모델 생성 사이트, 무료.<br>
https://www.meshy.ai/discover

-----
블로그 주소 : 

