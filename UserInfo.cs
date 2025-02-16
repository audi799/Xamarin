using System;
using System.Collections.Generic;

namespace REMICON.Common
{
    public class UserInfo
    {
        public string User_Id;
        public string User_Pass;
        public string User_Name;
        public string Jikchaek;
        public int SelectedCompanyIdx;
        public string LoginStatus = "FAIL";
        public List<Common.Company> Companies;

        public UserInfo()
        {
            SelectedCompanyIdx = 0;
            Companies = new List<Company>();
            Company company = new Company();
            Companies.Add(company);
        }

        public Common.Company GetCompany()
        {
            return Companies[SelectedCompanyIdx];
        }
    }
}
