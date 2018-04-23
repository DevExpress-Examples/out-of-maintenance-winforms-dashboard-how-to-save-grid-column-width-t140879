Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Collections.Generic

Namespace NewProject
	<Serializable> _
	Public Class GridColumnLayoutWrapper
		Private privateFieldName As String
		Public Property FieldName() As String
			Get
				Return privateFieldName
			End Get
			Set(ByVal value As String)
				privateFieldName = value
			End Set
		End Property

		Private privateWidth As Integer
		Public Property Width() As Integer
			Get
				Return privateWidth
			End Get
			Set(ByVal value As Integer)
				privateWidth = value
			End Set
		End Property
	End Class
End Namespace
