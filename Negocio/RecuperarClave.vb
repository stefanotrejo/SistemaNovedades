Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class RecuperarClave

            Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _rclId As Integer
            Public Property rclId() As Integer
                Get
					Return _rclId
                End Get
                Set(ByVal value As Integer)
                    _rclId = value
                End Set
            End Property

			Private _rclFecha As Date
            Public Property rclFecha() As Date
                Get
					Return _rclFecha
                End Get
                Set(ByVal value As Date)
                    _rclFecha = value
                End Set
            End Property

			Private _rclUsuario As String
            Public Property rclUsuario() As String
                Get
					Return _rclUsuario
                End Get
                Set(ByVal value As String)
                    _rclUsuario = value
                End Set
            End Property

			Private _rclEmailRecuperacion As String
            Public Property rclEmailRecuperacion() As String
                Get
					Return _rclEmailRecuperacion
                End Get
                Set(ByVal value As String)
                    _rclEmailRecuperacion = value
                End Set
            End Property

			Private _rclUsuarioEncriptado As String
            Public Property rclUsuarioEncriptado() As String
                Get
					Return _rclUsuarioEncriptado
                End Get
                Set(ByVal value As String)
                    _rclUsuarioEncriptado = value
                End Set
            End Property

			Private _rclEmailRecuperacionEncriptado As String
            Public Property rclEmailRecuperacionEncriptado() As String
                Get
					Return _rclEmailRecuperacionEncriptado
                End Get
                Set(ByVal value As String)
                    _rclEmailRecuperacionEncriptado = value
                End Set
            End Property

			Private _rclActivo As Boolean
            Public Property rclActivo() As Boolean
                Get
					Return _rclActivo
                End Get
                Set(ByVal value As Boolean)
                    _rclActivo = value
                End Set
            End Property

			Private _rclFechaHoraCreacion As Date
            Public Property rclFechaHoraCreacion() As Date
                Get
					Return _rclFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _rclFechaHoraCreacion = value
                End Set
            End Property

			Private _rclFechaHoraUltimaModificacion As Date
            Public Property rclFechaHoraUltimaModificacion() As Date
                Get
					Return _rclFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _rclFechaHoraUltimaModificacion = value
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
                    Me.rclId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal rclId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerUno]", New Object(,) {{"@rclId", rclId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("rclId").ToString().Trim().Length > 0 Then
                            Me.rclId = Convert.ToInt32(Fila(0)("rclId"))
                        Else
                            Me.rclId = 0
                        End If
                        
						If Fila(0)("rclFecha").ToString().Trim().Length > 0 Then
                            Me.rclFecha = Convert.ToDateTime(Fila(0)("rclFecha"))
                        Else
                            Me.rclFecha = Date.Now
                        End If
                        
						If Fila(0)("rclUsuario").ToString().Trim().Length > 0 Then
                            Me.rclUsuario = Convert.ToString(Fila(0)("rclUsuario"))
                        Else
                            Me.rclUsuario = ""
                        End If
                        
						If Fila(0)("rclEmailRecuperacion").ToString().Trim().Length > 0 Then
                            Me.rclEmailRecuperacion = Convert.ToString(Fila(0)("rclEmailRecuperacion"))
                        Else
                            Me.rclEmailRecuperacion = ""
                        End If
                        
						If Fila(0)("rclUsuarioEncriptado").ToString().Trim().Length > 0 Then
                            Me.rclUsuarioEncriptado = Convert.ToString(Fila(0)("rclUsuarioEncriptado"))
                        Else
                            Me.rclUsuarioEncriptado = ""
                        End If
                        
						If Fila(0)("rclEmailRecuperacionEncriptado").ToString().Trim().Length > 0 Then
                            Me.rclEmailRecuperacionEncriptado = Convert.ToString(Fila(0)("rclEmailRecuperacionEncriptado"))
                        Else
                            Me.rclEmailRecuperacionEncriptado = ""
                        End If
                        
						If Fila(0)("rclFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.rclFechaHoraCreacion = Convert.ToDateTime(Fila(0)("rclFechaHoraCreacion"))
                        Else
                            Me.rclFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("rclFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.rclFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("rclFechaHoraUltimaModificacion"))
                        Else
                            Me.rclFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("rclActivo").ToString().Trim().Length > 0 Then
                            Me.rclActivo = IIf(Convert.ToInt32(Fila(0)("rclActivo")) = 1, True, False)
                        Else
							Me.rclActivo = False
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

			Public Sub New(ByVal rclId As Integer, ByVal rclFecha As Date, ByVal rclUsuario As String, ByVal rclEmailRecuperacion As String, ByVal rclUsuarioEncriptado As String, ByVal rclEmailRecuperacionEncriptado As String, ByVal rclActivo As Boolean, ByVal rclFechaHoraCreacion As Date, ByVal rclFechaHoraUltimaModificacion As Date, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.rclId = rclId
					me.rclFecha = rclFecha
					me.rclUsuario = rclUsuario
					me.rclEmailRecuperacion = rclEmailRecuperacion
					me.rclUsuarioEncriptado = rclUsuarioEncriptado
					me.rclEmailRecuperacionEncriptado = rclEmailRecuperacionEncriptado
					me.rclActivo = rclActivo
					me.rclFechaHoraCreacion = rclFechaHoraCreacion
					me.rclFechaHoraUltimaModificacion = rclFechaHoraUltimaModificacion
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerConValoresEncriptados(ByVal UsuarioEncriptado as String, ByVal EmailEncriptado as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerConValoresEncriptados]", New Object(,) {{"@UsuarioEncriptado", UsuarioEncriptado}, {"@EmailEncriptado", EmailEncriptado}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal rclId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[RecuperarClave.ObtenerUno]", New Object(,) {{"@rclId", rclId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub Actualizar(ByVal rclId as Integer, ByVal rclFecha as Date, ByVal rclUsuario as String, ByVal rclEmailRecuperacion as String, ByVal rclUsuarioEncriptado as String, ByVal rclEmailRecuperacionEncriptado as String, ByVal rclActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal rclFechaHoraCreacion as Date, ByVal rclFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.Actualizar]", New Object(,) {{"@rclId", rclId}, {"@rclFecha", rclFecha}, {"@rclUsuario", rclUsuario}, {"@rclEmailRecuperacion", rclEmailRecuperacion}, {"@rclUsuarioEncriptado", rclUsuarioEncriptado}, {"@rclEmailRecuperacionEncriptado", rclEmailRecuperacionEncriptado}, {"@rclActivo", rclActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@rclFechaHoraCreacion", rclFechaHoraCreacion}, {"@rclFechaHoraUltimaModificacion", rclFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal rclId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.Eliminar]", New Object(,) {{"@rclId", rclId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal rclFecha as Date, ByVal rclUsuario as String, ByVal rclEmailRecuperacion as String, ByVal rclUsuarioEncriptado as String, ByVal rclEmailRecuperacionEncriptado as String, ByVal rclActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal rclFechaHoraCreacion as Date, ByVal rclFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.Insertar]", New Object(,) {{"@rclFecha", rclFecha}, {"@rclUsuario", rclUsuario}, {"@rclEmailRecuperacion", rclEmailRecuperacion}, {"@rclUsuarioEncriptado", rclUsuarioEncriptado}, {"@rclEmailRecuperacionEncriptado", rclEmailRecuperacionEncriptado}, {"@rclActivo", rclActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@rclFechaHoraCreacion", rclFechaHoraCreacion}, {"@rclFechaHoraUltimaModificacion", rclFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub InsertarCustom(ByVal Usuario as String, ByVal Email as String, ByVal UsuarioEncriptado as String, ByVal EmailEncriptado as String)
				Try
                    ocdGestor.EjecutarNonQuery("[RecuperarClave.InsertarCustom]", New Object(,) {{"@Usuario", Usuario}, {"@Email", Email}, {"@UsuarioEncriptado", UsuarioEncriptado}, {"@EmailEncriptado", EmailEncriptado}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.rclId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[RecuperarClave.Actualizar]", New Object(,) {{"@rclId", rclId}, {"@rclFecha", rclFecha}, {"@rclUsuario", rclUsuario}, {"@rclEmailRecuperacion", rclEmailRecuperacion}, {"@rclUsuarioEncriptado", rclUsuarioEncriptado}, {"@rclEmailRecuperacionEncriptado", rclEmailRecuperacionEncriptado}, {"@rclActivo", rclActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@rclFechaHoraCreacion", rclFechaHoraCreacion}, {"@rclFechaHoraUltimaModificacion", rclFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.rclId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[RecuperarClave.Eliminar]", New Object(,) {{"@rclId", rclId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[RecuperarClave.Insertar]", New Object(,) {{"@rclFecha", rclFecha}, {"@rclUsuario", rclUsuario}, {"@rclEmailRecuperacion", rclEmailRecuperacion}, {"@rclUsuarioEncriptado", rclUsuarioEncriptado}, {"@rclEmailRecuperacionEncriptado", rclEmailRecuperacionEncriptado}, {"@rclActivo", rclActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@rclFechaHoraCreacion", rclFechaHoraCreacion}, {"@rclFechaHoraUltimaModificacion", rclFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace