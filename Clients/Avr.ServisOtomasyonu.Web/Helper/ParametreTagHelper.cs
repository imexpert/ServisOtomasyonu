using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Web.Helper
{
    [HtmlTargetElement("Parametre")]
    public class ParametreTagHelper : TagHelper
    {
        public string Name { get; set; }
        public string GrupKod { get; set; }
        public int AnaGrupKod { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat(
                "<select " +
                "style='width:100%'" +
                "class='select2Parametre form-control' " +
                "name='{0}' " +
                "id='{0}' " +
                "data-parametreGrup='{1}'" +
                "data-anaGrupKod='{2}'" +
                "data-defaultOptionText='Seçiniz' " +
                "data-defaultOptionValue='Seçiniz' " +
                "data-url='parametre/getirparametre' " +
                "data-text='aciklama' " +
                "data-value='kod' " +
                "data-allowClear='true'> ", Name, GrupKod, AnaGrupKod);
            sb.Append("</select>");

            output.PreContent.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }
}
