<%@ Page Language="C#" MasterPageFile="~/RES.Master" AutoEventWireup="true" CodeBehind="RES_Menu.aspx.cs" Inherits="RESDOT.RES_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: flex-start;
        }

        /* Hamburger Button */
        .hamburger {
            font-size: 30px;
            cursor: pointer;
            position: fixed;
            top: 15px;
            left: 15px;
            z-index: 1001;
            background: #333;
            color: white;
            padding: 10px 15px;
            border-radius: 5px;
        }

        /* Sidebar Menu */
        .sidebar {
            position: fixed;
            top: 0;
            left: -250px; /* Initially hidden */
            width: 250px;
            height: 100%;
            background: #333;
            padding-top: 60px;
            transition: left 0.3s ease-in-out;
            box-shadow: 2px 0px 5px rgba(0, 0, 0, 0.2);
            z-index: 1000;
        }

        .sidebar a {
            display: block;
            padding: 15px;
            color: white;
            text-decoration: none;
            font-size: 18px;
            text-align: left;
            padding-left: 20px;
        }

        .sidebar a:hover {
            background: #575757;
        }

        /* Show Sidebar */
        .sidebar.open {
            left: 0;
        }

        /* Dark Overlay when Sidebar is Open */
        .overlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            z-index: 999;
        }

        .overlay.active {
            display: block;
        }

        /* Centered Menu Grid */
        .menu-container {
            display: grid;
            grid-template-columns: repeat(3, 1fr); /* Default 3 columns */
            gap: 20px;
            max-width: 600px;
            margin: 20px auto; /* Adjusted margin */
            text-align: center;
            padding: 20px;
            overflow: hidden; /* Prevent overflow */
        }

        /* Individual Menu Items */
        .menu-item {
            background: white;
            padding: 15px;
            border-radius: 10px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
            transition: transform 0.2s;
            cursor: pointer;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            margin: 10px;
        }

        .menu-item:hover {
            transform: scale(1.05);
        }

        .menu-item img {
            width: 80px;
            height: 80px;
            border-radius: 10px;
        }

        .menu-item span {
            margin-top: 10px;
            font-size: 16px;
            font-weight: bold;
            color: #333;
        }

        /* Logo and Version Section */
        .logo-container {
            text-align: center;
            margin: 20px 0; /* Adjusted margin */
            padding: 0 10px; /* Padding to prevent overflow */
        }

        .logo-container img {
            width: 120px; /* Adjust logo size */
            height: auto;
            max-width: 100%; /* Ensure logo scales correctly */
        }

        .logo-container span {
            display: block;
            margin-top: 10px;
            font-size: 18px;
            color: #333;
        }

        /* Mobile Responsive Layout */
        @media (max-width: 768px) {
            .menu-container {
                grid-template-columns: repeat(2, 1fr); /* 2 columns for tablet and small devices */
            }

            .logo-container img {
                width: 100px; /* Smaller logo for small screens */
            }

            .logo-container span {
                font-size: 16px; /* Adjusted font size for version text */
            }
        }

        @media (max-width: 600px) {
            body {
                padding: 0;
            }

            .menu-container {
                grid-template-columns: repeat(2, 1fr); /* 2 columns for small screens */
                padding: 10px;
                margin: 10px auto; /* Adjusted margin */
            }

            .hamburger {
                top: 10px;
                left: 10px;
            }

            .logo-container img {
                width: 90px; /* Further reduced logo size */
            }

            .logo-container span {
                font-size: 14px; /* Smaller version text */
            }
        }

    </style>

    <!-- Logo and Version Info -->
    <div class="logo-container">
        <img src="RES_icon.png" alt="RES_icon">
        <span>RES 2.8.2.2</span>
    </div>

    <!-- Main Menu (Grid) -->
    <div class="menu-container">
        <div class="menu-item" onclick="location.href='Dummy.aspx?menuid=188&menuname=AssignCase'">
            <img src="AssignedCases.png" alt="Assigned Cases">
            <span>Assigned Cases</span>
        </div>

        <div class="menu-item" onclick="location.href='Dummy.aspx?menuid=189&menuname=Accepted_Cases'">
            <img src="AcceptedCases.png" alt="Accepted Cases">
            <span>Accepted Cases</span>
        </div>

        <div class="menu-item" onclick="location.href='#'">
            <img src="DownloadCases.png" alt="Downloading Cases">
            <span>Downloading Cases</span>
        </div>

        <div class="menu-item" onclick="location.href='#'">
            <img src="SendCases.png" alt="Sending Cases">
            <span>Sending Cases</span>
        </div>

        <div class="menu-item" onclick="location.href='#'">
            <img src="CaseHistory.png" alt="Case History">
            <span>Case History</span>
        </div>

        <div class="menu-item" onclick="location.href='#'">
            <img src="Profile.png" alt="Profile">
            <span>Profile</span>
        </div>
    </div>

    <script>
        function toggleSidebar() {
            var sidebar = document.getElementById("sidebar");
            var overlay = document.getElementById("overlay");
            var isOpen = sidebar.classList.contains("open");

            if (isOpen) {
                sidebar.classList.remove("open");
                overlay.classList.remove("active");
            } else {
                sidebar.classList.add("open");
                overlay.classList.add("active");
            }
        }
    </script>
</asp:Content>

