Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class Ayuda

            Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _ayuId As Integer
            Public Property ayuId() As Integer
                Get
					Return _ayuId
                End Get
                Set(ByVal value As Integer)
                    _ayuId = value
                End Set
            End Property

			Private _ayuPaginaNombre As String
            Public Property ayuPaginaNombre() As String
                Get
					Return _ayuPaginaNombre
                End Get
                Set(ByVal value As String)
                    _ayuPaginaNombre = value
                End Set
            End Property

			Private _ayuDescripcion As String
            Public Property ayuDescripcion() As String
                Get
					Return _ayuDescripcion
                End Get
                Set(ByVal value As String)
                    _ayuDescripcion = value
                End Set
            End Property

			Private _ayuActivo As Boolean
            Public Property ayuActivo() As Boolean
                Get
					Return _ayuActivo
                End Get
                Set(ByVal value As Boolean)
                    _ayuActivo = value
                End Set
            End Property

			Private _ayuFechaHoraCreacion As Date
            Public Property ayuFechaHoraCreacion() As Date
                Get
					Return _ayuFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _ayuFechaHoraCreacion = value
                End Set
            End Property

			Private _ayuFechaHoraUltimaModificacion As Date
            Public Property ayuFechaHoraUltimaModificacion() As Date
                Get
					Return _ayuFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _ayuFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _usuIdCreacion As Integer
            Public Property usuIdCreacion() As Integer
                Get
					Return _usuIdCreacion
                End Get
                Set(ByVal value As Integer)
                    _usuIdCreacion = value
                End Set
            End Property

			Private _usuIdUltimaModificacion As Integer
            Public Property usuIdUltimaModificacion() As Integer
                Get
					Return _usuIdUltimaModificacion
                End Get
                Set(ByVal value As Integer)
                    _usuIdUltimaModificacion = value
                End Set
            End Property

			Public Sub New()
                Try                
                    Me.ayuId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal ayuId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[Ayuda.ObtenerUno]", New Object(,) {{"@ayuId", ayuId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("ayuId").ToString().Trim().Length > 0 Then
                            Me.ayuId = Convert.ToInt32(Fila(0)("ayuId"))
                        Else
                            Me.ayuId = 0
                        End If
                        
						If Fila(0)("ayuPaginaNombre").ToString().Trim().Length > 0 Then
                            Me.ayuPaginaNombre = Convert.ToString(Fila(0)("ayuPaginaNombre"))
                        Else
                            Me.ayuPaginaNombre = ""
                        End If
                        
						If Fila(0)("ayuDescripcion").ToString().Trim().Length > 0 Then
                            Me.ayuDescripcion = Convert.ToString(Fila(0)("ayuDescripcion"))
                        Else
                            Me.ayuDescripcion = ""
                        End If
                        
						If Fila(0)("ayuFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.ayuFechaHoraCreacion = Convert.ToDateTime(Fila(0)("ayuFechaHoraCreacion"))
                        Else
                            Me.ayuFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("ayuFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.ayuFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("ayuFechaHoraUltimaModificacion"))
                        Else
                            Me.ayuFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("ayuActivo").ToString().Trim().Length > 0 Then
                            Me.ayuActivo = IIf(Convert.ToInt32(Fila(0)("ayuActivo")) = 1, True, False)
                        Else
							Me.ayuActivo = False
                        End If
                        
						If Fila(0)("usuIdCreacion").ToString().Trim().Length > 0 Then
                            Me.usuIdCreacion = Convert.ToInt32(Fila(0)("usuIdCreacion"))
                        Else
							Me.usuIdCreacion = 0
                        End If
                        
						If Fila(0)("usuIdUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.usuIdUltimaModificacion = Convert.ToInt32(Fila(0)("usuIdUltimaModificacion"))
                        Else
							Me.usuIdUltimaModificacion = 0
                        End If
                        
					End If
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub New(ByVal ayuId As Integer, ByVal ayuPaginaNombre As String, ByVal ayuDescripcion As String, ByVal ayuActivo As Boolean, ByVal ayuFechaHoraCreacion As Date, ByVal ayuFechaHoraUltimaModificacion As Date, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.ayuId = ayuId
					me.ayuPaginaNombre = ayuPaginaNombre
					me.ayuDescripcion = ayuDescripcion
					me.ayuActivo = ayuActivo
					me.ayuFechaHoraCreacion = ayuFechaHoraCreacion
					me.ayuFechaHoraUltimaModificacion = ayuFechaHoraUltimaModificacion
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Ayuda.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal ayuId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Ayuda.ObtenerUno]", New Object(,) {{"@ayuId", ayuId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerxNombrePagina(ByVal ayuPaginaNombre as String, ByVal usuId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Ayuda.ObtenerxNombrePagina]", New Object(,) {{"@ayuPaginaNombre", ayuPaginaNombre}, {"@usuId", usuId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub Actualizar(ByVal ayuId as Integer, ByVal ayuPaginaNombre as String, ByVal ayuDescripcion as String, ByVal ayuActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal ayuFechaHoraCreacion as Date, ByVal ayuFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Ayuda.Actualizar]", New Object(,) {{"@ayuId", ayuId}, {"@ayuPaginaNombre", ayuPaginaNombre}, {"@ayuDescripcion", ayuDescripcion}, {"@ayuActivo", ayuActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ayuFechaHoraCreacion", ayuFechaHoraCreacion}, {"@ayuFechaHoraUltimaModificacion", ayuFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal ayuId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Ayuda.Eliminar]", New Object(,) {{"@ayuId", ayuId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal ayuPaginaNombre as String, ByVal ayuDescripcion as String, ByVal ayuActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal ayuFechaHoraCreacion as Date, ByVal ayuFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Ayuda.Insertar]", New Object(,) {{"@ayuPaginaNombre", ayuPaginaNombre}, {"@ayuDescripcion", ayuDescripcion}, {"@ayuActivo", ayuActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ayuFechaHoraCreacion", ayuFechaHoraCreacion}, {"@ayuFechaHoraUltimaModificacion", ayuFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.ayuId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Ayuda.Actualizar]", New Object(,) {{"@ayuId", ayuId}, {"@ayuPaginaNombre", ayuPaginaNombre}, {"@ayuDescripcion", ayuDescripcion}, {"@ayuActivo", ayuActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ayuFechaHoraCreacion", ayuFechaHoraCreacion}, {"@ayuFechaHoraUltimaModificacion", ayuFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.ayuId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Ayuda.Eliminar]", New Object(,) {{"@ayuId", ayuId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Ayuda.Insertar]", New Object(,) {{"@ayuPaginaNombre", ayuPaginaNombre}, {"@ayuDescripcion", ayuDescripcion}, {"@ayuActivo", ayuActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ayuFechaHoraCreacion", ayuFechaHoraCreacion}, {"@ayuFechaHoraUltimaModificacion", ayuFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace