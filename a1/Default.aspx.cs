using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) //First draw of page or redraw (preserves information)
        {

            string[] tipPercent = { "Ten Percent", "Fiftenn Percent", "Twenty Percent", "Other" };
            TipPercentsRadioButtonList.DataSource = tipPercent;
            TipPercentsRadioButtonList.DataBind();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        GetInfo();
        

    }

    protected void GetInfo()
    {
        Tip tip = new Tip();
        tip.MealAmount = double.Parse(MealTextBox.Text);

        foreach (ListItem item in TipPercentsRadioButtonList.Items)
        {
            if (item.Selected == true)
            {
                if (item.Text.Equals("Ten Percent"))
                {
                    tip.TipPercent = .10;
                }
                else if (item.Text.Equals("Fifteen Percent"))
                {
                    tip.TipPercent = .15;
                }
                else if (item.Text.Equals("Twenty Percent"))
                {
                    tip.TipPercent = .20;
                }
                else if (item.Text.Equals("Other"))
                {
                    tip.TipPercent = .1 * double.Parse(OtherTextBox.Text);
                }
                else
                {
                    tip.TipPercent = (0);
                }
             }
            }
       ResultLabel.Text="Amount " + tip.MealAmount.ToString("$#,##0.00") + "<br/" +
                        "Tip: " + tip.CalculateTip().ToString("$#,##0.00") + "<br/>" +
                        "Tax: " + tip.CalculateTax().ToString("$#,##0.00") + "<br/>" +
                        "Total: " + tip.Total().ToString("$#,##0.00");
        }
    }
