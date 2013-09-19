<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="NorthwindEmployees.TreeView.TreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TreeView ID="TreeViewLibrary" runat="server" DataSourceID="XmlDataSourceLibrary"
                OnTreeNodeCollapsed="TreeViewLibrary_TreeNodeCollapsed"
                OnTreeNodeExpanded="TreeViewLibrary_TreeNodeExpanded"
                ExpandImageUrl="~/TreeView/images/1378761191_14280.ico"
                CollapseImageUrl="~/TreeView/images/1378761275_14279.ico"
                NoExpandImageUrl="~/TreeView/images/1378761579_14125.ico">

                <DataBindings>
                    <asp:TreeNodeBinding DataMember="genre" TextField="name" />
                    <asp:TreeNodeBinding DataMember="book" TextField="#Name"/>
                    <asp:TreeNodeBinding DataMember="title" TextField="#InnerText" />
                    <asp:TreeNodeBinding DataMember="price" TextField="#InnerText" />
                    <asp:TreeNodeBinding DataMember="userComment" TextField="#InnerText" />
                </DataBindings>
            </asp:TreeView>
            <asp:XmlDataSource ID="XmlDataSourceLibrary" runat="server" DataFile="~/TreeView/library.xml"></asp:XmlDataSource>
        </div>
    </form>
</body>
</html>
