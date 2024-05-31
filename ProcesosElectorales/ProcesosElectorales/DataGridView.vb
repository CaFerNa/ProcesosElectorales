
Private Sub DataGridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridView1.KeyPress

  Static KeysPressed As String

  Static LastKeyPress As Date

  'if more than 2 seconds has passed, clear the string

  If DateDiff(DateInterval.Second, LastKeyPress, Now) >= 2 Then

    KeysPressed = CStr(e.KeyChar)

  Else

    KeysPressed += CStr(e.KeyChar)

  End If

  LastKeyPress = Now

  'to see the typed string: Label1.Text = KeysPressed

  Dim dg As DataGridView = CType(sender, DataGridView)

  Dim DS As DataSet = CType(BindingSource1.DataSource, DataSet)

  Dim FieldNameToSearch As String = "StLastName"

  BindingSource1.Position = BindingSource1.Find(DS.Tables(0).Columns(FieldNameToSearch).ToString, KeysPressed)

End Sub

REM --------------------------------------------------


Also why not use

Private Sub textboxSearch_TestChanged(object sender, EventArgs e)

 if (textboxSearch.Length > 2) then

  BindingSource1.Position = BindingSource1.Find(FieldNameToSearch ,  textboxSearch)

 end If

End Sub

REM ----------------------------------------------------

private void btnFind_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                if (DataGridView1.Rows[i].Cells["ColumnName"].Value.ToString().Trim() == Textbox1.Text)
                {
                    DataGridView1.Rows[i].Selected = true;
                }
            }
        }
        
REM ------------------------------------------------

Private Sub Column_Name_TextBox_Click(sender As Object, e As EventArgs) Handles Column_Name_TextBox.Click

        ' Handles mouse click in the column name search text box, in which case we clear the previous text.

        Me.Column_Name_TextBox.Text = ""
        Me.ColumnSearchEnabled = False
        NEXT_COLUMN_MenuItem.Enabled = False
        PREVIOUS_COLUMN_MenuItem.Enabled = False
        Exit Sub

    End Sub

    Private Sub Column_Name_TextBox_TextChanged(sender As Object, e As EventArgs) Handles Column_Name_TextBox.TextChanged

        ' Allows the user to type a number of characters into the Column_Name_TextBox and we attempt to find a matching
        ' column in the P_DataGridView. If there is a partial match, then we select the column.

        Dim Col_SearchIdx As Integer
        Dim Search_Name As String
        Dim ColumnFound As Boolean = False

        Try
            If Not Me.GUIEnabled Then Exit Sub

            ' Require at least 3 characters before we start searching.

            If Not Len(Column_Name_TextBox.Text) > 2 Then Exit Sub
            Me.GUIEnabled = False
            Me.ColumnSearchEnabled = True

            Search_Name = Me.Column_Name_TextBox.Text

            ' Search all columns currently in the P_DataGridView.

            Me.ColumnNames = (From column As DataGridViewColumn In Me.P_DataGridView.Columns.Cast(Of DataGridViewColumn)() _
                                Order By column.Name Select column.Name).ToArray

            Me.ColumnSearchIdx = 0

            ' We do a partial name search, it doesn't have to be exact.

            For n = Me.ColumnSearchIdx To Me.ColumnNames.GetLength(0) - 1
                Col_SearchIdx = InStr(Me.ColumnNames(n), Search_Name)
                If Col_SearchIdx > 0 Then
                    Me.ColumnSearchIdx = n
                    ColumnFound = True
                    NEXT_COLUMN_MenuItem.Enabled = True
                    PREVIOUS_COLUMN_MenuItem.Enabled = True
                    Exit For 'n
                End If
            Next n

            If ColumnFound Then Find_Column()

            Me.GUIEnabled = True
            Exit Sub

        Catch ex As Exception
            PrintException(ex.ToString)
            Me.GUIEnabled = True
            Exit Sub
        End Try
    End Sub
    
    
        Private Sub Next_Column_MenuItem_Click(sender As Object, e As EventArgs) Handles NEXT_COLUMN_MenuItem.Click

        ' Continues searching for a column as a result of a previous search

        Dim Col_SearchIdx As Integer
        Dim Search_Name As String
        Dim ColumnFound As Boolean = False

        Try
            If Not Me.GUIEnabled Then Exit Sub
            If Not Me.ColumnSearchEnabled Then Exit Sub

            Me.GUIEnabled = False

            Search_Name = Me.Column_Name_TextBox.Text

            If Me.ColumnSearchIdx < Me.ColumnNames.GetLength(0) - 1 Then
                Me.ColumnSearchIdx += 1
            End If

            ' We do a partial name search, it doesn't have to be exact.

            For n = Me.ColumnSearchIdx To Me.ColumnNames.GetLength(0) - 1
                Col_SearchIdx = InStr(Me.ColumnNames(n), Search_Name)
                If Col_SearchIdx > 0 Then
                    Me.ColumnSearchIdx = n
                    ColumnFound = True
                    Exit For 'n
                End If
            Next n

            If ColumnFound Then Find_Column()

            Me.GUIEnabled = True
            Exit Sub

        Catch ex As Exception
            PrintException(ex.ToString)
            Me.GUIEnabled = True
            Exit Sub
        End Try
    End Sub
    
     Private Function FindString(ByVal strSearchString As String, ByVal strFields As String) As Boolean

        dgvDisbursements.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDisbursements.ClearSelection()

        Dim intCount As Integer = 0

        For Each row As DataGridViewRow In dgvDisbursements.Rows
            If InStr(1, dgvDisbursements.Rows(intCount).Cells(strFields).Value.ToString, strSearchString, CompareMethod.Text) Then
                dgvDisbursements.Rows(intCount).Selected = True
                FindString = True
                Exit Function
            End If
            intCount += 1
        Next row

        FindString = False

    End Function
    
    For Each myRow As DataGridViewRow In dgvDisbursements.Rows
    For Each myCell in myRow.Cells
        'Do the search in myCell
    Next
    
    Private Function FindItems(ByVal strSearchString As String) As Boolean

        dgvDisbursements.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDisbursements.ClearSelection()

        Dim intCount As Integer = 0
        Dim intCell As Integer

        For Each myRow As DataGridViewRow In dgvDisbursements.Rows
            For Each myCell In myRow.Cells

                For intCell = 1 To 8
                    'Do the search in myCell
                    If InStr(1, dgvDisbursements.Rows(intCount).Cells(intCell).Value.ToString, strSearchString, CompareMethod.Text) Then
                        dgvDisbursements.Rows(intCount).Selected = True
                        FindItems = True
                        Exit Function
                    End If
                Next
                intCell += 1
            Next
            intCount += 1
        Next

        Return False

    End Function
    
     Private Function FindItems(ByVal strSearchString As String) As Boolean
        dgvDisbursements.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDisbursements.ClearSelection()

        For Each myRow As DataGridViewRow In dgvDisbursements.Rows
            For Each myCell As DataGridViewCell In myRow.Cells
                If InStr(myCell.Value.ToString, strSearchString) Then
                    myRow.Selected = True
                    Return True
                End If
            Next
        Next
        Return False

    End Function
