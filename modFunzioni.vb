


Imports System.Globalization

Module modFunzioni

	Public InAggiornamento As Boolean = False



#Region "=== Caricamento impostazioni generali da file cfg.ini ==="

	Public Sub Load_CFG()
		Try


			Dim pp = My.Computer.FileSystem.ReadAllText(MyPath & "cfg.ini")

			myInifile.Load(MyIniFilePath)

			'FileIni.BoolFalseValue = "0"
			'FileIni.BoolTrueValue = "1"


			'[main]
			' COSTANTE => "|"    _ini_split_char = myInifile.GetKeyValue_String("main", "_ini_split_char")
			'_form_number = myInifile.GetKeyValue_Integer("main", "_form_number")
			_offset_position = myInifile.GetKeyValue_Integer("main", "_offset_position")
			_width = myInifile.GetKeyValue_Integer("main", "_width")
			_link_file_name = myInifile.GetKeyValue_String("main", "_link_file_name")

			mySize = New Size(_width, 5)

			'[clipboard]
			_clipboard_close_color = DaStringRgbAColor(myInifile.GetKeyValue_String("clipboard", "_clipboard_close_color"), ",")
			_clipboard_open_color = DaStringRgbAColor(myInifile.GetKeyValue_String("clipboard", "_clipboard_open_color"), ",")
			_clipboard_text_color = DaStringRgbAColor(myInifile.GetKeyValue_String("clipboard", "_clipboard_text_color"), ",")
			_clipboard_elements_number = myInifile.GetKeyValue_Integer("clipboard", "_clipboard_elements_number")

			'	_clipboard_fixed_lines = myInifile.GetKeyValue_String("clipboard_fixed_lines", "array").Split(";").ToList

			'[fixedtext]
			_fixedtext_close_color = DaStringRgbAColor(myInifile.GetKeyValue_String("fixedtext", "_fixedtext_close_color"), ",")
			_fixedtext_open_color = DaStringRgbAColor(myInifile.GetKeyValue_String("fixedtext", "_fixedtext_open_color"), ",")
			_fixedtext_text_color = DaStringRgbAColor(myInifile.GetKeyValue_String("fixedtext", "_fixedtext_text_color"), ",")
			_fixedtext_elements_number = myInifile.GetKeyValue_Integer("fixedtext", "_fixedtext_elements_number")

			_fixedtext_fixed_lines = myInifile.GetKeyValue_String("fixedtext_fixed_lines", "array").Split(";").ToList
			Dim a = 0

		Catch ex As Exception
			Dim msg As String = vbCrLf & ex.Message
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			MsgBox(code & msg)
		End Try


	End Sub

	Function LoadGroupsConfiguration()
		LinkList.Clear()
		Dim tx As String = My.Computer.FileSystem.ReadAllText(MyPath & _link_file_name)

		tx = tx.Substring(("[form]" & vbCrLf).Length)

		Dim str() As String = tx.Split("[form]" & vbCrLf)
		For Each s In str
			If s <> "" Then
				LinkList.Add(s)
			End If
		Next

		' per ogni pacchetto genero un form
		For Each F In LinkList
			If F <> "" Then
				Dim frm As New frmElementsGroup
				FormList.Add(frm)
			End If
			Dim a = 0
		Next

		Dim c As Integer = 0
		For Each f In LinkList
			Dim S() As String = (f).Split(vbCrLf)
			FormList(c).ElementList.Clear()

			For Each T As String In S
				If T.ToLower.StartsWith("color:") Then
					T = T.Substring(6).Trim
					_closed_color(c) = DaStringRgbAColor(T, ";")
					FormList(c).ClosedColor = DaStringRgbAColor(T, ";")

					Dim a = 0
				ElseIf T.ToLower.StartsWith("back_color:") Then
					T = T.Substring(11).Trim
					_opened_color(c) = DaStringRgbAColor(T, ";")
					FormList(c).OpenedColor = DaStringRgbAColor(T, ";")
					Dim a = 0

				ElseIf T.ToLower.StartsWith("text_color:") Then
					T = T.Substring(11).Trim
					_text_color(c) = DaStringRgbAColor(T, ";")
					FormList(c).TextColor = DaStringRgbAColor(T, ";")
					Dim a = 0

				ElseIf T.ToLower.StartsWith("separator:") Then
					T = "--------------------"
					Dim E = New Element(T)
					E.Element_Type = Element.ElementType.separator
					FormList(c).ElementList.Add(E)
					Dim a = 0

				ElseIf T.ToLower.StartsWith("special_folder:") Then
					T = T.Substring(15).Trim
					Dim E = New Element(T)
					E.Element_Type = Element.ElementType.special_folder
					FormList(c).ElementList.Add(E)
					Dim a = 0

				ElseIf T.ToLower.StartsWith("link:") Then
					T = T.Substring(5).Trim
					Dim E = New Element(T)
					E.Element_Type = Element.ElementType.general
					FormList(c).ElementList.Add(E)
					Dim a = 0
				End If
			Next

			c += 1

		Next


	End Function

	Sub WriteShorcutFile() 'frm As frmElementsGroup)
		Dim T As String = ""

		For Each frm In FormList

			T &= IIf(T <> "", vbCrLf, "") & "[form]"
			T &= vbCrLf & "color:" & DaColorAStringRgb(frm.ClosedColor, ";")
			T &= vbCrLf & "back_color:" & DaColorAStringRgb(frm.OpenedColor, ";")
			T &= vbCrLf & "text_color:" & DaColorAStringRgb(frm.TextColor, ";")
			T &= vbCrLf

			For Each E In frm.ElementList
				Select Case E.Element_Type
					Case Element.ElementType.document

					Case Element.ElementType.executable

					Case Element.ElementType.general
						T &= vbCrLf & "link:" & E.Text & _ini_split_char & E.Link
					Case Element.ElementType.separator
						T &= vbCrLf & "separator:" & E.Text & _ini_split_char & E.Link
					Case Element.ElementType.special_folder
						T &= vbCrLf & "special_folder:" & E.Text & _ini_split_char & E.Link
				End Select

			Next

			T &= vbCrLf

			Dim a = 0
		Next

		My.Computer.FileSystem.WriteAllText(MyPath & _link_file_name, T, False)

	End Sub


	Function GenereteNewFormCFG() As Element
		Dim T As String = ""

		T &= vbCrLf & "[form]" & vbCrLf
		T &= "color:0;255;0" & vbCrLf
		T &= "back_color:255;255;255" & vbCrLf
		T &= "text_color:0;0;0" & vbCrLf
		T &= "" & vbCrLf

		Dim P As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
		Dim SystemDisc As String = P.Substring(0, P.IndexOf("\") + 1)
		Dim L = "System disk : " & SystemDisc & _ini_split_char & SystemDisc

		T &= "link:" & L & vbCrLf


		My.Computer.FileSystem.WriteAllText(MyPath & _link_file_name, T, True)

		Dim El = New Element(L)

		Return El
	End Function


	Function CBoolINI(ByVal valore As Integer) As Boolean
		If valore >= 1 Then
			Return True
		Else
			Return False
		End If
	End Function



#End Region

	Sub CreateSpecialFoldersLists()
		SpecialFoldersName.Add("AdminTools")
		SpecialFoldersName.Add("ApplicationData")
		SpecialFoldersName.Add("CDBurning")
		SpecialFoldersName.Add("CommonAdminTools")
		SpecialFoldersName.Add("CommonApplicationData")
		SpecialFoldersName.Add("CommonDesktopDirectory")
		SpecialFoldersName.Add("CommonDocuments")
		SpecialFoldersName.Add("CommonMusic")
		SpecialFoldersName.Add("CommonOemLinks")
		SpecialFoldersName.Add("CommonPictures")
		SpecialFoldersName.Add("CommonProgramFiles")
		SpecialFoldersName.Add("CommonProgramFilesX86")
		SpecialFoldersName.Add("CommonPrograms")
		SpecialFoldersName.Add("CommonStartMenu")
		SpecialFoldersName.Add("CommonStartup")
		SpecialFoldersName.Add("CommonTemplates")
		SpecialFoldersName.Add("CommonVideos")
		SpecialFoldersName.Add("Cookies")
		SpecialFoldersName.Add("Desktop")
		SpecialFoldersName.Add("DesktopDirectory")
		SpecialFoldersName.Add("Favorites")
		SpecialFoldersName.Add("Fonts")
		SpecialFoldersName.Add("History")
		SpecialFoldersName.Add("InternetCache")
		SpecialFoldersName.Add("LocalApplicationData")
		SpecialFoldersName.Add("LocalizedResources")
		SpecialFoldersName.Add("MyComputer")
		SpecialFoldersName.Add("MyDocuments")
		SpecialFoldersName.Add("MyMusic")
		SpecialFoldersName.Add("MyPictures")
		SpecialFoldersName.Add("MyVideos")
		SpecialFoldersName.Add("NetworkShortcuts")
		SpecialFoldersName.Add("Personal")
		SpecialFoldersName.Add("PrinterShortcuts")
		SpecialFoldersName.Add("ProgramFiles")
		SpecialFoldersName.Add("ProgramFilesX86")
		SpecialFoldersName.Add("Programs")
		SpecialFoldersName.Add("Recent")
		SpecialFoldersName.Add("Resources")
		SpecialFoldersName.Add("SendTo")
		SpecialFoldersName.Add("StartMenu")
		SpecialFoldersName.Add("Startup")
		SpecialFoldersName.Add("System")
		SpecialFoldersName.Add("SystemX86")
		SpecialFoldersName.Add("Templates")
		SpecialFoldersName.Add("UserProfile")
		SpecialFoldersName.Add("Windows")

		SpecialFoldersIndex.Add(48)  ' 0
		SpecialFoldersIndex.Add(26)  ' 1
		SpecialFoldersIndex.Add(59)  ' 2
		SpecialFoldersIndex.Add(47)  ' 3
		SpecialFoldersIndex.Add(35)  ' 4
		SpecialFoldersIndex.Add(25)  ' 5
		SpecialFoldersIndex.Add(46)  ' 6
		SpecialFoldersIndex.Add(53)  ' 7
		SpecialFoldersIndex.Add(58)  ' 8
		SpecialFoldersIndex.Add(54)  ' 9
		SpecialFoldersIndex.Add(43)  ' 10
		SpecialFoldersIndex.Add(44)  ' 11
		SpecialFoldersIndex.Add(23)  ' 12
		SpecialFoldersIndex.Add(22)  ' 13
		SpecialFoldersIndex.Add(24)  ' 14
		SpecialFoldersIndex.Add(45)  ' 15
		SpecialFoldersIndex.Add(55)  ' 16
		SpecialFoldersIndex.Add(33)  ' 17
		SpecialFoldersIndex.Add(0)   ' 18
		SpecialFoldersIndex.Add(16)  ' 19
		SpecialFoldersIndex.Add(6)   ' 20
		SpecialFoldersIndex.Add(20)  ' 21
		SpecialFoldersIndex.Add(34)  ' 22
		SpecialFoldersIndex.Add(32)  ' 23
		SpecialFoldersIndex.Add(28)  ' 24
		SpecialFoldersIndex.Add(57)  ' 25
		SpecialFoldersIndex.Add(17)  ' 26
		SpecialFoldersIndex.Add(5)   ' 27
		SpecialFoldersIndex.Add(13)  ' 28
		SpecialFoldersIndex.Add(39)  ' 29
		SpecialFoldersIndex.Add(14)  ' 30
		SpecialFoldersIndex.Add(19)  ' 31
		SpecialFoldersIndex.Add(5)   ' 32
		SpecialFoldersIndex.Add(27)  ' 33
		SpecialFoldersIndex.Add(38)  ' 34
		SpecialFoldersIndex.Add(42)  ' 35
		SpecialFoldersIndex.Add(2)   ' 36
		SpecialFoldersIndex.Add(8)   ' 37
		SpecialFoldersIndex.Add(56)  ' 38
		SpecialFoldersIndex.Add(9)   ' 39
		SpecialFoldersIndex.Add(11)  ' 40
		SpecialFoldersIndex.Add(7)   ' 41
		SpecialFoldersIndex.Add(37)  ' 42
		SpecialFoldersIndex.Add(41)  ' 43
		SpecialFoldersIndex.Add(21)  ' 44
		SpecialFoldersIndex.Add(40)  ' 45
		SpecialFoldersIndex.Add(36)  ' 46

		SpecialFoldersDescription.Add("SpecialFoldersDescription.add(Directory del file system usata per archiviare strumenti amministrativi per un singolo utente. Microsoft Management Console (MMC) salverà le console personalizzate in questa directory e verrà eseguito il roaming.")
		SpecialFoldersDescription.Add("Directory usata come repository comune dei dati specifici dell'applicazione per l'utente roaming corrente. Un utente mobile lavora su più computer di una rete. Il profilo di un utente mobile viene conservato in un server della rete e viene caricato in un sistema quando l'utente esegue l'accesso.")
		SpecialFoldersDescription.Add("Directory del file system che viene usata come un'area di gestione temporanea per i file in attesa di essere scritti su un CD.")
		SpecialFoldersDescription.Add("Directory del file system che contiene strumenti amministrativi per tutti gli utenti del computer.")
		SpecialFoldersDescription.Add("Directory usata come repository comune dei dati specifici dell'applicazione usati da tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory del file system che contiene file e cartelle che vengono visualizzati sul desktop di tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory del file system che contiene documenti comuni a tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory del file system che viene usata come repository per i file musicali comuni a tutti gli utenti.")
		SpecialFoldersDescription.Add("Questo valore è riconosciuto in Windows Vista per la compatibilità con le versioni precedenti, ma la cartella speciale non è più usata.")
		SpecialFoldersDescription.Add("Directory del file system che viene usata come repository per i file di immagine comuni a tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory per i componenti condivisi da più applicazioni.Per ottenere la directory dei file di programma comuni x86 in un processo non x86, usare il membro ProgramFilesX86.")
		SpecialFoldersDescription.Add("Cartella Programmi.")
		SpecialFoldersDescription.Add("Cartella per i componenti condivisi da più applicazioni.")
		SpecialFoldersDescription.Add("Directory del file system che contiene i programmi e le cartelle che vengono visualizzati nel menu Start per tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory del file system che contiene i programmi che vengono visualizzati nella cartella Avvio per tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory del file system che contiene i modelli disponibili per tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory del file system che viene usata come repository per i file video comuni a tutti gli utenti.")
		SpecialFoldersDescription.Add("Directory usata come repository comune dei cookie di Internet.")
		SpecialFoldersDescription.Add("Desktop logico anziché percorso fisico del file system.")
		SpecialFoldersDescription.Add("Directory usata per archiviare fisicamente gli oggetti file sul desktop. Non confondere questa directory con la cartella desktop, che è una cartella virtuale.")
		SpecialFoldersDescription.Add("Directory usata come repository degli elementi preferiti dell'utente.")
		SpecialFoldersDescription.Add("Cartella virtuale che contiene i tipi di carattere.")
		SpecialFoldersDescription.Add("Directory usata come repository comune degli elementi della cronologia di Internet.")
		SpecialFoldersDescription.Add("Directory usata come repository comune dei file temporanei Internet.")
		SpecialFoldersDescription.Add("Directory usata come repository comune dei dati specifici dell'applicazione usati dall'utente non roaming corrente.")
		SpecialFoldersDescription.Add("Directory del file system che contiene i dati di risorsa localizzati.")
		SpecialFoldersDescription.Add("Cartella Risorse del computer. Quando viene passato al metodo Environment.GetFolderPath, il membro di enumerazione MyComputer restituisce sempre la stringa vuota ("") perché non è definito alcun percorso per la cartella Risorse del computer.")
		SpecialFoldersDescription.Add("Cartella Documenti. Questo membro equivale a Personal.")
		SpecialFoldersDescription.Add("Cartella Musica.")
		SpecialFoldersDescription.Add("Cartella Immagini.")
		SpecialFoldersDescription.Add("Directory del file system che viene usata come repository per i video che appartengono a un utente.")
		SpecialFoldersDescription.Add("Directory del file system che contiene gli oggetti collegamento che esistono nella cartella virtuale Risorse di rete.")
		SpecialFoldersDescription.Add("Directory usata come repository comune dei documenti. Questo membro equivale a MyDocuments.")
		SpecialFoldersDescription.Add("Directory del file system che contiene gli oggetti collegamento che possono esistere nella cartella virtuale Stampanti.")
		SpecialFoldersDescription.Add("Directory dei programmi.In un processo non x86, il passaggio di ProgramFiles al metodo GetFolderPath(Environment+SpecialFolder) restituisce il percorso dei programmi non x86. Per ottenere la directory dei file di programma x86 in un processo non x86, usare il membro ProgramFilesX86.")
		SpecialFoldersDescription.Add("Cartella Programmi x86.")
		SpecialFoldersDescription.Add("Directory contenente i gruppi di programmi dell'utente.")
		SpecialFoldersDescription.Add("Directory contenente i documenti usati di recente dall'utente.")
		SpecialFoldersDescription.Add("Directory del file system che contiene i dati di risorsa.")
		SpecialFoldersDescription.Add("Directory contenente le voci del menu Invia a.")
		SpecialFoldersDescription.Add("Directory contenente le voci del menu Start.")
		SpecialFoldersDescription.Add("Directory corrispondente al gruppo di programmi di Esecuzione automatica dell'utente. Il sistema avvia questi programmi ogni volta che un utente avvia o accede a Windows.")
		SpecialFoldersDescription.Add("Directory System.")
		SpecialFoldersDescription.Add("Cartella System di Windows.")
		SpecialFoldersDescription.Add("Directory usata come repository comune dei modelli di documenti.")
		SpecialFoldersDescription.Add("Cartella del profilo dell'utente. Le applicazioni non devono creare file o cartelle a questo livello; devono inserire i dati nei percorsi a cui fa riferimento il campo ApplicationData.")
		SpecialFoldersDescription.Add("Directory di Windows o SYSROOT. Corrisponde alle variabili di ambiente %windir% o %SYSTEMROOT%.")

	End Sub


#Region "--- GESTIONE COMBOBOX E GRIGLIE ---"

	Function PopolaGrigliaDati(ByVal DGV As DataGridView, ByVal righe() As Dictionary(Of String, String)) As Integer

		Try
			DGV.Rows.Clear()
			If IsNothing(righe(0)) Then Exit Function
			For Each rr As Dictionary(Of String, String) In righe
				DGV.Rows.Insert(0)
				For Each dato As Object In rr
					If DGV.Columns.Contains(dato.Key) Then
						DGV.Rows.Item(0).Cells(dato.Key).Value = dato.Value
					End If
				Next
			Next
			Return righe.Length
		Catch ex As Exception
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			Dim msg As String = vbCrLf & ex.Message
			MsgBox(code & msg)
		End Try
	End Function

	'Function PopolaGrigliaDati(ByVal DGV As DataGridView, ByVal query As String) As Integer
	'	InAggiornamento = True

	'	DGV.SuspendLayout()
	'	Try
	'		'Dim ris() As Dictionary(Of String, String) = myFunc.EseguiQueryComandoConRisultatoStrutturato(query)
	'		Dim ris() As Dictionary(Of String, String) = myFunc.EseguiQueryConRisultatoStrutturato(query)
	'		DGV.Rows.Clear()
	'		If IsNothing(ris) Then
	'			DGV.ResumeLayout()
	'			Return 0
	'			'Exit Function
	'		End If
	'		For Each rr As Dictionary(Of String, String) In ris
	'			DGV.Rows.Insert(0)
	'			For Each dato As Object In rr
	'				If DGV.Columns.Contains(dato.Key) Then
	'					DGV.Rows.Item(0).Cells(dato.Key).Value = dato.Value
	'				End If
	'			Next
	'		Next
	'		InAggiornamento = False
	'		DGV.ResumeLayout()

	'		Return ris.Length
	'	Catch ex As Exception
	'		Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
	'		Dim msg As String = vbCrLf & ex.Message
	'		MsgBox(code & msg)
	'	End Try
	'	InAggiornamento = False
	'	DGV.ResumeLayout()
	'End Function



	Public Sub PopolaComboBox(ByVal CB As ComboBox, ByVal ValueMembers() As String, ByVal DisplayMembers() As String)

		Try
			Dim DVMembers As New ArrayList()

			If ValueMembers.Length > 0 And ValueMembers.Length = DisplayMembers.Length Then
				For f As Integer = 0 To ValueMembers.Length - 1
					DVMembers.Add(New CBDataSource(DisplayMembers(f), ValueMembers(f)))
				Next
			End If

			CB.DataSource = DVMembers
			CB.DisplayMember = "DisplayMember"
			CB.ValueMember = "ValueMember"
		Catch ex As Exception
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			Dim msg As String = vbCrLf & ex.Message
			MsgBox(code & msg)
		End Try
	End Sub

	Public Sub PopolaComboBox(ByVal CB As DataGridViewComboBoxColumn, ByVal ValueMembers() As String, ByVal DisplayMembers() As String)

		Try
			Dim DVMembers As New ArrayList()

			If ValueMembers.Length > 0 And ValueMembers.Length = DisplayMembers.Length Then
				For f As Integer = 0 To ValueMembers.Length - 1
					DVMembers.Add(New CBDataSource(DisplayMembers(f), ValueMembers(f)))
				Next
			End If

			CB.DataSource = DVMembers
			CB.DisplayMember = "DisplayMember"
			CB.ValueMember = "ValueMember"
		Catch ex As Exception
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			Dim msg As String = vbCrLf & ex.Message
			MsgBox(code & msg)
		End Try
	End Sub

	'Public Sub PopolaComboBox(ByVal CB As ComboBox, ByVal query As String, Optional FirstEmpty As Boolean = False, Optional firstValue As Integer = 0)

	'	Try

	'		Dim DVMembers As New ArrayList()

	'		Dim ValueMembers() As String
	'		Dim DisplayMembers() As String

	'		'Dim dati() As String = myFunc.EseguiQueryComandoConRisultato(query, "|", "").Split("|")
	'		Dim dati() As String = myFunc.EseguiQueryConRisultatoStringa(query, "|", "").Split("|")
	'		If dati(0) <> "" Then

	'			If FirstEmpty Then
	'				dati(0) = firstValue & ";" & dati(0)
	'				dati(1) = ";" & dati(1)
	'			End If

	'			ValueMembers = dati(0).Split(";")
	'			DisplayMembers = dati(1).Split(";")

	'			If ValueMembers.Length > 0 And ValueMembers.Length = DisplayMembers.Length Then
	'				For f As Integer = 0 To ValueMembers.Length - 1
	'					DVMembers.Add(New CBDataSource(DisplayMembers(f), ValueMembers(f)))
	'				Next
	'			End If

	'			CB.DataSource = DVMembers
	'			CB.DisplayMember = "DisplayMember"
	'			CB.ValueMember = "ValueMember"
	'		Else

	'		End If
	'	Catch ex As Exception
	'		Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
	'		Dim msg As String = vbCrLf & ex.Message
	'		MsgBox(code & msg)
	'	End Try
	'End Sub

	Public Sub PopolaComboBox(ByVal CB As ComboBox, ByVal lista() As String)

		Try

			CB.Items.Clear()
			CB.SelectedItem = ""
			CB.Text = ""
			For Each ll In lista
				CB.Items.Add(ll)
			Next
		Catch ex As Exception
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			Dim msg As String = vbCrLf & ex.Message
			MsgBox(code & msg)
		End Try
	End Sub

	'Public Sub PopolaComboBox(ByVal CB As DataGridViewComboBoxColumn, ByVal query As String, Optional FirstEmpty As Boolean = False, Optional firstValue As Integer = 0)

	'	Try

	'		Dim DVMembers As New ArrayList()

	'		Dim ValueMembers() As String
	'		Dim DisplayMembers() As String

	'		'Dim dati() As String = myFunc.EseguiQueryComandoConRisultato(query, "|", "").Split("|")
	'		Dim dati() As String = myFunc.EseguiQueryConRisultatoStringa(query, "|", "").Split("|")
	'		If dati(0) <> "" Then

	'			If FirstEmpty Then
	'				dati(0) = firstValue & ";" & dati(0)
	'				dati(1) = ";" & dati(1)
	'			End If

	'			ValueMembers = dati(0).Split(";")
	'			DisplayMembers = dati(1).Split(";")

	'			If ValueMembers.Length > 0 And ValueMembers.Length = DisplayMembers.Length Then
	'				For f As Integer = 0 To ValueMembers.Length - 1
	'					DVMembers.Add(New CBDataSource(DisplayMembers(f), ValueMembers(f)))
	'				Next
	'			End If

	'			CB.DataSource = DVMembers
	'			CB.DisplayMember = "DisplayMember"
	'			CB.ValueMember = "ValueMember"
	'		Else

	'		End If
	'	Catch ex As Exception
	'		Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
	'		Dim msg As String = vbCrLf & ex.Message
	'		MsgBox(code & msg)
	'	End Try
	'End Sub


	'Public Sub ComboListaPorteSeriali(ByVal cb As ComboBox)
	'	'preparo la combo box delle porte COM

	'	Dim vport(30) As String
	'	Dim dport(30) As String
	'	Dim cont As Integer = 0
	'	For Each ps As String In My.Computer.Ports.SerialPortNames
	'		vport(cont) = (ps.Replace("COM", ""))
	'		dport(cont) = ps
	'		cont = cont + 1
	'	Next
	'	ReDim Preserve vport(cont - 1)
	'	ReDim Preserve dport(cont - 1)
	'	PopolaComboBox(cb, vport, dport)
	'End Sub

	Public Sub ComboListaIP(ByVal cb As ComboBox)
		'preparo la combo box degli indirizzi IP del PC

		Dim vIP(30) As String
		Dim dIP(30) As String
		Dim cont As Integer = 0
		For Each ip As System.Net.IPAddress In System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList

			vIP(cont) = ip.ToString ' (ip.Replace("COM", ""))
			dIP(cont) = ip.ToString
			cont = cont + 1

		Next
		ReDim Preserve vIP(cont - 1)
		ReDim Preserve dIP(cont - 1)
		PopolaComboBox(cb, vIP, dIP)
	End Sub

	Public Function EsportaGrigliaDati(ByVal GrigliaDati As DataGridView, ByVal Intestazioni As Boolean, ByVal SeparatoreRighe As String, ByVal SeparatoreColonne As String) As String
		Try
			Dim Testo As String = ""

			If Intestazioni Then
				For f = 0 To GrigliaDati.Columns.Count - 1
					Testo &= IIf(Testo = "", "", SeparatoreColonne) & GrigliaDati.Columns.Item(f).Name
				Next
				Testo = Testo & SeparatoreRighe
			End If

			For f = 0 To GrigliaDati.Rows.Count - 1
				For g = 0 To GrigliaDati.Columns.Count - 1
					Testo &= IIf(Testo = "", "", SeparatoreColonne) & GrigliaDati.Rows.Item(f).Cells(g).Value.ToString
				Next
				Testo &= Testo & SeparatoreRighe
			Next
			Dim pippo = Testo.Length

			Return Testo
		Catch ex As Exception
			Dim msg As String = vbCrLf & ex.Message
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			MsgBox(code & msg)
		End Try
	End Function

#End Region

#Region "--- CONVERTITORI ---"

	Public Function StringToInteger(ByVal stringa As String) As Integer
		Return CInt(stringa)
	End Function

	Public Function StringToSingle(ByVal ss As String) As Single
		Return CSng(ss.Replace(".", ","))
	End Function

	Public Function IntegerToString(ByVal intero As Integer) As String
		Return Str(intero)
	End Function

	Public Function IntToBool(ByVal intero As Integer, Optional ByVal inverti As Boolean = False)
		Dim risultato As Boolean = IIf(intero = 0, False, True)
		If inverti Then risultato = Not risultato
		Return risultato
	End Function

	Public Function DaStringRgbAColor(ByVal stringa As String, ByVal Separatore As String) As Color
		Try
			Dim rgb() As String = stringa.Split(Separatore)
			Dim colore As Color = Color.FromArgb(255, rgb(0), rgb(1), rgb(2))
			Return colore
		Catch ex As Exception
			Dim msg As String = vbCrLf & ex.Message
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			MsgBox(code & msg)

		End Try
	End Function

	Public Function DaColorAStringRgb(ByVal colore As Color, ByVal Separatore As String) As String
		Dim rgb As String = colore.R & Separatore & colore.G & Separatore & colore.B
		Return rgb
	End Function

	Public Function DaGG_MM_YY_a_Date(ByVal gg As String, ByVal mm As String, ByVal yy As String) As DateTime
		Dim dd As New DateTime
		Dim myCIintl As New CultureInfo("it-IT", False)
		dd = Date.Parse(gg & "/" & mm & "/" & yy, myCIintl)
		Return dd
	End Function

#End Region

#Region "--- FUNZIONI PER MYSQL ---"

	'Public Function MySql_CreaStringaConnessione(ByVal ip As String, ByVal login As String, ByVal password As String, ByVal database As String, ByVal timeout As String) As String

	'	Dim stringa As String = DBConnectionString.Replace("{ipaddress}", ip)
	'	stringa = stringa.Replace("{login}", login)
	'	stringa = stringa.Replace("{password}", password)
	'	stringa = stringa.Replace("{database}", database)
	'	stringa = stringa.Replace("{Timeout}", timeout)
	'	Return stringa
	'End Function

	Function Data_Mysql_to_VB(ByVal dataMySql As String, Optional ByVal SeparatoreData As Char = "-", Optional ByVal SeparatoreOra As Char = ":")
		Try
			Dim tmp() As String = dataMySql.Split(" ")
			Dim strData() As String = tmp(0).Split(SeparatoreData)
			Dim data As Date = CDate(strData(2) & "/" & strData(1) & "/" & strData(0))
			Dim ora As Date
			If tmp.Length > 1 Then
				Dim strOra() As String = tmp(1).Split(SeparatoreOra)
				ora = CDate(strOra(0) & ":" & strOra(1) & ":" & strOra(2))
			End If

			Return CDate(data & " " & ora)
		Catch ex As Exception
			Dim msg As String = vbCrLf & ex.Message
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			MsgBox(code & msg)
		End Try

	End Function

	Function Data_VB_to_MySql(ByVal data As Date, Optional ByVal ora As Date = Nothing) As String
		Try
			Dim gg As String
			Dim mm As String
			Dim aa As String
			Dim oo As String = "00"
			Dim mi As String = "00"
			Dim ss As String = "00"

			gg = data.Day.ToString.PadLeft(2, "0")
			mm = data.Month.ToString.PadLeft(2, "0")
			aa = data.Year.ToString.PadLeft(2, "0")

			If Not IsNothing(ora) Then
				oo = ora.Hour.ToString.PadLeft(2, "0")
				mi = ora.Minute.ToString.PadLeft(2, "0")
				ss = ora.Second.ToString.PadLeft(2, "0")
				Return aa & "-" & mm & "-" & gg & " " & oo & ":" & mi & ":" & ss
			Else
				Return aa & "-" & mm & "-" & gg & " 00:00:00"
			End If
		Catch ex As Exception
			Dim msg As String = vbCrLf & ex.Message
			Dim code = ex.TargetSite.DeclaringType.ToString & "." & ex.TargetSite.Name
			MsgBox(code & msg)
		End Try

	End Function


	'Public Sub ControlloECreazioneTabelleBaseMySqlDB()
	'	'pesco la lista delle tabelle
	'	Dim query As String = "show tables"
	'	'Dim res As String() = myFunc.EseguiQueryComandoConRisultato(query, "", "|").Split("|")
	'	Dim res As String() = myFunc.EseguiQueryConRisultatoStringa(query, "", "|").Split("|")

	'	'se manca la tabella di errore la creo
	'	If Array.IndexOf(res, "err") = -1 Then
	'		query = " CREATE TABLE `err` ( "
	'		query &= "   `errkey` bigint(20) unsigned NOT NULL AUTO_INCREMENT, "
	'		query &= "   `errswr` varchar(200) DEFAULT NULL COMMENT 'software', "
	'		query &= "   `errcod` text, "
	'		query &= "   `errdes` varchar(1000) DEFAULT NULL, "
	'		query &= "   `errdtt` datetime DEFAULT NULL, "
	'		query &= "   PRIMARY KEY (`errkey`) "
	'		query &= " ) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 "
	'		myFunc.EseguiQueryComando(query)
	'	End If

	'	'se manca la tabella di configurazione la creo
	'	If Array.IndexOf(res, "cfg") = -1 Then
	'		query = " CREATE TABLE `cfg` ( "
	'		query &= "   `cfgkey` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT 'chiave', "
	'		query &= "   `cfgsez` varchar(50) DEFAULT NULL COMMENT 'sezione', "
	'		query &= "   `cfgchi` varchar(50) DEFAULT NULL COMMENT 'chiave di sezione', "
	'		query &= "   `cfgval` varchar(255) DEFAULT NULL COMMENT 'valore stringa', "
	'		query &= "   `cfgdes` text COMMENT 'descrizione', "
	'		query &= "   PRIMARY KEY (`cfgkey`), "
	'		query &= "   UNIQUE KEY `NewIndex1` (`cfgsez`,`cfgchi`) "
	'		query &= " ) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC COMMENT='tabella di configurazione' "
	'		myFunc.EseguiQueryComando(query)
	'	End If

	'End Sub

#End Region

#Region "--- ERRORI ---"

	Public Enum TipoLog
		errore = 2 ^ 0
		warning = 2 ^ 1
		azione = 2 ^ 2
	End Enum

	Sub ScriviLog(testo As String, TipoLog As TipoLog, show_message As Boolean)
		Dim s As String = ""
		Dim nome_directory_log = MyPath & "\log\"
		Dim nome_file_log = "log_" & Now().ToString("yyyyMMdd") & ".log"
		Select Case TipoLog
			Case TipoLog.errore
				s = "Err - " & Now().ToString("yyyy.MM.dd") & " " & testo
				If show_message Then MsgBox(testo, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Errore")
			Case TipoLog.warning
				s = "War - " & Now().ToString("yyyy.MM.dd") & " " & testo
				If show_message Then MsgBox(testo, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Avvertimento")
			Case TipoLog.azione
				s = "Log - " & Now().ToString("yyyy.MM.dd") & " " & testo
				If show_message Then MsgBox(testo, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Log")
		End Select
		If Not My.Computer.FileSystem.DirectoryExists(MyPath & "\log") Then My.Computer.FileSystem.CreateDirectory(nome_directory_log)
		My.Computer.FileSystem.WriteAllText(nome_directory_log & nome_file_log, s, True)

	End Sub

#End Region




End Module




'##################################################
'#                  Classi Globali                #
'##################################################


'### CLASSE PER POPOLARE COMBOBOX ###
Public Class CBDataSource
	Private _ValueMember As String
	Private _DisplayMember As String

	Public Sub New(ByVal strDisplayMember As String, ByVal strValueMember As String)
		Me._ValueMember = strValueMember
		Me._DisplayMember = strDisplayMember
	End Sub 'New

	Public ReadOnly Property ValueMember() As String
		Get
			Return _ValueMember
		End Get
	End Property

	Public ReadOnly Property DisplayMember() As String
		Get
			Return _DisplayMember
		End Get
	End Property


End Class