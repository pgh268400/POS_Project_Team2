using System.Text;

namespace POS_Project_Team2.Class
{
    /*
      결제내역 및 모든 내용을 추적하는 
      Logger 객체의 설계도 (Class)
    */
    public class Logger
    {
        // 멤버 변수

        // 결제 내역을 저장하는 경로
        private string payment_log_path;

        // 환불 기록을 저장하는 경로
        private string refund_log_path;

        // 통합 기록을 저장하는 경로.
        // 모든 로그는 필연적으로 여기에 쌓인다.
        private string total_log_path;

        // 영수증 출력 기록을 저장하는 경로
        private string receipt_log_path;

        // 결제 내역, 환불기록, 통합 기록, 영수증 출력 기록
        private List<string[]> payment_log, refund_log, total_log, receipt_log;

        /*
         생성자 (Constructor)
          결제 내역, 환불 기록에 대해 저장을 해야하니
          결제 내역, 환불 기록을 저장하는 경로를 입력 받는다.
          파일 생성의 경우 "./payment.csv", "./refund.csv" 과 같은 형태로
          입력이 들어온다. 물론 입력이 귀찮을 수 있으니 default parameter 을 사용해
          기본 경로를 설정해 놓는다.

          마지막 인자로는 통합 결제 내역을 저장하는 경로를 입력 받는다.
        */
        public Logger(string payment_log_path = "./payment.csv", string refund_log_path = "./refund.csv", string receipt_log_path = "./receipt.csv", string total_log_path = "./total.csv")
        {
            // 결제 내역, 환불 기록, 통합기록을 저장하는 경로를 입력 받는다.
            // 캡슐화를 잘 지키도록 하자.
            this.payment_log_path = payment_log_path;
            this.refund_log_path = refund_log_path;
            this.total_log_path = total_log_path;
            this.receipt_log_path = receipt_log_path;

            payment_log = initialize_log(payment_log_path);
            refund_log = initialize_log(refund_log_path);
            total_log = initialize_log(total_log_path);
            receipt_log = initialize_log(receipt_log_path);
        }

        /*
         로그 파일을 초기화하는 함수
         파일이 없으면 생성하고, 있으면 읽어서 리스트를 반환한다.
        */
        private List<string[]> initialize_log(string file_path)
        {
            if (!File.Exists(file_path))
            {
                File.Create(file_path).Close();
                return new List<string[]>();
            }
            else
            {
                return read_csv(file_path);
            }
        }

        // csv 파일을 읽어서 List<string[]> 형태로 반환하는 함수
        public List<string[]> read_csv(string file_path)
        {
            var result = new List<string[]>();
            using (var reader = new StreamReader(file_path, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    result.Add(values);
                }
            }
            return result;
        }

        // csv 파일에 List<string[]> 형태로 저장하는 함수
        public void write_csv(string file_path, List<string[]> data)
        {
            using (var writer = new StreamWriter(file_path, false, Encoding.UTF8))
            {
                foreach (var line in data)
                {
                    writer.WriteLine(string.Join(",", line));
                }
            }
        }

        /*
         로그 항목을 추가하고 CSV에 기록하는 공통 함수
         로그 리스트와 파일 경로, 추가할 정보를 인자로 받는다.
        */
        private void append_log(List<string[]> log, string file_path, string[] info, bool addTimestamp = true)
        {
            var new_entry = new List<string>();
            if (addTimestamp)
            {
                new_entry.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            new_entry.AddRange(info);
            var new_entry_array = new_entry.ToArray();

            log.Add(new_entry_array);
            total_log.Add(new_entry_array);

            write_csv(file_path, log);
            write_csv(total_log_path, total_log);
        }

        // 결제 내역을 추가하는 함수
        public void append_payment_log(string[] payment_info)
        {
            append_log(payment_log, payment_log_path, payment_info);
        }

        // 결제 내역을 조회하는 함수
        public List<string[]> get_payment_log()
        {
            return payment_log;
        }

        // 삭제할 인덱스 위치를 받아 결제 내역을 삭제하는 함수
        public void remove_payment_log(int index)
        {
            payment_log.RemoveAt(index);
            write_csv(payment_log_path, payment_log);

            // 참고로 total log 는 모든 내역을 기록해야 하므로,
            // 추가시만 더 추가될뿐, 삭제는 없다.
        }

        // 영수증 내역을 추가하는 함수
        public void append_receipt_log(string[] receipt_info)
        {
            append_log(receipt_log, receipt_log_path, receipt_info);
        }

        // 영수증 내역을 조회하는 함수
        public List<string[]> get_receipt_log()
        {
            return receipt_log;
        }

        // 삭제할 인덱스 위치를 받아 영수증 내역을 삭제하는 함수
        public void remove_receipt_log(int index)
        {
            receipt_log.RemoveAt(index);
            write_csv(receipt_log_path, receipt_log);

            // 참고로 total log 는 모든 내역을 기록해야 하므로,
            // 추가시만 더 추가될뿐, 삭제는 없다.
        }

        // 환불 내역을 추가하는 함수
        public void append_refund_log(string[] refund_info)
        {
            append_log(refund_log, refund_log_path, refund_info, false);
        }

        // 전체 로그 기록을 조회하는 함수
        public List<string[]> get_total_log()
        {
            return total_log;
        }

        // 환불 내역을 조회하는 함수
        public List<string[]> get_refund_log()
        {
            return refund_log;
        }

        // 삭제할 인덱스 위치를 받아 환불 내역을 삭제하는 함수
        public void remove_refund_log(int index)
        {
            refund_log.RemoveAt(index);
            write_csv(refund_log_path, refund_log);

            // 참고로 total log 는 모든 내역을 기록해야 하므로,
            // 추가시만 더 추가될뿐, 삭제는 없다.
        }

        // 모든 로그 파일을 삭제하는 함수
        public void delete_all_log()
        {
            payment_log.Clear();
            refund_log.Clear();
            total_log.Clear();
            receipt_log.Clear();

            write_csv(payment_log_path, payment_log);
            write_csv(refund_log_path, refund_log);
            write_csv(total_log_path, total_log);
            write_csv(receipt_log_path, receipt_log);
        }
    }
}
