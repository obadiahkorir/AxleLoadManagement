using Axle_Load_Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Axle_Load_Control.Controllers
{

    public class HomeController : Controller
    {
        Config config = new Config();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
               {
                    var nav = config.nav.AxleUsers.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).FirstOrDefault();
                if (nav != null)
                    {
                    Session["email"] = nav.Email.ToString();
                    Session["password"] = nav.Password.ToString();
                    return RedirectToAction("Dashboard");
                    }
                 else
                {
                    TempData["error"] = "The UserName or Password provided is incorrect.";
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AxlePermit(AxlePermitViewModel model)
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    AxlePermitViewModel axle = new AxlePermitViewModel();
                    axle.applicantname = model.applicantname;
                    var result = Config.ObjNav.AddPermits(axle.applicantname);
                    if (result != null)
                    {
                        Session["applicant"] = result;
                        return RedirectToAction("Dashboard", "Home", new { ClaimNo = result });
                    }
                    else
                    {
                        TempData["error"] = "An error occured during the process of Submission,Please contact your system administrator";
                        return RedirectToAction("", "");
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
         return RedirectToAction("PendingAxles");
        } 
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Dashboard()
        {
            if (Session["email"] == null || Session["email"].ToString() == "")
            {
                TempData["error"] = "Please Login to proceed.";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult PermitApplication()
        {
            if (Session["email"] == null || Session["email"].ToString() == "")
            {
                TempData["error"] = "Please enter your Email Address in small letters";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult AxleFines()
        {
            if (Session["email"] == null || Session["email"].ToString() == "")
            {
                TempData["error"] = "Please enter your Email Address in small letters";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult PendingAxles()
        {
            if (Session["emp"] == null || Session["emp"].ToString() == "")
            {
                TempData["error"] = "Please enter your Email Address in small letters";
                return RedirectToAction("Index", "Home");
            }
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status =="Pending");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);
        
    }
        public ActionResult VerifiedAxles()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Verified");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult ApprovedAxles()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Approved");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult OpenCommunications()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Approved");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult OpenAxlePermits()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult VerifiedCommunications()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Verified");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult ApprovedCommunications()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Approved");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult MaximumAxleLoad()
        {
            return View();

        }
        public ActionResult GrossWeight()
        {
            return View();

        }
        public ActionResult BulkLiquid()
        {
            return View();

        }
        public ActionResult OpenPower()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult OpenWater()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult VerifiedWayLeave()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult OpenBillboards()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult ApprovedBillboards()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Approved");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult VerifiedBillboards()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Verified");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult PendingBillboards()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Pending");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult BillBoards()
        {
            return View();
        }
        public ActionResult AccesssRoad()
        {
            return View();
        }
        public ActionResult WayLeave()
        {
            return View();
        }
        public ActionResult OpenWayleave()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Pending");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);
        }
        public ActionResult ApprovedWayLeave()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Pending");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);
        }
        public ActionResult PendinWayleave()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Pending");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);
        }
        public ActionResult Rejectedwayleave()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Pending");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);
        
    }
        public ActionResult CommunicationLines()
        {
            return View();
        }
        public ActionResult PowerLines()
        {
            return View();
        }
        public ActionResult SewerLines()
        {
            return View();
        }
        public ActionResult WaterLines()
        {
            return View();
        }
      
        public ActionResult OpenSewer()
        {
            return View();
        }
        public ActionResult ApprovedRoadAccess()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult RejectedAccessRoad()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult PendingAccessRoad()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
        public ActionResult VerifiedAccessRoad()
        {
            List<AxlePermitViewModel> list = new List<AxlePermitViewModel>();
            var query = config.nav.AxlePermits.Where(x => x.Status == "Open");
            foreach (var item in query)
            {
                AxlePermitViewModel vm = new AxlePermitViewModel();
                vm.refno = item.Ref_No;
                vm.vehicleregistration = item.Vehicle_Registration_No;
                vm.tareweight = Convert.ToString(item.Tare_Weight);
                vm.vehiclemake = item.Vehicle_Make;
                vm.region = item.Region;
                vm.route = item.Route;
                vm.status = item.Status;
                vm.totalamount = Convert.ToString(item.Amount);
                vm.totalbalance = Convert.ToString(item.Balance);
                vm.region = item.Region;
                list.Add(vm);
            }
            return View(list);

        }
    }
}