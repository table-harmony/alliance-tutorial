<%@ Page Async="true" Title="AspNetUpload" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AspNetUpload.aspx.cs" Inherits="FileUploaderTutorial.AspNetUpload" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
	<div class="h-100 d-flex align-items-center justify-content-center">
		<div class="col-md-8">
			<div class="card shadow-sm">
				<div class="card-header bg-primary text-white">
					<h3 class="card-title mb-0">ASP.NET File Upload</h3>
				</div>
				<div class="card-body">
					<form id="UploadFileForm" runat="server">
						<div class="mb-4">
							<label for="FileUploadControl" class="form-label">Choose a file to upload</label>
							<asp:FileUpload ID="FileUploadControl" runat="server" class="form-control" />
						</div>
						<div class="mb-4">
							<asp:Button ID="UploadButton" runat="server" Text="Upload File" 
								OnClick="UploadButton_Click" class="btn btn-primary" />
						</div>
						<asp:Label ID="StatusLabel" runat="server" />
					</form>
				</div>
			</div>
		</div>
	</div>
</asp:Content>