' -*- Visual basic -*-

'*****************************************************************
'
'              Copyright 2017 Hiranmoy Basak
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


Imports System.Threading



'tcp response argument
Public Class TcpParameter
    Private mDataStr As String
    Private mStreamIdx As Integer
    Private mResponse As String
    Private mKey As Integer

    Public Sub New(aDataStr As String, aStreamIdx As Integer)
        mDataStr = aDataStr
        mStreamIdx = aStreamIdx
        mResponse = ""

        'using system uptime (in ms) as key)
        mKey = My.Computer.Clock.TickCount

        'wait for 1 ms
        Thread.Sleep(1)
    End Sub

    Public Function GetDataStr() As String
        Return mDataStr
    End Function

    Public Function GetStreamIdx() As String
        Return mStreamIdx
    End Function

    Public Function GetResponse() As String
        Return mResponse
    End Function

    Public Sub SetResponse(aResponse As String)
        mResponse = aResponse
    End Sub

    Public Function GetKey()
        Return mKey
    End Function

    Public Function GetTcpDataStr()
        Return mKey.ToString + "#" + mDataStr
    End Function
End Class
