
Imports System.Net
Imports System.DirectoryServices
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Public Class Form1
    Inherits System.Windows.Forms.Form
    Private v_opac As String
    Private v_x, v_y, x, y, count, count1 As Integer
    Dim t As Boolean


    Public Sub sendcommand(ByVal command As String, ByVal hostname As String)

        Try
            Dim port As Integer = 63000
            Dim tcpCli As New TcpClient(hostname, port)
            Dim ns As NetworkStream = tcpCli.GetStream
            ' Send data to the server.
            Dim sw As New StreamWriter(ns)
            sw.WriteLine(command)
            sw.Flush()

            ' Receive and display data.
            Dim sr As New StreamReader(ns)
            Dim result As String = sr.ReadLine()
            If result = "###OK###" Then
                MsgBox("Ýþlem Tamamlandý!!!", MsgBoxStyle.Information, "Ýþlem")
            End If
            'MsgBox(result)
            sr.Close()
            sw.Close()
            ns.Close()
        Catch ex As Exception
            MsgBox(ex.Message + "     Makine Bulunamýyor...")
        End Try
    End Sub

    Dim sorgu As String
    Dim baglan As New OleDb.OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=" & CurDir.ToString & "\comps.mdb")
    Dim ad As New OleDb.OleDbDataAdapter(sorgu, baglan)
    Dim dr As OleDb.OleDbDataReader

    Public Sub yukle()
        sorgu = "select Department.Name from Department"
        ad = New OleDb.OleDbDataAdapter(sorgu, baglan)
        baglan.Open()
        dr = ad.SelectCommand.ExecuteReader
        Do While dr.Read = True
            Dim group As New ListViewGroup
            group.Header = dr(0)
            group.Name = dr(0)
            ListView1.Groups.Add(group)
        Loop
        baglan.Close()
        sorgu = "select Computer.Name, Computer.IP, Department.Name from Computer, Department where Department.ID = Computer.Department_ID "
        ad = New OleDb.OleDbDataAdapter(sorgu, baglan)
        baglan.Open()
        dr = ad.SelectCommand.ExecuteReader
        Do While dr.Read = True

            Dim item As New ListViewItem
            item.Text = dr(0)
            item.ImageIndex = 0
            item.Font = New Font("tahoma", 8, FontStyle.Bold)
            item.ForeColor = Color.FromArgb(63, 72, 93)
            ListView1.Items.Add(item)
            item.Group = ListView1.Groups(dr(2))
            Dim subitem As New ListViewItem.ListViewSubItem
            subitem.Text = dr(1)
            subitem.ForeColor = Color.FromArgb(64, 64, 64)
            item.SubItems.Add(subitem)
        Loop
        baglan.Close()
    End Sub



    Public Sub ping()
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1

            Try
                Dim port As Integer = 63000
                Dim tcpCli As New TcpClient(ListView1.SelectedItems(i).SubItems(1).Text, port)
                Dim ns As NetworkStream = tcpCli.GetStream
                ' Send data to the server.
                Dim sw As New StreamWriter(ns)
                sw.WriteLine("###PING###")
                sw.Flush()

                ' Receive and display data.
                Dim sr As New StreamReader(ns)
                Dim result As String = sr.ReadLine()
                If result = "###OK###" Then
                    ListView1.SelectedItems(i).ImageIndex = 0
                End If
                'MsgBox(result)
                sr.Close()
                sw.Close()
                ns.Close()
            Catch ex As Exception

                ListView1.SelectedItems(i).ImageIndex = 1
            End Try
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Select Case v_opac
            Case "Close"
                If Me.Opacity > 0 Then
                    Me.Opacity -= 0.04
                Else
                    Me.Close()
                End If
            Case "Minimize"
                If Me.Opacity > 0 Then
                    Me.Opacity -= 0.05
                Else
                    Me.WindowState = FormWindowState.Minimized
                    v_opac = "Normal"
                End If
            Case "Normal"
                If Me.WindowState <> FormWindowState.Minimized Then
                    If Me.Opacity < 1 Then
                        Me.Opacity += 0.05
                    Else
                        Timer1.Enabled = False
                    End If
                End If
        End Select
    End Sub

    Private Sub pctClose_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctClose.MouseMove
        pctClose.BackgroundImage = My.Resources.CloseOver
    End Sub

    Private Sub pctClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pctClose.MouseLeave
        On Error Resume Next
        pctClose.BackgroundImage = My.Resources.Close
    End Sub

    Private Sub pctClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctClose.Click
        v_opac = "Close"
        Timer1.Enabled = True
    End Sub

    Private Sub Mouse_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.Font = New Font("Calibri", 10, FontStyle.Bold + FontStyle.Italic, GraphicsUnit.Point)
    End Sub

    Private Sub Mouse_Move(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Sender.Cursor = Cursors.Hand
        Sender.Font = New Font("Calibri", 11, FontStyle.Bold + FontStyle.Underline + FontStyle.Italic, GraphicsUnit.Point)
    End Sub

    Private Sub FormMoveMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseDown
        v_x = e.X
        v_y = e.Y
    End Sub

    Private Sub FormMove_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitle.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Left += e.X - v_x
            Me.Top += e.Y - v_y
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        t = True

        Call yukle()
        Me.Label2.Text = My.Computer.Name & " (" & Me.GetIPAddress(My.Computer.Name) & ")"
        Me.v_opac = "Normal"
        Timer1.Enabled = True
        SplitContainer3.Panel1Collapsed = True
        ContextMenuStrip1.AllowTransparency = True
        ContextMenuStrip1.Opacity = 0.9
        Dim childEntry As DirectoryEntry
        Dim ParentEntry As New DirectoryEntry()
        Try
            ParentEntry.Path = "WinNT:"
            For Each childEntry In ParentEntry.Children
                Dim newNode As New TreeNode(childEntry.Name)
                Select Case childEntry.SchemaClassName
                    Case "Domain"
                        Dim ParentDomain As New TreeNode(childEntry.Name)
                        
                        Dim SubChildEntry As DirectoryEntry
                        Dim SubParentEntry As New DirectoryEntry()
                        SubParentEntry.Path = "WinNT://" & childEntry.Name
                        For Each SubChildEntry In SubParentEntry.Children
                            Dim newNode1 As New TreeNode(SubChildEntry.Name)
                            Select Case SubChildEntry.SchemaClassName
                                Case "Computer"
                                    ParentDomain.Nodes.Add(newNode1)
                            End Select
                        Next
                End Select
            Next
        Catch Excep As Exception
            MsgBox("Error While Reading Directories")
        Finally
            ParentEntry = Nothing
        End Try
    End Sub

    Private Sub pctMinimize_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pctMinimize.MouseLeave
        Me.pctMinimize.BackgroundImage = My.Resources.Minimize
    End Sub

    Private Sub pctMinimize_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctMinimize.MouseMove
        Me.pctMinimize.BackgroundImage = My.Resources.MinimizeOver
    End Sub

    Private Sub MenuStrip1_MenuActivate(ByVal sender As Object, ByVal e As System.EventArgs)
        SplitContainer3.Panel1Collapsed = False
        SplitContainer3.SplitterDistance = 125

    End Sub

    Private Sub MenuStrip1_MenuDeactivate(ByVal sender As Object, ByVal e As System.EventArgs)
        SplitContainer3.Panel1Collapsed = True

    End Sub

    Private Sub FormMove_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _
        pctTitle02.MouseDown, pctTitle03.MouseDown, PictureBox6.MouseDown, lblTitle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If sender.name = "PictureBox6" Then
                ContextMenuStrip1.Show(Me.Left + 1, Me.Top + 72)
            End If
            x = e.X
            y = e.Y
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            Select Case sender.name
                Case "pctTitle02"
                    ContextMenuStrip1.Show(Me.Left + +91 + e.X, Me.Top + e.Y)
                Case "lblTitle"
                    ContextMenuStrip1.Show(Me.Left + 155 + e.X, Me.Top + e.Y)
                Case "pctTitle03"
                    ContextMenuStrip1.Show(Me.Left + 155 + Me.lblTitle.Width + e.X, Me.Top + e.Y)
            End Select
        End If

    End Sub

    Private Sub pctMinimize_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctMinimize.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            v_opac = "Minimize"
            Timer1.Enabled = True
        End If
    End Sub

    Function GetIPAddress(ByVal CompName As String) As String
        Dim oAddr As System.Net.IPAddress
        Dim sAddr As String
        Try
            With System.Net.Dns.GetHostByName(CompName)
                oAddr = New System.Net.IPAddress(.AddressList(0).Address)
                sAddr = oAddr.ToString
            End With
            GetIPAddress = sAddr
        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Fredd NET SEND", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

#Region "sendcommand"
    Dim countt As Integer
    Dim strs() As String
    Dim command As Thread

    Private Sub Poweroff()
        For i As Integer = 0 To count
            Try
                Call sendcommand("###POWEROFF###", strs(i))
            Catch
            End Try
        Next
    End Sub

    Private Sub Logoff()
        For i As Integer = 0 To count
            Try
                Call sendcommand("###LOGOFF###", strs(i))
            Catch 
            End Try
        Next
    End Sub

    Private Sub reboot()
        For i As Integer = 0 To count
            Try
                Call sendcommand("###REBOOT###", strs(i))
            Catch 
            End Try
        Next
    End Sub

    Private Sub Shutdown()
        For i As Integer = 0 To count
            Try
                Call sendcommand("###SHUTDOWN###", strs(i))
            Catch
            End Try
        Next
    End Sub

    Private Sub PowerOffToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs _
   ) Handles PowerOffToolStripMenuItem1.Click, PowerOFfToolStripMenuItem.Click
        countt = Me.ListView1.SelectedItems.Count - 1
        strs = New String(count) {}
        For a As Integer = 0 To count
            strs(a) = Me.ListView1.SelectedItems(a).SubItems(1).Text
        Next
        command = New Thread(AddressOf Poweroff)
        command.Start()
    End Sub

    Private Sub LogOffToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs _
 ) Handles LogOffToolStripMenuItem2.Click, LogOffToolStripMenuItem.Click
        countt = Me.ListView1.SelectedItems.Count - 1
        strs = New String(count) {}
        For a As Integer = 0 To count
            strs(a) = Me.ListView1.SelectedItems(a).SubItems(1).Text
        Next
        command = New Thread(AddressOf Logoff)
        command.Start()
    End Sub


    Private Sub RestartToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs _
    ) Handles RestartToolStripMenuItem1.Click, RestartToolStripMenuItem.Click
        countt = Me.ListView1.SelectedItems.Count - 1
        strs = New String(count) {}
        For a As Integer = 0 To count
            strs(a) = Me.ListView1.SelectedItems(a).SubItems(1).Text
        Next
        command = New Thread(AddressOf reboot)
        command.Start()
    End Sub

    Private Sub ShutdownToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs _
) Handles ShutdownToolStripMenuItem1.Click, ShutdownToolStripMenuItem.Click
        countt = Me.ListView1.SelectedItems.Count - 1
        strs = New String(count) {}
        For a As Integer = 0 To count
            strs(a) = Me.ListView1.SelectedItems(a).SubItems(1).Text
        Next
        command = New Thread(AddressOf Shutdown)
        command.Start()
    End Sub
#End Region

#Region "view"

    Private Sub BüyükÝconToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BüyükÝconToolStripMenuItem.Click
        ListView1.View = View.LargeIcon
    End Sub
    Private Sub KüçükIconToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KüçükIconToolStripMenuItem.Click
        ListView1.View = View.SmallIcon
    End Sub

    Private Sub DetaylarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetaylarToolStripMenuItem.Click
        ListView1.View = View.Details
    End Sub
    Private Sub SýralýToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SýralýToolStripMenuItem.Click
        ListView1.View = View.List
    End Sub
    Private Sub ListeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListeToolStripMenuItem.Click
        ListView1.View = View.Tile
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Call ping()

    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem1.Click
        Call ping()
    End Sub

#End Region

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Shell("net send " & TextBox1.Text & " " & TextBox2.Text)
            TextBox2.Text = ""
            TextBox2.Focus()
        End If
    End Sub
End Class
