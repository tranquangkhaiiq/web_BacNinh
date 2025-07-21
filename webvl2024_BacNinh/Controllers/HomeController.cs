using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webvl2024_BacNinh.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using webvl2024_BacNinh.DAO;
using System.IO;
using System.Web.UI;
using System.Configuration;
using webvl2024_BacNinh.Filters;
using webvl2024_BacNinh.Utils;

namespace webvl2024_BacNinh.Controllers
{
    public class HomeController : Controller
    {
        ModelBN dbc = new ModelBN();
        public ActionResult Index()
        {
            //CategoryId == 4168 : QuangCao_Small
            Session["requestUri"] = "/Home/Index";
            New_Dao.model_NewsSlide = New_Dao.LinQ_NewsSlide(dbc);
            New_Dao.Pay_Sys = New_Dao.GetPay_Sys(dbc);
            Session["Pay"] = New_Dao.Pay_Sys.Pay;

            if ((bool)Session["Pay"] == true)
            {
                DN_HoSoTuyenDung_Dao.model_ListTD_Pay = DN_HoSoTuyenDung_Dao.LinQ_DN_TD_Pay(dbc);
            }
            else
            {
                DN_HoSoTuyenDung_Dao.model_ListTD = DN_HoSoTuyenDung_Dao.LinQ_DN_TD(dbc);
            }
            NTV_HoSoXinViec_Dao.model_ListNTV = NTV_HoSoXinViec_Dao.LinQ_HSTV(dbc);

            ViewBag.QC_TuyenDungPanel = new New_Dao().Get_NewQCslideisActive(4166, 0, 4);
            ViewBag.QC_TuyenDungTieuBieu = new New_Dao().Get_NewQCslideisActive(4167, 0, 8);
            ViewBag.QC_NewLong = new New_Dao().Get_NewSTTOne(4170);
            bool key = (bool)Session["Pay"];
            ViewBag.HotJob_count = DN_HoSoTuyenDung_Dao.GetList_DuyetHot_NICEAD_Home_Index(key, 0, 4).Count();
            ViewBag.CandidateXemNhieu_count = NTV_HoSoXinViec_Dao.GetListNTV_XemNhieu(0, 4).Count();
            return View();
        }
        public ActionResult Mlienket()
        {
            //mmmmmmmmmmm
            ViewBag.Lienket1 = dbc.m_Lienkets.Where(kh => kh.loaiId == 1).ToList();
            ViewBag.Lienket2 = dbc.m_Lienkets.Where(kh => kh.loaiId == 2).ToList();
            ViewBag.Lienket3 = dbc.m_Lienkets.Where(kh => kh.loaiId == 3).ToList();
            return PartialView();
        }
        public ActionResult About()
        {
            var tong = dbc.m_gioithieus.Count();
            ViewBag.tong = tong;

            ViewBag.active = dbc.m_gioithieus
                .OrderBy(kh => kh.id)
                .Skip(0)
                .Take(1)
                .ToList();
            ViewBag.GioiThieu = dbc.m_gioithieus
                .OrderBy(kh => kh.id)
                .Skip(1)
                .Take(tong - 1)
                .ToList();

            return View();
        }

        public ActionResult QLLoGo()
        {
            ViewBag.Logo = dbc.News.Where(kh => kh.CategoryId == 4176 && kh.isActive == true)
                .OrderByDescending(kh => kh.NewId)
                .Take(1)
                .ToList();

            return PartialView();
        }
        public ActionResult QCslide_Mobile()
        {

            ViewBag.TTNoiBat1 = New_Dao.Get_NewQCslideNOisActive(dbc, 0, 1);
            ViewBag.TTNoiBat5 = New_Dao.Get_NewQCslideNOisActive(dbc, 1, 5);
            return PartialView("_Slider_Mobile");
        }
        //ok
        public ActionResult QCslide_PC()
        {
            ViewBag.TTNoiBat1 = New_Dao.Get_NewQCslideNOisActive(dbc, 0, 1);
            ViewBag.TTNoiBat5 = New_Dao.Get_NewQCslideNOisActive(dbc, 1, 5);
            return PartialView("_Slider_PC");
        }
        public ActionResult QCTT_small()
        {
            ViewBag.QCTT_small = new New_Dao().Get_NewQCslideisActive(4168, 0, 4);

            return PartialView();
        }
        public ActionResult HotJob_PC()
        {
            //new dbc test xem co nhanh hown khong?
            bool key = (bool)Session["Pay"];
            ViewBag.HotJob = DN_HoSoTuyenDung_Dao.GetList_DuyetHot_NICEAD_Home_Index(key, 1, 3);
            ViewBag.HotJob_Active = DN_HoSoTuyenDung_Dao.GetList_DuyetHot_NICEAD_Home_Index(key, 0, 1);

            return PartialView("HotJob_PC");
        }
        public ActionResult UngVienXemNhieu_PC()
        {
            ViewBag.CandidateXemNhieu = NTV_HoSoXinViec_Dao.GetListNTV_XemNhieu(1, 3);
            ViewBag.CandidateXemNhieu_Active = NTV_HoSoXinViec_Dao.GetListNTV_XemNhieu(0, 1);

            return PartialView("");
        }
        public ActionResult LastestJob_PC()
        {
            //Index
            ViewBag.LastestJob = DN_HoSoTuyenDung_Dao.GetListTD_moinhat((bool)Session["Pay"], 0, 10);
            return PartialView("_TD_MoiNhat");
        }
        public ActionResult TDbyNghanhNghe_PC()
        {
            //Index
            New_Dao.Pay_Sys = New_Dao.GetPay_Sys(dbc);
            Session["Pay"] = New_Dao.Pay_Sys.Pay;
            if ((bool)Session["Pay"] == true)
            {
                DN_HoSoTuyenDung_Dao.model_DNTD_Job_Pay = DN_HoSoTuyenDung_Dao.LinQ_Job_left_Pay(dbc);
            }
            else
            {
                DN_HoSoTuyenDung_Dao.model_DNTD_Job = DN_HoSoTuyenDung_Dao.LinQ_Job_left(dbc);
            }
            ViewBag.strmapaotu = dbc.aspnet_mapautos.ToList();
            var model = new DN_HoSoTuyenDung_Dao().GetListTDbyNghanhNghe(0, (bool)Session["Pay"], 10, "");
            return PartialView("_TD_NganhNghe", model);
        }
        public ActionResult LastestCandidate_PC()
        {
            //Index
            ViewBag.LastestCandidate = NTV_HoSoXinViec_Dao.GetListNTV_moinhat(0, 10);
            //var model = DAO.NTV_HoSoXinViec_Dao.GetListNTV_moinhat(dbc, 0, 10);

            return PartialView("_LD_MoiNhat");
        }

        public ActionResult LuxuryJob_PC()
        {
            //Index
            ViewBag.LuxuryJob = DN_HoSoTuyenDung_Dao.GetListTD_luongcao((bool)Session["Pay"], 0, 15);
            return PartialView("_TD_Luxury");
        }
        public ActionResult Slide_RightTB()
        {
            if (Session["quyen"] != null)
            {
                if (Session["quyen"].ToString() == "TD")
                {
                    int uID = int.Parse(Session["UsrID"].ToString());
                    var DN_ID = dbc.UserWebs.FirstOrDefault(kh => kh.UserID == uID && kh.UserRoles_NVLoaitaikhoan == 4);
                    if (DN_ID != null)
                    {
                        var DNId = dbc.Database.SqlQuery<int>("select DN_ID from [VLBN].[dbo].[DoanhNghiep] where DN_ID=" + DN_ID.UserChild_id);
                        ViewBag.Tonghoso = new DN_HoSoTuyenDung_Dao().GetTuyenDungbyDNID(DNId.First());
                        ViewBag.TonghosoHuy = new DN_HoSoTuyenDung_Dao().GetTuyenDungbyDNID_tinhtrang(DNId.First(), 4);
                        ViewBag.TonghosoDuyet = new DN_HoSoTuyenDung_Dao().GetTuyenDungbyDNID_tinhtrang(DNId.First(), 3);
                        ViewBag.TonghosoChoDuyet = new DN_HoSoTuyenDung_Dao().GetTuyenDungbyDNID_tinhtrang(DNId.First(), 2);
                        ViewBag.TonghosoDuyet_hethan = new DN_HoSoTuyenDung_Dao().GetTuyenDungbyDNID_Duyet_hethan(DNId.First());
                        ViewBag.Tonghoso_NoWeb = new DN_HoSoTuyenDung_Dao().GetTuyenDungbyDNID_hienthiweb(DNId.First(), false);
                        ViewBag.Tonghoso_Online = new DN_HoSoTuyenDung_Dao().GetTuyenDungbyDNID_Duyet_conhan(DNId.First());
                        ViewBag.Tinchuaxem = new DN_HoSoTuyenDung_Dao().Tinchuaxem(DNId.First());
                        ViewBag.totalungtuyen = DN_UngTuyen_Dao.GetListUngTuyenByDN(dbc, DN_ID.UserChild_id).Count();
                    }
                }
                if (Session["quyen"].ToString() == "NTV")
                {
                    int uID = int.Parse(Session["UsrID"].ToString());
                    var NTV_ID = dbc.UserWebs.FirstOrDefault(kh => kh.UserID == uID && kh.UserRoles_NVLoaitaikhoan == 3);
                    if (NTV_ID != null)
                    {
                        var KHId = dbc.Database.SqlQuery<int>("select KH_ID from [VLBN].[dbo].[KhachHang] where KH_ID=" + NTV_ID.UserChild_id);
                        ViewBag.Tonghoso = new NTV_HoSoXinViec_Dao().GetTimViecbyKHID(KHId.First());
                        ViewBag.TonghosoHuy = new NTV_HoSoXinViec_Dao().GetTimViecbyKHID_tinhtrang(KHId.First(), 4);
                        ViewBag.TonghosoDuyet = new NTV_HoSoXinViec_Dao().GetTimViecbyKHID_tinhtrang(KHId.First(), 3);
                        ViewBag.TonghosoChoDuyet = new NTV_HoSoXinViec_Dao().GetTimViecbyKHID_tinhtrang(KHId.First(), 2);
                        ViewBag.TonghosoDuyet_hethan = new NTV_HoSoXinViec_Dao().GetTimViecbyKHID_Duyet_hethan(KHId.First());
                        ViewBag.Tonghoso_NoWeb = new NTV_HoSoXinViec_Dao().GetTimViecbyKHID_hienthiweb(KHId.First(), false);
                        ViewBag.Tonghoso_Online = new NTV_HoSoXinViec_Dao().GetTimViecbyKHID_Duyet_conhan(KHId.First());
                        ViewBag.Tonghoso_ungtuyen = DN_UngTuyen_Dao.GetListUngTuyenByNTV(dbc, NTV_ID.UserChild_id).Count();
                    }
                }
                return PartialView("");
            }
            return Json("No", JsonRequestBehavior.AllowGet);

        }
        public ActionResult Slide_Right()
        {
            //Index
            //ViewBag.LuxuryJob = DAO.DN_HoSoTuyenDung_Dao.GetListTD_luongcao(dbc, 0, 10);

            ViewBag.QC_NewSlide = new New_Dao().Get_NewSTTOne(4169);
            ViewBag.QC_Right = new New_Dao().Get_NewQCslideisActive(4171, 0, 15);

            return PartialView("");
        }
        [ProtectUser]
        public ActionResult GopY(string customer_name, string email, string phone, string msg_content)
        {
            if (Session["User"] != null)
            {
                string Conemail = ConfigurationManager.AppSettings["Email"];
                var kq = Mailer.Send(Conemail, "Mail liên hệ góp ý từ Web VL " + XString.tinh, "Tôi tên " + customer_name + ", email: " + email + ", điện thoại: " + phone + "<br /><br />" + msg_content);
                if (kq)
                {
                    ModelState.AddModelError("", "Cám ơn bạn đã gửi thư góp ý.");
                }
                else
                {
                    ModelState.AddModelError("", "Có lỗi gửi mail góp ý!!!");
                }

            }
            else return RedirectToAction("_Login", "Account");
            //CategoryId == 4168 : QuangCao_Small
            Session["requestUri"] = "/Home/Index";
            New_Dao.Pay_Sys = New_Dao.GetPay_Sys(dbc);
            Session["Pay"] = New_Dao.Pay_Sys.Pay;
            New_Dao.model_NewsSlide = New_Dao.LinQ_NewsSlide(dbc);
            if ((bool)Session["Pay"] == true)
            {
                DN_HoSoTuyenDung_Dao.model_ListTD_Pay = DN_HoSoTuyenDung_Dao.LinQ_DN_TD_Pay(dbc);
            }
            else
            {
                DN_HoSoTuyenDung_Dao.model_ListTD = DN_HoSoTuyenDung_Dao.LinQ_DN_TD(dbc);
            }
            NTV_HoSoXinViec_Dao.model_ListNTV = NTV_HoSoXinViec_Dao.LinQ_HSTV(dbc);
            //ConfigurationManager.AppSettings["Type"]

            ViewBag.QC_TuyenDungPanel = new New_Dao().Get_NewQCslideisActive(4166, 0, 4);

            ViewBag.QC_TuyenDungTieuBieu = new New_Dao().Get_NewQCslideisActive(4167, 0, 8);
            ViewBag.QC_NewLong = new New_Dao().Get_NewSTTOne(4170);
            return View("Index");
        }
    }
}