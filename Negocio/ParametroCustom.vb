Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class Parametro
            Public Function ObtenerValor(ByVal Nombre As String) As String
                ocdGestor = New Datos.Gestor
                Tabla = New DataTable

                Try
                    Tabla = ocdGestor.EjecutarReader("[Parametro.ObtenerTodoBuscarxNombre]", New Object(,) {{"@Nombre", Nombre}})
                Catch ex As Exception
                    Throw ex
                End Try

                If Tabla.Rows.Count = 0 Then
                    Return ""
                Else
                    Return Tabla.Rows(0)("Valor").ToString()
                End If
            End Function
        End Class
    End Namespace
End Namespace