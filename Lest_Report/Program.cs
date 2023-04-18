namespace Lest_Report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 배열요소 추가 및 허용량 초과시 반응 확인
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            list.Add("1번 데이터");
            list.Add("2번 데이터");
            list.Add("3번 데이터");
            list.Add("4번 데이터");
            list.Add("5번 데이터");
            list.Add("6번 데이터");

            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);


            // 배열요소 제거 반응 확인
            list.Remove("2번 데이터");
            list.RemoveNum(0);

            // 배열크기 확인
            for (int i = 0; i < list2.Count; i++)
            {
                Console.WriteLine(list2[i]);
            }

            // 배열 요소 값과 위치를 찾는 함수 확인
            string? findValue = list.Find(x => x.Contains('4'));
            int findIndex = list.FindIndex(x => x.Contains('1'));
        }

        //기술면접=====================================
        // 배열 :

        // 선형리스트 :

    }
}