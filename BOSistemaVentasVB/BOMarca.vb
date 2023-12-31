﻿Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Metadata.W3cXsd2001
Imports Microsoft.VisualBasic.Devices

Public Class BOMarca
    Private _Id_Marca As Integer
    Private _Nombre As String
    Private _Descripcion As String
    Private _Estatus As Integer
    Private _Id_Ucrear As Integer
    Private _Id_Umodificar As Integer
    Private conexion = "Server=DESKTOP-R538THL; Database=SistemaVentas; Integrated Security=true"
    Public Sub New()
        _Id_Marca = 0
        _Nombre = ""
        _Descripcion = ""
        _Estatus = 0
        _Id_Ucrear = 0
        _Id_Umodificar = 0
    End Sub
    Public Sub New(id As Integer, nom As String, desc As String, status As Integer, idcrear As Integer, idmodificar As Integer)
        _Id_Marca = id
        _Nombre = nom
        _Descripcion = desc
        _Estatus = status
        _Id_Ucrear = idcrear
        _Id_Umodificar = idmodificar
    End Sub
    Public Sub New(row As DataRow)
        _Id_Marca = row.Field(Of Integer)("Id_Marca")
        _Nombre = row.Field(Of String)("Nombre")
        _Descripcion = row.Field(Of String)("Descripcion")
        _Estatus = row.Field(Of Integer)("Estatus")
        _Id_Ucrear = row.Field(Of Integer)("Id_Ucrear")
        _Id_Umodificar = row.Field(Of Integer)("Id_Umodificar")
    End Sub
    Property Id_Marca As Integer
        Get
            Return _Id_Marca
        End Get
        Set(value As Integer)
            _Id_Marca = value
        End Set
    End Property
    Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property
    Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
    Property Estatus As Integer
        Get
            Return _Estatus
        End Get
        Set(value As Integer)
            _Estatus = value
        End Set
    End Property
    Property Id_Ucrear As Integer
        Get
            Return _Id_Ucrear
        End Get
        Set(value As Integer)
            _Id_Ucrear = value
        End Set
    End Property
    Property Id_Umodificar As Integer
        Get
            Return _Id_Umodificar
        End Get
        Set(value As Integer)
            _Id_Umodificar = value
        End Set
    End Property
    Function RegistrarMarcas(id As Integer, nom As String, desc As String, status As Integer, idcrear As Integer, idmodificar As Integer)

        Dim response As Boolean = False
        Dim conn As SqlConnection = New SqlConnection(conexion)
        conn.Open()
        Dim cmd As New SqlCommand("RegistroMarca", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Id_Marca", id))
        cmd.Parameters.Add(New SqlParameter("Nombre", nom))
        cmd.Parameters.Add(New SqlParameter("@Descripcion", desc))
        cmd.Parameters.Add(New SqlParameter("@Estatus", status))
        cmd.Parameters.Add(New SqlParameter("@Id_Ucrear", idcrear))
        cmd.Parameters.Add(New SqlParameter("@Id_Umodificar", idmodificar))
        Using rdr As SqlDataReader = cmd.ExecuteReader()
            While rdr.Read
                response = rdr("response")
            End While
        End Using
        If response = 1 Then
            Id_Marca = id
            Nombre = nom
            Descripcion = desc
            Estatus = status
            Id_Ucrear = idcrear
            Id_Umodificar = idmodificar
        End If
        conn.Close()
        Return response
    End Function
    Function ModificarMarcas(id As Integer, nom As String, desc As String, status As Integer, idcrear As Integer, idmodificar As Integer)

        Dim response As Boolean = False
        Dim conn As SqlConnection = New SqlConnection(conexion)
        conn.Open()
        Dim cmd As New SqlCommand("ModificarMarca", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Id_Marca", id))
        cmd.Parameters.Add(New SqlParameter("Nombre", nom))
        cmd.Parameters.Add(New SqlParameter("@Descripcion", desc))
        cmd.Parameters.Add(New SqlParameter("@Estatus", status))
        cmd.Parameters.Add(New SqlParameter("@Id_Ucrear", idcrear))
        cmd.Parameters.Add(New SqlParameter("@Id_Umodificar", idmodificar))
        Using rdr As SqlDataReader = cmd.ExecuteReader()
            While rdr.Read
                response = rdr("response")
            End While
        End Using
        If response = 1 Then
            Id_Marca = id
            Nombre = nom
            Descripcion = desc
            Estatus = status
            Id_Ucrear = idcrear
            Id_Umodificar = idmodificar
        End If
        conn.Close()
        Return response
    End Function
    Function EliminarMarcas(id As Integer)

        Dim response As Boolean = False
        Dim conn As SqlConnection = New SqlConnection(conexion)
        conn.Open()
        Dim cmd As New SqlCommand("EliminarMarca", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(New SqlParameter("@Id_Marca", id))
        Using rdr As SqlDataReader = cmd.ExecuteReader()
            While rdr.Read
                response = rdr("response")
            End While
        End Using
        If response = 1 Then
            Id_Marca = id
        End If
        conn.Close()
        Return response
    End Function
End Class
