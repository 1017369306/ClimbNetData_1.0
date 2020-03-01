using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Share.PublicShare.BindingData
{
    public class WebSitesData
    {
        private string _guid;
        private websitebase _websitebaseParent;
        private websitebase _websitebase;

        public string Guid { get => _guid; set => _guid = value; }
        /// <summary>
        /// 父类websitebase
        /// </summary>
        public websitebase WebsitebaseParent { get => _websitebaseParent; set => _websitebaseParent = value; }
        /// <summary>
        /// 当前的websitebase
        /// </summary>
        public websitebase Websitebase { get => _websitebase; set => _websitebase = value; }
    }
}
