using Timer = System.Windows.Forms.Timer;

namespace POS_Project_Team2.Class
{
    // 라벨의 실시간 시간 표시를 구현하기 위한 
    // RealTimeClock 객체의 설계도(= Class)
    // 싱글톤 패턴으로 구현되어 구조가 다소 복잡하다.
    public class RealTimeClock
    {
        // 내부 변수 및 함수는 캡슐화를 원칙으로 한다.

        // 싱글톤 인스턴스를 저장할 정적 변수
        private static RealTimeClock instance;

        // 타이머와 현재 시간을 저장할 변수
        private Timer realtime_timer;
        private DateTime currentTime;

        // 등록된 라벨을 저장할 배열
        private Label[] labels;

        // sender, event 관련
        private object sender;
        private EventArgs e;

        public RealTimeClock()
        {
            this.realtime_timer = new Timer();
            this.realtime_timer.Interval = 1000; // 1초 간격
            this.realtime_timer.Tick += Realtime_timer_Tick;
            this.labels = new Label[0]; // 초기에는 아무 레이블도 없음
        }

        // 싱글톤 인스턴스를 반환하는 정적 프로퍼티
        public static RealTimeClock Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RealTimeClock();
                }

                return instance;
            }
        }

        // 타이머를 시작하는 메서드
        public void start_clock()
        {
            // 타이머 시작 전에 현재 시간을 표시
            Realtime_timer_Tick(null, EventArgs.Empty);

            // 이후 타이머 실행
            this.realtime_timer.Start();
        }

        // 라벨을 등록하는 메서드
        public void register_label(Label label)
        {
            /*
             label 을 인자로 받는다. 참고로 label은 Class 형이라, Class 형은 기본적으로
             C/C++ 로 따지면 주소를 참조하는 형태가 된다. (Call by Reference)
             즉 인자로 받은게 실제로는 특정 폼의 label 객체 메모리를 가르키게 된다.
             여기서 받아낸 label을 수정하면 호출자쪽의 label 역시 수정된다.
             이 원리를 사용하여 들어온 label에 타이머와 기능을 걸어주면
             label을 손쉽게 실시간 시간 label로 만들 수 있다.
           */

            // 새로운 Label을 배열에 추가
            Array.Resize(ref labels, labels.Length + 1);
            labels[labels.Length - 1] = label;

            // Label에 현재 시간 표시
            label.Text = currentTime.ToString("HH:mm:ss");
        }

        // 타이머 틱 이벤트 핸들러
        private void Realtime_timer_Tick(object sender, EventArgs e)
        {
            // 현재 시간을 갱신
            currentTime = DateTime.Now;

            // 모든 등록된 Label에 현재 시간 표시
            foreach (var label in labels)
            {
                label.Text = currentTime.ToString("HH:mm:ss");
            }
        }
    }
}