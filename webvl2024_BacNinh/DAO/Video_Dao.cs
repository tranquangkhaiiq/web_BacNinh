﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webvl2024_BacNinh.Models;
namespace webvl2024_BacNinh.DAO
{
    public class Video_Dao
    {
        //public static Object GetList_Skip(ModelBN db, int Sec, int pageSize)
        //{
        //    var model = db.Videos.Where(cc => cc.IsVisible == true && cc.PortalId == 81)
        //                .OrderByDescending(cc => cc.Fixdate).ThenByDescending(cc => cc.VideoId)
        //                .Skip(Sec * pageSize)
        //                .Take(pageSize)
        //                .ToList();
        //    return model;
        //}
        //public static Object GetList_NoSkip(ModelBN db, int Sec, int pageSize)
        //{
        //    var model = db.Videos.Where(cc => cc.IsVisible == true && cc.PortalId == 81)
        //                .OrderByDescending(cc => cc.Fixdate).ThenByDescending(cc => cc.VideoId)
        //                .Take(pageSize * (Sec + 1))
        //                .ToList();
        //    return model;
        //}
    }
}