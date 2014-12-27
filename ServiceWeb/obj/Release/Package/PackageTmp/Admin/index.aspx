<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ServiceWeb.Admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Admin/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/Admin/css/bui-min.css" type="text/css" rel="stylesheet" />
    <link href="/Admin/css/grid-min.css" type="text/css" rel="stylesheet" />
    <link href="/Admin/css/dpl-min.css" type="text/css" rel="stylesheet" />
    <link href="/Admin/css/main-min.css" type="text/css" rel="stylesheet" />
    <link href="/Admin/style/admin.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="/Admin/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="/Admin/js/bui-min.js"></script>
    <script type="text/javascript" src="/Admin/js/config-min.js"></script>
    <script type="text/javascript" src="/Admin/js/form.js"></script>
    <script type="text/javascript" src="/Admin/js/util.js"></script>
    <script type="text/javascript" src="/Admin/js/jquery.md5.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="dl-title">后台管理</div>
            <div class="dl-log">
                <asp:LinkButton runat="server" ID="btnLogout" Text="退出" ForeColor="red" Visible="False" OnClick="btnLogout_Click"></asp:LinkButton>
            </div>
        </div>
        <div class="content">
            <div class="dl-main-nav">
                <ul id="J_Nav" class="nav-list ks-clear">
                    <li class="nav-item dl-selected">
                        <div class="nav-item-inner nav-storage">首页</div>
                    </li>
                    <li class="nav-item">
                        <div class="nav-item-inner nav-inventory">新闻管理</div>
                    </li>
                    <li class="nav-item">
                        <div class="nav-item-inner nav-inventory">用户管理</div>
                    </li>
                    <li class="nav-item">
                        <div class="nav-item-inner nav-inventory">系统设置</div>
                    </li>
                    <li class="nav-item">
                        <div class="nav-item-inner nav-inventory">重点企业</div>
                    </li>
                    <li class="nav-item">
                        <div class="nav-item-inner nav-inventory">首页幻灯片</div>
                    </li>


                </ul>
            </div>
            <ul id="J_NavContent" class="dl-tab-conten">
            </ul>
        </div>
        <script type="text/javascript">
            BUI.use('common/main', function () {
                var config = [{
                    id: 'menu',
                    menu: [{
                        text: '首页内容',
                        items: [
                    { id: 'demand', text: '诉求管理', href: 'Demand/DemandShow.aspx' },
                    { id: 'demandtype', text: '诉求类别', href: 'Demand/DemandType.aspx' }]
                    }]
                },
                    {
                        id: 'posts',
                        menu: [{
                            text: '新闻管理',
                            items: [
                            { id: 'add', text: '增加新闻', href: 'post/post.aspx' },
                            { id: 'list', text: '新闻列表', href: 'post/PostShow.aspx' }]
                        }]
                    },
                    {
                        id: 'member',
                        menu: [
                        {
                            text: '用户管理', items: [
                                { id: 'useradd', text: '用户添加', href: 'user/UserProfileAdd.aspx' },
                                { id: 'userman', text: '用户管理', href: 'user/UserProfileShow.aspx' }
                            ]
                        }]
                    },
                    {
                        id: 'sys',
                        menu: [
                        {
                            text: '系统管理', items: [
                            { id: 'country', text: '单位管理', href: 'country/Country.aspx' },
                            { id: 'deperment', text: '部门管理', href: 'Deperment/DeparmentShow.aspx' },
                            { id: 'contact', text: '联系人管理', href: 'Deperment/ContactNameADD.aspx' },
                            { id: 'admin', text: '管理员管理', href: 'user/useradd.aspx' }]
                        }]
                    },
                    {
                        id: 'zd',
                        menu: [
                        {
                            text: '重点企业', items: [
                            { id: 'zdompany', text: '重点企业列表', href: 'zdompany/ComPanyShow.aspx' }]
                        }]
                    },
                    {
                        id: 'banner',
                        menu: [
                        {
                            text: '首页幻灯片', items: [{ id: 'BannerShow.aspx', text: '幻灯片', href: 'uploadbanner/BannerShow.aspx' }]
                        }]
                    }

                ];
                new PageUtil.MainPage({
                    modulesConfig: config
                });
            });
        </script>
    </form>
</body>
</html>
