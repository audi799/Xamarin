using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using REMICON.Views;

using Newtonsoft.Json.Linq;

namespace REMICON
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //저장된 사용자 아이디, 패스워드 불러오기
            if (Application.Current.Properties.ContainsKey("User_Id"))
            {
                etUser_Id.Text = Application.Current.Properties["User_Id"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("User_Pass"))
            {
                etUser_Pass.Text = Application.Current.Properties["User_Pass"].ToString();
            }
        }
        public async Task<bool> process_login_receive(string User_Id, string User_Pass)
        {
            string Q = "select U.Cust_Code, U.User_Id, U.User_Password, U.User_Name, U.Buseo_Code, U.Connect_Ymd, P.Program_No "
                                + "from cm_connect_user U, cm_connect_program P "
                                + "where P.cust_code = U.cust_code "
                                + "and P.user_id = U.user_id "
                                + "and P.program_no = 101 "
                                + "and U.cust_code = 'RM_314' "
                                + "and U.user_id = '" + User_Id + "' "
                                + "and U.user_password = '" + User_Pass + "' ";
            JArray jArray = App.DM.GetData(Q, "gimaek", "J0");

            if (jArray.Count == 1)
            {
                Application.Current.Properties["User_Id"] = User_Id;
                Application.Current.Properties["User_Pass"] = User_Pass;
                return true; //로그인성공
            }
            else
            {
                return false; //로그인실패
            }

        }
        private async void BnLoginClickedAsync(object sender, System.EventArgs e)
        {
            if (await process_login_receive(etUser_Id.Text, etUser_Pass.Text))
            {
                Application.Current.MainPage = new Yu221Frm();
            }
            else
            {
                await DisplayAlert("Gimaek", "Login Failed !!" + "\r\n" + "Check your ID or password.", "OK");
            }
        }

        private void etUser_IdOnCompleted(object sender, EventArgs e)
        {
            etUser_Pass.Focus();
        }

        private void etUser_PassOnCompleted(object sender, EventArgs e)
        {
            BnLoginClickedAsync(this, e);
        }
    }
}
