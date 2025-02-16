using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections;

namespace REMICON.Common
{
    public class CustomGrid : ContentView
    {
        ScrollView sv;
        StackLayout sl;
        StackLayout slColumn;
        Grid grdColumn;
        ListView lvData;

        Grid grdRow;

        int columnCnt;

        public CustomGrid(IEnumerable itemsource, List<Column> columns)
        {
            //Content = new Label { Text = "Hello ContentView" };


            columnCnt = 0;
            sv = new ScrollView { Orientation = ScrollOrientation.Horizontal };
            sl = new StackLayout { Orientation = StackOrientation.Vertical };
            slColumn = new StackLayout { Orientation = StackOrientation.Horizontal, Padding = 0, Margin = new Thickness(0, 0, 0, -6) };
            grdColumn = new Grid { ColumnSpacing = 0, RowSpacing = 0, Margin = 0, Padding = 0 };

            foreach (Column c in columns)
            {
                AddColumn(c.Caption);
            }

            var it = new DataTemplate(() =>
            {
                grdRow = new Grid { ColumnSpacing = 0, RowSpacing = 0 };

                int x = 0;
                foreach (Column c in columns)
                {
                    AddRow(c.Field, x, 0, c.ToD, c.DisplayFormat);
                    x += 1;
                }

                return new ViewCell { View = grdRow };
            });
            lvData = new ListView { ItemsSource = itemsource, ItemTemplate = it, Margin = 0, HasUnevenRows = true, SeparatorColor = Color.FromHex("dbdbe0") };



            Content = sv;
            sv.Content = sl;
            sl.Children.Add(slColumn);
            slColumn.Children.Add(grdColumn);
            sl.Children.Add(lvData);
        }

        public void AddColumn(string caption)
        {
            BoxView boxView = new BoxView { BackgroundColor = Color.FromHex("E0E0E0") };
            Grid inGrid = new Grid { BackgroundColor = Color.FromHex("F5F5F5"), Margin = new Thickness(1, 1, 1, 1), Padding = 0 };
            grdColumn.Children.Add(boxView, columnCnt, 0);
            grdColumn.Children.Add(inGrid, columnCnt, 0);

            inGrid.Children.Add(new Label
            {
                Text = caption,
                WidthRequest = 120,
                HeightRequest = 30,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            });
            columnCnt += 1;
        }

        public void AddRow(string value, int x, int y, Column.TypeOfData typeOfData, String displayFormat)
        {
            BoxView bvRow = new BoxView { BackgroundColor = Color.FromHex("E0E0E0") };//dbdbe0
            Grid inRow = new Grid { BackgroundColor = Color.White, Margin = new Thickness(1, 0, 1, 1), Padding = 0 };
            grdRow.Children.Add(bvRow, x, y);
            grdRow.Children.Add(inRow, x, y);

            Label lbValue = new Label();
            //lbValue.SetBinding(Label.TextProperty, value);
            //lbValue.SetBinding(Label.FormattedTextProperty)
            lbValue.VerticalTextAlignment = TextAlignment.Center;
            lbValue.WidthRequest = 120;
            lbValue.Margin = new Thickness(3, 3, 3, 3);

            switch (typeOfData)
            {
                case Column.TypeOfData.NumberField:
                    lbValue.HorizontalTextAlignment = TextAlignment.End;
                    if (displayFormat.Equals(""))
                    {
                        lbValue.SetBinding(Label.TextProperty, value);
                    }
                    else
                    {
                        var binding = new Binding(value)
                        {
                            StringFormat = "{0:" + displayFormat + "}"
                        };
                        lbValue.SetBinding(Label.TextProperty, binding);
                    }

                    break;
                case Column.TypeOfData.StringField:
                    lbValue.SetBinding(Label.TextProperty, value);
                    lbValue.HorizontalTextAlignment = TextAlignment.Start;
                    break;
                default:
                    lbValue.SetBinding(Label.TextProperty, value);
                    lbValue.HorizontalTextAlignment = TextAlignment.Start;
                    break;
            }
            inRow.Children.Add(lbValue);
        }
    }

    public class Column
    {
        public enum TypeOfData : int
        {
            StringField = 0,
            NumberField = 1
        }
        public string Caption;
        public string Field;
        public string DisplayFormat = "";
        public string Align;
        public TypeOfData ToD { get; set; }
    }
}


