﻿Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports BOSistemaVentasVB

Public Class Categorias
    Dim categoria As New BOCategoria()
    Dim etiqueta As Boolean = True

    Private Sub Categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarCategoria()
    End Sub
    Public Sub Limpiar()
        txtIdCategoria.Clear()
        txtNombre.Clear()
        txtDescripcion.Clear()
        txtEstatus.Clear()
        txtIdCrear.Clear()
        txtIdModificar.Clear()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim conexion As String = "Server=DESKTOP-R538THL;Database=SistemaVentas; Integrated Security=True;"
        Dim conn As SqlConnection = New SqlConnection(conexion)
        conn.Open()
        Dim cmd As New SqlCommand("select * from Categoria where Id_Categoria = @Id_Categoria", conn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add(New SqlParameter("@Id_Marca", txtIdCategoria.Text))
        Using sda As New SqlDataAdapter()
            sda.SelectCommand = cmd
            Using dt As New DataTable()
                sda.Fill(dt)
                If dt.Rows.Count Then
                    txtNombre.Text = dt.Rows(0)(1).ToString
                    txtDescripcion.Text = dt.Rows(0)(2).ToString
                    If dt.Rows(0)(3) = True Then
                        txtEstatus.Text = 1
                    Else
                        txtEstatus.Text = 0
                    End If
                    txtIdCrear.Text = dt.Rows(0)(4).ToString
                    txtIdModificar.Text = dt.Rows(0)(5).ToString
                End If
            End Using
        End Using
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click
        Dim valido As Boolean = True

        If (String.IsNullOrEmpty(txtIdCategoria.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtNombre.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtEstatus.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdCrear.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdModificar.Text)) Then
            valido = False
        End If
        If valido Then
            etiqueta = categoria.RegistrarCategoria(txtIdCategoria.Text, txtNombre.Text, txtDescripcion.Text, txtEstatus.Text, txtIdCrear.Text, txtIdModificar.Text)
            MsgBox("La informacion se ha registrado con Exito")
            Limpiar()
            MostrarCategoria()
        Else
            MsgBox("No se ha podido registrar la informacion.")
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim valido As Boolean = True

        If (String.IsNullOrEmpty(txtIdCategoria.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtNombre.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtEstatus.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdCrear.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdModificar.Text)) Then
            valido = False
        End If
        If valido Then
            etiqueta = categoria.ModificarCategoria(txtIdCategoria.Text, txtNombre.Text, txtDescripcion.Text, txtEstatus.Text, txtIdCrear.Text, txtIdModificar.Text)
            MsgBox("La informacion se ha registrado con Exito")
            Limpiar()
            MostrarCategoria()
        Else
            MsgBox("No se ha podido registrar la informacion.")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim valido As Boolean = True

        If (String.IsNullOrEmpty(txtIdCategoria.Text)) Then
            valido = False
        End If
        If valido Then
            etiqueta = categoria.EliminarCategoria(txtIdCategoria.Text)
            MsgBox("La informacion se ha registrado con Exito")
            Limpiar()
            MostrarCategoria()
        Else
            MsgBox("No se ha podido registrar la informacion.")
        End If
    End Sub
    Public Sub MostrarCategoria()
        Dim cnn As SqlConnection = New SqlConnection("Server=DESKTOP-R538THL;Database=SistemaVentas; Integrated Security=True;")
        Dim cmd = New SqlCommand("SELECT * FROM Categoria", cnn)
        Dim da = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        Try
            cnn.Open()
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Error al abrir la conexión: " & ex.Message)
        Finally
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try

        ' Mostrar los datos en el DataGridView
        dgvCategoria.DataSource = dt
    End Sub
End Class