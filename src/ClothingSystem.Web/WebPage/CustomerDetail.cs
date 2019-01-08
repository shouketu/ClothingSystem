using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothingSystem.Common;
using ClothingSystem.Dto.Model;
using ClothingSystem.Service.Interface;
using ClothingSystem.Service.Impl;

namespace ClothingSystem.Web.WebPage
{
    public partial class CustomerDetail : BasePage
    {
        protected CustomerInfoFullDto _model;

        public CustomerDetail() : base(UserTypeEnum.UserInfo)
        {
            
        }

        public CustomerDetail(UserTypeEnum user) : base(user)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var url = "customerlist.aspx";
            var cid = Request.QueryString["cid"].ToInt32();
            if (cid <= 0)
                Redirect(url);
            ICustomerInfoService _customerInfoService = new CustomerInfoService(_user);
            _model = _customerInfoService.GetById(cid);
            if (_model == null)
                Redirect(url);
        }
    }
}