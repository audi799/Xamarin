using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace REMICON.Common
{
    public class CustomDataStackLayout : ContentView
    {
        int columnCnt;
        Grid grdColumn;
        Grid grdRow;
        ScrollView sv;
        StackLayout sl;
        //StackLayout mainSl;
        //StackLayout slColumn;


        public CustomDataStackLayout(JArray array, List<ColumnDataStackLayout> columns)
        {
            columnCnt = 0;
            //mainSl = new StackLayout { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            sv = new ScrollView { Orientation = ScrollOrientation.Both, Margin = new Thickness(0, -6, 0, 0) };
            sl = new StackLayout { Orientation = StackOrientation.Vertical };
            grdColumn = new Grid { ColumnSpacing = 0, RowSpacing = 0, Margin = new Thickness(1, 0, 0, 0), Padding = 0 };
            grdRow = new Grid { ColumnSpacing = 0, RowSpacing = 0, Margin = new Thickness(1, -6, 0, 0), Padding = 0 };

            foreach (ColumnDataStackLayout c in columns)
            {
                AddColumn(c.Caption, c.Width);
            }
            //Content = mainSl;
            //mainSl.Children.Add(grdColumn);
            //mainSl.Children.Add(sv);
            //sl.Children.Add(grdColumn);

            Content = sv;
            sv.Content = sl;
            sl.Children.Add(grdColumn);

            int rowidx = 0;
            if (array.Count == 0)
            {
                sl.Children.Add(new Label()
                {
                    Text = "조회된 데이터가 없습니다.",
                    FontSize = 12,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(30, 50, 0, 0),
                    TextColor = Color.FromHex("#E65100")
                });
            }
            else
            {
                sl.Children.Add(grdRow);
                foreach (JObject jObject in array)
                {
                    columnCnt = 0;
                    for (int i = 0; i < columns.Count; i++)
                    {
                        switch (columns[i].ToD)
                        {
                            case ColumnDataStackLayout.TypeOfData.NumberField:
                                if (jObject.GetValue(columns[i].Field) != null)
                                {
                                    double d = double.Parse(jObject.GetValue(columns[i].Field).ToString());
                                    AddRow(d.ToString(columns[i].DisplayFormat), rowidx, columns[i].Width);
//                                    AddRow(jObject.GetValue(columns[i].Field).ToString(), rowidx, columns[i].Width);
                                }
                                else
                                {
                                    AddRow("0", rowidx, columns[i].Width);
                                }
                                break;
                            case ColumnDataStackLayout.TypeOfData.StringField:
                                if (jObject.GetValue(columns[i].Field) != null)
                                {
                                    AddRow(jObject.GetValue(columns[i].Field).ToString(), rowidx, columns[i].Width);
                                }
                                else
                                {
                                    AddRow("", rowidx, columns[i].Width);
                                }
                                break;
                            default:
                                if (jObject.GetValue(columns[i].Field) != null)
                                {
                                    AddRow(jObject.GetValue(columns[i].Field).ToString(), rowidx, columns[i].Width);
                                }
                                else
                                {
                                    AddRow("", rowidx, columns[i].Width);
                                }
                                break;
                        }
                    }
                    rowidx++;
                }
            }

        }

        public void AddColumn(string caption, int w)
        {
            BoxView boxView = new BoxView { BackgroundColor = Color.FromHex("E0E0E0") };
            Grid inGrid = new Grid { BackgroundColor = Color.FromHex("F5F5F5"), Margin = new Thickness(0, 1, 1, 0), Padding = 0 };
            grdColumn.Children.Add(boxView, columnCnt, 0);
            grdColumn.Children.Add(inGrid, columnCnt, 0);

            inGrid.Children.Add(new Label
            {
                Text = caption,
                FontSize = 10,
                WidthRequest = w,
                HeightRequest = 30,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            });
            columnCnt += 1;
        }
        public void AddRow(string value, int t, int w)
        {
            BoxView boxView = new BoxView { BackgroundColor = Color.FromHex("E0E0E0") };
            StackLayout inSl = new StackLayout
            {
                BackgroundColor = Color.White,
                Margin = new Thickness(0, 1, 1, 0),
                Padding = 0
            };
            grdRow.Children.Add(boxView, columnCnt, t);
            grdRow.Children.Add(inSl, columnCnt, t);

            inSl.Children.Add(new Label
            {
                Text = value,
                FontSize = 10,
                WidthRequest = w,
                HeightRequest = 30,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            });
            columnCnt += 1;
        }
    }
    public class ColumnDataStackLayout
    {
        public enum TypeOfData : int
        {
            StringField = 0,
            NumberField = 1
        }
        public int idx;
        public string Caption;
        public string Field;
        public string DisplayFormat = "";
        public string Align;
        public int Width = 120;
        public TypeOfData ToD { get; set; }
    }
}
