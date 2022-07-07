Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class UsuarioConectado
        
			Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _ucoId As Integer
            Public Property ucoId() As Integer
                Get
					Return _ucoId
                End Get
                Set(ByVal value As Integer)
                    _ucoId = value
                End Set
            End Property

			Private _ucoFechaHoraUltimaConexion As Date
            Public Property ucoFechaHoraUltimaConexion() As Date
                Get
					Return _ucoFechaHoraUltimaConexion
                End Get
                Set(ByVal value As Date)
                    _ucoFechaHoraUltimaConexion = value
                End Set
            End Property

			Private _ucoGuid As String
            Public Property ucoGuid() As String
                Get
					Return _ucoGuid
                End Get
                Set(ByVal value As String)
                    _ucoGuid = value
                End Set
            End Property

			Private _ucoIpPublica As String
            Public Property ucoIpPublica() As String
                Get
					Return _ucoIpPublica
                End Get
                Set(ByVal value As String)
                    _ucoIpPublica = value
                End Set
            End Property

			Private _ucoDesconectar As Boolean
            Public Property ucoDesconectar() As Boolean
                Get
					Return _ucoDesconectar
                End Get
                Set(ByVal value As Boolean)
                    _ucoDesconectar = value
                End Set
            End Property

			Private _ucoActivo As Boolean
            Public Property ucoActivo() As Boolean
                Get
					Return _ucoActivo
                End Get
                Set(ByVal value As Boolean)
                    _ucoActivo = value
                End Set
            End Property

			Private _ucoFechaHoraCreacion As Date
            Public Property ucoFechaHoraCreacion() As Date
                Get
					Return _ucoFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _ucoFechaHoraCreacion = value
                End Set
            End Property

			Private _ucoFechaHoraUltimaModificacion As Date
            Public Property ucoFechaHoraUltimaModificacion() As Date
                Get
					Return _ucoFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _ucoFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _usuId As Integer
            Public Property usuId() As Integer
                Get
					Return _usuId
                End Get
                Set(ByVal value As Integer)
                    _usuId = value
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
                    Me.ucoId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal ucoId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerUno]", New Object(,) {{"@ucoId", ucoId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("ucoId").ToString().Trim().Length > 0 Then
                            Me.ucoId = Convert.ToInt32(Fila(0)("ucoId"))
                        Else
                            Me.ucoId = 0
                        End If
                        
						If Fila(0)("ucoFechaHoraUltimaConexion").ToString().Trim().Length > 0 Then
                            Me.ucoFechaHoraUltimaConexion = Convert.ToDateTime(Fila(0)("ucoFechaHoraUltimaConexion"))
                        Else
                            Me.ucoFechaHoraUltimaConexion = Date.Now
                        End If
                        
						If Fila(0)("ucoGuid").ToString().Trim().Length > 0 Then
                            Me.ucoGuid = Convert.ToString(Fila(0)("ucoGuid"))
                        Else
                            Me.ucoGuid = ""
                        End If
                        
						If Fila(0)("ucoIpPublica").ToString().Trim().Length > 0 Then
                            Me.ucoIpPublica = Convert.ToString(Fila(0)("ucoIpPublica"))
                        Else
                            Me.ucoIpPublica = ""
                        End If
                        
						If Fila(0)("ucoFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.ucoFechaHoraCreacion = Convert.ToDateTime(Fila(0)("ucoFechaHoraCreacion"))
                        Else
                            Me.ucoFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("ucoFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.ucoFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("ucoFechaHoraUltimaModificacion"))
                        Else
                            Me.ucoFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("ucoDesconectar").ToString().Trim().Length > 0 Then
                            Me.ucoDesconectar = IIf(Convert.ToInt32(Fila(0)("ucoDesconectar")) = 1, True, False)
                        Else
							Me.ucoDesconectar = False
                        End If
                        
						If Fila(0)("ucoActivo").ToString().Trim().Length > 0 Then
                            Me.ucoActivo = IIf(Convert.ToInt32(Fila(0)("ucoActivo")) = 1, True, False)
                        Else
							Me.ucoActivo = False
                        End If
                        
						If Fila(0)("usuId").ToString().Trim().Length > 0 Then
                            Me.usuId = Convert.ToInt32(Fila(0)("usuId"))
                        Else
							Me.usuId = 0
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

			Public Sub New(ByVal ucoId As Integer, ByVal ucoFechaHoraUltimaConexion As Date, ByVal ucoGuid As String, ByVal ucoIpPublica As String, ByVal ucoDesconectar As Boolean, ByVal ucoActivo As Boolean, ByVal ucoFechaHoraCreacion As Date, ByVal ucoFechaHoraUltimaModificacion As Date, ByVal IusuId As Integer, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.ucoId = ucoId
					me.ucoFechaHoraUltimaConexion = ucoFechaHoraUltimaConexion
					me.ucoGuid = ucoGuid
					me.ucoIpPublica = ucoIpPublica
					me.ucoDesconectar = ucoDesconectar
					me.ucoActivo = ucoActivo
					me.ucoFechaHoraCreacion = ucoFechaHoraCreacion
					me.ucoFechaHoraUltimaModificacion = ucoFechaHoraUltimaModificacion
					me.usuId = usuId
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerConectar(ByVal usuId as Integer, ByVal ucoGuid as String, ByVal ucoIpPublica as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerConectar]", New Object(,) {{"@usuId", usuId}, {"@ucoGuid", ucoGuid}, {"@ucoIpPublica", ucoIpPublica}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodoCustom() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerTodoCustom]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal ucoId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[UsuarioConectado.ObtenerUno]", New Object(,) {{"@ucoId", ucoId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub Actualizar(ByVal ucoId as Integer, ByVal usuId as Integer, ByVal ucoFechaHoraUltimaConexion as Date, ByVal ucoGuid as String, ByVal ucoIpPublica as String, ByVal ucoDesconectar as Boolean, ByVal ucoActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal ucoFechaHoraCreacion as Date, ByVal ucoFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.Actualizar]", New Object(,) {{"@ucoId", ucoId}, {"@usuId", usuId}, {"@ucoFechaHoraUltimaConexion", ucoFechaHoraUltimaConexion}, {"@ucoGuid", ucoGuid}, {"@ucoIpPublica", ucoIpPublica}, {"@ucoDesconectar", ucoDesconectar}, {"@ucoActivo", ucoActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ucoFechaHoraCreacion", ucoFechaHoraCreacion}, {"@ucoFechaHoraUltimaModificacion", ucoFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub DesconectarOtros(ByVal usuId as Integer, ByVal ucoGuid as String, ByVal ucoIpPublica as String)
				Try
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.DesconectarOtros]", New Object(,) {{"@usuId", usuId}, {"@ucoGuid", ucoGuid}, {"@ucoIpPublica", ucoIpPublica}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal ucoId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.Eliminar]", New Object(,) {{"@ucoId", ucoId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal usuId as Integer, ByVal ucoFechaHoraUltimaConexion as Date, ByVal ucoGuid as String, ByVal ucoIpPublica as String, ByVal ucoDesconectar as Boolean, ByVal ucoActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal ucoFechaHoraCreacion as Date, ByVal ucoFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[UsuarioConectado.Insertar]", New Object(,) {{"@usuId", usuId}, {"@ucoFechaHoraUltimaConexion", ucoFechaHoraUltimaConexion}, {"@ucoGuid", ucoGuid}, {"@ucoIpPublica", ucoIpPublica}, {"@ucoDesconectar", ucoDesconectar}, {"@ucoActivo", ucoActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ucoFechaHoraCreacion", ucoFechaHoraCreacion}, {"@ucoFechaHoraUltimaModificacion", ucoFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.ucoId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[UsuarioConectado.Actualizar]", New Object(,) {{"@ucoId", ucoId}, {"@usuId", usuId}, {"@ucoFechaHoraUltimaConexion", ucoFechaHoraUltimaConexion}, {"@ucoGuid", ucoGuid}, {"@ucoIpPublica", ucoIpPublica}, {"@ucoDesconectar", ucoDesconectar}, {"@ucoActivo", ucoActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ucoFechaHoraCreacion", ucoFechaHoraCreacion}, {"@ucoFechaHoraUltimaModificacion", ucoFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.ucoId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[UsuarioConectado.Eliminar]", New Object(,) {{"@ucoId", ucoId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[UsuarioConectado.Insertar]", New Object(,) {{"@usuId", usuId}, {"@ucoFechaHoraUltimaConexion", ucoFechaHoraUltimaConexion}, {"@ucoGuid", ucoGuid}, {"@ucoIpPublica", ucoIpPublica}, {"@ucoDesconectar", ucoDesconectar}, {"@ucoActivo", ucoActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@ucoFechaHoraCreacion", ucoFechaHoraCreacion}, {"@ucoFechaHoraUltimaModificacion", ucoFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace