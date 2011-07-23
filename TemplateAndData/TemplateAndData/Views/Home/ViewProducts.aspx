<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="MvcContrib" %>
<%@ Import Namespace="TemplateAndData.Controllers" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>ViewProducts</title>
</head>
<body>
    <ul id="products">
    </ul>
    
    <script id="products-template" type="text/x-jquery-tmpl"> 

    </script>

    <script src="<% = Url.Content("~/Scripts/jquery-1.5.1.js") %>"></script>
    <script src="<% = Url.Content("~/Scripts/jQuery.tmpl.js") %>"></script>
    <script>
        var url = "<% = Url.Action<ProductServiceController>(x => x.Products()) %>";
        $.get(url, function (data, textStatus, jqXHR) {
            var template = jqXHR.getResponseHeader("X-View-Template");
            $.tmpl(template, { "products": data }).appendTo("#products");
        });
    </script>
</body>
</html>
