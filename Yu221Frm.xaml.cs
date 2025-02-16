using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json.Linq;
using REMICON.Common;

namespace REMICON.Views
{
    public partial class Yu221Frm : ContentPage
    {
        List<Common.ColumnDataStackLayout> columns;
        public Yu221Frm()
        {
            InitializeComponent();
            columns = new List<Common.ColumnDataStackLayout>();
            columns.Add(new Common.ColumnDataStackLayout
            {
                Caption = "회사명",
                Field = "Company_Name",
                ToD = ColumnDataStackLayout.TypeOfData.StringField
            });
            columns.Add(new Common.ColumnDataStackLayout
            {
                Caption = "예정량",
                Field = "Plan_Suryang",
                DisplayFormat = "#,##0.#0",
                ToD = ColumnDataStackLayout.TypeOfData.NumberField
            });
            columns.Add(new Common.ColumnDataStackLayout
            {
                Caption = "출하량",
                Field = "Chulha_Suryang",
                DisplayFormat = "#,##0.#0",
                ToD = ColumnDataStackLayout.TypeOfData.NumberField
            });
            columns.Add(new Common.ColumnDataStackLayout
            {
                Caption = "잔량",
                Field = "Janryang",
                DisplayFormat = "#,##0.#0",
                ToD = ColumnDataStackLayout.TypeOfData.NumberField
            });
            columns.Add(new Common.ColumnDataStackLayout
            {
                Caption = "횟수",
                Field = "Chulha_Cnt",
                DisplayFormat = "#,##0",
                ToD = ColumnDataStackLayout.TypeOfData.NumberField
            });

            var grBnSearch = new TapGestureRecognizer();
            grBnSearch.Tapped += TabSearch;
            bnSearch.GestureRecognizers.Add(grBnSearch);

            process_data_receive();
        }
        private void process_data_receive()
        {
            string Q = "Group_Yu221 '" + dpYmd.Date.ToString("yyyy-MM-dd") + "' "; //계열사별출하현황
            JArray jArray = App.DM.GetData(Q, App.UI.GetCompany().CompanyCode, App.UI.GetCompany().DataServer);
            if (jArray != null)
            {
                slRGrid.Children.Clear();
                slRGrid.Children.Add(new Common.CustomDataStackLayout(jArray, columns));
            }
        }

        void TabSearch(object sender, EventArgs e)
        {
            process_data_receive();
        }
    }
    class Yu221
    {
        public int Gubun { get; set; }
        public string Company_Code { get; set; }
        public string Company_Name { get; set; }
        public double Plan_Suryang { get; set; }
        public double Chulha_Suryang { get; set; }
        public int Chulha_Cnt { get; set; }
        public double Janryang { get; set; }
    }
}