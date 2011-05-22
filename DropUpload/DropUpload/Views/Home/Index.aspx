<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>upload</title>
    <link href="<% = Url.Content("~/Content/way1/fileuploader.css") %>" media="screen"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <hr />
    simple upload (soon to have drag-and-drop)
    <br />
    <input id="upload" type="button" value="upload by form post" />
    <div style="display: none;" id="uploader-frame">
        <iframe id="uploader" style="height: 200px; width: 400px;"></iframe>
    </div>

    <hr />
    advance upload with filter (now only *.txt, *.log) (with drag-and-drop)
    <br />
    <div id="file-uploader">
    </div>

    <script src="<% = Url.Content("~/Scripts/jquery-1.4.1.js") %> "></script>
    <script src="<% = Url.Content("~/Content/way1/fileuploader.js") %> "></script>
    <script>
    
        $("#upload").click(function () {
            $("#uploader-frame").show();
            $("#uploader")
                .attr("src", "<% = Url.Action("UploadView") %>")
                .load(function () {
                    var status = $(this).contents().find("#status").text();
                    if (status === "done") {
                        $("#uploader-frame").hide();            
                        alert("file uploaded!");
                    }
                });
        });

        var uploader = new qq.FileUploader({
            element: document.getElementById('file-uploader'), // $("#")[0]
            action: '/Home/UploadAjax',
            params: {},
            allowedExtensions: ['txt', 'log'],
            sizeLimit: 0, // max size   
            debug: false,
            onSubmit: function (id, fileName) { },
            onProgress: function (id, fileName, loaded, total) { },
            onComplete: function (id, fileName, responseJSON) { alert("file uploaded!"); },
            onCancel: function (id, fileName) { },
            messages: { /* error messages, see qq.FileUploaderBasic for content */ },
            showMessage: function (message) { alert(message); }
        });          
        
    </script>
</body>
</html>
