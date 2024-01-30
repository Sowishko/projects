object Form1: TForm1
  Left = 371
  Top = 210
  BorderStyle = bsDialog
  Caption = #1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072#1103' '#1088#1072#1073#1086#1090#1072' '#8470'2'
  ClientHeight = 313
  ClientWidth = 601
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 160
    Top = 224
    Width = 433
    Height = 17
    AutoSize = False
    Caption = 
      #1040#1076#1088#1077#1089' '#1074#1080#1088#1090#1091#1072#1083#1100#1085#1086#1081' '#1087#1072#1084#1103#1090#1080' ('#1086#1089#1090#1072#1074#1100#1090#1077' '#1087#1091#1089#1090#1099#1084' '#1076#1083#1103' '#1087#1086#1083#1091#1095#1077#1085#1080#1103' '#1089' '#1087#1086#1084#1086#1097#1100 +
      #1102' VirtualAlloc)'
    WordWrap = True
  end
  object Label2: TLabel
    Left = 160
    Top = 264
    Width = 130
    Height = 13
    Caption = #1040#1090#1088#1080#1073#1091#1090' '#1079#1072#1097#1080#1090#1099' '#1089#1090#1088#1072#1085#1080#1094
  end
  object Memo1: TMemo
    Left = 160
    Top = 8
    Width = 433
    Height = 169
    ReadOnly = True
    ScrollBars = ssBoth
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 160
    Top = 240
    Width = 433
    Height = 21
    TabOrder = 1
  end
  object Button1: TButton
    Left = 8
    Top = 8
    Width = 145
    Height = 25
    Caption = 'SysInfo'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 8
    Top = 40
    Width = 145
    Height = 25
    Caption = 'GlobalmemoryStatus'
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 8
    Top = 72
    Width = 145
    Height = 25
    Caption = 'VirtualQuery'
    TabOrder = 4
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 8
    Top = 104
    Width = 145
    Height = 25
    Caption = 'VirtualAlloc'
    TabOrder = 5
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 8
    Top = 136
    Width = 145
    Height = 25
    Caption = 'VirtualFree'
    TabOrder = 6
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 8
    Top = 168
    Width = 145
    Height = 25
    Caption = 'VirtualProtect'
    TabOrder = 7
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 8
    Top = 256
    Width = 145
    Height = 41
    Caption = #1042#1099#1093#1086#1076
    TabOrder = 8
    OnClick = Button7Click
  end
  object ComboBox1: TComboBox
    Left = 160
    Top = 280
    Width = 433
    Height = 21
    Style = csDropDownList
    ItemHeight = 13
    ItemIndex = 0
    TabOrder = 9
    Text = 'PAGE_NOACCESS'
    Items.Strings = (
      'PAGE_NOACCESS'
      'PAGE_READONLY'
      'PAGE_READWRITE'
      'PAGE_EXECUTE'
      'PAGE_EXECUTE_READ'
      'PAGE_EXECUTE_READWRITE'
      'PAGE_WRITECOPY'
      'PAGE_EXECUTE_WRITECOPY')
  end
  object LabeledEdit1: TLabeledEdit
    Left = 160
    Top = 200
    Width = 433
    Height = 21
    EditLabel.Width = 204
    EditLabel.Height = 13
    EditLabel.Caption = #1050#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1074#1099#1076#1077#1083#1103#1077#1084#1086#1081' '#1087#1072#1084#1103#1090#1080' ('#1073#1072#1081#1090'):'
    TabOrder = 10
    Text = '4096'
  end
end
