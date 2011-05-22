<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>upload</title>
</head>
<body>
    <% Html.BeginForm("Upload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }); %>
    <input id="file" name="file" type="file" />
    <input id="upload" type="submit" value="upload by form post" />
    <% Html.EndForm(); %>
</body>
</html>
