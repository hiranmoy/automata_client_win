'tcp response argument
Public Class TcpParameter
    Private mDataStr As String
    Private mStreamIdx As Integer

    Public Sub New(aDataStr As String, aStreamIdx As Integer)
        mDataStr = aDataStr
        mStreamIdx = aStreamIdx
    End Sub

    Public Function GetDataStr() As String
        Return mDataStr
    End Function

    Public Function GetStreamIdx() As String
        Return mStreamIdx
    End Function
End Class

'tcp response thread argument
Public Class TcpParameterTrd
    Private mTcpParam As TcpParameter
    Private mResponse As String

    Public Sub New(aTcpParam As TcpParameter, aResponse As String)
        mTcpParam = aTcpParam
        mResponse = aResponse
    End Sub

    Public Function GetTcpParam() As TcpParameter
        Return mTcpParam
    End Function

    Public Function GetResponse() As String
        Return mResponse
    End Function

    Public Sub SetResponse(aResponse As String)
        mResponse = aResponse
    End Sub
End Class
