using POS_Project_Team2.Class;

namespace POS_Project_Team2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // 애플리케이션 시작 로직
            StartApplication();
        }

        private static void StartApplication()
        {
            // 자동 로그인 처리
            if (File.Exists(LoginForm.auto_login_file_path) && is_verify_auto_login())
            {
                // 자동 로그인이 성공하면 바로 메인 폼을 실행
                Application.Run(new MainForm());
            }
            else
            {
                // 자동 로그인이 실패하거나 파일이 없으면 로그인 폼을 실행
                Application.Run(new LoginForm());
            }
        }

        // 자동 로그인 검증 메서드
        private static bool is_verify_auto_login()
        {
            // 자동 로그인 파일이 있는지 확인
            if (File.Exists(LoginForm.auto_login_file_path))
            {
                string[] lines = File.ReadAllLines(LoginForm.auto_login_file_path);

                if (lines.Length != 2) return false;
                string username = lines[0];
                string hashed_password = lines[1];

                // DBMaster.Instance 에 접근하는 순간 객체가 생성.
                // 이후로 DBMaster.Instance 는 생성된 객체를 반환.
                return DBMaster.Instance.is_exist_user(username, hashed_password);
            }
            return false;
        }
    }
}