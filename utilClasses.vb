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
    'tcp input to rpi
    Private mDataStr As String

    'stream index
    Private mStreamIdx As Integer

    'number of data packets to be received from rpi
    Private mNumPackets As Integer

    'priority of packet(s) to be received from rpi
    Private mPriority As Integer

    'tcp responses from rpi
    Private mResponse() As String

    'tcp key
    Private mKey As Integer

    'check whether all packets are recived
    Private mReceived() As Boolean


    Public Sub New(aDataStr As String, aStreamIdx As Integer, priority As Integer, Optional numPackets As Integer = 1)
        mDataStr = aDataStr
        mStreamIdx = aStreamIdx
        mPriority = 10 * priority
        mNumPackets = numPackets

        'initilize responses and packet check
        ReDim mResponse(numPackets - 1)
        ReDim mReceived(numPackets - 1)
        For idx = 0 To numPackets - 1
            mResponse(idx) = ""
            mReceived(idx) = False
        Next

        'using system uptime (in ms) as key)
        mKey = My.Computer.Clock.TickCount

        'debug: checking for duplicate keys
        Debug.Assert(gTcpKeys.Contains(mKey) = False)
        gTcpKeys.Add(mKey)

        'wait for 20 ms
        Thread.Sleep(20)

        'TcpParameter should be created only in main thread
        Debug.Assert(Thread.CurrentThread.Name() = "Automata_Main_Trd")
    End Sub

    Public Function GetDataStr() As String
        Return mDataStr
    End Function

    Public Function GetStreamIdx() As String
        Return mStreamIdx
    End Function

    Public Function GetNumPackets() As Integer
        Return mNumPackets
    End Function

    Public Function GetPriority() As Integer
        Return mPriority
    End Function

    Public Function GetResponse(Optional idx As Integer = 0) As String
        Return mResponse(idx)
    End Function

    Public Sub SetResponse(aResponse As String, idx As Integer)
        mResponse(idx) = aResponse
        mReceived(idx) = True
    End Sub

    Public Function GetKey() As Integer
        Return mKey
    End Function

    Public Function GetTcpDataStr() As String
        Return "#" + mKey.ToString + "=" + mDataStr + "~"
    End Function

    Public Function IsAllPacketsReceived() As Boolean
        For idx = 0 To mNumPackets - 1
            If mReceived(idx) = False Then
                Return False
            End If
        Next

        Return True
    End Function

End Class
