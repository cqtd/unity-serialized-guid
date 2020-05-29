# Serialized GUID

### Example

- 빈 GUID

![image-20200529101014646](https://github.com/cqtd/unity-serialized-guid/blob/master/Documentation~/image-20200529101014646.png?raw=true/)

- Generate 된 GUID

  ![image-20200529101057208](https://github.com/cqtd/unity-serialized-guid/blob/master/Documentation~/image-20200529101057208.png?raw=true)

### Usage

게임을 개발하다보면 고유한 아이디의 역할을 해줄 데이터가 필요합니다. 간단하게 System.Guid를 사용할 수 있지만, Serialize 되지 않는 타입입니다. 조금 편하게 사용하기 위해 래핑해서 사용합니다. 아이템의 고유 ID 등처럼 사용가능합니다. 아이템을 비교할 때 GUID로 비교하여 같은 아이템인지 판별하는 등에 사용 가능합니다.



### Install

OpenUPM으로 https://github.com/cqtd/unity-serialized-guid.git 설치



### Reference

- 유니티 스팟라이트 팀 - GUID 베이스 레퍼런스 : https://blogs.unity3d.com/2018/07/19/spotlight-team-best-practices-guid-based-references/
- 유니티 테크놀로지 깃허브 - https://github.com/Unity-Technologies/guid-based-reference