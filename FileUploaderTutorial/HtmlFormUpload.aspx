<%@ Page Async="true" Title="HtmlFormUpload" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HtmlFormUpload.aspx.cs" Inherits="FileUploaderTutorial.HtmlFormUpload" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="main" runat="server">
	<div class="h-100 d-flex align-items-center justify-content-center">
		<div class="col-md-8">
			<div class="card shadow-sm">
				<div class="card-header bg-primary text-white">
					<h3 class="card-title mb-0">HTML Form Upload</h3>
				</div>
				<div class="card-body">
					<form method="post" enctype="multipart/form-data" class="needs-validation" novalidate>
						<div class="mb-4">
							<label for="fileUpload" class="form-label">Choose a file to upload</label>
							<input type="file" name="fileUpload" id="fileUpload" class="form-control" required />
							<div class="invalid-feedback">
								Please select a file to upload
							</div>
						</div>
						<div class="mb-4">
							<button type="submit" name="submit" class="btn btn-primary">Upload File</button>
						</div>
						<asp:Label ID="StatusLabel" runat="server" />
					</form>
				</div>
			</div>
		</div>
	</div>
</asp:Content>