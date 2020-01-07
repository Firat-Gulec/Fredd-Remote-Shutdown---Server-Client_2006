Imports System.net
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading



Public Class Form1

    Dim trlisten As Thread
    Dim trShutdown As Thread
    Dim trReboot As Thread
    Dim trLogOff As Thread
    Dim trpoweroff As Thread

    Sub poweroff()
        Dim t As Single
        Dim objWMIService, objComputer As Object
        'Now get some privileges
        objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")
        For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

            t = objComputer.Win32Shutdown(8 + 4, 0)

            If t <> 0 Then
                'Error occurred!!!
            Else
                'Shutdown your system
            End If
        Next
    End Sub
    Sub shutdown()
        Dim t As Single
        Dim objWMIService, objComputer As Object
        'Now get some privileges
        objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")
        For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

            t = objComputer.Win32Shutdown(1 + 4, 0)

            If t <> 0 Then
                'Error occurred!!!
            Else
                'Shutdown your system
            End If
        Next
    End Sub
    Sub reboot()
        Dim t As Single
        Dim objWMIService, objComputer As Object
        'Now get some privileges
        objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")
        For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

            t = objComputer.Win32Shutdown(2 + 4, 0)

            If t <> 0 Then
                'Error occurred!!!
            Else
                'Reboot your system
            End If
        Next
    End Sub
    Sub logoff()
        Dim t As Single
        Dim objWMIService, objComputer As Object
        'Now get some privileges
        objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")
        For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

            t = objComputer.Win32Shutdown(0, 0)

            If t <> 0 Then
                'Error occurred!!!
            Else
                'LogOff your system
            End If
        Next
    End Sub
    Dim host As String = ""
    Dim port As Integer = 63000
    Sub ListenToServer()
        'Try

        Dim LISTENING As Boolean
        Dim localhostAddress As IPAddress = ipAddress.Parse(ipAddress.ToString)
        Dim port As Integer = 63000      '' PORT ADDRESS
        ''''''''''' making socket tcpList ''''''''''''''''
        Dim tcpList As New TcpListener(localhostAddress, port)
        Try
            tcpList.Start()
            LISTENING = True

            Do While LISTENING

                Do While tcpList.Pending = False And LISTENING = True
                    ' Yield the CPU for a while.
                    Thread.Sleep(10)
                Loop
                If Not LISTENING Then Exit Do

                Dim tcpCli As TcpClient = tcpList.AcceptTcpClient()
                'ListBox1.Items.Add("Data from " & "128.10.20.63")
                Dim ns As NetworkStream = tcpCli.GetStream
                Dim sr As New StreamReader(ns)
                ''''''''' get data from client '''''''''''''''
                Dim receivedData As String = sr.ReadLine()
                If receivedData = "###SHUTDOWN###" Then
                    trShutdown = New Thread(AddressOf shutdown)
                    trShutdown.Start()
                End If

                If receivedData = "###REBOOT###" Then
                    trReboot = New Thread(AddressOf reboot)
                    trReboot.Start()
                End If
                If receivedData = "###POWEROFF###" Then
                    trpoweroff = New Thread(AddressOf poweroff)
                    trpoweroff.Start()
                End If
                If receivedData = "###LOGOFF###" Then
                    trLogOff = New Thread(AddressOf logoff)
                    trLogOff.Start()
                End If
                If receivedData = "###PING###" Then

                End If

                Dim returnedData As String = "###OK###" '& " From Server"
                Dim sw As New StreamWriter(ns)
                sw.WriteLine(returnedData)
                sw.Flush()
                sr.Close()
                sw.Close()
                ns.Close()
                tcpCli.Close()
            Loop
            tcpList.Stop()
        Catch ex As Exception
            'error
            LISTENING = False
        End Try
    End Sub
    Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NotifyIcon1.Icon = Me.Icon
        Label1.Text = ipAddress.ToString
        trlisten = New Thread(AddressOf ListenToServer)
        trlisten.Start()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        NotifyIcon1.Visible = False
        End
    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        NotifyIcon1.Visible = True
        Me.Hide()
    End Sub


    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.Show()
    End Sub

End Class
