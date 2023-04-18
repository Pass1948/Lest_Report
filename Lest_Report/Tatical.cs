﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Report
{
    internal class Tatical
    {
        //기술면접=====================================

        /******************************************************
		 * 배열 (Array)
		 * 
		 * 배열은 연속된 메모리 공간으로 이루어져 있어서 메모리 관리가 용이하고 배열의 요소(값)들이 인덱스를 사용해서 직접적으로 접근 시 빠르게 값을 찾을 수 있다
		 * 배열은 초기화때 정한 크기가 소멸때 까지 유지되는 특징 때문에 배열을 동적으로 크기 할당이 불가능하다 예를들어 n개로 크기를 정한 이상
		 * n개 이상으로 크기를 늘릴수도 줄일수도 없을 뿐더러 연속된 공간을 사용하기 때문에 중간에 값을 삽입하는 것과 삭제하는 것도 불가능 하다
		 * 또한 값이 배열크기안에 순서대로 할당되어 선형 자료구조를 이룬다
		 * 
		 * <배열의 시간복잡도>
		 * 접근시 인덱스로 값에 직접적으로 접근이 가능해서 시간복잡도는 O(1)로 한번의 연산으로 값에 접근할수있다
		 * 배열의 값을 탐색할 경우 배열의 크기만큼 검사를 하고 조건을 탐색해야 하기 때문에 배열의 크기가 n개로 치면 시간복잡도는 n번만큼 정해지기에 O(N)로 표기된다
		 ******************************************************/

        /******************************************************
		 * 리스트(List) 혹은 동적배열(Dynamic Array)
		 * 
		 * 리스트는 크기가 정해지지 않은 배열로 리스트를 선언할때 힙메모리 영역에 어느정도 크기가 된 빈공간을 할당하고 그안에 값을 넣는 방식으로
		 * 배열요소가 들어간 크기가 공간 허용량을 넘게 되면 본래 할당한 공간의 n배 되는 공간을 재생성하고 본래 공간안에 배열크기를 새로운공간에 복사하고
		 * 새로운 공간을 이전 공간과 교체한다 이러한 이유로 정해진 적은량을 리스트로 사용할 경우 불필요한 메모리공간을 상당부분 차지하는 상황이 생길수 있다 
		 * 주소값을 갖고있어 데이터의 추가 또는 삭제을 포함한 동적 할당이 가능하다 고로 n개 만큼 크기를 늘릴수 있고 줄일수도 있다
		 * 이러한 특징들 때문에 리스트는 크기가 정해져있지 않지만 삽입과 삭제가 자주 일어날 경우 쓰인다 
		 * 크기가 정해지지 않는 만큼 검색면에서 처리시간이 제각각이어서 일정치 않는점이 있다
		 * 
		 * <List의 시간복잡도>
		 * 접근시 주소값으로 참조할 수 있어서 한번의 연산으로 값에 접근할수있다 그래서 시간복잡도는 O(1)로 표기한다
		 * 탐색, 삽입, 삭제등 접근 이외의 기능은 공간 허용량안에 요소가 할당된 크기만큼 조건과 위치 탐색이 이뤄지고 이후 추가 적으로 연산이 이뤄져야하는 부분이라
		 * 배열크기 n개만큼 연산이 되어야 한다 그래서 시간복잡도는 O(n)로 표기된다
		 ******************************************************/
    }
}
