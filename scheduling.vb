' -*- Visual basic -*-

'*****************************************************************
'
'              Copyright 2016 Hiranmoy Basak
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
Module Scheduling

    'set appliance toggle timer depending on the checked radio button
    Public Sub SetApplianceTimer(timerVal As Integer)
        If homeCtrl.SelectFluLight.Checked = True Then
            gTcpMgr.mFluLight.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectPlug0.Checked = True Then
            gTcpMgr.mPlug0.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectFan.Checked = True Then
            gTcpMgr.mFan.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectBalconyLight.Checked = True Then
            gTcpMgr.mBalconyLight.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectLightBulb.Checked = True Then
            gTcpMgr.mLightBulb.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectPlug1.Checked = True Then
            gTcpMgr.mPlug1.SetTimerVal(timerVal)
        End If
    End Sub

    'toggle appliances
    Public Sub ToggleAppliancesIfNeeded()
        Try
            gTcpMgr.mFluLight.TimerToggle()
            gTcpMgr.mPlug0.TimerToggle()
            gTcpMgr.mFan.TimerToggle()
            gTcpMgr.mBalconyLight.TimerToggle()
            gTcpMgr.mLightBulb.TimerToggle()
            gTcpMgr.mPlug1.TimerToggle()
        Catch
        End Try
    End Sub

    'set appliance scheduler depending on the checked radio button
    Public Sub SetApplianceSchedule(startTime As Integer, endTime As Integer, disabled As Boolean)
        If homeCtrl.SelectFluLight.Checked = True Then
            gTcpMgr.mFluLight.SaveSchedule(startTime, endTime, disabled)
        End If
        If homeCtrl.SelectPlug0.Checked = True Then
            gTcpMgr.mPlug0.SaveSchedule(startTime, endTime, disabled)
        End If
        If homeCtrl.SelectFan.Checked = True Then
            gTcpMgr.mFan.SaveSchedule(startTime, endTime, disabled)
        End If
        If homeCtrl.SelectBalconyLight.Checked = True Then
            gTcpMgr.mBalconyLight.SaveSchedule(startTime, endTime, disabled)
        End If
        If homeCtrl.SelectLightBulb.Checked = True Then
            gTcpMgr.mLightBulb.SaveSchedule(startTime, endTime, disabled)
        End If
        If homeCtrl.SelectPlug1.Checked = True Then
            gTcpMgr.mPlug1.SaveSchedule(startTime, endTime, disabled)
        End If
    End Sub

    'check scheduler of the appliances
    Public Sub ScheduleAppliances()
        Try
            gTcpMgr.mFluLight.SetSchedule()
            gTcpMgr.mPlug0.SetSchedule()
            gTcpMgr.mFan.SetSchedule()
            gTcpMgr.mBalconyLight.SetSchedule()
            gTcpMgr.mLightBulb.SetSchedule()
            gTcpMgr.mPlug1.SetSchedule()
        Catch
        End Try
    End Sub

    'reset scheduler of the appliances depending on the checked radio button
    Public Sub ResetScheduleAppliances()
        If homeCtrl.SelectFluLight.Checked = True Then
            gTcpMgr.mFluLight.ResetSchedule()
        End If
        If homeCtrl.SelectPlug0.Checked = True Then
            gTcpMgr.mPlug0.ResetSchedule()
        End If
        If homeCtrl.SelectFan.Checked = True Then
            gTcpMgr.mFan.ResetSchedule()
        End If
        If homeCtrl.SelectBalconyLight.Checked = True Then
            gTcpMgr.mBalconyLight.ResetSchedule()
        End If
        If homeCtrl.SelectLightBulb.Checked = True Then
            gTcpMgr.mLightBulb.ResetSchedule()
        End If
        If homeCtrl.SelectPlug1.Checked = True Then
            gTcpMgr.mPlug1.ResetSchedule()
        End If

        'uncheck scheduler and timer checkbox
        homeCtrl.EnableLightSchedule.Checked = False
        homeCtrl.ToggleLightings.Checked = False
        homeCtrl.DisableLightSchedule.Enabled = False
    End Sub

End Module
