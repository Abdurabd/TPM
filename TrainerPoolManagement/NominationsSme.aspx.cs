using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dao;
using model;

namespace TrainerPage
{
    public partial class NominationsSme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SmeNominationsList> listofnominations = new List<SmeNominationsList>();
            SmeDao smedao = new SmeDaoSqlImpl();
            Details d = new Details();
            long det = d.smedet(Session["adminlogin"].ToString());
            smedao.smeNominationList(det);

            

        }
    }
}