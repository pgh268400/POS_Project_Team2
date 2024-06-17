using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // 결제 내역을 저장하는 List<string[]> 형태의 변수
        private List<string[]> payment_log;

        // 환불 기록을 저장하는 List<string[]> 형태의 변수
        private List<string[]> refund_log;

        // 통합 기록을 저장하는 List<string[]> 형태의 변수
        private List<string[]> total_log;

        // 영수증 출력 기록을 저장하는 List<string[]> 형태의 변수
        private List<string[]> receipt_log;


        /*
         생성자 (Constructor)
          결제 내역, 환불 기록에 대해 저장을 해야하니
          결제 내역, 환불 기록을 저장하는 경로를 입력 받는다.
          파일 생성의 경우 "./payment.csv", "./refund.csv" 과 같은 형태로
          입력이 들어온다. 물론 입력이 귀찮을 수 있으니 default parameter 을 사용해
          기본 경로를 설정해 놓는다.

          마지막 인자로는 통합 결제 내역을 저장하는 경로를 입력 받는다.
        */
        public Logger(string payment_log_path = "./payment.csv", string refund_log_path="./refund.csv", string receipt_log_path="./receipt.csv", string total_log_path = "./total.csv")
        {
            // 결제 내역, 환불 기록, 통합기록을 저장하는 경로를 입력 받는다.
            // 캡슐화를 잘 지키도록 하자.
            this.payment_log_path = payment_log_path;
            this.refund_log_path = refund_log_path;
            this.total_log_path = total_log_path;
            this.receipt_log_path = receipt_log_path;

            // 결제 내역, 환불 기록, 통합 기록을 저장하는 파일이 없다면 생성한다.

            if (!File.Exists(payment_log_path))
            {
                File.Create(payment_log_path).Close();
                payment_log = new List<string[]>();
            }

            if (!File.Exists(refund_log_path))
            {
                File.Create(refund_log_path).Close();
                refund_log = new List<string[]>();
            }

            if (!File.Exists(total_log_path))
            {
                File.Create(total_log_path).Close();
                total_log = new List<string[]>();
            }

            if (!File.Exists(receipt_log_path))
            {
                File.Create(receipt_log_path).Close();
                receipt_log = new List<string[]>();
            }

            // 결제 내역, 환불 기록, 통합 기록에 대한 정보가 있다면
            // 읽어 들여서 멤버 변수에 기록한다.
            // 이 때, 결제 내역, 환불 기록, 통합 기록은 List<string[]> 형태로 저장한다.

            this.payment_log = read_csv(payment_log_path);
            this.refund_log = read_csv(refund_log_path);
            this.total_log = read_csv(total_log_path);
            this.receipt_log = read_csv(receipt_log_path);
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

        // 결제 내역을 추가하는 함수
        public void append_payment_log(string[] payment_info)
        {
            this.payment_log.Add(payment_info);
            this.total_log.Add(payment_info);
            write_csv(payment_log_path, payment_log);
            write_csv(total_log_path, total_log);
        }

        // 결제 내역을 조회 하는 함수
        public List<string[]> get_payment_log()
        {
            return this.payment_log;
        }

        // 삭제할 인덱스 위치를 받아 결제 내역을 삭제하는 함수
        public void remove_payment_log(int index)
        {
            this.payment_log.RemoveAt(index);
            write_csv(payment_log_path, payment_log);

            // 참고로 total log 는 모든 내역을 기록해야 하므로,
            // 추가시만 더 추가될뿐, 삭제는 없다.
        }

        // 영수증 내역을 추가하는 함수
        public void append_receipt_log(string[] receipt_info)
        {
            this.receipt_log.Add(receipt_info);
            write_csv(receipt_log_path, receipt_log);

            this.total_log.Add(receipt_info);
            write_csv(total_log_path, total_log);
        }

        // 영수증 내역을 조회 하는 함수
        public List<string[]> get_receipt_log()
        {
            return this.receipt_log;
        }

        // 삭제할 인덱스 위치를 받아 영수증 내역을 삭제하는 함수
        public void remove_receipt_log(int index)
        {
            this.receipt_log.RemoveAt(index);
            write_csv(receipt_log_path, receipt_log);

            // 참고로 total log 는 모든 내역을 기록해야 하므로,
            // 추가시만 더 추가될뿐, 삭제는 없다.
        }


        // 환불 내역을 추가하는 함수
        public void append_refund_log(string[] refund_info)
        {
            this.refund_log.Add(refund_info);
            this.total_log.Add(refund_info);
            write_csv(refund_log_path, refund_log);
            write_csv(total_log_path, total_log);
        }

        // 환불 내역을 조회 하는 함수
        public List<string[]> get_refund_log()
        {
            return this.refund_log;
        }

        // 삭제할 인덱스 위치를 받아 환불 내역을 삭제하는 함수
        public void remove_refund_log(int index)
        {
            this.refund_log.RemoveAt(index);
            write_csv(refund_log_path, refund_log);

            // 참고로 total log 는 모든 내역을 기록해야 하므로,
            // 추가시만 더 추가될뿐, 삭제는 없다.
        }

        // 모든 로그 파일을 삭제하는 함수
        public void delete_all_log()
        {
            this.payment_log.Clear();
            this.refund_log.Clear();
            this.total_log.Clear();
            this.receipt_log.Clear();

            write_csv(payment_log_path, payment_log);
            write_csv(refund_log_path, refund_log);
            write_csv(total_log_path, total_log);
            write_csv(receipt_log_path, receipt_log);
        }
    }
}
