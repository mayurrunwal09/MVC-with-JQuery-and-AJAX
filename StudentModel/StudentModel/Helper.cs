using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.JSInterop.Implementation;

namespace StudentModel
{
    public class Helper
    {
        public static string viewstring(Controller controller,string viewname,object model = null)
        {
            controller.ViewData.Model = model;
            using(var sw = new StringWriter())
            {
                IViewEngine viewengine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewresult = viewengine.FindView(controller.ControllerContext, viewname, false);

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewresult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions());
                viewresult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.GetTypedHeaders().Referer == null ||
         filterContext.HttpContext.Request.GetTypedHeaders().Host.Host.ToString() != filterContext.HttpContext.Request.GetTypedHeaders().Referer.Host.ToString())
                {
                    filterContext.HttpContext.Response.Redirect("/");
                }
            }
        }
    }
}
