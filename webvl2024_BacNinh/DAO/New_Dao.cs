using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using webvl2024_BacNinh.Models;
using webvl2024_BacNinh.DAO;
namespace webvl2024_BacNinh.DAO
{
    public class New_Dao
    {

        ModelBN dbc = new ModelBN();
        public static Pay_Sys Pay_Sys = new Pay_Sys();
        public static List<New_small> model_NewsSlide = new List<New_small>();
        private static List<New_small> model_NewCategoryId = new List<New_small>();
        
        public static Pay_Sys GetPay_Sys(ModelBN db)
        {
            //load o trang Index
            var model = db.Database.SqlQuery<Pay_Sys>("SELECT top(1) * FROM [VLBN].[dbo].[Pay_Sys]").FirstOrDefault();
            return model;
        }
        public NewsCategory GetCategory(int Id)
        {
            var model = dbc.NewsCategories.FirstOrDefault(kh=>kh.CategoryID == Id);
            return model;
        }
        //public static List<News> Get_NewIndexPortalId(ModelBN db,int CategoryId, int skip, int take)
        //{
        //    //CategoryId == 4168 : QuangCao_Small
        //    var model = new List<News>();
        //    if (skip == 0)
        //    {
        //        model = db.Database.SqlQuery<News>("SELECT top(1) * FROM [ModelBN].[dbo].[News] where CategoryId = @Key and PortalId=81 " +
        //                            "order by NewId desc", new SqlParameter("@Key", CategoryId))
        //                                .Take(take)
        //                                .ToList();
        //    }
        //    else
        //    {
        //        model = db.Database.SqlQuery<News>("SELECT top(1) * FROM [ModelBN].[dbo].[News] where CategoryId = @Key and PortalId=81 " +
        //                            "order by NewId desc", new SqlParameter("@Key", CategoryId))
        //                                .Skip(skip)
        //                                .Take(take)
        //                                .ToList();
        //    }
        //    return model;
        //}
        public static List<New_small> Get_QCslideisActive(ModelBN db, int skip, int take)
        {
            var model = new List<New_small>();
            if (skip == 0 && take > 0)
            {
                model = db.Database.SqlQuery<New_small>("SELECT [NewId],[CategoryId],[Title],[ImagePath],[Summary],[Hotcat],[Hotsite],[Createdate]" +
                    ",[PortalId],[View] FROM [VLBN].[dbo].[News] where (CategoryId = 4166 or CategoryId = 4167) and isActive=1 " +
                                    "order by NewId desc")
                                        .Take(take)
                                        .ToList();
            }
            else if (skip > 0 && take > 0)
            {
                model = db.Database.SqlQuery<New_small>("SELECT [NewId],[CategoryId],[Title],[ImagePath],[Summary],[Hotcat],[Hotsite],[Createdate]" +
                    ",[PortalId],[View] FROM [VLBN].[dbo].[News] where (CategoryId = 4166 or CategoryId = 4167) and isActive=1 " +
                                    "order by NewId desc")
                                        .Skip(skip * take)
                                        .Take(take)
                                        .ToList();
            }
            else if (skip == 0 && take == 0)
            {
                model = db.Database.SqlQuery<New_small>("SELECT [NewId],[CategoryId],[Title],[ImagePath],[Summary],[Hotcat],[Hotsite],[Createdate]" +
                    ",[PortalId],[View] FROM [VLBN].[dbo].[News] where (CategoryId = 4166 or CategoryId = 4167) and isActive=1 " +
                                    "order by NewId desc").ToList();
            }
            return model;
        }
        public static List<New_small> LinQ_NewsSlide(ModelBN db)
        {
            //load o trang Index
            var model = db.Database.SqlQuery<New_small>("exec GetListNew_Slide_Khai").ToList();
            return model;
        }
        public List<New_small> LinQQC_NewCategoryId(int CategoryId)
        {
            var model = dbc.Database.SqlQuery<New_small>("SELECT [NewId],[CategoryId],[Title],[ImagePath],[Summary],[Hotcat],[Hotsite],[Createdate]" +
                    ",[PortalId],[View] FROM [VLBN].[dbo].[News] where CategoryId = @Key and isActive=1 " +
                                    "order by NewId desc", new SqlParameter("@Key", CategoryId)).ToList();
            return model;
        }
        public List<New_small> Get_NewQCslideisActive(int CategoryId, int skip, int take)
        {
            //CategoryId == 4169 : QuangCaoTT_Slide
            var model = new List<New_small>();
            
            model_NewCategoryId = LinQQC_NewCategoryId(CategoryId);
            if (skip == 0 && take > 0)
            {
                model = model_NewCategoryId
                                        .Take(take)
                                        .ToList();
            }
            else if (skip > 0 && take > 0)
            {
                model = model_NewCategoryId
                                        .Skip(skip * take)
                                        .Take(take)
                                        .ToList();
            }
            else if (skip == 0 && take == 0)
            {
                model = model_NewCategoryId.ToList();
            }
            return model;
        }
        //
        public static List<New_small> Get_NewQCslideNOisActive(ModelBN db, int skip, int take)
        {//chỉ có 10 tin nổi bật quan ly boi proc "GetListNew_Slide_Khai"

            ////*****isActive =1 and Hotsite =1 order by Createdate2 desc
            var model = new List<New_small>();
            if (skip == 0 && take == 1)
            {
                model = model_NewsSlide
                                    .Take(1)
                                    .ToList();
            }
            else if (skip == 0 && take > 1)
            {
                model  = model_NewsSlide.Take(take).ToList();
            }
            else if (skip > 0)
            {
                model = model_NewsSlide
                        .Skip(skip)
                        .Take(take)
                        .ToList();
            }

            return model;
        }
        public List<New_small> Get_NewCategoryId(int CategoryId, int skip, int take)
        {
            var model = new List<New_small>();
            
            model_NewCategoryId = LinQQC_NewCategoryId(CategoryId);

            if (skip == 0)
            {
                model = model_NewCategoryId
                                        .Take(take)
                                        .ToList();
            }
            else
            {
                model = model_NewCategoryId
                                        .Skip(skip)
                                        .Take(take)
                                        .ToList();
            }

            return model;
        }
        public List<News> Get_NewSTTOne(int Id)
        {
            //QuangCaoTT_Slide//QuangCaoTT_Long
            var model = dbc.News.Where(kh=>kh.CategoryId==Id && kh.isActive==true)
                .OrderByDescending(kh => kh.NewId)
                .Take(1)
                .ToList();
            var tt= model.First().Content;
            return model;
        }
        }
}