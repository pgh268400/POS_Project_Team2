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
// PayMentRefundRecord 를 상속후 isRefund 변수만 추가로 가진다.
public class TotalRecord : PayMentRefundRecord
{

    // SQlite에는 boolean 타입이 없어 int로 구분한다.
    // 0 = 결제, 1 = 환불
    public int isRefund { get; set; }
}

// 영수증 기록 데이터를 담을 클래스
public class ReceiptRecord
{
    public int Id { get; set; }  // 자동 증가하는 기본 키
    public string TerminalNumber { get; set; }  // 단말기 번호
    public string SlipNumber { get; set; }  // 전표 번호
    public string Merchant { get; set; }  // 가맹점
    public string PointHolder { get; set; }  // 포인트 적립자
    public string BusinessNumber { get; set; }  // 사업자 번호
    public string TelNumber { get; set; }  // 전화번호
    public int Amount { get; set; }  // 금액
    public int Vat { get; set; }  // 부가세
    public int Total { get; set; }  // 합계
    public string CardName { get; set; }  // 카드명
    public string CardNumber { get; set; }  // 카드 번호
    public bool IsInstallment { get; set; }  // 일시불 여부 (true 또는 false)
    public DateTime PayDay { get; set; }  // 거래 일시
    public string ApprovalNumber { get; set; }  // 승인 번호

}

// 재고 테이블의 데이터를 담을 클래스
public class StockRecord
{
    public int Id { get; set; }
    public string ItemName { get; set; }
    public int Cost { get; set; }
    public int Count { get; set; }
}

// DB 테이블 이름과 레코드 타입을 저장하는 클래스
public class SQLiteTable
{
    public string table_name { get; }
    public Type record_type { get; }

    public SQLiteTable(string table_name, Type record_type)
    {
        this.table_name = table_name;
        this.record_type = record_type;
    }
}