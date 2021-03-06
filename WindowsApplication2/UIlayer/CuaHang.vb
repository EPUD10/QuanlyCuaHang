﻿Imports BUS
Imports Entyti
Public Class CuaHang
    Private cls As New CuaHangBUS
    Private CH As New CuaHangEntyti
    Public Sub showData()
        dgvCH.DataSource = cls.LoadData()
    End Sub
    Public Sub Clear()
        txtMaCH.Text = ""
        txtName.Text = ""
        txtEmail.Text = ""
        txtDT.Text = ""
        txtDC.Text = ""
        txtMaCH.Focus()
    End Sub
    Public Sub dgv()
        dgvCH.Columns("ID_CHang").HeaderText = "ID store"
        dgvCH.Columns("Ten_CHang").HeaderText = "Name store"
        dgvCH.Columns("DC_CHang").HeaderText = "Address"
        dgvCH.Columns("DT_CHang").HeaderText = "Phone number"
        dgvCH.Columns("Email_CHang").HeaderText = "Email"
    End Sub
    Public Sub Emtylabel()
        lbAdd.Text = ""
        lbEmail.Text = ""
        lbName.Text = ""
        lbPhone.Text = ""
        lbID.Text = ""
    End Sub
    Private Sub CuaHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Emtylabel()
        Clear()
        showData()
        dgv()
    End Sub
    Public Sub boolEmty()
        If String.IsNullOrEmpty(txtMaCH.Text) Then
            lbID.Text = "ID is not NULL "
        End If
        If String.IsNullOrEmpty(txtName.Text) Then
            lbName.Text = "Name is not NULL "
        End If
        If String.IsNullOrEmpty(txtDT.Text) Then
            lbPhone.Text = "Phone is not NULL "
        End If
        If String.IsNullOrEmpty(txtEmail.Text) Then
            lbEmail.Text = "Email is not NULL "
        End If
        If String.IsNullOrEmpty(txtDC.Text) Then
            lbAdd.Text = "Address is not NULL "
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtMaCH.Text) OrElse String.IsNullOrEmpty(txtName.Text) OrElse String.IsNullOrEmpty(txtDT.Text) OrElse String.IsNullOrEmpty(txtEmail.Text) OrElse String.IsNullOrEmpty(txtDC.Text) Then
            boolEmty()
        Else
            CH.Ma = txtMaCH.Text
            CH.Ten = txtName.Text
            CH.Email = txtEmail.Text
            CH.DienThoai = txtDT.Text
            CH.DiaChi = txtDC.Text
            cls.Add(CH)
            showData()
            Clear()
            MessageBox.Show("Add success !!!")
        End If
    End Sub

    Private Sub dgvCH_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCH.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = dgvCH.Rows(e.RowIndex)
            txtMaCH.Text = row.Cells("ID_CHang").Value.ToString
            txtDC.Text = row.Cells("DC_CHang").Value.ToString
            txtDT.Text = row.Cells("DT_CHang").Value.ToString
            txtEmail.Text = row.Cells("Email_CHang").Value.ToString
            txtName.Text = row.Cells("Ten_CHang").Value.ToString
        End If
    End Sub

    Private Sub txtDC_Click(sender As Object, e As EventArgs) Handles txtDC.Click
        Emtylabel()
    End Sub

    Private Sub txtDT_Click(sender As Object, e As EventArgs) Handles txtDT.Click
        Emtylabel()
    End Sub

    Private Sub txtEmail_Click(sender As Object, e As EventArgs) Handles txtEmail.Click
        Emtylabel()
    End Sub

    Private Sub txtMaCH_Click(sender As Object, e As EventArgs) Handles txtMaCH.Click
        Emtylabel()
    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs) Handles txtName.Click
        Emtylabel()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        CH.Ma = txtMaCH.Text
        cls.Remove(CH)
        showData()
        MessageBox.Show("Remove success !")
        Clear()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrEmpty(txtMaCH.Text) OrElse String.IsNullOrEmpty(txtName.Text) OrElse String.IsNullOrEmpty(txtDT.Text) OrElse String.IsNullOrEmpty(txtEmail.Text) OrElse String.IsNullOrEmpty(txtDC.Text) Then
            boolEmty()
        Else
            CH.Ma = txtMaCH.Text
            CH.Ten = txtName.Text
            CH.Email = txtEmail.Text
            CH.DienThoai = Integer.Parse(txtDT.Text)
            MessageBox.Show(Integer.Parse(txtDT.Text))
            CH.DiaChi = txtDC.Text
            cls.Update(CH)
            showData()
            Clear()
            MessageBox.Show("Update success !!!")
        End If
    End Sub
End Class
