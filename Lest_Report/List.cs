using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lest_Report
{
    internal class List<T>
    {
        private const int AllCapacity = 5;          // 리스트 허용량 5로 설정

        private T[] items;                          // 배열 생성
        private int size;                           // 사이즈(배열요소 갯수) 생성

        public List()
        {
            this.items = new T[AllCapacity];        // 허용량 5만큼 가진 배열
            this.size = 0;                          // 현재 배열요소는 없기애 0으로 작성
        }

        public T this[int index]                            // 배열요소에 접근 및 불러오기 가능케 하며 어떤 자료형 상관없이 일반화로 처리
        {
            get                                             // 배열접근
            {
                if (index < 0 || index >= size)             // 예외처리(배열크기에 벗어날경우)
                    throw new IndexOutOfRangeException();

                return items[index];                        // 배열요소 값 반환
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;                       // 해당 배열요소에 값 셋팅가능
            }
        }

        // 배열 허용량 확인 기능===================================================================
        public int Capacity { get { return items.Length; } }    // 배열의 허용량을 알기 위해 접근허용과 길이 값을 반환시켜주도록 함

        // 배열크기 확인 기능===================================================================
        public int Count { get { return size; } }               // 현재 들어가있는 배열요소에 접근하여 들어간 총 갯수를 반환하도록함

        // 배열요소 추가 관련 기능===================================================================
        public void Add(T item)                                 // 리스트에 배열요소 추가기능
        {
            if (size < items.Length)                            // 현재 배열크기가 허용치보단 작을경우 
                                                                // 배열에 해당 변수를 넣고 크기를 후위연산자로 옆으로 한칸 옮긴다
            {
                items[size++] = item;
                Console.WriteLine($"리스트에{item}를(을) 추가하였습니다");
            }
            else                                                // 배열 허용량보단 배열크기가 클경우
            {
                Exceed();                                       // 관련 함수 사용
                items[size++] = item;                           // 배열에 요소 추가
                Console.WriteLine($"리스트에{item}를(을) 추가하였습니다");
            }
        }

        public void Exceed()                                    // 배열 허용치를 초과해서 요소를 추가할경우 더큰배열을 복제해서 본래 배열에 대채하는 함수
        {
            int newCapcity = items.Length * 2;                  // 본래 배열길이의 2배길이생성
            T[] newItems = new T[newCapcity];                   // 복제 배열생성, 배열길이는 전배열의 2배
            Array.Copy(items, 0, newItems, 0, size);            // 배열클래스의 배열복사 함수 사용, 본래배열 크기에 복제배열 크기(본래 배열크기 만큼 복사) 복사하기
            items = newItems;                                   // 본래 배열을 복제배열로 대채하기
        }

        // 배열요소 삭제 관련 기능===================================================================
        public bool Remove(T item)                              // 배열요소를 찾아서 입력한 값과 동일하면 삭제하도록 논리형 bool형을 사용
        {
            int index = Contains(item);                         // 찾는 배열요소 변수에 대입
            if (index >= 0)                                     // 배열안에 있을경우
            {
                if (index < 0 || index >= size)                 // 혹시 찾는 배열이 배열크기를 벗어난 경우 경고
                    throw new IndexOutOfRangeException();
                size--;                                         // 해당 배열크기 삭제
                Array.Copy(items, index + 1, items, index, size - index);   // 삭제된 위치뒤 부터 크기까지 복사해서 삭제된 위치에 붙여둠
                Console.WriteLine($"리스트에서{item}를(을) 삭제하였습니다");
                return true;
            }
            else
            {
                Console.WriteLine($"리스트에는 {item}이(가) 존재하지 않습니다");
                return false;
            }
        }

        public void RemoveNum(int index)
        {
            if (index < 0 || index >= size)                     // 배열크기에 벗어날 경우 예외처리사용
                throw new IndexOutOfRangeException();
            if (index >= 0)
            {
                size--;
                Array.Copy(items, index + 1, items, index, size - index);
                Console.WriteLine($"리스트에서{index}를(을) 삭제하였습니다");
            }

        }

        public int Contains(T item)                             // 배열에 요소가 있는지 확인하는 함수
        {
            return Array.IndexOf(items, item, 0, size);         // 배열요소를 배열크기 만큼 찾아 해당 배열크기를 반환함
        }

        // 배열요소 값을 찾는 기능===================================================================
        public T? Find(Predicate<T> match)                      // 해당 찾는 조건이 어떤 자료형이든 올수있게 일반화T를 사용함
                                                                // 배열의 값을 찾을수있게 조건을 검사해서 나타내는 논리반환형 함수 대리자 Predicate사용 
                                                                // null일경우도 포함해서 ?를 사용함
        {
            if (match == null)                                  // null을 찾을 경우 경고인 예외처리를 구현
                throw new ArgumentNullException("wrong");

            for (int i = 0; i < size; i++)                      // 현재 배열크기 만큼 각 요소 확인
            {
                if (match(items[i]))                            // 배열요소 값과 조건이 같을경우
                    return items[i];                            // 해당 값을 반환
            }

            return default(T?);                                 // 해당 조건을 못찾을 경우 자료형에 대한 기본값을 반환(ex. int = 0, string " "...)
        }

        // 배열요소 찾는 기능===================================================================
        public int FindIndex(Predicate<T> match)                // Find 함수와 메커니즘은 비슷하지만 해당조건 값이 아닌 배열위치를 반환함
        {
            for (int i = 0; i < size; i++)
            {
                if (match(items[i]))
                    return i;                                    // 찾으면 배열위치를 반환
            }
            return -1;                                           // 해당없을 경우 배열밖인 음수-1을 반환함
        }
    }
}
