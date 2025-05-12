<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RESDOT_Login.aspx.cs" Inherits="RESDOT.RES_Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title></title>
     <!-- Viewport Meta Tag for Responsive Design -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <style>
        
        /* Center the form in the page */
        .center-container 
        {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;  /* Ensure elements are stacked vertically */
            height: 100vh; /* Full viewport height */
            text-align: center; /* Center text */
        }

        .input-container 
        {
            position: relative;
            width: 100%;
            /*max-width: 300px;*/
             max-width: 200px; /* You can adjust the max-width as needed */
            margin: 10px 0; /* Add some spacing between fields */
        }

        .input-field 
        {
            width: 100%;
            padding: 8px 0;
            font-size: 16px;
            border: none;
            border-bottom: 2px solid gray;
            outline: none;
            background: transparent;
        }

        .floating-placeholder 
        {
            position: absolute;
            left: 10px;
            top: 8px;
            font-size: 16px;
            color: gray;
            transition: all 0.3s ease-in-out;
            pointer-events: none;
        }

        /* Move placeholder above when input is focused */
        .input-field:focus ~ .floating-placeholder,
        .input-field:not(:placeholder-shown) ~ .floating-placeholder 
        {
            top: -20px;
            font-size: 12px;
            color: #0398fc /*blue*/;
        }

        /* Underline color change on focus */
        .input-field:focus 
        {
            border-bottom: 2px solid blue;
        }

        /* Style for the submit button */
        .btn 
        {
            margin-top: 20px;
            padding: 10px 20px;
            font-size: 16px;
            background-color: #0398fc; /*#007bff;*/
            color: black; /*white;*/
            border: none;
            border-radius: 4px;
            cursor: pointer;
            /*width: 100%;*/ /* This will make the button take up the full width of its container */
             /*max-width: 400px;*/ /* Optional: You can specify a maximum width if you want */
        }

        .btn:hover 
        {
            /*background-color: #0056b3;*/
        }

        /* Responsive Design using Media Queries */
        @media (max-width: 768px) {
            .input-field {
                font-size: 14px;
                padding: 8px;
            }

            .btn {
                font-size: 14px;
            }
        }

        @media (max-width: 480px) {
            .center-container {
                padding: 20px;
            }

            .input-container {
                max-width: 100%;  /* Full width on small screens */
            }

            .btn {
                font-size: 14px;
                width: 100%;  /* Make button full width on small devices */
            }

            .floating-placeholder {
                font-size: 14px;
                top: 12px;
            }
        }

        /* Ensure image doesn't exceed screen width */
        .login {
            max-width: 100%;
            height: auto;
        }

    </style>
    <script>
    function floatLabel(input) {
        let placeholder = input.nextElementSibling;
        placeholder.classList.add("active");
        input.setAttribute("data-placeholder", input.placeholder);
        input.placeholder = ""; // Remove placeholder when focused
    }

    function resetLabel(input) {
        let placeholder = input.nextElementSibling;
        if (input.value === "") {
            placeholder.classList.remove("active");
            input.placeholder = input.getAttribute("data-placeholder"); // Restore placeholder if empty
        }
    }
    </script>

  

</head>
<body>
    <form id="form1" runat="server">

        <div class="center-container">
            <div class="imgcontainer" align="center">
                 <img src="RES_icon.png" width="50px" alt="login" class="login" >
            </div><br/>

        <div align="center" class="input-container">
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control input-field"
                placeholder="" onfocus="floatLabel(this)" onblur="resetLabel(this)"></asp:TextBox> <%--placeholder="Username1"--%>
            <span class="floating-placeholder">User Name</span>
        </div>

        <div align="center" class="input-container">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control input-field"
                placeholder="" onfocus="floatLabel(this)" onblur="resetLabel(this)"></asp:TextBox> <%--placeholder="Username1"--%>
            <span class="floating-placeholder">Password</span>
        </div>
        <div align="center">
                <asp:Button ID="Login" Width="200px" runat="server" Text="Login" CssClass="btn" OnClick="Login_Click" />
        </div>
        </div>
    </form>
</body>
</html>

