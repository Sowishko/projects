object Form1: TForm1
  Left = 383
  Top = 229
  Width = 780
  Height = 382
  Caption = 'OS2'
  Color = clSilver
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 144
    Top = 184
    Width = 182
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1072#1076#1088#1077#1089' '#1074#1080#1088#1090#1091#1072#1083#1100#1085#1086#1081' '#1087#1072#1084#1103#1090#1080
    WordWrap = True
  end
  object Label2: TLabel
    Left = 144
    Top = 224
    Width = 185
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1082#1086#1083'-'#1074#1086' '#1074#1099#1076#1077#1083#1103#1077#1084#1086#1081' '#1087#1072#1084#1103#1090#1080
  end
  object Label3: TLabel
    Left = 144
    Top = 264
    Width = 127
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1072#1090#1088#1080#1073#1091#1090' '#1079#1072#1097#1080#1090#1099
  end
  object Button1: TButton
    Left = 8
    Top = 8
    Width = 113
    Height = 25
    Caption = 'SysInfo'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 8
    Top = 48
    Width = 113
    Height = 25
    Caption = 'GlobalMemoryStatus'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 8
    Top = 88
    Width = 113
    Height = 25
    Caption = 'VirtualQuery'
    TabOrder = 2
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 8
    Top = 128
    Width = 113
    Height = 25
    Caption = 'VirtualAlloc'
    TabOrder = 3
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 8
    Top = 168
    Width = 113
    Height = 25
    Caption = 'VirtualFree'
    TabOrder = 4
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 8
    Top = 208
    Width = 113
    Height = 25
    Caption = 'VirtualProtect'
    TabOrder = 5
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 8
    Top = 280
    Width = 113
    Height = 25
    Caption = 'Quit'
    TabOrder = 6
    OnClick = Button7Click
  end
  object Edit1: TEdit
    Left = 144
    Top = 200
    Width = 353
    Height = 21
    TabOrder = 7
  end
  object memo1: TMemo
    Left = 144
    Top = 8
    Width = 353
    Height = 169
    Lines.Strings = (
      'memo1')
    ReadOnly = True
    TabOrder = 8
  end
  object Edit2: TEdit
    Left = 144
    Top = 240
    Width = 353
    Height = 21
    TabOrder = 9
  end
  object ComboBox1: TComboBox
    Left = 144
    Top = 280
    Width = 353
    Height = 21
    Style = csDropDownList
    ItemHeight = 13
    TabOrder = 10
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
  object Memo2: TMemo
    Left = 512
    Top = 8
    Width = 209
    Height = 257
    Lines.Strings = (
      'memo1')
    ReadOnly = True
    TabOrder = 11
  end
  object Button8: TButton
    Left = 560
    Top = 272
    Width = 113
    Height = 25
    Caption = #1057#1074#1086#1073#1086#1076#1085#1099#1077' '#1088#1077#1075#1080#1086#1085#1099
    TabOrder = 12
    OnClick = Button8Click
  end
end
