Imports System.Data
Imports System.Diagnostics
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Text

Namespace LiquidacionSueldos
    Namespace Negocio
        Public Class Seguridad
            Shared ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Shared Tabla As New DataTable

            Public Shared Function Autenticar(ByVal usuNombreIngreso As String, ByVal usuClave As String) As DataTable
                Dim ClaveEncriptada As String = EncriptarClave(usuClave)
                Return ocdGestor.EjecutarReader("[Usuario.ObtenerAutenticar]", New Object(,) {{"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", ClaveEncriptada}})
            End Function

            Public Shared Function ValidarIngresoPagina(ByVal perId As Integer, ByVal PaginaNombre As String) As Boolean
                Tabla = ocdGestor.EjecutarReader("[Usuario.ValidarPagina]", New Object(,) {{"@perId", perId}, {"@PaginaNombre", PaginaNombre}})

                If Tabla.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Shared Function ObtenerMenu(ByVal menId As Integer, ByVal perId As Integer) As DataTable
                Return ocdGestor.EjecutarReader("[Perfil.ObtenerMenu]", New Object(,) {{"@menId", menId}, {"@perId", perId}})
            End Function

            Public Shared Function EncriptarClave(ByVal usuClave As String) As String
                Dim encoder As UnicodeEncoding = Nothing
                Dim sSHA512 As SHA512Managed = Nothing
                Try
                    encoder = New UnicodeEncoding()
                    sSHA512 = New SHA512Managed()

                Catch oError As Exception
                    Throw oError
                End Try

                Return Convert.ToBase64String(sSHA512.ComputeHash(encoder.GetBytes(usuClave)))
            End Function
        End Class
    End Namespace
End Namespace
