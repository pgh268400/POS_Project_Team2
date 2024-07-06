namespace POS_Project_Team2.Class;

/*
 DBMaster 에서 사용하는 DB 스키마를 정의하는 클래스
*/

// 유저 테이블의 데이터를 담을 클래스
public class UserRecord
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

// 결제 테이블과 환불 테이블의 데이터를 담을 클래스
// 참고 : 결제 테이블과 환불 데이터는 테이블 구성(스키마) 이 같다.
public class PayMentRefundRecord
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public string ItemName { get; set; }
    public int UnitPrice { get; set; }
    public int Count { get; set; }
    public int TotalPrice { get; set; }
    public string? Payer { get; set; } // nullable
    public string? PhoneNumber { get; set; } // nullable
}

// 통합 조회 데이터를 담을 클래스
public class TotalRecord : PayMentRefundRecord
{
    // SQlite에는 boolean 타입이 없어 int로 구분한다.
    // 0 = 결제, 1 = 환불
    public int isRefund { get; set; }
}

// 재고 테이블의 데이터를 담을 클래스
public class StockRecord
{
    public int Id { get; set; }
    public string ItemName { get; set; }
    public int Cost { get; set; }
    public int Count { get; set; }
}