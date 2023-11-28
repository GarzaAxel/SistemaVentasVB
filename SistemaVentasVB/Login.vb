
Imports System.Data.SqlClient

Public Class Login

    Private Sub btnAcceder_Click(sender As Object, e As EventArgs) Handles btnAcceder.Click
        Dim conn = New SqlConnection("Server=DESKTOP-R538THL; Database=SistemaVentas; Integrated Security=true")
        conn.Open()
        Dim query As String = ("select * from Usuarios where NombreUsuario= '" & txtUsuario.Text & "' and Contraseña= '" & txtPassword.Text & "'")
        Dim cmd As New SqlCommand(query, conn)
        Dim rdr As SqlDataReader = cmd.ExecuteReader()
        If rdr.HasRows Then
            MessageBox.Show("Acceso Exitoso")
            Inicio.ShowDialog()
        Else
            MessageBox.Show("Este usuario no existe o los datos son incorrectos.")
        End If
        conn.Close()
    End Sub
End Class