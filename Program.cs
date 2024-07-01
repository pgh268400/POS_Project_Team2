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

            // ���ø����̼� ���� ����
            StartApplication();
        }

        private static void StartApplication()
        {
            // �ڵ� �α��� ó��
            if (File.Exists(LoginForm.auto_login_file_path) && is_verify_auto_login())
            {
                // �ڵ� �α����� �����ϸ� �ٷ� ���� ���� ����
                Application.Run(new MainForm());
            }
            else
            {
                // �ڵ� �α����� �����ϰų� ������ ������ �α��� ���� ����
                Application.Run(new LoginForm());
            }
        }

        // �ڵ� �α��� ���� �޼���
        private static bool is_verify_auto_login()
        {
            // �ڵ� �α��� ������ �ִ��� Ȯ��
            if (File.Exists(LoginForm.auto_login_file_path))
            {
                string[] lines = File.ReadAllLines(LoginForm.auto_login_file_path);

                if (lines.Length != 2) return false;
                string username = lines[0];
                string hashed_password = lines[1];

                // DBMaster.Instance �� �����ϴ� ���� ��ü�� ����.
                // ���ķ� DBMaster.Instance �� ������ ��ü�� ��ȯ.
                return DBMaster.Instance.is_exist_user(username, hashed_password);
            }
            return false;
        }
    }
}