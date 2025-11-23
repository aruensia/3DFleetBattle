
# [<img width="60" height="60" alt="Youtube_logo" src="https://github.com/user-attachments/assets/8e31fdca-af1b-4ebc-b2c9-cdb9983454b4" />](https://youtu.be/MvmJK4SbtK0)  3DFleetBattle

### 나만의 함선을 조립하여 적 함선을 해치워라!

<br>

<table>
  <tr>
    <td align="center" width="33%">
      <img src="https://github.com/user-attachments/assets/37486176-02cf-45c0-b391-e7b2b2d21d8b" alt="인게임 게임 플레이" width="100%"/>
      <br/>
      <b>인 게임 플레이</b>
    </td>
    <td align="center" width="33%">
      <img src="https://github.com/user-attachments/assets/2d81d64a-7d23-4a6c-94ce-9cf923066770" alt="게임 로고" width="100%"/>
      <br/>
      <b>게임 로고</b>
    </td>
  </tr>
</table>


</div>

<br>
<br>


---

</div>

<br>
<br>

## 📋 목차

- [게임 소개](#-게임-소개)
- [주요 스크립트](#-주요-스크립트)
  - [데이터](#-데이터)
  - [상점](#-상점)
  - [함선 디자인](#-함선-디자인)
  - [함대 AI](#-함대-AI)
  - [함선](#-함선)
- [기술 스택](#-주요-기술-스택)
- [참고사항](#-참고사항)
- [개발자](#-개발자)

<br>
<br>

---

<br>
<br>

## 🎯 게임 소개

**3DFleetBattle**은 상점에서 함선을 구매해 자신만의 함선을 조립하여 함대를 꾸리는 게임입니다.  
함선을 꾸린 후, 적 함대와 교전을 하여 자신의 함대의 전투력을 측정하는 시뮬레이션이 주 기능입니다.

<br>
<br>

---

<br>
<br>

# 📁 Scripts

> 3DFleetBattle 프로젝트의 스크립트 모음입니다.

<br>
<br>

---

## 💻 주요 스크립트

<br>

## 🎵 데이터

<br>

### [`DataList.cs`](https://github.com/aruensia/3DFleetBattle/blob/main/Assets/Resources/Script/Data/DataList.cs)

**💡 기능**: 스크립터블 오브젝트에서 데이터를 불러와 유저 딕셔너리에 저장

**📌 주요 메서드**:
- `GetShipData()`: Resources폴더에 있는 스크립트 오브젝트의 파일들을 순차적으로 불러온 후 딕셔너리 키 값에 맞는 리스트에 저장
- `AllShipDataDicClear()`: 유저의 함대 딕셔너리 초기화

**✨ 특징**: 유저 함대 딕셔너리의 키값을 참조하여 스크립터블 오브젝트의 데이터를 불러온 후, 딕셔너리에 저장.
             

<br>
<br>

---

<br>
<br>

## 🔐 상점

<br>

### [`ShopMain.cs`](https://github.com/aruensia/3DFleetBattle/blob/main/Assets/Resources/Script/Shop/ShopMain.cs)

**💡 기능**: 유저가 상점에서 부품을 구매할 수 있음

**📌 주요 기능**:
- 상점 목록을 등급 및 확률에 따라 관리
- 유저가 함선 부품을 구매한 후 유저 딕셔너리에 데이터를 저장
- 정규식을 통해 특정 string으로 조건을 구분

**📌 주요 메서드**:
- `DropdownDataInit()`: 드롭다운 목록에 들어갈 값의 List를 생성함
- `LoadShopData()`: 상점에 판매할 아이템 데이터를 불러옴
- `ShowShopItem()`: 상점에 판매할 아이템을 UI에 출력함
- `SetBuyPopup()`: 상점에서 아이템을 클릭할 경우 구매 팝업 출력
- `BuyItem()`: 구매 팝업을 통해 아이템 구매

<br>
<br>

---

<br>
<br>

## 📋 함선 디자인

<br>

### [`ShipDesign.cs`](https://github.com/aruensia/3DFleetBattle/blob/main/Assets/Resources/Script/Design/ShipDesign.cs)

**💡 기능**: 구매한 부품들을 가지고 함선을 조립

**📌 주요 기능**:
- 인벤토리에서 아이템 정렬
- 보유한 아이템으로 함선을 조립 및 저장

**📌 주요 메서드**:
- `SetShipPart()`: 부품중에서 선두, 선체, 선미를 장착
- `SetSubItem()`: 부품중에서 무기, 보조 장치를 장착
- `ShipSave()`: 조립을 끝낸 함선을 저장하여 유저함대 List에 추가.

<br>
<br>

---

<br>
<br>

## 🎮 함대 AI

<br>

### [`PlayerFleetAI.cs`](https://github.com/aruensia/3DFleetBattle/blob/main/Assets/Resources/Script/Character/Player/PlayerFleetAI.cs)

**💡 기능**: 플레이어 함대를 관리하는 AI

**✨ 특징**:
- 적과 마주치기 전 까지, 모든 함대의 이동 및 상태를 관리
- 적과 마주치면 자신을 비활성화하고 자식 함대들의 FSM 상태를 활성화

**📌 주요 메서드**:
- `PatrolMove()`: 적을 향해 기본 이동
- `FleetBattleState()`: 함대의 상태를 관리하는 FSM
- `PlayerContectisOn()`: 적이 일정 영역에 도달하여 접촉 시 상태를 변경

<br>
<br>

---

<br>
<br>

## 📕 함선

<br>

### [`Ship.cs`](https://github.com/aruensia/3DFleetBattle/blob/main/Assets/Resources/Script/Data/Ship.cs)

**💡 기능**: 게임에 사용되는 최소 유닛 단위

**✨ 특징**:
- FSM 통해 조건에 따라 자율적으로 행동

  **📌 주요 메서드**:
- `WeaponFireReady()`: 생성 시, 자신이 가진 무기를 확인하고 공격 유무를 파악하는 메서드
- `CombatMove()`: 공격대상으로 지정한 오브젝트를 향해 이동하는 메서드
- `SearchTarget()`: 특정 프레임 단위로 적을 찾는 메서드
- `WeaponFire()`: 적을 공격하는 메서드


<br>
<br>

## 🔧 주요 기술 스택

<br>

**🔥 RegularExpressions**: 정규식
**📝 TextMeshPro**: UI 텍스트
**📝 ScriptableObject**: 스크립터블 오브젝트

<br>
<br>

---

<br>
<br>

## 📝 참고사항

<br>

💡 **간편한 데이터 관리**
- ScriptableObject를 이용하여 에디터 상으로 데이터를 관리

💡 **데이터 지속성**
- DontDestroyOnLoad 패턴을 사용하여 씬 전환 시에도 데이터 유지

<br>
<br>

---

<br>
<br>

<div align="center">

## 👨‍💻 개발자

<br>

**aruensia (하준영)**

<br>
<br>

[![GitHub](https://img.shields.io/badge/GitHub-aruensia-181717?style=for-the-badge&logo=github)](https://github.com/aruensia/aruensia)

<br>

**📌 모든 스크립트 링크는 위의 GitHub 저장소에서 확인할 수 있습니다.**

</div>

<br>
<br>

