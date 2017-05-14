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
        gTcpMgr.mFluLight.SetTimerVal(timerVal)
        gTcpMgr.mPlug0.SetTimerVal(timerVal)
        gTcpMgr.mFan.SetTimerVal(timerVal)
        gTcpMgr.mBalconyLight.SetTimerVal(timerVal)
        gTcpMgr.mLightBulb.SetTimerVal(timerVal)
        gTcpMgr.mPlug1.SetTimerVal(timerVal)
        gTcpMgr.mAC.SetTimerVal(timerVal)
    End Sub

    'toggle appliances
    Public Sub ToggleAppliancesIfNeeded()
        gTcpMgr.mFluLight.TimerToggle()
        gTcpMgr.mPlug0.TimerToggle()
        gTcpMgr.mFan.TimerToggle()
        gTcpMgr.mBalconyLight.TimerToggle()
        gTcpMgr.mLightBulb.TimerToggle()
        gTcpMgr.mPlug1.TimerToggle()
        gTcpMgr.mAC.TimerToggle()
    End Sub

    'set appliance scheduler depending on the checked radio button
    Public Sub SetApplianceSchedule(startTime As Integer, endTime As Integer, disabled As Boolean)
        gTcpMgr.mFluLight.SaveSchedule(startTime, endTime, disabled)
        gTcpMgr.mPlug0.SaveSchedule(startTime, endTime, disabled)
        gTcpMgr.mFan.SaveSchedule(startTime, endTime, disabled)
        gTcpMgr.mBalconyLight.SaveSchedule(startTime, endTime, disabled)
        gTcpMgr.mLightBulb.SaveSchedule(startTime, endTime, disabled)
        gTcpMgr.mPlug1.SaveSchedule(startTime, endTime, disabled)
        gTcpMgr.mAC.SaveSchedule(startTime, endTime, disabled)
    End Sub

    'check scheduler of the appliances
    Public Sub ScheduleAppliances()
        gTcpMgr.mFluLight.CheckSchedule()
        gTcpMgr.mPlug0.CheckSchedule()
        gTcpMgr.mFan.CheckSchedule()
        gTcpMgr.mBalconyLight.CheckSchedule()
        gTcpMgr.mLightBulb.CheckSchedule()
        gTcpMgr.mPlug1.CheckSchedule()
        gTcpMgr.mAC.CheckSchedule()
    End Sub

    'reset scheduler of the appliances depending on the checked radio button
    Public Sub ResetScheduleAppliances()
        gTcpMgr.mFluLight.ResetSchedule()
        gTcpMgr.mPlug0.ResetSchedule()
        gTcpMgr.mFan.ResetSchedule()
        gTcpMgr.mBalconyLight.ResetSchedule()
        gTcpMgr.mLightBulb.ResetSchedule()
        gTcpMgr.mPlug1.ResetSchedule()
        gTcpMgr.mAC.ResetSchedule()

        'uncheck scheduler and timer checkbox
        homeCtrl.EnableLightSchedule.Checked = False
        homeCtrl.ToggleLightings.Checked = False
        homeCtrl.DisableLightSchedule.Enabled = False
    End Sub

    'load appliance schedule
    Public Sub LoadApplianceSchedule()
        gTcpMgr.mPlug0.GetSchedule()
        gTcpMgr.mFluLight.GetSchedule()
        gTcpMgr.mBalconyLight.GetSchedule()
        gTcpMgr.mFan.GetSchedule()
        gTcpMgr.mLightBulb.GetSchedule()
        gTcpMgr.mPlug1.GetSchedule()
        gTcpMgr.mAC.GetSchedule()
    End Sub

    'load power histogram
    Public Sub GetAppliancePowerHistogram()
        gTcpMgr.mPlug0.GetPowerHistogram()
        gTcpMgr.mFluLight.GetPowerHistogram()
        gTcpMgr.mBalconyLight.GetPowerHistogram()
        gTcpMgr.mFan.GetPowerHistogram()
        gTcpMgr.mLightBulb.GetPowerHistogram()
        gTcpMgr.mPlug1.GetPowerHistogram()
        gTcpMgr.mAC.GetPowerHistogram()
    End Sub

End Module
