using System;
using System.Collections.Generic;
using System.Text;

namespace REMICON.Models
{
    public enum MenuItemType
    {
        HOME,
        Yu221,//출하현황조회
        Yu421,//판매일보
        Yu431,//거래처별판매원장
        Yu531,//기간별입금현황
        Jj222,//자재입고내역
        Jj241//자재출고내역
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
