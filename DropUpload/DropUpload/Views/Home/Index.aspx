<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>upload</title>
    <link href="<% = Url.Content("~/Content/way1/fileuploader.css") %>" media="screen"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <% Html.BeginForm("Upload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }); %>
    <input id="file" name="file" type="file" />
    <input id="upload" type="submit" value="upload by form post" />
    <input id="upload-ajax" type="button" value="upload by ajax post" />
    <% Html.EndForm(); %>
    <br />
    <br />
    <div id="file-uploader">
        <noscript>
            <p>
                Please enable JavaScript to use file uploader.</p>
            <!-- or put a simple form for upload here -->
        </noscript>
    </div>
    <script src="<% = Url.Content("~/Scripts/jquery-1.4.1.js") %> "></script>
    <script src="<% = Url.Content("~/Content/way1/fileuploader.js") %> "></script>
    <script>
        var uploader = new qq.FileUploader({
            element: document.getElementById('file-uploader'), // $("#")[0]
            action: '/Home/UploadAjax',
            params: {},
            allowedExtensions: ['txt', 'log'],
            sizeLimit: 0, // max size   
            debug: false,
            onSubmit: function (id, fileName) { },
            onProgress: function (id, fileName, loaded, total) { },
            onComplete: function (id, fileName, responseJSON) { },
            onCancel: function (id, fileName) { },
            messages: { /* error messages, see qq.FileUploaderBasic for content */ },
            showMessage: function (message) { alert(message); }
        });          
        
    </script>
</body>
<html>
