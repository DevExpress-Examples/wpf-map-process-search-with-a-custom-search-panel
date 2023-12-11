Imports DevExpress.Xpf.Map
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls

Namespace MapControl_SearchPanel

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

'#Region "#CustomSearch"
        Private Sub bSearch_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.tbSearchResult.Text = ""
            Me.searchProvider.Search(Me.tbLocation.Text)
        End Sub

'#End Region  ' #CustomSearch
        Private Sub ValidationError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
            If e.Action = ValidationErrorEventAction.Added Then Call MessageBox.Show(e.Error.ErrorContent.ToString())
        End Sub

'#Region "#SearchCompletedEventHandler"
        Private Sub searchProvider_SearchCompleted(ByVal sender As Object, ByVal e As BingSearchCompletedEventArgs)
            If e.Cancelled Then Return
            If e.RequestResult.ResultCode <> RequestResultCode.Success Then Return
            Dim sb As StringBuilder = New StringBuilder()
            Dim requestResult As SearchRequestResult = e.RequestResult
            sb.Append(String.Format("Result Code: {0}" & Microsoft.VisualBasic.Constants.vbLf, requestResult.ResultCode))
            If String.IsNullOrEmpty(requestResult.FaultReason) Then
                sb.Append(String.Format("Fault Reason: (none)" & Microsoft.VisualBasic.Constants.vbLf, requestResult.FaultReason))
            Else
                sb.Append(String.Format("Fault Reason: {0}" & Microsoft.VisualBasic.Constants.vbLf, requestResult.FaultReason))
            End If

            sb.Append(String.Format("Search Location: {0}" & Microsoft.VisualBasic.Constants.vbLf, requestResult.Keyword))
            sb.Append(String.Format("Estimated Matches: {0}" & Microsoft.VisualBasic.Constants.vbLf, requestResult.EstimatedMatches))
            sb.Append(String.Format("SearchResults:" & Microsoft.VisualBasic.Constants.vbLf & "{0}", ProcessLocationList(requestResult.SearchResults)))
            Me.tbSearchResult.Text = sb.ToString()
        End Sub

        Private Function ProcessLocationList(ByVal results As List(Of LocationInformation)) As String
            If results Is Nothing Then Return ""
            Dim sb As StringBuilder = New StringBuilder()
            For i As Integer = 0 To results.Count - 1
                sb.Append(String.Format("{0}) {1}", i + 1, ProcessLocationInformation(results(i))))
            Next

            Return sb.ToString()
        End Function

'#End Region  ' #SearchCompletedEventHandler
'#Region "#ProcessLocationInformation"
        Private Function ProcessLocationInformation(ByVal info As LocationInformation) As String
            If info Is Nothing Then Return ""
            Dim sb As StringBuilder = New StringBuilder()
            sb.Append(String.Format("{0}" & Microsoft.VisualBasic.Constants.vbLf, info.DisplayName))
            sb.Append(String.Format(Microsoft.VisualBasic.Constants.vbTab & "Adress: {0}" & Microsoft.VisualBasic.Constants.vbLf, info.Address))
            sb.Append(String.Format(Microsoft.VisualBasic.Constants.vbTab & "Location: {0}" & Microsoft.VisualBasic.Constants.vbLf, info.Location))
            Return sb.ToString()
        End Function
'#End Region  ' #ProcessLocationInformation
    End Class

    Friend Class NonNegativeIntValidationRule
        Inherits ValidationRule

        Private minField As Integer = 0

        Private maxField As Integer = Integer.MaxValue

        Public ReadOnly Property Min As Integer
            Get
                Return minField
            End Get
        End Property

        Public Property Max As Integer
            Get
                Return maxField
            End Get

            Set(ByVal value As Integer)
                If value <> maxField Then maxField = value
            End Set
        End Property

        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
            Dim i As Integer
            If Not Integer.TryParse(TryCast(value, String), NumberStyles.Integer, cultureInfo, i) Then Return New ValidationResult(False, "Input value should be an integer.")
            If i > maxField OrElse i < minField Then Return New ValidationResult(False, String.Format("Input value should be larger than or equals to 0 and les than or equals to {0}", maxField))
            Return New ValidationResult(True, Nothing)
        End Function
    End Class
End Namespace
