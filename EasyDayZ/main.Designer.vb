<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_commandline = New System.Windows.Forms.TextBox()
        Me.btn_commandline_send = New System.Windows.Forms.Button()
        Me.tab_commands = New System.Windows.Forms.TabControl()
        Me.tab_server = New System.Windows.Forms.TabPage()
        Me.grp_backup = New System.Windows.Forms.GroupBox()
        Me.chk_backup_on_restart = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_backup_revisions = New System.Windows.Forms.TextBox()
        Me.grp_watchdog = New System.Windows.Forms.GroupBox()
        Me.btn_watchdog_stop = New System.Windows.Forms.Button()
        Me.btn_watchdog_start = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grp_server_path = New System.Windows.Forms.GroupBox()
        Me.btn_missionfolder_search = New System.Windows.Forms.Button()
        Me.txt_mission_folder = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_backupfolder_search = New System.Windows.Forms.Button()
        Me.btn_battleyefolder_search = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_backup_folder = New System.Windows.Forms.TextBox()
        Me.txt_battleye_folder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_serverfolder_search = New System.Windows.Forms.Button()
        Me.txt_server_folder = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grp_connection = New System.Windows.Forms.GroupBox()
        Me.btn_disconnect = New System.Windows.Forms.Button()
        Me.chk_save_password = New System.Windows.Forms.CheckBox()
        Me.chk_show_password = New System.Windows.Forms.CheckBox()
        Me.chk_reconnect = New System.Windows.Forms.CheckBox()
        Me.btn_connect = New System.Windows.Forms.Button()
        Me.txt_rcon_password = New System.Windows.Forms.TextBox()
        Me.txt_port = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_ip = New System.Windows.Forms.TextBox()
        Me.label_ip = New System.Windows.Forms.Label()
        Me.tab_players = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.data_players = New System.Windows.Forms.DataGridView()
        Me.col_players_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_players_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_players_guid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_players_ip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_players_ping = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_schedule = New System.Windows.Forms.TabPage()
        Me.btn_save_schedule = New System.Windows.Forms.Button()
        Me.btn_schedule_delete = New System.Windows.Forms.Button()
        Me.btn_schedule_change = New System.Windows.Forms.Button()
        Me.btn_schedule_add = New System.Windows.Forms.Button()
        Me.txt_schedule_command = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.datetime_schedule_time = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grp_schedule_day = New System.Windows.Forms.GroupBox()
        Me.chk_schedule_day_su = New System.Windows.Forms.CheckBox()
        Me.chk_schedule_day_sa = New System.Windows.Forms.CheckBox()
        Me.chk_schedule_day_fr = New System.Windows.Forms.CheckBox()
        Me.chk_schedule_day_th = New System.Windows.Forms.CheckBox()
        Me.chk_schedule_day_we = New System.Windows.Forms.CheckBox()
        Me.chk_schedule_day_tu = New System.Windows.Forms.CheckBox()
        Me.chk_schedule_day_mo = New System.Windows.Forms.CheckBox()
        Me.data_schedule = New System.Windows.Forms.DataGridView()
        Me.col_schedule_day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_schedule_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_schedule_command = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_whitelist = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_save_whitelist = New System.Windows.Forms.Button()
        Me.txt_whitelist_kick_text = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chk_whitelist_enabled = New System.Windows.Forms.CheckBox()
        Me.data_whitelist = New System.Windows.Forms.DataGridView()
        Me.col_guid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_name_note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_bans = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.data_bans = New System.Windows.Forms.DataGridView()
        Me.col_ban_guid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ban_playername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ban_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ban_reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_players_history = New System.Windows.Forms.TabPage()
        Me.data_player_history = New System.Windows.Forms.DataGridView()
        Me.col_history_playername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_history_guid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_histroy_last_seen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_history_first_seen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.folderbrowser_server = New System.Windows.Forms.FolderBrowserDialog()
        Me.timer_watchdog = New System.Windows.Forms.Timer(Me.components)
        Me.timer_schedule = New System.Windows.Forms.Timer(Me.components)
        Me.rtxt_log = New System.Windows.Forms.RichTextBox()
        Me.timer_reconnect = New System.Windows.Forms.Timer(Me.components)
        Me.chk_autoscroll = New System.Windows.Forms.CheckBox()
        Me.tab_commands.SuspendLayout()
        Me.tab_server.SuspendLayout()
        Me.grp_backup.SuspendLayout()
        Me.grp_watchdog.SuspendLayout()
        Me.grp_server_path.SuspendLayout()
        Me.grp_connection.SuspendLayout()
        Me.tab_players.SuspendLayout()
        CType(Me.data_players, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_schedule.SuspendLayout()
        Me.grp_schedule_day.SuspendLayout()
        CType(Me.data_schedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_whitelist.SuspendLayout()
        CType(Me.data_whitelist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_bans.SuspendLayout()
        CType(Me.data_bans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_players_history.SuspendLayout()
        CType(Me.data_player_history, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 507)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Console"
        '
        'txt_commandline
        '
        Me.txt_commandline.Location = New System.Drawing.Point(63, 504)
        Me.txt_commandline.Name = "txt_commandline"
        Me.txt_commandline.Size = New System.Drawing.Size(689, 20)
        Me.txt_commandline.TabIndex = 19
        '
        'btn_commandline_send
        '
        Me.btn_commandline_send.Location = New System.Drawing.Point(758, 502)
        Me.btn_commandline_send.Name = "btn_commandline_send"
        Me.btn_commandline_send.Size = New System.Drawing.Size(75, 23)
        Me.btn_commandline_send.TabIndex = 20
        Me.btn_commandline_send.Text = "send"
        Me.btn_commandline_send.UseVisualStyleBackColor = True
        '
        'tab_commands
        '
        Me.tab_commands.Controls.Add(Me.tab_server)
        Me.tab_commands.Controls.Add(Me.tab_players)
        Me.tab_commands.Controls.Add(Me.tab_schedule)
        Me.tab_commands.Controls.Add(Me.tab_whitelist)
        Me.tab_commands.Controls.Add(Me.tab_bans)
        Me.tab_commands.Controls.Add(Me.tab_players_history)
        Me.tab_commands.Location = New System.Drawing.Point(12, 12)
        Me.tab_commands.Name = "tab_commands"
        Me.tab_commands.SelectedIndex = 0
        Me.tab_commands.Size = New System.Drawing.Size(944, 277)
        Me.tab_commands.TabIndex = 21
        '
        'tab_server
        '
        Me.tab_server.Controls.Add(Me.grp_backup)
        Me.tab_server.Controls.Add(Me.grp_watchdog)
        Me.tab_server.Controls.Add(Me.btn_save)
        Me.tab_server.Controls.Add(Me.Button1)
        Me.tab_server.Controls.Add(Me.grp_server_path)
        Me.tab_server.Controls.Add(Me.grp_connection)
        Me.tab_server.Location = New System.Drawing.Point(4, 22)
        Me.tab_server.Name = "tab_server"
        Me.tab_server.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_server.Size = New System.Drawing.Size(936, 251)
        Me.tab_server.TabIndex = 0
        Me.tab_server.Text = "Server"
        Me.tab_server.UseVisualStyleBackColor = True
        '
        'grp_backup
        '
        Me.grp_backup.Controls.Add(Me.chk_backup_on_restart)
        Me.grp_backup.Controls.Add(Me.Label13)
        Me.grp_backup.Controls.Add(Me.txt_backup_revisions)
        Me.grp_backup.Location = New System.Drawing.Point(357, 135)
        Me.grp_backup.Name = "grp_backup"
        Me.grp_backup.Size = New System.Drawing.Size(357, 50)
        Me.grp_backup.TabIndex = 40
        Me.grp_backup.TabStop = False
        Me.grp_backup.Text = "Backup"
        '
        'chk_backup_on_restart
        '
        Me.chk_backup_on_restart.AutoSize = True
        Me.chk_backup_on_restart.Location = New System.Drawing.Point(9, 21)
        Me.chk_backup_on_restart.Name = "chk_backup_on_restart"
        Me.chk_backup_on_restart.Size = New System.Drawing.Size(166, 17)
        Me.chk_backup_on_restart.TabIndex = 2
        Me.chk_backup_on_restart.Text = "Backup server data on restart"
        Me.chk_backup_on_restart.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(200, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Backup-Revisions"
        '
        'txt_backup_revisions
        '
        Me.txt_backup_revisions.Location = New System.Drawing.Point(299, 19)
        Me.txt_backup_revisions.Name = "txt_backup_revisions"
        Me.txt_backup_revisions.Size = New System.Drawing.Size(49, 20)
        Me.txt_backup_revisions.TabIndex = 0
        Me.txt_backup_revisions.Text = "20"
        '
        'grp_watchdog
        '
        Me.grp_watchdog.Controls.Add(Me.btn_watchdog_stop)
        Me.grp_watchdog.Controls.Add(Me.btn_watchdog_start)
        Me.grp_watchdog.Location = New System.Drawing.Point(9, 135)
        Me.grp_watchdog.Name = "grp_watchdog"
        Me.grp_watchdog.Size = New System.Drawing.Size(332, 50)
        Me.grp_watchdog.TabIndex = 39
        Me.grp_watchdog.TabStop = False
        Me.grp_watchdog.Text = "Watchdog (restart server on crash)"
        '
        'btn_watchdog_stop
        '
        Me.btn_watchdog_stop.Enabled = False
        Me.btn_watchdog_stop.Location = New System.Drawing.Point(87, 19)
        Me.btn_watchdog_stop.Name = "btn_watchdog_stop"
        Me.btn_watchdog_stop.Size = New System.Drawing.Size(75, 23)
        Me.btn_watchdog_stop.TabIndex = 1
        Me.btn_watchdog_stop.Text = "stop"
        Me.btn_watchdog_stop.UseVisualStyleBackColor = True
        '
        'btn_watchdog_start
        '
        Me.btn_watchdog_start.Location = New System.Drawing.Point(6, 19)
        Me.btn_watchdog_start.Name = "btn_watchdog_start"
        Me.btn_watchdog_start.Size = New System.Drawing.Size(75, 23)
        Me.btn_watchdog_start.TabIndex = 0
        Me.btn_watchdog_start.Text = "start"
        Me.btn_watchdog_start.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(837, 152)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 38
        Me.btn_save.Text = "save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(756, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grp_server_path
        '
        Me.grp_server_path.Controls.Add(Me.btn_missionfolder_search)
        Me.grp_server_path.Controls.Add(Me.txt_mission_folder)
        Me.grp_server_path.Controls.Add(Me.Label11)
        Me.grp_server_path.Controls.Add(Me.btn_backupfolder_search)
        Me.grp_server_path.Controls.Add(Me.btn_battleyefolder_search)
        Me.grp_server_path.Controls.Add(Me.Label10)
        Me.grp_server_path.Controls.Add(Me.txt_backup_folder)
        Me.grp_server_path.Controls.Add(Me.txt_battleye_folder)
        Me.grp_server_path.Controls.Add(Me.Label9)
        Me.grp_server_path.Controls.Add(Me.btn_serverfolder_search)
        Me.grp_server_path.Controls.Add(Me.txt_server_folder)
        Me.grp_server_path.Controls.Add(Me.Label7)
        Me.grp_server_path.Location = New System.Drawing.Point(357, 6)
        Me.grp_server_path.Name = "grp_server_path"
        Me.grp_server_path.Size = New System.Drawing.Size(561, 123)
        Me.grp_server_path.TabIndex = 30
        Me.grp_server_path.TabStop = False
        Me.grp_server_path.Text = "Folders"
        '
        'btn_missionfolder_search
        '
        Me.btn_missionfolder_search.Location = New System.Drawing.Point(480, 68)
        Me.btn_missionfolder_search.Name = "btn_missionfolder_search"
        Me.btn_missionfolder_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_missionfolder_search.TabIndex = 41
        Me.btn_missionfolder_search.Text = "search"
        Me.btn_missionfolder_search.UseVisualStyleBackColor = True
        '
        'txt_mission_folder
        '
        Me.txt_mission_folder.Location = New System.Drawing.Point(128, 71)
        Me.txt_mission_folder.Name = "txt_mission_folder"
        Me.txt_mission_folder.Size = New System.Drawing.Size(346, 20)
        Me.txt_mission_folder.TabIndex = 40
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Mission-Folder:"
        '
        'btn_backupfolder_search
        '
        Me.btn_backupfolder_search.Location = New System.Drawing.Point(480, 94)
        Me.btn_backupfolder_search.Name = "btn_backupfolder_search"
        Me.btn_backupfolder_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_backupfolder_search.TabIndex = 38
        Me.btn_backupfolder_search.Text = "search"
        Me.btn_backupfolder_search.UseVisualStyleBackColor = True
        '
        'btn_battleyefolder_search
        '
        Me.btn_battleyefolder_search.Location = New System.Drawing.Point(480, 42)
        Me.btn_battleyefolder_search.Name = "btn_battleyefolder_search"
        Me.btn_battleyefolder_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_battleyefolder_search.TabIndex = 37
        Me.btn_battleyefolder_search.Text = "search"
        Me.btn_battleyefolder_search.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Backup-Folder"
        '
        'txt_backup_folder
        '
        Me.txt_backup_folder.Location = New System.Drawing.Point(128, 97)
        Me.txt_backup_folder.Name = "txt_backup_folder"
        Me.txt_backup_folder.Size = New System.Drawing.Size(346, 20)
        Me.txt_backup_folder.TabIndex = 35
        '
        'txt_battleye_folder
        '
        Me.txt_battleye_folder.Location = New System.Drawing.Point(128, 45)
        Me.txt_battleye_folder.Name = "txt_battleye_folder"
        Me.txt_battleye_folder.Size = New System.Drawing.Size(346, 20)
        Me.txt_battleye_folder.TabIndex = 34
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "BattlEye-Folder"
        '
        'btn_serverfolder_search
        '
        Me.btn_serverfolder_search.Location = New System.Drawing.Point(480, 17)
        Me.btn_serverfolder_search.Name = "btn_serverfolder_search"
        Me.btn_serverfolder_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_serverfolder_search.TabIndex = 31
        Me.btn_serverfolder_search.Text = "search"
        Me.btn_serverfolder_search.UseVisualStyleBackColor = True
        '
        'txt_server_folder
        '
        Me.txt_server_folder.Location = New System.Drawing.Point(128, 20)
        Me.txt_server_folder.Name = "txt_server_folder"
        Me.txt_server_folder.Size = New System.Drawing.Size(346, 20)
        Me.txt_server_folder.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Server-Folder"
        '
        'grp_connection
        '
        Me.grp_connection.Controls.Add(Me.btn_disconnect)
        Me.grp_connection.Controls.Add(Me.chk_save_password)
        Me.grp_connection.Controls.Add(Me.chk_show_password)
        Me.grp_connection.Controls.Add(Me.chk_reconnect)
        Me.grp_connection.Controls.Add(Me.btn_connect)
        Me.grp_connection.Controls.Add(Me.txt_rcon_password)
        Me.grp_connection.Controls.Add(Me.txt_port)
        Me.grp_connection.Controls.Add(Me.Label2)
        Me.grp_connection.Controls.Add(Me.Label1)
        Me.grp_connection.Controls.Add(Me.txt_ip)
        Me.grp_connection.Controls.Add(Me.label_ip)
        Me.grp_connection.Location = New System.Drawing.Point(9, 6)
        Me.grp_connection.Name = "grp_connection"
        Me.grp_connection.Size = New System.Drawing.Size(332, 129)
        Me.grp_connection.TabIndex = 29
        Me.grp_connection.TabStop = False
        Me.grp_connection.Text = "Connection"
        '
        'btn_disconnect
        '
        Me.btn_disconnect.Enabled = False
        Me.btn_disconnect.Location = New System.Drawing.Point(103, 99)
        Me.btn_disconnect.Name = "btn_disconnect"
        Me.btn_disconnect.Size = New System.Drawing.Size(75, 23)
        Me.btn_disconnect.TabIndex = 38
        Me.btn_disconnect.Text = "disconnect"
        Me.btn_disconnect.UseVisualStyleBackColor = True
        '
        'chk_save_password
        '
        Me.chk_save_password.AutoSize = True
        Me.chk_save_password.Location = New System.Drawing.Point(9, 75)
        Me.chk_save_password.Name = "chk_save_password"
        Me.chk_save_password.Size = New System.Drawing.Size(151, 17)
        Me.chk_save_password.TabIndex = 37
        Me.chk_save_password.Text = "save password (plain-text!)"
        Me.chk_save_password.UseVisualStyleBackColor = True
        '
        'chk_show_password
        '
        Me.chk_show_password.AutoSize = True
        Me.chk_show_password.Location = New System.Drawing.Point(174, 51)
        Me.chk_show_password.Name = "chk_show_password"
        Me.chk_show_password.Size = New System.Drawing.Size(99, 17)
        Me.chk_show_password.TabIndex = 36
        Me.chk_show_password.Text = "show password"
        Me.chk_show_password.UseVisualStyleBackColor = True
        '
        'chk_reconnect
        '
        Me.chk_reconnect.AutoSize = True
        Me.chk_reconnect.Location = New System.Drawing.Point(174, 75)
        Me.chk_reconnect.Name = "chk_reconnect"
        Me.chk_reconnect.Size = New System.Drawing.Size(123, 17)
        Me.chk_reconnect.TabIndex = 35
        Me.chk_reconnect.Text = "automatic reconnect"
        Me.chk_reconnect.UseVisualStyleBackColor = True
        '
        'btn_connect
        '
        Me.btn_connect.Location = New System.Drawing.Point(9, 100)
        Me.btn_connect.Name = "btn_connect"
        Me.btn_connect.Size = New System.Drawing.Size(75, 23)
        Me.btn_connect.TabIndex = 34
        Me.btn_connect.Text = "connect"
        Me.btn_connect.UseVisualStyleBackColor = True
        '
        'txt_rcon_password
        '
        Me.txt_rcon_password.Location = New System.Drawing.Point(65, 49)
        Me.txt_rcon_password.Name = "txt_rcon_password"
        Me.txt_rcon_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_rcon_password.Size = New System.Drawing.Size(100, 20)
        Me.txt_rcon_password.TabIndex = 33
        '
        'txt_port
        '
        Me.txt_port.Location = New System.Drawing.Point(206, 23)
        Me.txt_port.Name = "txt_port"
        Me.txt_port.Size = New System.Drawing.Size(100, 20)
        Me.txt_port.TabIndex = 32
        Me.txt_port.Text = "2302"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(171, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Port:"
        '
        'txt_ip
        '
        Me.txt_ip.Location = New System.Drawing.Point(65, 23)
        Me.txt_ip.Name = "txt_ip"
        Me.txt_ip.Size = New System.Drawing.Size(100, 20)
        Me.txt_ip.TabIndex = 29
        Me.txt_ip.Text = "127.0.0.1"
        '
        'label_ip
        '
        Me.label_ip.AutoSize = True
        Me.label_ip.Location = New System.Drawing.Point(6, 26)
        Me.label_ip.Name = "label_ip"
        Me.label_ip.Size = New System.Drawing.Size(53, 13)
        Me.label_ip.TabIndex = 28
        Me.label_ip.Text = "IP / Host:"
        Me.label_ip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tab_players
        '
        Me.tab_players.Controls.Add(Me.Label15)
        Me.tab_players.Controls.Add(Me.data_players)
        Me.tab_players.Location = New System.Drawing.Point(4, 22)
        Me.tab_players.Name = "tab_players"
        Me.tab_players.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_players.Size = New System.Drawing.Size(936, 251)
        Me.tab_players.TabIndex = 4
        Me.tab_players.Text = "Players"
        Me.tab_players.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(779, 228)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(151, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "(use context menu - right click)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'data_players
        '
        Me.data_players.AllowUserToAddRows = False
        Me.data_players.AllowUserToDeleteRows = False
        Me.data_players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_players.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_players_id, Me.col_players_name, Me.col_players_guid, Me.col_players_ip, Me.col_players_ping})
        Me.data_players.Location = New System.Drawing.Point(6, 6)
        Me.data_players.Name = "data_players"
        Me.data_players.ReadOnly = True
        Me.data_players.Size = New System.Drawing.Size(924, 213)
        Me.data_players.TabIndex = 0
        '
        'col_players_id
        '
        Me.col_players_id.HeaderText = "ID"
        Me.col_players_id.Name = "col_players_id"
        Me.col_players_id.ReadOnly = True
        Me.col_players_id.Width = 50
        '
        'col_players_name
        '
        Me.col_players_name.HeaderText = "Name"
        Me.col_players_name.Name = "col_players_name"
        Me.col_players_name.ReadOnly = True
        Me.col_players_name.Width = 300
        '
        'col_players_guid
        '
        Me.col_players_guid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_players_guid.HeaderText = "GUID"
        Me.col_players_guid.Name = "col_players_guid"
        Me.col_players_guid.ReadOnly = True
        '
        'col_players_ip
        '
        Me.col_players_ip.HeaderText = "IP"
        Me.col_players_ip.Name = "col_players_ip"
        Me.col_players_ip.ReadOnly = True
        Me.col_players_ip.Width = 150
        '
        'col_players_ping
        '
        Me.col_players_ping.HeaderText = "Ping"
        Me.col_players_ping.Name = "col_players_ping"
        Me.col_players_ping.ReadOnly = True
        Me.col_players_ping.Visible = False
        '
        'tab_schedule
        '
        Me.tab_schedule.Controls.Add(Me.btn_save_schedule)
        Me.tab_schedule.Controls.Add(Me.btn_schedule_delete)
        Me.tab_schedule.Controls.Add(Me.btn_schedule_change)
        Me.tab_schedule.Controls.Add(Me.btn_schedule_add)
        Me.tab_schedule.Controls.Add(Me.txt_schedule_command)
        Me.tab_schedule.Controls.Add(Me.Label6)
        Me.tab_schedule.Controls.Add(Me.datetime_schedule_time)
        Me.tab_schedule.Controls.Add(Me.Label5)
        Me.tab_schedule.Controls.Add(Me.grp_schedule_day)
        Me.tab_schedule.Controls.Add(Me.data_schedule)
        Me.tab_schedule.Location = New System.Drawing.Point(4, 22)
        Me.tab_schedule.Name = "tab_schedule"
        Me.tab_schedule.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_schedule.Size = New System.Drawing.Size(936, 251)
        Me.tab_schedule.TabIndex = 2
        Me.tab_schedule.Text = "Schedule"
        Me.tab_schedule.UseVisualStyleBackColor = True
        '
        'btn_save_schedule
        '
        Me.btn_save_schedule.Location = New System.Drawing.Point(855, 222)
        Me.btn_save_schedule.Name = "btn_save_schedule"
        Me.btn_save_schedule.Size = New System.Drawing.Size(75, 23)
        Me.btn_save_schedule.TabIndex = 9
        Me.btn_save_schedule.Text = "save"
        Me.btn_save_schedule.UseVisualStyleBackColor = True
        '
        'btn_schedule_delete
        '
        Me.btn_schedule_delete.Enabled = False
        Me.btn_schedule_delete.Location = New System.Drawing.Point(853, 98)
        Me.btn_schedule_delete.Name = "btn_schedule_delete"
        Me.btn_schedule_delete.Size = New System.Drawing.Size(77, 23)
        Me.btn_schedule_delete.TabIndex = 8
        Me.btn_schedule_delete.Text = "delete"
        Me.btn_schedule_delete.UseVisualStyleBackColor = True
        '
        'btn_schedule_change
        '
        Me.btn_schedule_change.Enabled = False
        Me.btn_schedule_change.Location = New System.Drawing.Point(770, 98)
        Me.btn_schedule_change.Name = "btn_schedule_change"
        Me.btn_schedule_change.Size = New System.Drawing.Size(77, 23)
        Me.btn_schedule_change.TabIndex = 7
        Me.btn_schedule_change.Text = "change"
        Me.btn_schedule_change.UseVisualStyleBackColor = True
        '
        'btn_schedule_add
        '
        Me.btn_schedule_add.Location = New System.Drawing.Point(687, 98)
        Me.btn_schedule_add.Name = "btn_schedule_add"
        Me.btn_schedule_add.Size = New System.Drawing.Size(77, 23)
        Me.btn_schedule_add.TabIndex = 6
        Me.btn_schedule_add.Text = "add"
        Me.btn_schedule_add.UseVisualStyleBackColor = True
        '
        'txt_schedule_command
        '
        Me.txt_schedule_command.Location = New System.Drawing.Point(687, 69)
        Me.txt_schedule_command.Name = "txt_schedule_command"
        Me.txt_schedule_command.Size = New System.Drawing.Size(243, 20)
        Me.txt_schedule_command.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(684, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Command:"
        '
        'datetime_schedule_time
        '
        Me.datetime_schedule_time.CustomFormat = "HH:mm:ss"
        Me.datetime_schedule_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetime_schedule_time.Location = New System.Drawing.Point(723, 23)
        Me.datetime_schedule_time.Name = "datetime_schedule_time"
        Me.datetime_schedule_time.ShowUpDown = True
        Me.datetime_schedule_time.Size = New System.Drawing.Size(72, 20)
        Me.datetime_schedule_time.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(684, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Time:"
        '
        'grp_schedule_day
        '
        Me.grp_schedule_day.Controls.Add(Me.chk_schedule_day_su)
        Me.grp_schedule_day.Controls.Add(Me.chk_schedule_day_sa)
        Me.grp_schedule_day.Controls.Add(Me.chk_schedule_day_fr)
        Me.grp_schedule_day.Controls.Add(Me.chk_schedule_day_th)
        Me.grp_schedule_day.Controls.Add(Me.chk_schedule_day_we)
        Me.grp_schedule_day.Controls.Add(Me.chk_schedule_day_tu)
        Me.grp_schedule_day.Controls.Add(Me.chk_schedule_day_mo)
        Me.grp_schedule_day.Location = New System.Drawing.Point(500, 6)
        Me.grp_schedule_day.Name = "grp_schedule_day"
        Me.grp_schedule_day.Size = New System.Drawing.Size(178, 115)
        Me.grp_schedule_day.TabIndex = 1
        Me.grp_schedule_day.TabStop = False
        Me.grp_schedule_day.Text = "Day of week"
        '
        'chk_schedule_day_su
        '
        Me.chk_schedule_day_su.AutoSize = True
        Me.chk_schedule_day_su.Location = New System.Drawing.Point(95, 65)
        Me.chk_schedule_day_su.Name = "chk_schedule_day_su"
        Me.chk_schedule_day_su.Size = New System.Drawing.Size(62, 17)
        Me.chk_schedule_day_su.TabIndex = 6
        Me.chk_schedule_day_su.Text = "Sunday"
        Me.chk_schedule_day_su.UseVisualStyleBackColor = True
        '
        'chk_schedule_day_sa
        '
        Me.chk_schedule_day_sa.AutoSize = True
        Me.chk_schedule_day_sa.Location = New System.Drawing.Point(95, 42)
        Me.chk_schedule_day_sa.Name = "chk_schedule_day_sa"
        Me.chk_schedule_day_sa.Size = New System.Drawing.Size(68, 17)
        Me.chk_schedule_day_sa.TabIndex = 5
        Me.chk_schedule_day_sa.Text = "Saturday"
        Me.chk_schedule_day_sa.UseVisualStyleBackColor = True
        '
        'chk_schedule_day_fr
        '
        Me.chk_schedule_day_fr.AutoSize = True
        Me.chk_schedule_day_fr.Location = New System.Drawing.Point(95, 19)
        Me.chk_schedule_day_fr.Name = "chk_schedule_day_fr"
        Me.chk_schedule_day_fr.Size = New System.Drawing.Size(54, 17)
        Me.chk_schedule_day_fr.TabIndex = 4
        Me.chk_schedule_day_fr.Text = "Friday"
        Me.chk_schedule_day_fr.UseVisualStyleBackColor = True
        '
        'chk_schedule_day_th
        '
        Me.chk_schedule_day_th.AutoSize = True
        Me.chk_schedule_day_th.Location = New System.Drawing.Point(6, 88)
        Me.chk_schedule_day_th.Name = "chk_schedule_day_th"
        Me.chk_schedule_day_th.Size = New System.Drawing.Size(70, 17)
        Me.chk_schedule_day_th.TabIndex = 3
        Me.chk_schedule_day_th.Text = "Thursday"
        Me.chk_schedule_day_th.UseVisualStyleBackColor = True
        '
        'chk_schedule_day_we
        '
        Me.chk_schedule_day_we.AutoSize = True
        Me.chk_schedule_day_we.Location = New System.Drawing.Point(6, 65)
        Me.chk_schedule_day_we.Name = "chk_schedule_day_we"
        Me.chk_schedule_day_we.Size = New System.Drawing.Size(83, 17)
        Me.chk_schedule_day_we.TabIndex = 2
        Me.chk_schedule_day_we.Text = "Wednesday"
        Me.chk_schedule_day_we.UseVisualStyleBackColor = True
        '
        'chk_schedule_day_tu
        '
        Me.chk_schedule_day_tu.AutoSize = True
        Me.chk_schedule_day_tu.Location = New System.Drawing.Point(6, 42)
        Me.chk_schedule_day_tu.Name = "chk_schedule_day_tu"
        Me.chk_schedule_day_tu.Size = New System.Drawing.Size(67, 17)
        Me.chk_schedule_day_tu.TabIndex = 1
        Me.chk_schedule_day_tu.Text = "Tuesday"
        Me.chk_schedule_day_tu.UseVisualStyleBackColor = True
        '
        'chk_schedule_day_mo
        '
        Me.chk_schedule_day_mo.AutoSize = True
        Me.chk_schedule_day_mo.Location = New System.Drawing.Point(6, 19)
        Me.chk_schedule_day_mo.Name = "chk_schedule_day_mo"
        Me.chk_schedule_day_mo.Size = New System.Drawing.Size(64, 17)
        Me.chk_schedule_day_mo.TabIndex = 0
        Me.chk_schedule_day_mo.Text = "Monday"
        Me.chk_schedule_day_mo.UseVisualStyleBackColor = True
        '
        'data_schedule
        '
        Me.data_schedule.AllowUserToAddRows = False
        Me.data_schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_schedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_schedule_day, Me.col_schedule_time, Me.col_schedule_command})
        Me.data_schedule.Location = New System.Drawing.Point(6, 6)
        Me.data_schedule.Name = "data_schedule"
        Me.data_schedule.ReadOnly = True
        Me.data_schedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.data_schedule.Size = New System.Drawing.Size(488, 239)
        Me.data_schedule.TabIndex = 0
        '
        'col_schedule_day
        '
        Me.col_schedule_day.HeaderText = "day of week"
        Me.col_schedule_day.Name = "col_schedule_day"
        Me.col_schedule_day.ReadOnly = True
        '
        'col_schedule_time
        '
        Me.col_schedule_time.HeaderText = "time"
        Me.col_schedule_time.Name = "col_schedule_time"
        Me.col_schedule_time.ReadOnly = True
        '
        'col_schedule_command
        '
        Me.col_schedule_command.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_schedule_command.HeaderText = "command"
        Me.col_schedule_command.Name = "col_schedule_command"
        Me.col_schedule_command.ReadOnly = True
        '
        'tab_whitelist
        '
        Me.tab_whitelist.Controls.Add(Me.Label8)
        Me.tab_whitelist.Controls.Add(Me.btn_save_whitelist)
        Me.tab_whitelist.Controls.Add(Me.txt_whitelist_kick_text)
        Me.tab_whitelist.Controls.Add(Me.Label4)
        Me.tab_whitelist.Controls.Add(Me.chk_whitelist_enabled)
        Me.tab_whitelist.Controls.Add(Me.data_whitelist)
        Me.tab_whitelist.Location = New System.Drawing.Point(4, 22)
        Me.tab_whitelist.Name = "tab_whitelist"
        Me.tab_whitelist.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_whitelist.Size = New System.Drawing.Size(936, 251)
        Me.tab_whitelist.TabIndex = 1
        Me.tab_whitelist.Text = "Whitelist"
        Me.tab_whitelist.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(469, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(304, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "To delete an entry, select it and press delete on your keyboard."
        '
        'btn_save_whitelist
        '
        Me.btn_save_whitelist.Location = New System.Drawing.Point(855, 222)
        Me.btn_save_whitelist.Name = "btn_save_whitelist"
        Me.btn_save_whitelist.Size = New System.Drawing.Size(75, 23)
        Me.btn_save_whitelist.TabIndex = 6
        Me.btn_save_whitelist.Text = "save"
        Me.btn_save_whitelist.UseVisualStyleBackColor = True
        '
        'txt_whitelist_kick_text
        '
        Me.txt_whitelist_kick_text.Location = New System.Drawing.Point(527, 42)
        Me.txt_whitelist_kick_text.Name = "txt_whitelist_kick_text"
        Me.txt_whitelist_kick_text.Size = New System.Drawing.Size(403, 20)
        Me.txt_whitelist_kick_text.TabIndex = 5
        Me.txt_whitelist_kick_text.Text = "Sorry, you are not whitelisted."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(469, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Kick-Text"
        '
        'chk_whitelist_enabled
        '
        Me.chk_whitelist_enabled.AutoSize = True
        Me.chk_whitelist_enabled.Location = New System.Drawing.Point(472, 16)
        Me.chk_whitelist_enabled.Name = "chk_whitelist_enabled"
        Me.chk_whitelist_enabled.Size = New System.Drawing.Size(107, 17)
        Me.chk_whitelist_enabled.TabIndex = 3
        Me.chk_whitelist_enabled.Text = "Whitelist enabled"
        Me.chk_whitelist_enabled.UseVisualStyleBackColor = True
        '
        'data_whitelist
        '
        Me.data_whitelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_whitelist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_guid, Me.col_name_note})
        Me.data_whitelist.Location = New System.Drawing.Point(9, 6)
        Me.data_whitelist.Name = "data_whitelist"
        Me.data_whitelist.Size = New System.Drawing.Size(445, 239)
        Me.data_whitelist.TabIndex = 2
        '
        'col_guid
        '
        Me.col_guid.HeaderText = "GUID"
        Me.col_guid.Name = "col_guid"
        Me.col_guid.Width = 220
        '
        'col_name_note
        '
        Me.col_name_note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_name_note.HeaderText = "Name/Note"
        Me.col_name_note.Name = "col_name_note"
        '
        'tab_bans
        '
        Me.tab_bans.Controls.Add(Me.Label14)
        Me.tab_bans.Controls.Add(Me.data_bans)
        Me.tab_bans.Location = New System.Drawing.Point(4, 22)
        Me.tab_bans.Name = "tab_bans"
        Me.tab_bans.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_bans.Size = New System.Drawing.Size(936, 251)
        Me.tab_bans.TabIndex = 5
        Me.tab_bans.Text = "Bans"
        Me.tab_bans.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(779, 228)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(151, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "(use context menu - right click)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'data_bans
        '
        Me.data_bans.AllowUserToOrderColumns = True
        Me.data_bans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_bans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ban_guid, Me.col_ban_playername, Me.col_ban_date, Me.col_ban_reason})
        Me.data_bans.Location = New System.Drawing.Point(6, 6)
        Me.data_bans.Name = "data_bans"
        Me.data_bans.Size = New System.Drawing.Size(924, 213)
        Me.data_bans.TabIndex = 0
        '
        'col_ban_guid
        '
        Me.col_ban_guid.HeaderText = "GUID"
        Me.col_ban_guid.Name = "col_ban_guid"
        Me.col_ban_guid.Width = 220
        '
        'col_ban_playername
        '
        Me.col_ban_playername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_ban_playername.HeaderText = "Name"
        Me.col_ban_playername.Name = "col_ban_playername"
        '
        'col_ban_date
        '
        Me.col_ban_date.HeaderText = "Time of ban"
        Me.col_ban_date.Name = "col_ban_date"
        Me.col_ban_date.Width = 140
        '
        'col_ban_reason
        '
        Me.col_ban_reason.HeaderText = "Reason"
        Me.col_ban_reason.Name = "col_ban_reason"
        Me.col_ban_reason.Width = 280
        '
        'tab_players_history
        '
        Me.tab_players_history.Controls.Add(Me.data_player_history)
        Me.tab_players_history.Location = New System.Drawing.Point(4, 22)
        Me.tab_players_history.Name = "tab_players_history"
        Me.tab_players_history.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_players_history.Size = New System.Drawing.Size(936, 251)
        Me.tab_players_history.TabIndex = 6
        Me.tab_players_history.Text = "All joined players"
        Me.tab_players_history.UseVisualStyleBackColor = True
        '
        'data_player_history
        '
        Me.data_player_history.AllowUserToAddRows = False
        Me.data_player_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data_player_history.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_history_playername, Me.col_history_guid, Me.col_histroy_last_seen, Me.col_history_first_seen})
        Me.data_player_history.Location = New System.Drawing.Point(6, 6)
        Me.data_player_history.Name = "data_player_history"
        Me.data_player_history.ReadOnly = True
        Me.data_player_history.Size = New System.Drawing.Size(924, 239)
        Me.data_player_history.TabIndex = 0
        '
        'col_history_playername
        '
        Me.col_history_playername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_history_playername.HeaderText = "Name"
        Me.col_history_playername.Name = "col_history_playername"
        Me.col_history_playername.ReadOnly = True
        '
        'col_history_guid
        '
        Me.col_history_guid.HeaderText = "GUID"
        Me.col_history_guid.Name = "col_history_guid"
        Me.col_history_guid.ReadOnly = True
        Me.col_history_guid.Width = 220
        '
        'col_histroy_last_seen
        '
        Me.col_histroy_last_seen.HeaderText = "Last seen"
        Me.col_histroy_last_seen.Name = "col_histroy_last_seen"
        Me.col_histroy_last_seen.ReadOnly = True
        Me.col_histroy_last_seen.Width = 140
        '
        'col_history_first_seen
        '
        Me.col_history_first_seen.HeaderText = "First seen"
        Me.col_history_first_seen.Name = "col_history_first_seen"
        Me.col_history_first_seen.ReadOnly = True
        Me.col_history_first_seen.Width = 140
        '
        'folderbrowser_server
        '
        Me.folderbrowser_server.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.folderbrowser_server.ShowNewFolderButton = False
        '
        'timer_watchdog
        '
        Me.timer_watchdog.Interval = 10000
        '
        'timer_schedule
        '
        Me.timer_schedule.Enabled = True
        Me.timer_schedule.Interval = 500
        '
        'rtxt_log
        '
        Me.rtxt_log.Location = New System.Drawing.Point(12, 291)
        Me.rtxt_log.Name = "rtxt_log"
        Me.rtxt_log.Size = New System.Drawing.Size(944, 205)
        Me.rtxt_log.TabIndex = 22
        Me.rtxt_log.Text = ""
        '
        'timer_reconnect
        '
        Me.timer_reconnect.Interval = 2000
        '
        'chk_autoscroll
        '
        Me.chk_autoscroll.AutoSize = True
        Me.chk_autoscroll.Checked = True
        Me.chk_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_autoscroll.Location = New System.Drawing.Point(839, 506)
        Me.chk_autoscroll.Name = "chk_autoscroll"
        Me.chk_autoscroll.Size = New System.Drawing.Size(117, 17)
        Me.chk_autoscroll.TabIndex = 23
        Me.chk_autoscroll.Text = "Automatic scroll log"
        Me.chk_autoscroll.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 537)
        Me.Controls.Add(Me.chk_autoscroll)
        Me.Controls.Add(Me.rtxt_log)
        Me.Controls.Add(Me.tab_commands)
        Me.Controls.Add(Me.btn_commandline_send)
        Me.Controls.Add(Me.txt_commandline)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "main"
        Me.Text = "EasyDayZ"
        Me.tab_commands.ResumeLayout(False)
        Me.tab_server.ResumeLayout(False)
        Me.grp_backup.ResumeLayout(False)
        Me.grp_backup.PerformLayout()
        Me.grp_watchdog.ResumeLayout(False)
        Me.grp_server_path.ResumeLayout(False)
        Me.grp_server_path.PerformLayout()
        Me.grp_connection.ResumeLayout(False)
        Me.grp_connection.PerformLayout()
        Me.tab_players.ResumeLayout(False)
        Me.tab_players.PerformLayout()
        CType(Me.data_players, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_schedule.ResumeLayout(False)
        Me.tab_schedule.PerformLayout()
        Me.grp_schedule_day.ResumeLayout(False)
        Me.grp_schedule_day.PerformLayout()
        CType(Me.data_schedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_whitelist.ResumeLayout(False)
        Me.tab_whitelist.PerformLayout()
        CType(Me.data_whitelist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_bans.ResumeLayout(False)
        Me.tab_bans.PerformLayout()
        CType(Me.data_bans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_players_history.ResumeLayout(False)
        CType(Me.data_player_history, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_commandline As TextBox
    Friend WithEvents btn_commandline_send As Button
    Friend WithEvents tab_commands As TabControl
    Friend WithEvents tab_server As TabPage
    Friend WithEvents tab_whitelist As TabPage
    Friend WithEvents data_whitelist As DataGridView
    Friend WithEvents txt_whitelist_kick_text As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chk_whitelist_enabled As CheckBox
    Friend WithEvents tab_schedule As TabPage
    Friend WithEvents grp_schedule_day As GroupBox
    Friend WithEvents chk_schedule_day_mo As CheckBox
    Friend WithEvents data_schedule As DataGridView
    Friend WithEvents col_schedule_day As DataGridViewTextBoxColumn
    Friend WithEvents col_schedule_time As DataGridViewTextBoxColumn
    Friend WithEvents col_schedule_command As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents datetime_schedule_time As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents chk_schedule_day_su As CheckBox
    Friend WithEvents chk_schedule_day_sa As CheckBox
    Friend WithEvents chk_schedule_day_fr As CheckBox
    Friend WithEvents chk_schedule_day_th As CheckBox
    Friend WithEvents chk_schedule_day_we As CheckBox
    Friend WithEvents chk_schedule_day_tu As CheckBox
    Friend WithEvents btn_schedule_change As Button
    Friend WithEvents btn_schedule_add As Button
    Friend WithEvents txt_schedule_command As TextBox
    Friend WithEvents tab_players As TabPage
    Friend WithEvents folderbrowser_server As FolderBrowserDialog
    Friend WithEvents grp_server_path As GroupBox
    Friend WithEvents btn_serverfolder_search As Button
    Friend WithEvents txt_server_folder As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents grp_connection As GroupBox
    Friend WithEvents chk_show_password As CheckBox
    Friend WithEvents chk_reconnect As CheckBox
    Friend WithEvents btn_connect As Button
    Friend WithEvents txt_rcon_password As TextBox
    Friend WithEvents txt_port As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_ip As TextBox
    Friend WithEvents label_ip As Label
    Friend WithEvents data_players As DataGridView
    Friend WithEvents timer_watchdog As Timer
    Friend WithEvents timer_schedule As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents rtxt_log As RichTextBox
    Friend WithEvents btn_save As Button
    Friend WithEvents chk_save_password As CheckBox
    Friend WithEvents btn_save_whitelist As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents btn_schedule_delete As Button
    Friend WithEvents btn_save_schedule As Button
    Friend WithEvents btn_backupfolder_search As Button
    Friend WithEvents btn_battleyefolder_search As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_backup_folder As TextBox
    Friend WithEvents txt_battleye_folder As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tab_bans As TabPage
    Friend WithEvents btn_disconnect As Button
    Friend WithEvents timer_reconnect As Timer
    Friend WithEvents grp_watchdog As GroupBox
    Friend WithEvents btn_watchdog_stop As Button
    Friend WithEvents btn_watchdog_start As Button
    Friend WithEvents grp_backup As GroupBox
    Friend WithEvents btn_missionfolder_search As Button
    Friend WithEvents txt_mission_folder As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents chk_backup_on_restart As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_backup_revisions As TextBox
    Friend WithEvents chk_autoscroll As CheckBox
    Friend WithEvents col_guid As DataGridViewTextBoxColumn
    Friend WithEvents col_name_note As DataGridViewTextBoxColumn
    Friend WithEvents data_bans As DataGridView
    Friend WithEvents tab_players_history As TabPage
    Friend WithEvents data_player_history As DataGridView
    Friend WithEvents col_history_playername As DataGridViewTextBoxColumn
    Friend WithEvents col_history_guid As DataGridViewTextBoxColumn
    Friend WithEvents col_histroy_last_seen As DataGridViewTextBoxColumn
    Friend WithEvents col_history_first_seen As DataGridViewTextBoxColumn
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents col_ban_guid As DataGridViewTextBoxColumn
    Friend WithEvents col_ban_playername As DataGridViewTextBoxColumn
    Friend WithEvents col_ban_date As DataGridViewTextBoxColumn
    Friend WithEvents col_ban_reason As DataGridViewTextBoxColumn
    Friend WithEvents col_players_id As DataGridViewTextBoxColumn
    Friend WithEvents col_players_name As DataGridViewTextBoxColumn
    Friend WithEvents col_players_guid As DataGridViewTextBoxColumn
    Friend WithEvents col_players_ip As DataGridViewTextBoxColumn
    Friend WithEvents col_players_ping As DataGridViewTextBoxColumn
End Class
