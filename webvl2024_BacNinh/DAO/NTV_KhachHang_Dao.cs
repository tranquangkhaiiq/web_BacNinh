using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webvl2024_BacNinh.Models;

namespace webvl2024_BacNinh.DAO
{
    public class NTV_KhachHang_Dao
    {
        ModelBN dbc = new ModelBN();
        
        public KhachHang GetNTV_ByKHID(int KH_ID)
        {
            var mode = dbc.KhachHangs.Find(KH_ID);
             
            return mode;
        }
    }
}