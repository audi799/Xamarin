using System;
using System.Collections.Generic;

namespace REMICON.Common
{
    public class Company
    {
        public int Idx = 0;
        public string CompanyCode = "";
        public string CompanyName = "";
        public string DataServerURL = "";
        public string JohapServerURL = "";
        public string BackupServerURL = "";
        public string GPSURL = "";
        public string DataServer = "";
        public string JohapServer = "";
        public string BackupServer = "";
        public string DataServerPath = "";
        public string JohapServerPath = "";
        public string BackupServerPath = "";
        public string GPSDBPath = "";
        //public List<Cm_Cust> Cm_Custs;
        public string Right_Jh111 = "";
        public string Right_Jh214 = "";
        public string Right_Yu121 = "";
        public string Right_Yu221 = "";
        public string Right_GPS = "";
        public string Right_Yu411 = "";
        public string Right_Yu421 = "";
        public string Right_Yu431 = "";
        public string Right_Yu432 = "";
        public string Right_Yu511 = "";
        public string Right_Yu521 = "";
        public string Right_Yu531 = "";
        public string Right_Yu541 = "";

        public Company()
        {
            //Cm_Custs = new List<Cm_Cust>();
            CompanyCode = "RM_314";
            CompanyName = "중앙계열사";
            DataServerURL = "";
            JohapServerURL = "";
            BackupServerURL = "";
            GPSURL = "";
            DataServer = "B3";
            JohapServer = "";
            BackupServer = "";
            DataServerPath = "";
            JohapServerPath = "";
            BackupServerPath = "";
            GPSDBPath = "";
        }
    }
}
