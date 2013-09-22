<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UploadZip.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/kendo.common.min.css" rel="stylesheet" />
    <link href="Styles/kendo.silver.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.0.3.js"></script>
    <script src="Scripts/kendo.web.js"></script>
</head>
<body>
    <input name="uploaded" id="uploaded" type="file" runat="server" />

    <script>
        function onUpload(ev) {
            var files = ev.files;
            $.each(files, function () {
                if (this.extension.toLowerCase() != ".zip") {
                    alert("Only .zip format is allowed");
                }
            });
        }

        $(document).ready(function () {
            $("#uploaded").kendoUpload({
                async: {
                    saveUrl: "Upload.aspx",
                    autoUpload: true,
                },
                upload: onUpload
            });
        });
    </script>
</body>
</html>
