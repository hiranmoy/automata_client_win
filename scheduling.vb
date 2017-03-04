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


Module Scheduling

    'set appliance toggle timer depending on the checked radio button
    Public Sub SetApplianceTimer(timerVal As Integer)
        If homeCtrl.SelectFluLight.Checked = True Then
            gFluLight.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectPlug0.Checked = True Then
            gPlug0.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectFan.Checked = True Then
            gFan.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectBalconyLight.Checked = True Then
            gBalconyLight.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectLightBulb.Checked = True Then
            gLightBulb.SetTimerVal(timerVal)
        End If
        If homeCtrl.SelectPlug1.Checked = True Then
            gPlug1.SetTimerVal(timerVal)
        End If
    End Sub

    'toggle appliances
    Public Sub ToggleAppliancesIfNeeded()
        Try
            gFluLight.TimerToggle()
            gPlug0.TimerToggle()
            gFan.TimerToggle()
            gBalconyLight.TimerToggle()
            gLightBulb.TimerToggle()
            gPlug1.TimerToggle()
        Catch
        End Try
    End Sub

    'set appliance scheduler depending on the checked radio button
    Public Sub SetApplianceSchedule(startTime As Integer, endTime As Integer)
        If homeCtrl.SelectFluLight.Checked = True Then
            gFluLight.SaveSchedule(startTime, endTime)
        End If
        If homeCtrl.SelectPlug0.Checked = True Then
            gPlug0.SaveSchedule(startTime, endTime)
        End If
        If homeCtrl.SelectFan.Checked = True Then
            gFan.SaveSchedule(startTime, endTime)
        End If
        If homeCtrl.SelectBalconyLight.Checked = True Then
            gBalconyLight.SaveSchedule(startTime, endTime)
        End If
        If homeCtrl.SelectLightBulb.Checked = True Then
            gLightBulb.SaveSchedule(startTime, endTime)
        End If
        If homeCtrl.SelectPlug1.Checked = True Then
            gPlug1.SaveSchedule(startTime, endTime)
        End If
    End Sub

    'check scheduler of the appliances
    Public Sub ScheduleAppliances()
        Try
            gFluLight.SetSchedule()
            gPlug0.SetSchedule()
            gFan.SetSchedule()
            gBalconyLight.SetSchedule()
            gLightBulb.SetSchedule()
            gPlug1.SetSchedule()
        Catch
        End Try
    End Sub

    'reset scheduler of the appliances depending on the checked radio button
    Public Sub ResetScheduleAppliances()
        If homeCtrl.SelectFluLight.Checked = True Then
            gFluLight.ResetSchedule()

        End If
        If homeCtrl.SelectPlug0.Checked = True Then
            gPlug0.ResetSchedule()

        End If
        If homeCtrl.SelectFan.Checked = True Then
            gFan.ResetSchedule()
        End If
        If homeCtrl.SelectBalconyLight.Checked = True Then
            gBalconyLight.ResetSchedule()
        End If
        If homeCtrl.SelectLightBulb.Checked = True Then
            gLightBulb.ResetSchedule()
        End If
        If homeCtrl.SelectPlug1.Checked = True Then
            gPlug1.ResetSchedule()
        End If

        'uncheck scheduler and timer checkbox
        homeCtrl.EnableLightSchedule.Checked = False
        homeCtrl.ToggleLightings.Checked = False
    End Sub

End Module
