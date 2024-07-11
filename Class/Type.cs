// 변수 저장 타입으로 사용할 커스텀 클래스들 정의

namespace POS_Project_Team2.Class
{
    // ENUM 으로 선언된 대기열 번호
    // 단순히 1,2,3 으로 하기보단 조금 더 의미 있게 선언
    public enum WaitNumber
    {
        None = 0,
        Wait1 = 1,
        Wait2 = 2,
        Wait3 = 3
    }

    // SavedProduct 클래스 정의
    public class SavedProduct
    {
        public WaitNumber wait_number { get; set; }
        public List<StockRecord> stock_records { get; set; }

        public SavedProduct(WaitNumber wait_number, List<StockRecord> stock_records)
        {
            this.wait_number = wait_number;
            this.stock_records = stock_records;
        }
    }
}
