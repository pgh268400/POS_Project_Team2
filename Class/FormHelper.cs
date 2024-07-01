namespace POS_Project_Team2.Class
{
    // 폼과 관련된 모든것의 작업을 도와주는 도우미 클래스

    using System.Collections.Generic;
    using System.Windows.Forms;

    public static class FormHelper
    {

        // 열린 폼들을 추적하기 위한 Dictionary
        // 이 변수를 통해 열린 폼들을 관리하며, static을 붙였기에 프로그램 종료때까지 메모리에 상주하게 된다.
        private static Dictionary<string, Form> open_forms = new();

        // 폼을 여는 함수.
        // 열려 있지 않다면 열고 열려있으면 해당 폼을 활성화한다.
        public static Form show(Form form)
        {
            string form_name = form.Name;

            // 이미 해당 이름의 폼이 열려있는지 확인
            if (open_forms.ContainsKey(form_name))
            {
                // 폼이 열려있다면 해당 폼을 활성화
                Form open_form = open_forms[form_name];
                if (open_form != null && !open_form.IsDisposed)
                {
                    open_form.Activate();
                }
                else
                {
                    // 폼이 닫혔거나 disposed 상태라면 Dictionary에서 제거
                    open_forms.Remove(form_name);
                    // 새로운 폼을 열고 Dictionary에 추가
                    form.Show();
                    open_forms[form_name] = form;
                }
            }
            else
            {
                // 폼이 열려있지 않다면 새로 열고 Dictionary에 추가
                form.Show();
                open_forms[form_name] = form;
            }

            // 폼이 닫힐 때 open_forms에서 제거
            form.FormClosed += (sender, e) => open_forms.Remove(form_name);

            // 참조(주소) 를 Form 타입으로 반환
            return form;
        }


        // 컬럼 너비를 비율로 조정하는 메서드
        public static void adjust_column_widths(ListView list_view, int[] column_widths)
        {
            if (list_view.Columns.Count != column_widths.Length)
                throw new ArgumentException("컬럼의 수와 비율 배열의 길이가 일치하지 않습니다.");

            /*
              리스트뷰 비율 전체 합이 100이 아닌 경우 Exception 발생
              Linq를 활용해 배열 내부에서 마치 SQL 쿼리를 사용하듯이 Sum(합)을 구한다.
              대충 배열 하나 하나 요소가 쿼리할 때 나오는 숫자 행 값들이라고 생각하면 될 거 같다.
              Ex) column_widths.Sum() -> SELECT SUM(column_widths) FROM column_widths
            */
            if (column_widths.Sum() != 100)
                throw new ArgumentException("컬럼 너비 비율의 합이 100이 아닙니다.");

            int total_width = list_view.ClientSize.Width;
            for (int i = 0; i < column_widths.Length; i++)
                list_view.Columns[i].Width = (int)(total_width * column_widths[i] / 100.0);
        }
    }
}
