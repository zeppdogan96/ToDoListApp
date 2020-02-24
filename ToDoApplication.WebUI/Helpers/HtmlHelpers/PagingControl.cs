using System.Text;
using System.Web.Mvc;

namespace ToDoApplication.WebUI.Helpers.HtmlHelpers
{
    public static class PagingControl
    {
        public static MvcHtmlString PagingWithPageSize(this HtmlHelper helper, int totalItemCount, int pageIndex, int pageSize)
        {
            var builder = new StringBuilder();

            builder.Append("<ul class='pagination'>");
            var pageCount = totalItemCount / pageSize;
            if (totalItemCount % pageSize != decimal.Zero)
            {
                pageCount++;
            }

            builder.Append("<li><button type='submit' name='submit' value='Paging' onclick=\"$('#PageIndex').val(1);\" class='btn btn-first'><i class='fa fa-chevron-left'></i>&nbsp;İlk</button></li>");
            var startIndex = (int)decimal.Zero;
            var endIndex = (int)decimal.Zero;

            if (pageIndex - 4 > 1)
            {
                startIndex = pageIndex - 4;
            }
            else
            {
                startIndex = pageIndex - (pageIndex - 1);
            }

            if (pageIndex + 4 < pageCount - 1)
            {
                endIndex = pageIndex + 4;
            }
            else
            {
                endIndex = pageIndex + (pageCount - pageIndex);
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                builder.AppendFormat("<li><button type='submit' name='submit' value='Paging' onclick=\"$('#PageIndex').val({0});\" class='btn {1}'>{2}</button></li>", i, i == pageIndex ? "btn-primary" : "btn-default", i);
            }

            builder.AppendFormat("<li><button type='submit' name='submit' value='Paging' onclick=\"$('#PageIndex').val({0});\" class='btn btn-first'>Son&nbsp;<i class='fa fa-chevron-right'></i></button></li>", pageCount);

            builder.Append("</ul>");

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}