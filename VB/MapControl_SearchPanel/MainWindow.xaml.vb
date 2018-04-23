Imports DevExpress.Xpf.Map
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls

Namespace MapControl_SearchPanel
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        #Region "#CustomSearch"
        Private Sub bSearch_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            tbSearchResult.Text = ""
            searchProvider.Search(tbLocation.Text)
        End Sub
        #End Region ' #CustomSearch

        Private Sub ValidationError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
            If e.Action = ValidationErrorEventAction.Added Then
                MessageBox.Show(e.Error.ErrorContent.ToString())
            End If
        End Sub
        #Region "#SearchCompletedEventHandler"
        Private Sub searchProvider_SearchCompleted(ByVal sender As Object, ByVal e As BingSearchCompletedEventArgs)
            If e.Cancelled Then
                Return
            End If
            If e.RequestResult.ResultCode <> RequestResultCode.Success Then
                Return
            End If

            Dim sb As New StringBuilder()

            Dim requestResult As SearchRequestResult = e.RequestResult
            sb.Append(String.Format("Result Code: {0}" & vbLf, requestResult.ResultCode))
            If String.IsNullOrEmpty(requestResult.FaultReason) Then
                sb.Append(String.Format("Fault Reason: (none)" & vbLf, requestResult.FaultReason))
            Else
                sb.Append(String.Format("Fault Reason: {0}" & vbLf, requestResult.FaultReason))
            End If
            sb.Append(String.Format("Search Location: {0}" & vbLf, requestResult.Keyword))
            sb.Append(String.Format("Estimated Matches: {0}" & vbLf, requestResult.EstimatedMatches))
            sb.Append(String.Format("SearchResults:" & vbLf & "{0}", ProcessLocationList(requestResult.SearchResults)))

            tbSearchResult.Text = sb.ToString()

        End Sub

        Private Function ProcessLocationList(ByVal results As List(Of LocationInformation)) As String
            If results Is Nothing Then
                Return ""
            End If

            Dim sb As New StringBuilder()
            For i As Integer = 0 To results.Count - 1
                sb.Append(String.Format("{0}) {1}", i + 1, ProcessLocationInformation(results(i))))
            Next i
            Return sb.ToString()
        End Function
        #End Region ' #SearchCompletedEventHandler

        #Region "#ProcessLocationInformation"
        Private Function ProcessLocationInformation(ByVal info As LocationInformation) As String
            If info Is Nothing Then
                Return ""
            End If

            Dim sb As New StringBuilder()

            sb.Append(String.Format("{0}" & vbLf, info.DisplayName))
            sb.Append(String.Format(vbTab & "Adress: {0}" & vbLf, info.Address))
            sb.Append(String.Format(vbTab & "Location: {0}" & vbLf, info.Location))
            Return sb.ToString()
        End Function
        #End Region ' #ProcessLocationInformation
    End Class

    Friend Class NonNegativeIntValidationRule
        Inherits ValidationRule


        Private min_Renamed As Integer = 0

        Private max_Renamed As Integer = Integer.MaxValue

        Public ReadOnly Property Min() As Integer
            Get
                Return min_Renamed
            End Get
        End Property
        Public Property Max() As Integer
            Get
                Return max_Renamed
            End Get
            Set(ByVal value As Integer)
                If value <> max_Renamed Then
                    max_Renamed = value
                End If
            End Set
        End Property

        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
            Dim i As Integer = Nothing
            If Not Integer.TryParse(TryCast(value, String), NumberStyles.Integer,cultureInfo, i) Then
                Return New ValidationResult(False, "Input value should be an integer.")
            End If
            If (i > max_Renamed) OrElse (i < min_Renamed) Then
                Return New ValidationResult(False, String.Format("Input value should be larger than or equals to 0 and les than or equals to {0}", max_Renamed))
            End If
            Return New ValidationResult(True, Nothing)
        End Function
    End Class
End Namespace
