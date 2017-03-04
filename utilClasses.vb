' -*- Visual basic -*-

'*****************************************************************
'
'        Copyright 2016 Hiranmoy Basak
'
'                  All Rights Reserved.
'
'           THIS WORK CONTAINS TRADE SECRET And
'       PROPRIETARY INFORMATION WHICH Is THE PROPERTY
'            OF HIRANMOY BASAK OR ITS LICENSOR
'            AND IS SUBJECT TO LICENSE TERMS.
'
'*****************************************************************/
'
' No part of this file may be reproduced, stored in a retrieval system,
' Or transmitted in any form Or by any means --- electronic, mechanical,
' photocopying, recording, Or otherwise --- without prior written permission
' of Hiranmoy Basak.
'
' WARRANTY:
' Use all material in this file at your own risk. Hiranmoy Basak.
' makes no claims about any material contained in this file.
' 
' Author: Hiranmoy Basak (hiranmoy.iitkgp@gmail.com)


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
